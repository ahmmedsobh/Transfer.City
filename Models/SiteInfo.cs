using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class SiteInfo: BusinessObjectBase
	{

		#region InnerClass
		public enum SiteInfoFields
		{RowNumber,
			ID,
			SiteName,
			Language
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _siteName;
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

		public string  SiteName
		{
			 get { return _siteName; }
			 set
			 {
				 if (_siteName != value)
				 {
					_siteName = value;
					 PropertyHasChanged("SiteName");
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
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SiteName", "SiteName"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("SiteName", "SiteName",250));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Language", "Language"));
		}

		#endregion

	}
}
