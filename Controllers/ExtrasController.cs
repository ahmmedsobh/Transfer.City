using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;

namespace Transfer.City.Controllers
{
    public class ExtrasController : BaseController
    {
        UploadImages UploadImages;
        public ExtrasController()
        {
            UploadImages = new UploadImages();
           
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExtrasList()
        {
            var ExtrasList = Extras.GetAll();
            var data = Json(ExtrasList,JsonRequestBehavior.AllowGet);
            return data;
        }
        [HttpPost]
        public ActionResult Insert(Extras extra)
        {
            UploadImages.MapPath = Server.MapPath("~/Content/Images/Extras");
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);
            if (extra.IsValid)
            {
                if(extra.ExtraType && extra.Count == 0)
                {
                    Message = new Message("Aadding process", "enter the number of allowed extras", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                extra.Icon = UploadImages.AddImage(extra.File,Guid.NewGuid().ToString());
                if (Extras.Insert(extra))
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
                if (extra.BrokenRulesList[0] != null)
                {
                    messageDescription = extra.BrokenRulesList[0].Description;
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
            var Extra = new Extras() { ID = Id };
            Extra = Extras.GetByID(Extra);

            var extra_Cars = Extra_Cars.GetApprovedCarsByExtraID(new Extra_Car {Extra = Id });

            return Json(new
            {
                Extra = Extra,
                Extra_Cars = extra_Cars
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePost(Extras extra)
        {
            UploadImages.MapPath = Server.MapPath("~/Content/Images/Extras");
            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (extra.IsValid)
            {
                var extra_Cars = Extra_Cars.GetApprovedCarsByExtraID(new Extra_Car { Extra = extra.ID });
                if(extra_Cars != null)
                {
                    if(extra_Cars.Count > 0)
                    {
                        extra.Count = 0;
                    }
                }
                else
                {
                    if (extra.ExtraType && extra.Count == 0)
                    {
                        Message = new Message("Aadding process", "enter the number of allowed extras", MessageType.warning);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);
                    }
                }

                var OldExtra = Extras.GetByID(new Models.Extras {ID = extra.ID });
                var OldImgName = "false";
                if (OldExtra != null)
                {
                    OldImgName = OldExtra.Icon;
                }

                extra.Icon = UploadImages.UpdataImage(extra.File,Guid.NewGuid().ToString(), OldImgName);
                if (Extras.Update(extra))
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
                if (extra.BrokenRulesList[0] != null)
                {
                    messageDescription = extra.BrokenRulesList[0].Description;
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
            UploadImages.MapPath = Server.MapPath("~/Content/Images/Extras");
            if (Id == 0)
            {
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            var extra = Extras.GetByID(new Extras { ID = Id});
            UploadImages.DeleteImage(extra.Icon);
            var result = Extras.Delete(extra);
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
        public ActionResult CarsList(int ExtraId = 0)
        {
            var CarsList = Extra_Cars.GetCarsByExtraID(new Extra_Car { Extra = ExtraId });
            var data = Json(CarsList, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult ApproveExtrasCars(int ExtraId = 0, int CarId = 0,int Count =0)
        {
            var Message = new Message("Approve cars", "An error occurred, please try", MessageType.warning);
            if (ExtraId == 0 || CarId == 0)
            {
                return Json(new { Result = false, Message = Message }, JsonRequestBehavior.AllowGet);

            }

            if (Count == 0)
            {
                Message = new Message("Approve cars", "Count Is Empty", MessageType.warning);
                return Json(new { Result=false,Message=Message}, JsonRequestBehavior.AllowGet);
            }

            var ExtraCar = Extra_Cars.GetByID(new Extra_Car() { Extra = ExtraId, Car = CarId });

            if (ExtraCar != null)
            {
                Extra_Cars.Delete(new Extra_Car {Extra = ExtraId,Car = CarId });
            }
            else
            {
                ExtraCar = new Extra_Car()
                {
                    Extra = ExtraId,
                    Car = CarId,
                    Count = Count
                };

                Extra_Cars.Insert(ExtraCar);
            }

            var data = Json(new { Result = false, Message = new Message() }, JsonRequestBehavior.AllowGet);
            return data;
        }
    }
}