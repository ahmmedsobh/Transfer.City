using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cn = Transfer.City.Areas.Company.Models.ViewModel;
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
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var Message = new Message("Login", "An error occurred, please try", MessageType.warning);
            if (model.IsValid)
            {
                var user = Users.GetByUserNameAndPassword(new Users { UserName = model.UserName, Password = model.Password });

                if (user != null)
                {
                    if(user.IsEnabled)
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
            CompanyViewModel model = new CompanyViewModel();

            model.Countries = (from c in Countries.GetAll()
                               select new DropdownViewModel<int>
                               { Name = c.Name, Value = c.ID }).ToList();

            model.Currencies = (from c in Currencies.GetAll()
                                select new DropdownViewModel<int>
                                { Name = c.Name, Value = c.ID }).ToList();
            return View(model);
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
        public ActionResult CompanyData()
        {

            var UserId = Convert.ToInt32(Session["UserId"]);
            //var UserId = 7;
            //if(UserId == 0)
            //{
            //    return HttpNotFound();
            //}

            CompanyViewModel model = new CompanyViewModel();

            var Company = new Companies() { UserID = UserId };
            Company = Companies.GetByUserId(Company);

            model.Company = Company;
            model.Countries = (from c in Countries.GetAll()
                               select new DropdownViewModel<int>
                               { Name = c.Name, Value = c.ID }).ToList();

            model.Currencies = (from c in Currencies.GetAll()
                                select new DropdownViewModel<int>
                                { Name = c.Name, Value = c.ID }).ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult CompanyData(Companies company)
        {
            company.Password = "gggggggggg$F1";
            company.RegisteredDate = DateTime.Now;

            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (company.IsValid)
            {
                var UserId = Convert.ToInt32(Session["UserId"]);
                //var UserId = 7;
                if (UserId == 0)
                {
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var OldCompany = Companies.GetByUserId(new Companies { UserID = UserId });
                if(OldCompany != null)
                {
                    company.ApprovedDate = OldCompany.ApprovedDate;
                    company.ID = OldCompany.ID;

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
        public ActionResult ChangePassword(cn.ChangePasswordViewModel model)
        {
            var Message = new Message("Change password", "An error occurred, please try", MessageType.warning);

            if (model.IsValid)
            {
                

                var user = Users.GetByUserNameAndPassword(new Users { UserName = model.UserName,Password = model.OldPassword });
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