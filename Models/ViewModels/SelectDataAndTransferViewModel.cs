using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class SelectDataAndTransferViewModel: BusinessObjectBase
    {
		int _locationFrom;
		int _locationTo;
		string _locationFromName;
		string _locationToName;
		DateTime _dateTime;
		public int LocationFrom
		{
			get { return _locationFrom; }
			set
			{
				if (_locationFrom != value)
				{
					_locationFrom = value;
					PropertyHasChanged("LocationFrom");
				}
			}
		}

		public int LocationTo
		{
			get { return _locationTo; }
			set
			{
				if (_locationTo != value)
				{
					_locationTo = value;
					PropertyHasChanged("LocationTo");
				}
			}
		}

		public string LocationFromName
		{
			get { return _locationFromName; }
			set
			{
				if (_locationFromName != value)
				{
					_locationFromName = value;
					PropertyHasChanged("LocationFromName");
				}
			}
		}

		public string LocationToName
		{
			get { return _locationToName; }
			set
			{
				if (_locationToName != value)
				{
					_locationToName = value;
					PropertyHasChanged("LocationToName");
				}
			}
		}
		public DateTime DateTime
		{
			get { return _dateTime; }
			set
			{
				if (_dateTime != value)
				{
					_dateTime = value;
					PropertyHasChanged("DateTime");
				}
			}
		}

		internal override void AddValidationRules()
		{
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LocationFrom", "LocationFrom"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LocationTo", "LocationTo"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DateTime", "DateTime"));
        }
	}
}