using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class LoginViewModel: BusinessObjectBase
    {
		string _userName;
		public string UserName
		{
			get { return _userName; }
			set
			{
				if (_userName != value)
				{
					_userName = value;
					PropertyHasChanged("UserName");
				}
			}
		}

		string _password;
		public string Password
		{
			get { return _password; }
			set
			{
				if (_password != value)
				{
					_password = value;
					PropertyHasChanged("Password");
				}
			}
		}


		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserName", "UserName"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Password", "Password"));
		}
	}
}