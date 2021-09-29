using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class UserLoginLog: BusinessObjectBase
	{

		#region InnerClass
		public enum UserLoginLogFields
		{RowNumber,
			ID,
			UserID,
			LoginDate,
			LoginIP,
			UserAgent
		}
		#endregion

		#region Data Members

			long _RowNumber;
			long _iD;
			int _userID;
			DateTime _loginDate;
			string _loginIP;
			int _userAgent;

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

		public long  ID
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

		public int  UserID
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

		public DateTime  LoginDate
		{
			 get { return _loginDate; }
			 set
			 {
				 if (_loginDate != value)
				 {
					_loginDate = value;
					 PropertyHasChanged("LoginDate");
				 }
			 }
		}

		public string  LoginIP
		{
			 get { return _loginIP; }
			 set
			 {
				 if (_loginIP != value)
				 {
					_loginIP = value;
					 PropertyHasChanged("LoginIP");
				 }
			 }
		}

		public int  UserAgent
		{
			 get { return _userAgent; }
			 set
			 {
				 if (_userAgent != value)
				 {
					_userAgent = value;
					 PropertyHasChanged("UserAgent");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserID", "UserID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LoginDate", "LoginDate"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LoginIP", "LoginIP"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LoginIP", "LoginIP",50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserAgent", "UserAgent"));
		}

		#endregion

	}
}
