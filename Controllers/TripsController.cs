using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;
using System.Linq.Dynamic.Core;

namespace Transfer.City.Controllers
{
    public class TripsController : BaseController
    {
        // GET: Trips
        public ActionResult Index()
        {
            TripsViewModel model = new TripsViewModel();
            model.Cars = Cars.GetAll().Select(c=> new DropdownViewModel<int> {Value= c.ID,Name=c.Name}).ToList();
            model.TripStatus = TripStatus;
            return View(model);
        }

        public ActionResult TripsList()
        {
            try
            {

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string drow = Request["draw"];

                if (sortColumnName == "")
                {
                    sortColumnName = "LocationFrom";
                }

                var TripsList =Trips.GetAll();

                int totalrows = TripsList.Count;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    TripsList = (from t in TripsList
                                 where t.LocationFrom.ToLower().Contains(searchValue.ToLower())
                                     || t.LocationTo.ToLower().Contains(searchValue.ToLower())
                                     || t.TripStatusTitle.ToLower().Contains(searchValue.ToLower())
                                     || t.Fees.ToString().Contains(searchValue)
                                 select t).ToList();
                }

                int totalrowsafterfiltering = TripsList.Count;
                //sorting
                TripsList = TripsList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();

                //paging
                TripsList = TripsList.Skip(start).Take(length).ToList();

                var data = Json(new { TripsList = TripsList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public ActionResult Details(int Id = 0)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }
            TripsViewModel model = new TripsViewModel();

            var Trip = new Trips() { ID = Id };
            Trip = Trips.GetByID(Trip);

            if(Trip == null)
            {
                return HttpNotFound();
            }

            var Car = Cars.GetByID(new Cars { ID = Trip.Car });
            var TripExtras = TripsExtras.GetByTripId(new Trip_Extars { Trip = Trip.ID });

            var tripInvitations = TripsInvitations.GetSentInvitations(new TransferInvitations {Trip = Trip.ID });

            decimal? VehiclePrice = 0;
            if (tripInvitations != null)
            {
                if(tripInvitations.Count>0)
                {
                    var ti = tripInvitations.FirstOrDefault(t => t.AcceptionStatus > 0);
                    if(ti != null)
                    {
                        VehiclePrice = ti.AgentFees;
                    }
                }
            }


            decimal ExtraTotal = 0;
            if (TripExtras != null)
            {
                if (TripExtras.Count > 0)
                {
                    ExtraTotal = TripExtras.Sum(t=>t.Fees);
                }
            }

            decimal TotalAmount = Convert.ToDecimal(VehiclePrice) + ExtraTotal;


            model.Trip = Trip;
            model.Car = Car;
            model.Trip_Extars = TripExtras;
            model.TransferInvitations = tripInvitations;
            model.VehiclePrice = VehiclePrice;
            model.ExtrasTotal = ExtraTotal;
            model.TotalAmount = TotalAmount;





            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            var Message = new Message("Deleting process", "An error occurred, please try", MessageType.warning);

            if (Id == 0)
            {
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            var trip = Trips.GetByID(new  Trips { ID = Id });

            if (trip == null)
            {
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            var result = Trips.Delete(trip);
            if (result)
            {
                Message = new Message("Deleting process", "Deleted successfully", MessageType.success);
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult CompaniesList(int TripId = 0, int CarId = 0, int TransferId = 0)
        {
            var CompaniesList = TripsInvitations.GetCompanyList(new TransferInvitations { Trip = TripId,CarId = CarId,GeneralTransferID=TransferId });
            if(CompaniesList ==null)
            {
                CompaniesList = new List<TransferInvitations>();
            }
            var data = Json(new { CompaniesList = CompaniesList }, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult SendInvitation(TransferInvitations model)
        {
            var Message = new Message("Send Invitation", "An error occurred, please try", MessageType.warning);
            if (model.Company == 0 || model.Trip == 0)
            {
                return Json(new { Result = false, Message=Message }, JsonRequestBehavior.AllowGet);
            }

            var Trip = Trips.GetByID(new Models.Trips { ID = model.Trip});
            if(Trip == null)
            {
                return Json(new { Result = false, Message = Message }, JsonRequestBehavior.AllowGet);
            }

            var TripInvitation = TripsInvitations.GetByID(new TransferInvitations() { Company = model.Company, Trip = Trip.ID });

            if (TripInvitation != null)
            {
                var result =  TripsInvitations.Delete(TripInvitation);
                if(result)
                {
                    Trip.TripStatus = 0;
                    Trips.Update(Trip);
                }
                Message = new Message("Send Invitation", "The invitation has been cancelled", MessageType.success);
                return Json(new { Result = true, Message = Message}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var SentInvitations = TripsInvitations.GetSentInvitations(new TransferInvitations { Trip = Trip.ID});
                if(SentInvitations.Count == 0)
                {
                    var CompanyPriceObject = CustomerPrices.GetSingle(new Customer_Prices {CompanyID = model.Company,CarID = Trip.Car,GeneralTransferID = Trip.Transfer});
                    decimal CompanyPrice = 0;
                    if(CompanyPriceObject != null)
                    {
                        CompanyPrice = CompanyPriceObject.Price;
                    }
                    TripInvitation = new TransferInvitations()
                    {
                        Trip = model.Trip,
                        Company = model.Company,
                        AcceptionStatus = 4,
                        SentDate = DateTime.Now,
                        AgentFees = CompanyPrice,
                        IsCancelled = DateTime.Now,
                        ActionTime = DateTime.Now
                    };


                    

                    var result = TripsInvitations.Insert(TripInvitation); ;
                    if (result)
                    {
                        Trip.TripStatus = TripInvitation.AcceptionStatus;
                        Trips.Update(Trip);
                    }

                    Message = new Message("Send Invitation", "Sended successfully", MessageType.success);
                    return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Message = new Message("Send Invitation", "It is not possible to send more than one invitation", MessageType.warning);
                    return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
                }
            }

        }
        public ActionResult FilterTrips(Trips trip)
        {
            try
            {

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string drow = Request["draw"];

                if (sortColumnName == "")
                {
                    sortColumnName = "LocationFrom";
                }

                var TripsList = Trips.FilterTrips(trip);

                int totalrows = TripsList.Count;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    TripsList = (from t in TripsList
                                 where t.LocationFrom.ToLower().Contains(searchValue.ToLower())
                                     || t.LocationTo.ToLower().Contains(searchValue.ToLower())
                                     || t.TripStatusTitle.ToLower().Contains(searchValue.ToLower())
                                     || t.Fees.ToString().Contains(searchValue)
                                 select t).ToList();
                }

                int totalrowsafterfiltering = TripsList.Count;
                //sorting
                TripsList = TripsList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();

                //paging
                TripsList = TripsList.Skip(start).Take(length).ToList();

                if(TripsList == null)
                {
                    TripsList = new List<Trips>();
                }

                var data = Json(new { TripsList = TripsList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult LocationsList(string term)
        {
            //.Where(l => l.Name.Contains(term.ToString())).ToList()
            var locations = (from l in Locations.GetAll()
                             where l.Name.Contains(term)
                             select new
                             {
                                 id = l.ID,
                                 text = l.Name
                             }).ToList();

            var data = Json(new
            {
                Locations = locations
            }, JsonRequestBehavior.AllowGet);

            data.MaxJsonLength = int.MaxValue;
            return data;
        }
    }
}