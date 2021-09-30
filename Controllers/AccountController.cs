using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var Message = new Message("Login", "An error occurred, please try", MessageType.warning);
            if (model.IsValid)
            {
                var user = Users.GetByUserNameAndPassword(new Models.Users {UserName=model.UserName,Password = model.Password });

                if (user != null)
                {
                    Session["UserName"] = user.UserName;
                    Session["UserId"] = user.ID;
                    Message = new Message("Login", "Logined Successfully", MessageType.success);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Message = new Message("Login", "Invalid User Name or Password", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (model.BrokenRulesList[0] != null)
                {
                    messageDescription = model.BrokenRulesList[0].Description;
                }
                Message = new Message("Login", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}