using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Rules: BusinessObjectBase
	{

		#region InnerClass
		public enum RulesFields
		{RowNumber,
			ID,
			Name
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _name;

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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name",50));
		}

		#endregion

	}
}
