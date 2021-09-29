using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
	public class Companies : BusinessObjectBase
	{

		#region InnerClass
		public enum CompaniesFields
		{
			RowNumber,
			ID,
			Company_Name,
			Trading_Name,
			Account_Administrator,
			Account_Administrator_Email,
			Password,
			Admin_Email,
			Finance_Email,
			Country,
			Phone,
			WebSite,
			Billing_Address,
			Registration_Number,
			Currency,
			VAT_Number,
			RegisteredDate,
			ApprovedDate,
			UserID,
			CountryName,
			CurrencyName,
			ConfirmPassword, 
			IsActive,
			IsEnabled,
			IsApproved
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _company_Name;
		string _trading_Name;
		string _account_Administrator;
		string _account_Administrator_Email;
		string _password;
		string _admin_Email;
		string _finance_Email;
		int? _country;
		string _phone;
		string _webSite;
		string _billing_Address;
		string _registration_Number;
		int? _currency;
		string _vAT_Number;
		DateTime _registeredDate;
		DateTime? _approvedDate;
		int _userID;
		string _countryName;
		string _currencyName;
		string _confirmPassword;
		bool _isActive;
		bool _isEnabled;
		bool _isApproved;
		#endregion

		#region Properties
		public long RowNumber
		{
			get { return _RowNumber; }
			set
			{
				if (_RowNumber != value)
				{
					_RowNumber = value;
					PropertyHasChanged("RowNumber");
				}
			}
		}

		public int ID
		{
			get { return _iD; }
			set
			{
				if (_iD != value)
				{
					_iD = value;
					PropertyHasChanged("ID");
				}
			}
		}

		public string Company_Name
		{
			get { return _company_Name; }
			set
			{
				if (_company_Name != value)
				{
					_company_Name = value;
					PropertyHasChanged("Company_Name");
				}
			}
		}

		public string Trading_Name
		{
			get { return _trading_Name; }
			set
			{
				if (_trading_Name != value)
				{
					_trading_Name = value;
					PropertyHasChanged("Trading_Name");
				}
			}
		}

		public string Account_Administrator
		{
			get { return _account_Administrator; }
			set
			{
				if (_account_Administrator != value)
				{
					_account_Administrator = value;
					PropertyHasChanged("Account_Administrator");
				}
			}
		}

		public string Account_Administrator_Email
		{
			get { return _account_Administrator_Email; }
			set
			{
				if (_account_Administrator_Email != value)
				{
					_account_Administrator_Email = value;
					PropertyHasChanged("Account_Administrator_Email");
				}
			}
		}

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

		public string Admin_Email
		{
			get { return _admin_Email; }
			set
			{
				if (_admin_Email != value)
				{
					_admin_Email = value;
					PropertyHasChanged("Admin_Email");
				}
			}
		}

		public string Finance_Email
		{
			get { return _finance_Email; }
			set
			{
				if (_finance_Email != value)
				{
					_finance_Email = value;
					PropertyHasChanged("Finance_Email");
				}
			}
		}

		public int? Country
		{
			get { return _country; }
			set
			{
				if (_country != value)
				{
					_country = value;
					PropertyHasChanged("Country");
				}
			}
		}

		public string Phone
		{
			get { return _phone; }
			set
			{
				if (_phone != value)
				{
					_phone = value;
					PropertyHasChanged("Phone");
				}
			}
		}

		public string WebSite
		{
			get { return _webSite; }
			set
			{
				if (_webSite != value)
				{
					_webSite = value;
					PropertyHasChanged("WebSite");
				}
			}
		}

		public string Billing_Address
		{
			get { return _billing_Address; }
			set
			{
				if (_billing_Address != value)
				{
					_billing_Address = value;
					PropertyHasChanged("Billing_Address");
				}
			}
		}

		public string Registration_Number
		{
			get { return _registration_Number; }
			set
			{
				if (_registration_Number != value)
				{
					_registration_Number = value;
					PropertyHasChanged("Registration_Number");
				}
			}
		}

		public int? Currency
		{
			get { return _currency; }
			set
			{
				if (_currency != value)
				{
					_currency = value;
					PropertyHasChanged("Currency");
				}
			}
		}

		public string VAT_Number
		{
			get { return _vAT_Number; }
			set
			{
				if (_vAT_Number != value)
				{
					_vAT_Number = value;
					PropertyHasChanged("VAT_Number");
				}
			}
		}

		public DateTime RegisteredDate
		{
			get { return _registeredDate; }
			set
			{
				if (_registeredDate != value)
				{
					_registeredDate = value;
					PropertyHasChanged("RegisteredDate");
				}
			}
		}

		public DateTime? ApprovedDate
		{
			get { return _approvedDate; }
			set
			{
				if (_approvedDate != value)
				{
					_approvedDate = value;
					PropertyHasChanged("ApprovedDate");
				}
			}
		}

		public int UserID
		{
			get { return _userID; }
			set
			{
				if (_userID != value)
				{
					_userID = value;
					PropertyHasChanged("UserID");
				}
			}
		}

		public string CountryName
		{
			get { return _countryName; }
			set
			{
				if (_countryName != value)
				{
					_countryName = value;
					PropertyHasChanged("CountryName");
				}
			}
		}

		public string CurrencyName
		{
			get { return _currencyName; }
			set
			{
				if (_currencyName != value)
				{
					_currencyName = value;
					PropertyHasChanged("CurrencyName");
				}
			}
		}

		public bool IsActive
		{
			get { return _isActive; }
			set
			{
				if (_isActive != value)
				{
					_isActive = value;
					PropertyHasChanged("IsActive");
				}
			}
		}

		public bool IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				if (_isEnabled != value)
				{
					_isEnabled = value;
					PropertyHasChanged("IsEnabled");
				}
			}
		}

		public bool IsApproved
		{
			get { return _isApproved; }
			set
			{
				if (_isEnabled != value)
				{
					_isApproved = value;
					PropertyHasChanged("IsApproved");
				}
			}
		}
		

		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Company_Name", "Company Name", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Trading_Name", "Trading Name", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Account_Administrator", "Account Administrator", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Account_Administrator_Email", "Account Administrator Email", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Password", "Password", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Admin_Email", "Admin Email", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Finance_Email", "Finance Email", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Phone", "Phone", 15));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("WebSite", "WebSite", 500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Billing_Address", "Billing Address", 1000));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Registration_Number", "Registration Number", 25));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VAT_Number", "VAT Number", 25));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("RegisteredDate", "RegisteredDate"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserID", "UserID"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("Account_Administrator_Email", "Account Administrator Email", @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("Admin_Email", "Admin Email", @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("Finance_Email", "Finance Email", @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("Phone", @"^\+(?:[0-9]●?){6,14}[0-9]$"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("Password", @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})"));



		}

		#endregion

	}
}