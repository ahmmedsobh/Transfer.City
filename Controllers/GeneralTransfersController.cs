using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;
using System.Linq.Dynamic.Core;

namespace Transfer.City.Controllers
{
    public class GeneralTransfersController : BaseController
    {
        // GET: GeneralTransfers
        public ActionResult Index()
        {
            return View(new GeneralTransfers());
        }

        public ActionResult GeneralTransersList()
        {
            try
            {
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                string drow = Request["draw"];

                if(sortColumnName == "")
                {
                    sortColumnName = "LocationFromName";
                }

                List<GeneralTransfers> TransfersList = (from t in Transfers.GetAll()
                                     select t).ToList<GeneralTransfers>();

                int totalrows = TransfersList.Count;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    TransfersList = (from t in TransfersList
                                     where t.LocationFromName.ToLower().Contains(searchValue.ToLower())
                                     || t.LocationToName.ToLower().Contains(searchValue.ToLower())
                                     || t.EstimatedDistance.ToString().Contains(searchValue)
                                     || t.EstimatedTime.ToString().Contains(searchValue)
                                     select t).ToList<GeneralTransfers>();
                }

                int totalrowsafterfiltering = TransfersList.Count;
                //sorting
                TransfersList = TransfersList.AsQueryable().OrderBy(sortColumnName + " " + sortDirection).ToList();


                //paging
                TransfersList = TransfersList.Skip(start).Take(length).ToList();

                var data = Json(new { TransfersList = TransfersList, draw = drow, recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch(Exception ex)
            {
                var TransfersList = new  List<GeneralTransfers>();
                var data = Json(TransfersList, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
                
        }

        [HttpPost]
        public ActionResult Insert(GeneralTransfers transfer)
        {
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);

            if (transfer.IsValid)
            {
                if (Transfers.Insert(transfer))
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
                if (transfer.BrokenRulesList[0] != null)
                {
                    messageDescription = transfer.BrokenRulesList[0].Description;
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
            var Transfer = new GeneralTransfers() { ID = Id };
            Transfer = Transfers.GetByID(Transfer);
            return Json(new
            {
                Transfer = Transfer
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePost(GeneralTransfers transfer)
        {

            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (transfer.IsValid)
            {
                if (Transfers.Update(transfer))
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
                if (transfer.BrokenRulesList[0] != null)
                {
                    messageDescription = transfer.BrokenRulesList[0].Description;
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

            var transfer = new GeneralTransfers() { ID = Id };
            var result = Transfers.Delete(transfer);
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

            var data =  Json(new
            {
                Locations = locations
            }, JsonRequestBehavior.AllowGet);

            data.MaxJsonLength = int.MaxValue;
            return data;
        }
    }
}