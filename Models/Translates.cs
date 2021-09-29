using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Translates: BusinessObjectBase
	{

		#region InnerClass
		public enum TranslatesFields
		{RowNumber,
			ID,
			Name,
			Component,
			Language
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _name;
			int _component;
			int _language;

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

		public int  Component
		{
			 get { return _component; }
			 set
			 {
				 if (_component != value)
				 {
					_component = value;
					 PropertyHasChanged("Component");
				 }
			 }
		}

		public int  Language
		{
			 get { return _language; }
			 set
			 {
				 if (_language != value)
				 {
					_language = value;
					 PropertyHasChanged("Language");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Component", "Component"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Language", "Language"));
		}

		#endregion

	}
}
