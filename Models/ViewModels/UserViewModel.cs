using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class UserViewModel
    {
        public Users User { get; set; }
        public List<UserPermissions> UserPermissions { get; set; } = new List<UserPermissions>();
    }
}