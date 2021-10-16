using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Users: BusinessObjectBase
	{

		#region InnerClass
		public enum UsersFields
		{RowNumber,
			ID,
			UserName,
			Password,
			EmailAddress,
			DisplayName,
			IsAdmin,
			IsCompany,
			IsCustomer,
			CreatedDate,
			ModifiedDate,
			LastLoginDate,
			LastLoginIPAddress,
			IsActive,
			IsEnabled,
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _userName;
			string _password;
			string _emailAddress;
			string _displayName;
			bool _isAdmin;
			bool _isCompany;
			bool _isCustomer;
			DateTime _createdDate;
			DateTime? _modifiedDate;
			DateTime? _lastLoginDate;
			string _lastLoginIPAddress;
			bool _isActive;
			bool _isEnabled;
		string _confirmPassword;

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

		public int  ID
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

		public string  UserName
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

		public string  Password
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

		public string  EmailAddress
		{
			 get { return _emailAddress; }
			 set
			 {
				 if (_emailAddress != value)
				 {
					_emailAddress = value;
					 PropertyHasChanged("EmailAddress");
				 }
			 }
		}

		public string  DisplayName
		{
			 get { return _displayName; }
			 set
			 {
				 if (_displayName != value)
				 {
					_displayName = value;
					 PropertyHasChanged("DisplayName");
				 }
			 }
		}

		public bool  IsAdmin
		{
			 get { return _isAdmin; }
			 set
			 {
				 if (_isAdmin != value)
				 {
					_isAdmin = value;
					 PropertyHasChanged("IsAdmin");
				 }
			 }
		}

		public bool  IsCompany
		{
			 get { return _isCompany; }
			 set
			 {
				 if (_isCompany != value)
				 {
					_isCompany = value;
					 PropertyHasChanged("IsCompany");
				 }
			 }
		}

		public bool  IsCustomer
		{
			 get { return _isCustomer; }
			 set
			 {
				 if (_isCustomer != value)
				 {
					_isCustomer = value;
					 PropertyHasChanged("IsCustomer");
				 }
			 }
		}

		public DateTime  CreatedDate
		{
			 get { return _createdDate; }
			 set
			 {
				 if (_createdDate != value)
				 {
					_createdDate = value;
					 PropertyHasChanged("CreatedDate");
				 }
			 }
		}

		public DateTime?  ModifiedDate
		{
			 get { return _modifiedDate; }
			 set
			 {
				 if (_modifiedDate != value)
				 {
					_modifiedDate = value;
					 PropertyHasChanged("ModifiedDate");
				 }
			 }
		}

		public DateTime?  LastLoginDate
		{
			 get { return _lastLoginDate; }
			 set
			 {
				 if (_lastLoginDate != value)
				 {
					_lastLoginDate = value;
					 PropertyHasChanged("LastLoginDate");
				 }
			 }
		}

		public string  LastLoginIPAddress
		{
			 get { return _lastLoginIPAddress; }
			 set
			 {
				 if (_lastLoginIPAddress != value)
				 {
					_lastLoginIPAddress = value;
					 PropertyHasChanged("LastLoginIPAddress");
				 }
			 }
		}

		public bool  IsActive
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

		public bool  IsEnabled
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

		

		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserName", "UserName"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("UserName", "UserName",50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Password", "Password"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Password", "Password",50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EmailAddress", "EmailAddress"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EmailAddress", "EmailAddress",50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DisplayName", "DisplayName"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DisplayName", "DisplayName",50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IsAdmin", "IsAdmin"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IsCompany", "IsCompany"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IsCustomer", "IsCustomer"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CreatedDate", "CreatedDate"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LastLoginIPAddress", "LastLoginIPAddress",50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IsActive", "IsActive"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IsEnabled", "IsEnabled"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("EmailAddress", "Email Address", @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"));
			ValidationRules.AddRules(new Validation.ValidateRuleRegexMatching("Password", @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})"));
		}

		#endregion

	}
}
