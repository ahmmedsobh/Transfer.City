using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Controllers;
using Transfer.City.Models;
using System.Linq.Dynamic.Core;
using Transfer.City.Helpers;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Areas.Company.Controllers
{
    public class TripsController : BaseController
    {
        // GET: Company/Trips
        public ActionResult Index()
        {
            TripsViewModel model = new TripsViewModel();
            model.Cars = Cars.GetAll().Select(c => new DropdownViewModel<int> { Value = c.ID, Name = c.Name }).ToList();
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
                var userId = UserId();
                var company = Companies.GetByUserId(new Companies { UserID = userId});
                var CompanyId = 0;
                if(company != null)
                {
                    CompanyId = company.ID;
                }

                var TripsList = Trips.GetByCompanyId(new Trips {CompanyId = CompanyId});

                if(TripsList == null)
                {
                    TripsList = new List<Trips>();
                }

                int totalrows = TripsList.Count;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    TripsList = (from t in TripsList
                                 where t.LocationFrom.ToLower().Contains(searchValue.ToLower())
                                     || t.LocationTo.ToLower().Contains(searchValue.ToLower())
                                     || t.TripStatusTitle.ToLower().Contains(searchValue.ToLower())
                                     || t.Fees.ToString().Contains(searchValue)
                                     || t.CarName.ToLower().Contains(searchValue.ToLower())
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

        public ActionResult ManageInvitations(int TripId = 0,int Status = 0)
        {
            var Message = new Message("Send Invitation", "An error occurred, please try", MessageType.warning);
            var userId = UserId();
            var company = Companies.GetByUserId(new Companies { UserID = userId });
            var CompanyId = 0;
            if (company != null)
            {
                CompanyId = company.ID;
            }
            if (CompanyId == 0 || TripId == 0 || Status == 0)
            {
                return Json(new { Result = false, Message = Message }, JsonRequestBehavior.AllowGet);
            }

            var Trip = Trips.GetByID(new Trips { ID = TripId });
            if (Trip == null)
            {
                return Json(new { Result = false, Message = Message }, JsonRequestBehavior.AllowGet);
            }

            var TripInvitation = TripsInvitations.GetByID(new TransferInvitations() { Company = CompanyId, Trip = Trip.ID });

            if (TripInvitation != null)
            {
                if(Status == 1)
                {
                    Trip.TripStatus = 6;
                    TripInvitation.AcceptionStatus = 6;
                    Trips.Update(Trip);
                    TripsInvitations.Update(TripInvitation);
                    Message = new Message("Accept Invitation", "The invitation was accepted", MessageType.success);
                    return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
                }
                else if(Status == 2)
                {
                    Trip.TripStatus = 7;
                    TripInvitation.AcceptionStatus = 7;
                    Trips.Update(Trip);
                    TripsInvitations.Update(TripInvitation);
                    Message = new Message("Accept Invitation", "The invitation was refused", MessageType.success);
                    return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
                }
                else if (Status == 3)
                {
                    Trip.TripStatus = 8;
                    TripInvitation.AcceptionStatus = 8;
                    Trips.Update(Trip);
                    TripsInvitations.Update(TripInvitation);
                    Message = new Message("Accept Invitation", "Trip in progress", MessageType.success);
                    return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
                }
                else if (Status == 4)
                {
                    Trip.TripStatus = 9;
                    TripInvitation.AcceptionStatus = 9;
                    Trips.Update(Trip);
                    TripsInvitations.Update(TripInvitation);
                    Message = new Message("Accept Invitation", "Trip done", MessageType.success);
                    return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
                }
                else if (Status == 5)
                {
                    Trip.TripStatus = 11;
                    TripInvitation.AcceptionStatus = 11;
                    Trips.Update(Trip);
                    TripsInvitations.Update(TripInvitation);
                    Message = new Message("Accept Invitation", "Trip Not implemented", MessageType.success);
                    return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
                }


                return Json(new { Result = true, Message = Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Result = false, Message = Message }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Details(int Id = 0)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }

            var userId = UserId();
            var company = Companies.GetByUserId(new Companies { UserID = userId });
            var CompanyId = 0;
            if (company != null)
            {
                CompanyId = company.ID;
            }

            var TripInvitation = TripsInvitations.GetByID(new TransferInvitations() { Company = CompanyId, Trip = Id });

            if (TripInvitation == null)
            {
                return HttpNotFound();
            }

            TripsViewModel model = new TripsViewModel();

            var Trip = new Trips() { ID = Id };
            Trip = Trips.GetByID(Trip);

            if (Trip == null)
            {
                return HttpNotFound();
            }

            var Car = Cars.GetByID(new Cars { ID = Trip.Car });
            var TripExtras = TripsExtras.GetByTripId(new Trip_Extars { Trip = Trip.ID });

            var tripInvitations = TripsInvitations.GetSentInvitations(new TransferInvitations { Trip = Trip.ID });

            decimal? VehiclePrice = 0;
            if (tripInvitations != null)
            {
                if (tripInvitations.Count > 0)
                {
                    var ti = tripInvitations.FirstOrDefault(t => t.AcceptionStatus > 0);
                    if (ti != null)
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
                    ExtraTotal = (from t in TripExtras select t.Info * t.Fees).Sum();
                }
            }

            decimal TotalAmount = Convert.ToDecimal(VehiclePrice) + ExtraTotal;

            var TripsKpi = TripsKpiFactory.GetByTripId(new TripsKpi { TripId = Id });
            var Complaints = ComplaintsFactory.GetByTripId(new Complaints { TripId = Id });


            model.Trip = Trip;
            model.Car = Car;
            model.Trip_Extars = TripExtras;
            model.TransferInvitations = tripInvitations.Where(ti=>ti.Company == CompanyId).ToList();
            model.VehiclePrice = VehiclePrice;
            model.ExtrasTotal = ExtraTotal;
            model.TotalAmount = Convert.ToDecimal(Trip.Fees);
            model.TripsKpis = TripsKpi;
            model.Complaints = Complaints;




            return View(model);
        }

        public ActionResult FilterTrips(Trips trip)
        {
            try
            {

                var userId = UserId();
                var company = Companies.GetByUserId(new Companies { UserID = userId });
                var CompanyId = 0;
                if (company != null)
                {
                    CompanyId = company.ID;
                }

                trip.CompanyId = CompanyId;

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

                var TripsList = Trips.FilterTripsForCompany(trip);
                if (TripsList == null)
                {
                    TripsList = new List<Trips>();
                }
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

                if (TripsList == null)
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