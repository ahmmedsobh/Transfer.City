using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class UserAgents: BusinessObjectBase
	{

		#region InnerClass
		public enum UserAgentsFields
		{RowNumber,
			ID,
			Name,
			Browser,
			OperatingSystem
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _name;
			string _browser;
			string _operatingSystem;

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

		public string  Browser
		{
			 get { return _browser; }
			 set
			 {
				 if (_browser != value)
				 {
					_browser = value;
					 PropertyHasChanged("Browser");
				 }
			 }
		}

		public string  OperatingSystem
		{
			 get { return _operatingSystem; }
			 set
			 {
				 if (_operatingSystem != value)
				 {
					_operatingSystem = value;
					 PropertyHasChanged("OperatingSystem");
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
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Browser", "Browser",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("OperatingSystem", "OperatingSystem",150));
		}

		#endregion

	}
}
