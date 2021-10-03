using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.Models;

namespace Transfer.City.Areas.Company.Models.ViewModel
{
    public class ChangePasswordViewModel: BusinessObjectBase
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

		string _oldPassword;
		public string OldPassword
		{
			get { return _oldPassword; }
			set
			{
				if (_oldPassword != value)
				{
					_oldPassword = value;
					PropertyHasChanged("OldPassword");
				}
			}
		}

		string _newPassword;
		public string NewPassword
		{
			get { return _newPassword; }
			set
			{
				if (_newPassword != value)
				{
					_newPassword = value;
					PropertyHasChanged("NewPassword");
				}
			}
		}


		string _confirmPassword;
		public string ConfirmPassword
		{
			get { return _confirmPassword; }
			set
			{
				if (_confirmPassword != value)
				{
					_confirmPassword = value;
					PropertyHasChanged("ConfirmPassword");
				}
			}
		}


		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserName", "UserName"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OldPassword", "OldPassword"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("NewPassword", "NewPassword"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ConfirmPassword", "ConfirmPassword"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("NewPassword", @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("ConfirmPassword", @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("OldPassword", @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})"));
		}
	}
}