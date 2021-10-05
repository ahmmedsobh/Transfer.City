using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Filter;
using Transfer.City.Helpers;
using Transfer.City.Models;

namespace Transfer.City.Controllers
{
    //[CustomAuthenticationFilter]
    public class CarsController : BaseController
    {
        UploadImages UploadImages = new UploadImages();
        //[CustomAuthorize("perm 3", "perm 2")]
        // GET: Cars
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CarsList()
        {
            var CarsList = Cars.GetAll();
            return Json(new
            {
                CarsList = CarsList
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Insert(Cars car)
        {
            UploadImages.MapPath = Server.MapPath("~/Content/Images/Cars");
            var CarsList = Cars.GetAll();
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);

            if (car.IsValid)
            {
                car.Img = UploadImages.AddImage(car.File,Guid.NewGuid().ToString());
                if (Cars.Insert(car))
                {
                    Message = new Message("Aadding process", "Added successfully", MessageType.success);
                    CarsList = Cars.GetAll();
                    return Json(new
                    {
                        Message = Message,
                        CarsList = CarsList
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (car.BrokenRulesList[0] != null)
                {
                    messageDescription = car.BrokenRulesList[0].Description;
                }
                Message = new Message("Aadding process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
                CarsList = CarsList
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateGet(int Id = 0)
        {
            var Car = new Cars() { ID = Id };
            Car = Cars.GetByID(Car);
            return Json(new
            {
                Car = Car
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePost(Cars car)
        {
            UploadImages.MapPath = Server.MapPath("~/Content/Images/Cars");

            var CarsList = Cars.GetAll();
            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            var CarToUpdate = Cars.GetByID(new Models.Cars {ID = car.ID});
            if(CarToUpdate == null)
            {
                return Json(new
                {
                    Message = Message,
                    CarsList = CarsList
                }, JsonRequestBehavior.AllowGet);
            }

            if (car.IsValid)
            {
                car.Img = UploadImages.UpdataImage(car.File, Guid.NewGuid().ToString(),CarToUpdate.Img);
                if (Cars.Update(car))
                {
                    Message = new Message("Updating process", "Edited successfully", MessageType.success);
                    CarsList = Cars.GetAll();
                    return Json(new
                    {
                        Message = Message,
                        CarsList = CarsList
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (car.BrokenRulesList[0] != null)
                {
                    messageDescription = car.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
                CarsList = CarsList
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            UploadImages.MapPath = Server.MapPath("~/Content/Images/Cars");
            var CarsList = Cars.GetAll();
            var Message = new Message("Deleting process", "An error occurred, please try", MessageType.warning);

            if (Id == 0)
            {
                return Json(new
                {
                    Message = Message,
                    CarsList = CarsList
                }, JsonRequestBehavior.AllowGet);
            }

            var car = Cars.GetByID(new Models.Cars {ID = Id });
            UploadImages.DeleteImage(car.Img);
            var result = Cars.Delete(car);
            if (result)
            {
                CarsList = Cars.GetAll();
                Message = new Message("Deleting process", "Deleted successfully", MessageType.success);
                return Json(new
                {
                    Message = Message,
                    CarsList = CarsList
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                Message = Message,
                CarsList = CarsList
            }, JsonRequestBehavior.AllowGet);
        }
    }
}