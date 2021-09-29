using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transfer.City.Helpers;
using Transfer.City.Models;
using Transfer.City.Models.ViewModels;
using System.Linq.Dynamic.Core;

namespace Transfer.City.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        public ActionResult Index()
        {
            var permissions = (from p in Permissions.GetAll()
                              select new DropdownViewModel<int>()
                              {
                                    Name = p.Name,
                                    Value = p.ID
                              }).ToList();

            return View(permissions);
        }
        public ActionResult UsersList()
        {
            try
            {
                
                var UsersList = (from u in Users.GetAll()
                             where u.IsAdmin
                             select new
                             {
                                 ID = u.ID, 
                                 DisplayName = u.DisplayName,
                                 EmailAddress = u.EmailAddress,
                                 CreatedDate = u.CreatedDate.ToString(),
                                 IsActive = u.IsActive,
                                 IsEnabled = u.IsEnabled
                             }).ToList();
                           

                var data = Json(UsersList, JsonRequestBehavior.AllowGet);
                data.MaxJsonLength = int.MaxValue;
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(UserViewModel model)
        {
            var Message = new Message("Aadding process", "An error occurred, please try", MessageType.warning);
            model.User.CreatedDate = DateTime.Now;
            model.User.IsAdmin = true;
            if (model.User.IsValid)
            {
                if (model.User.Password != model.User.ConfirmPassword)
                {
                    Message = new Message("Aadding process", "Confirm password is not equal", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var UserFromDB = Users.GetByUserNameOrEmail(new Users { UserName = model.User.UserName, EmailAddress = model.User.EmailAddress });
                if (UserFromDB != null)
                {
                    Message = new Message("Aadding process", "Username or login email already exists", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                if (Users.Insert(model.User))
                {
                    var userPermissions = model.UserPermissions.Where(up=>up.Enabled);
                    foreach (var item in userPermissions)
                    {
                        var permission = Permissions.GetByID(new Permissions {ID=item.PermissionID});
                        if(permission != null)
                        {
                            item.UserID = model.User.ID;
                            UserPermissions.Insert(item);
                        }
                    }

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
                if (model.User.BrokenRulesList[0] != null)
                {
                    messageDescription = model.User.BrokenRulesList[0].Description;
                }
                Message = new Message("Aadding process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int Id = 0)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }

            var user = Users.GetByID(new Models.Users {ID=Id});

            return View(user);
        }
        [HttpPost]
        public ActionResult Update(UserViewModel model)
        {
            model.User.EmailAddress = "a@g.com";
            model.User.Password = "gggggggggg$F1";
            model.User.CreatedDate = DateTime.Now;
            model.User.IsAdmin = true;
            model.User.ModifiedDate = DateTime.Now;

            var Message = new Message("Updating process", "An error occurred, please try", MessageType.warning);

            if (model.User.IsValid)
            {
                if (Users.Update(model.User))
                {
                    foreach(var item in model.UserPermissions)
                    {
                        var userPermission = UserPermissions.GetByUserIdAndPermissionId(new Models.UserPermissions {UserID=model.User.ID,PermissionID = item.PermissionID});
                        if(userPermission != null)
                        {
                            if(userPermission.Enabled != item.Enabled)
                            {
                                userPermission.Enabled = item.Enabled;
                                UserPermissions.Update(userPermission);
                            }
                        }
                        else
                        {
                            if(item.Enabled)
                            {
                                var permission = Permissions.GetByID(new Permissions { ID = item.PermissionID });
                                if (permission != null)
                                {
                                    item.UserID = model.User.ID;
                                    UserPermissions.Insert(item);
                                }
                            }
                        }
                    }

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
                if (model.User.BrokenRulesList[0] != null)
                {
                    messageDescription = model.User.BrokenRulesList[0].Description;
                }
                Message = new Message("Updating process", messageDescription, MessageType.warning);
            }

            return Json(new
            {
                Message = Message,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int Id = 0)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }

            var user = Users.GetByID(new Models.Users { ID = Id });
            var permissions = UserPermissions.GetEnabledPermissionsList(new Models.UserPermissions {UserID=Id});
            UserViewModel model = new UserViewModel();
            model.User = user;
            model.UserPermissions = permissions;

            return View(model);
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

            var user = Users.GetByID(new Users { ID = Id });

            if (user == null)
            {
                return Json(new
                {
                    Message = Message,
                }, JsonRequestBehavior.AllowGet);
            }

            var result = Users.Delete(new Users { ID = user.ID });
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
        public ActionResult PermissionsList(int UserId = 0)
        {
            var PermissionsList = UserPermissions.GetPermissionsList(new Models.UserPermissions { UserID = UserId});

            var data = Json(PermissionsList, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult FilterUsers(int PermissionId = 0)
        {
            var UsersList = (from u in Users.FilterUsers(new Models.UserPermissions { PermissionID = PermissionId})
                            where u.IsAdmin
                            select new
                            {
                                ID = u.ID,
                                DisplayName = u.DisplayName,
                                EmailAddress = u.EmailAddress,
                                CreatedDate = u.CreatedDate.ToString(),
                                IsActive = u.IsActive,
                                IsEnabled = u.IsEnabled
                            }).ToList();
            
            var data = Json(UsersList, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var Message = new Message("Change password", "An error occurred, please try", MessageType.warning);

            if (model.IsValid)
            {
                if(model.UserId == 0)
                {
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                var user = Users.GetByID(new Models.Users { ID = model.UserId});
                if(user == null)
                {
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                if(model.NewPassword != model.ConfirmPassword)
                {
                    Message = new Message("Change password", "Confirm password is not equal", MessageType.warning);
                    return Json(new
                    {
                        Message = Message,
                    }, JsonRequestBehavior.AllowGet);
                }

                user.Password = model.NewPassword;

                if(Users.ChangePassword(user))
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