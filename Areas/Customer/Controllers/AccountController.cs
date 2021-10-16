using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Controllers;
using Transfer.City.Helpers;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Areas.Customer.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Customer/Account
        public ActionResult LoginByReference()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginByReference(LoginViewModel model)
        {
            var Message = new Message("Login", "An error occurred, please try", MessageType.warning);
            if (model.IsValid)
            {

                var user = Users.GetByUserNameOrEmail(new Users { EmailAddress = model.UserName,UserName="" });

                if (user != null)
                {
                    if (user.IsEnabled)
                    {
                        Message = new Message("Login", "Login by your account", MessageType.error);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Message = new Message("Login", "This account is unactive", MessageType.warning);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    var trips = Trips.GetByReferenceAndEmail(new Trips { EmailAddress = model.UserName, BookingReference = model.Password });
                    if (trips != null)
                    {
                        if (trips.Count > 0)
                        {
                            Session["UserName"] = model.UserName;
                            Message = new Message("Login", "Logined Successfully", MessageType.success);
                            return Json(new
                            {
                                Message = Message,
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }

                    Message = new Message("Login", "Invalid Email Address or Booking Reference", MessageType.warning);
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
                var user = Users.GetByUserNameAndPassword(new Users { UserName = model.UserName, Password = model.Password });

                if (user != null)
                {
                    if (user.IsEnabled)
                    {
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.ID;
                        Message = new Message("Login", "", MessageType.success);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Message = new Message("Login", "This account is unactive", MessageType.warning);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);
                    }

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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {
            var Message = new Message("Register User", "An error occurred, please try", MessageType.warning);
            user.CreatedDate = DateTime.Now;
            if (user.IsValid)
            {
                if (user.Password != user.ConfirmPassword)
                {
                    Message = new Message("Register User", "Confirm password is not equal", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var UserFromDB = Users.GetByUserNameOrEmail(new Users { UserName = user.UserName, EmailAddress = user.EmailAddress });
                if (UserFromDB != null)
                {
                    Message = new Message("Register User", "Username or login email already exists", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var userToAdd = new Users()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    EmailAddress = user.EmailAddress,
                    DisplayName = user.DisplayName,
                    IsCustomer = true,
                    CreatedDate = DateTime.Now,
                    IsAdmin=false,
                    IsCompany = false,
                    IsActive = false,
                    IsEnabled = false
                };

                if (Users.Insert(userToAdd))
                {
                    Message = new Message("Register User", "Registered successfully", MessageType.success);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }


            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (user.BrokenRulesList[0] != null)
                {
                    messageDescription = user.BrokenRulesList[0].Description;
                }
                Message = new Message("Register User", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}