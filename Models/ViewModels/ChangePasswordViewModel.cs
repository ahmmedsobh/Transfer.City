using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{

    public class ChangePasswordViewModel: BusinessObjectBase
    {
		int _userId;
		public int UserId
		{
			get { return _userId; }
			set
			{
				if (_userId != value)
				{
					_userId = value;
					PropertyHasChanged("UserId");
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
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserId", "User Id"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("NewPassword", "NewPassword"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ConfirmPassword", "ConfirmPassword"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("NewPassword", @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("ConfirmPassword", @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})"));
		}

	}
}