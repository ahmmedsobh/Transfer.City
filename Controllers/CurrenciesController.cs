using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;

namespace Transfer.City.Controllers
{
    public class CurrenciesController : BaseController
    {
        // GET: Currencies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CurrenciesList()
        {
            var CurrenciesList = Currencies.GetAll();
            return Json(new
            {
                CurrenciesList = CurrenciesList
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(Currencies currency)
        {
            var CurrenciesList = Currencies.GetAll();
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);

            if (currency.IsValid)
            {
                if (Currencies.Insert(currency))
                {
                    Message = new Message("Aadding process", "Added successfully", MessageType.success);
                    CurrenciesList = Currencies.GetAll();
                    return Json(new
                    {
                        Message = Message,
                        CurrenciesList = CurrenciesList
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (currency.BrokenRulesList[0] != null)
                {
                    messageDescription = currency.BrokenRulesList[0].Description;
                }
                Message = new Message("Aadding process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
                CurrenciesList = CurrenciesList
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateGet(int Id = 0)
        {
            var Currency = new Currencies() { ID = Id };
            Currency = Currencies.GetByID(Currency);
            return Json(new
            {
                Currency = Currency
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePost(Currencies currency)
        {

            var CurrenciesList = Currencies.GetAll();
            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (currency.IsValid)
            {
                if (Currencies.Update(currency))
                {
                    Message = new Message("Updating process", "Edited successfully", MessageType.success);
                    CurrenciesList = Currencies.GetAll();
                    return Json(new
                    {
                        Message = Message,
                        CurrenciesList = CurrenciesList
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (currency.BrokenRulesList[0] != null)
                {
                    messageDescription = currency.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
                CurrenciesList = CurrenciesList
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            var CurrenciesList = Currencies.GetAll();
            var Message = new Message("Deleting process", "An error occurred, please try", MessageType.warning);

            if (Id == 0)
            {
                return Json(new
                {
                    Message = Message,
                    CurrenciesList = CurrenciesList
                }, JsonRequestBehavior.AllowGet);
            }

            var currency = new Currencies() { ID = Id };
            var result = Currencies.Delete(currency);
            if (result)
            {
                CurrenciesList = Currencies.GetAll();
                Message = new Message("Deleting process", "Deleted successfully", MessageType.success);
                return Json(new
                {
                    Message = Message,
                    CurrenciesList = CurrenciesList
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                Message = Message,
                CurrenciesList = CurrenciesList
            }, JsonRequestBehavior.AllowGet);
        }
    }
}