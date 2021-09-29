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
    public class LocationsController : BaseController
    {
        
        

        // GET: Locations
        public ActionResult Index()
        {
            var countries = from c in Countries.GetAll()
                            select new DropdownViewModel<int>
                            {
                                Value = c.ID,
                                Name = c.Country
                            };
            return View(countries);
        }

        public ActionResult LocationsList()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string drow = Request["draw"];

            if (sortColumnName == "")
            {
                sortColumnName = "Name";
            }
            var LocationsList = Locations.GetAll();

            int totalrows = LocationsList.Count;

            if (!string.IsNullOrEmpty(searchValue))
            {
                LocationsList = (from t in LocationsList
                                 where t.Name.Contains(searchValue.ToLower())
                                 || t.CountryName.ToLower().Contains(searchValue.ToLower())
                                 || t.LocationTypeName.ToLower().ToString().Contains(searchValue)
                                 || t.Longitude.ToString().Contains(searchValue)
                                 || t.Latitude.ToString().Contains(searchValue)
                                 select t).ToList();
            }

            int totalrowsafterfiltering = LocationsList.Count;
            //sorting
            LocationsList = LocationsList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();


            //paging
            LocationsList = LocationsList.Skip(start).Take(length).ToList();


            var data = Json(new {LocationsList= LocationsList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering } , JsonRequestBehavior.AllowGet);

            data.MaxJsonLength = int.MaxValue;
            return data;
        }

        [HttpPost]
        public ActionResult Insert(Locations location)
        {
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);

            if (location.IsValid)
            {
                if (Locations.Insert(location))
                {
                    Message = new Message("Aadding process", "Added successfully", MessageType.success);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (location.BrokenRulesList[0] != null)
                {
                    messageDescription = location.BrokenRulesList[0].Description;
                }
                Message = new Message("Aadding process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateGet(int Id = 0)
        {
            var Location = new Locations() { ID = Id };
            Location = Locations.GetByID(Location);
            return Json(new
            {
                Location = Location
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePost(Locations location)
        {

            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (location.IsValid)
            {
                if (Locations.Update(location))
                {
                    Message = new Message("Updating process", "Edited successfully", MessageType.success);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (location.BrokenRulesList[0] != null)
                {
                    messageDescription = location.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
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

            var location = new Locations() { ID = Id };
            var result = Locations.Delete(location);
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

        public ActionResult FilterLocations(int CountryId = 0, int LocationType = 0)
        {
            var LocationsList = Locations.FilterLocations(CountryId, LocationType);

            var data = Json(LocationsList, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
    }
}