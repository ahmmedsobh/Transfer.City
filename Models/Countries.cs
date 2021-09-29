using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
	public class Countries : BusinessObjectBase
	{

		#region InnerClass
		public enum CountriesFields
		{
			RowNumber,
			ID,
			Country,
			PhoneCode,
			Latitude,
			Longitude
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _country;
		string _phoneCode;
		decimal? _latitude;
		decimal? _longitude;

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

		public int ID
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

		public string Name
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

		public string Country
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

		public string PhoneCode
		{
			get { return _phoneCode; }
			set
			{
				if (_phoneCode != value)
				{
					_phoneCode = value;
					PropertyHasChanged("PhoneCode");
				}
			}
		}

		public decimal? Latitude
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

		public decimal? Longitude
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Country", "Country"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Country", "Country", 250));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PhoneCode", "PhoneCode"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PhoneCode", "PhoneCode", 5));
		}

		#endregion

	}
}