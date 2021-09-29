using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class UserPermissions: BusinessObjectBase
	{

		#region InnerClass
		public enum UserPermissionsFields
		{RowNumber,
			ID,
			UserID,
			PermissionID,
			Enabled,
			RuleId,
			RuleName,
			PermissionName
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			int _userID;
			int _permissionID;
			bool _enabled;
		int _ruleId;
		string _ruleName;
		string _permissionName;

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

		public int  PermissionID
		{
			 get { return _permissionID; }
			 set
			 {
				 if (_permissionID != value)
				 {
					_permissionID = value;
					 PropertyHasChanged("PermissionID");
				 }
			 }
		}

		public bool  Enabled
		{
			 get { return _enabled; }
			 set
			 {
				 if (_enabled != value)
				 {
					_enabled = value;
					 PropertyHasChanged("Enabled");
				 }
			 }
		}

		public int RuleId
		{
			get { return _ruleId; }
			set
			{
				if (_ruleId != value)
				{
					_ruleId = value;
					PropertyHasChanged("RuleId");
				}
			}
		}

		public string RuleName
		{
			get { return _ruleName; }
			set
			{
				if (_ruleName != value)
				{
					_ruleName = value;
					PropertyHasChanged("RuleName");
				}
			}
		}

		public string PermissionName
		{
			get { return _permissionName; }
			set
			{
				if (_permissionName != value)
				{
					_permissionName = value;
					PropertyHasChanged("PermissionName");
				}
			}
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("UserID", "UserID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PermissionID", "PermissionID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Enabled", "Enabled"));
		}

		#endregion

	}
}
