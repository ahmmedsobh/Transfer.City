using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
	public class Company_Locations : BusinessObjectBase
	{

		#region InnerClass
		public enum Company_LocationsFields
		{
			RowNumber,
			ID,
			Company,
			Location,
			Enabled,
			EnabledDate,
			LocationName,
			CountryName,
			LocationType,
			LocationTypeName,
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		int _company;
		int _location;
		bool _enabled;
		DateTime? _enabledDate;
		string _locationName;
		string _countryName;
		int _locationType;
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

		public int Company
		{
			get { return _company; }
			set
			{
				if (_company != value)
				{
					_company = value;
					PropertyHasChanged("Company");
				}
			}
		}

		public int Location
		{
			get { return _location; }
			set
			{
				if (_location != value)
				{
					_location = value;
					PropertyHasChanged("Location");
				}
			}
		}

		public bool Enabled
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

		public DateTime? EnabledDate
		{
			get { return _enabledDate; }
			set
			{
				if (_enabledDate != value)
				{
					_enabledDate = value;
					PropertyHasChanged("EnabledDate");
				}
			}
		}

		public string LocationName
		{
			get { return _locationName; }
			set
			{
				if (_locationName != value)
				{
					_locationName = value;
					PropertyHasChanged("LocationName");
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

		public int LocationType
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
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Company", "Company"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Location", "Location"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Enabled", "Enabled"));
		}

		#endregion

	}
}