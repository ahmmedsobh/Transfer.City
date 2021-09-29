using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Permissions: BusinessObjectBase
	{

		#region InnerClass
		public enum PermissionsFields
		{RowNumber,
			ID,
			Name,
			RuleID
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _name;
			int _ruleID;

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

		public string  Name
		{
			 get { return _name; }
			 set
			 {
				 if (_name != value)
				 {
					_name = value;
					 PropertyHasChanged("Name");
				 }
			 }
		}

		public int  RuleID
		{
			 get { return _ruleID; }
			 set
			 {
				 if (_ruleID != value)
				 {
					_ruleID = value;
					 PropertyHasChanged("RuleID");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name",150));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("RuleID", "RuleID"));
		}

		#endregion

	}
}
