using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Transfer.City.BusinessLayer;

namespace Transfer.City.Filter
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {
        private readonly string[] allowedPermissions;
        public CustomAuthorizeAttribute(params string[] permissions)
        {
            this.allowedPermissions = permissions;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
             UserPermissionsFactory UserPermissions = new UserPermissionsFactory();
            bool authorize = false;
            var userId = Convert.ToInt32(httpContext.Session["UserId"]);
            if (userId != 0)
            {
                var userPermissions = UserPermissions.GetEnabledPermissionsList(new Models.UserPermissions { UserID = userId });

                foreach (var item in allowedPermissions)
                {
                    var permission = userPermissions.FirstOrDefault(p => p.PermissionName == item);
                    if (permission != null)
                        return true;
                }
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Account" },
                    { "action", "UnAuthorized" }
               });
        }
    }
}