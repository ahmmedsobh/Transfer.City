using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;

namespace Transfer.City.Controllers
{
    public class CountriesController : BaseController
    {
        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CountriesList()
        {
            var CountriesList = Countries.GetAll();
            return Json(new
            {
                CountriesList = CountriesList
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(Countries country)
         {
            var CountriesList = Countries.GetAll();
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);

            if (country.IsValid)
            {
                if (Countries.Insert(country))
                {
                    Message = new Message("Aadding process", "Added successfully", MessageType.success);
                    CountriesList = Countries.GetAll();
                    return Json(new
                    {
                        Message = Message,
                        CountriesList = CountriesList
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (country.BrokenRulesList[0] != null)
                {
                    messageDescription = country.BrokenRulesList[0].Description;
                }
                Message = new Message("Aadding process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
                CountriesList = CountriesList
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateGet(int Id = 0)
        {
            var Country = new Countries() { ID = Id };
            Country = Countries.GetByID(Country);
            return Json(new
            {
                Country = Country
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePost(Countries country)
        {

            var CountriesList = Countries.GetAll();
            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (country.IsValid)
            {
                if (Countries.Update(country))
                {
                    Message = new Message("Updating process", "Edited successfully", MessageType.success);
                    CountriesList = Countries.GetAll();
                    return Json(new
                    {
                        Message = Message,
                        CountriesList = CountriesList
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (country.BrokenRulesList[0] != null)
                {
                    messageDescription = country.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
                CountriesList = CountriesList
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            var CountriesList = Countries.GetAll();
            var Message = new Message("Deleting process", "An error occurred, please try", MessageType.warning);

            if(Id == 0)
            {
                return Json(new
                {
                    Message = Message,
                    CountriesList = CountriesList
                }, JsonRequestBehavior.AllowGet);
            }

            var country = new Countries() { ID = Id };
            var result = Countries.Delete(country);
            if(result)
            {
                CountriesList = Countries.GetAll();
                Message = new Message("Deleting process", "Deleted successfully", MessageType.success);
                return Json(new
                {
                    Message = Message,
                    CountriesList = CountriesList
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                Message = Message,
                CountriesList = CountriesList
            }, JsonRequestBehavior.AllowGet);
        }
            

        
    }
}