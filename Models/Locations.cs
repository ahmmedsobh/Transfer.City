using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Locations: BusinessObjectBase
	{

		#region InnerClass
		public enum LocationsFields
		{RowNumber,
			ID,
			Name,
			LocationType,
			Latitude,
			Longitude,
			Country,
			CountryName,
			LocationTypeName

		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			string _name;
			int _locationType;
			decimal? _latitude;
			decimal? _longitude;
			int _country;
			string _countryName;
			string _locationTypeName;

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

		public int  LocationType
		{
			 get { return _locationType; }
			 set
			 {
				 if (_locationType != value)
				 {
					_locationType = value;
					 PropertyHasChanged("LocationType");
				 }
			 }
		}

		public decimal?  Latitude
		{
			 get { return _latitude; }
			 set
			 {
				 if (_latitude != value)
				 {
					_latitude = value;
					 PropertyHasChanged("Latitude");
				 }
			 }
		}

		public decimal?  Longitude
		{
			 get { return _longitude; }
			 set
			 {
				 if (_longitude != value)
				 {
					_longitude = value;
					 PropertyHasChanged("Longitude");
				 }
			 }
		}

		public int  Country
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

		public string LocationTypeName
		{
			get { return _locationTypeName; }
			set
			{
				if (_locationTypeName != value)
				{
					_locationTypeName = value;
					PropertyHasChanged("LocationTypeName");
				}
			}
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name",250));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LocationType", "LocationType"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Country", "Country"));
		}

		#endregion

	}
}
