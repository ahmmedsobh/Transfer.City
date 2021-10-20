using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;

namespace Transfer.City.Controllers
{
    public class KpiController : BaseController
    {
        // GET: Kpi
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult KpiList()
        {
            var KpiList = KpiFactory.GetAll();
            return Json(new
            {
                KpiList = KpiList
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(Kpi kpi)
        {
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);

            if (kpi.IsValid)
            {
                if (KpiFactory.Insert(kpi))
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
                if (kpi.BrokenRulesList[0] != null)
                {
                    messageDescription = kpi.BrokenRulesList[0].Description;
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
            var Kpi = new Kpi() { ID = Id };
            Kpi = KpiFactory.GetByID(Kpi);
            return Json(new
            {
                Kpi = Kpi
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePost(Kpi kpi)
        {

            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (kpi.IsValid)
            {
                if (KpiFactory.Update(kpi))
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
                if (kpi.BrokenRulesList[0] != null)
                {
                    messageDescription = kpi.BrokenRulesList[0].Description;
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

            var kpi = new Kpi() { ID = Id };
            var result = KpiFactory.Delete(kpi);
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
    }
}