using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Languages: BusinessObjectBase
	{

		#region InnerClass
		public enum LanguagesFields
		{RowNumber,
			ID,
			Name,
			Code,
			RTL,
			Enabled
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _name;
			string _code;
			bool _rTL;
			bool _enabled;

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

		public string  Code
		{
			 get { return _code; }
			 set
			 {
				 if (_code != value)
				 {
					_code = value;
					 PropertyHasChanged("Code");
				 }
			 }
		}

		public bool  RTL
		{
			 get { return _rTL; }
			 set
			 {
				 if (_rTL != value)
				 {
					_rTL = value;
					 PropertyHasChanged("RTL");
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name",100));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Code", "Code"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Code", "Code",7));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("RTL", "RTL"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Enabled", "Enabled"));
		}

		#endregion

	}
}
