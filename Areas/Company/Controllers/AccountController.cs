using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Controllers;
using Transfer.City.Helpers;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Areas.Company.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Company/Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Companies company)
        {
            var Message = new Message("Register Company", "An error occurred, please try", MessageType.warning);
            company.RegisteredDate = DateTime.Now;
            if (company.IsValid)
            {
                if (company.Password != company.ConfirmPassword)
                {
                    Message = new Message("Register Company", "Confirm password is not equal", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var UserFromDB = Users.GetByUserNameOrEmail(new Users { UserName = company.Account_Administrator, EmailAddress = company.Account_Administrator_Email });
                if (UserFromDB != null)
                {
                    Message = new Message("Register Company", "Username or login email already exists", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var user = new Users()
                {
                    UserName = company.Account_Administrator,
                    Password = company.Password,
                    EmailAddress = company.Account_Administrator_Email,
                    DisplayName = company.Company_Name,
                    IsCompany = true,
                    CreatedDate = DateTime.Now,
                };

                if (Users.Insert(user))
                {
                    company.UserID = user.ID;

                    if (Companies.Insert(company))
                    {
                        Message = new Message("Register Company", "Registered successfully", MessageType.success);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);

                    }
                }


            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (company.BrokenRulesList[0] != null)
                {
                    messageDescription = company.BrokenRulesList[0].Description;
                }
                Message = new Message("Register Company", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CompanyData(int Id = 0)
        {
            if(Id == 0)
            {
                return HttpNotFound();
            }

            var company = Companies.GetByID(new Models.Companies {ID= Id });

            return View(company);
        }

        [HttpPost]
        public ActionResult CompanyData(Companies company)
        {
            company.Account_Administrator_Email = "a@g.com";
            company.Password = "gggggggggg$F1";
            company.RegisteredDate = DateTime.Now;

            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (company.IsValid)
            {
                var OldCompany = Companies.GetByID(new Models.Companies { ID = company.ID });
                if(OldCompany != null)
                {
                    company.ApprovedDate = OldCompany.ApprovedDate;

                    if (Companies.Update(company))
                    {
                        Message = new Message("Updating process", "Edited successfully", MessageType.success);
                        return Json(new
                        {
                            Message = Message,
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                var messageDescription = "An error occurred, please try";
                if (company.BrokenRulesList[0] != null)
                {
                    messageDescription = company.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var Message = new Message("Change password", "An error occurred, please try", MessageType.warning);

            if (model.IsValid)
            {
                if (model.UserId == 0)
                {
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var user = Users.GetByID(new Models.Users { ID = model.UserId });
                if (user == null)
                {
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    Message = new Message("Change password", "Confirm password is not equal", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                user.Password = model.NewPassword;

                if (Users.ChangePassword(user))
                {
                    Message = new Message("Change password", "Password changed successfully", MessageType.success);
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
                Message = new Message("Updating process", messageDescription, MessageType.warning);

            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}