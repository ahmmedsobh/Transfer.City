using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class PassengersAndTransferViewModel: BusinessObjectBase
	{
		public enum TripsFields
		{

			ContactName,
			ContactSurname,
			SaveQuota,
			EmailAddress,
			LeadPassengerMobile,
			SMS,
			FromAirline,
			FromFlightNumber,
			FromOriginatingAirport,
			FromFlightArrivalTime,
			ToDropOfPoint
		}

			#region Data Members

	
		string _contactName;
		string _contactSurname;
		bool? _saveQuota;
		string _emailAddress;
		string _leadPassengerMobile;
		bool? _sMS;
		string _fromAirline;
		string _fromFlightNumber;
		string _fromOriginatingAirport;
		DateTime? _fromFlightArrivalTime;
		string _toDropOfPoint;
		

		#endregion

		#region Properties

		

		public string ContactName
		{
			get { return _contactName; }
			set
			{
				if (_contactName != value)
				{
					_contactName = value;
					PropertyHasChanged("ContactName");
				}
			}
		}

		public string ContactSurname
		{
			get { return _contactSurname; }
			set
			{
				if (_contactSurname != value)
				{
					_contactSurname = value;
					PropertyHasChanged("ContactSurname");
				}
			}
		}

		public bool? SaveQuota
		{
			get { return _saveQuota; }
			set
			{
				if (_saveQuota != value)
				{
					_saveQuota = value;
					PropertyHasChanged("SaveQuota");
				}
			}
		}

		public string EmailAddress
		{
			get { return _emailAddress; }
			set
			{
				if (_emailAddress != value)
				{
					_emailAddress = value;
					PropertyHasChanged("EmailAddress");
				}
			}
		}

		public string LeadPassengerMobile
		{
			get { return _leadPassengerMobile; }
			set
			{
				if (_leadPassengerMobile != value)
				{
					_leadPassengerMobile = value;
					PropertyHasChanged("LeadPassengerMobile");
				}
			}
		}

		public bool? SMS
		{
			get { return _sMS; }
			set
			{
				if (_sMS != value)
				{
					_sMS = value;
					PropertyHasChanged("SMS");
				}
			}
		}

		public string FromAirline
		{
			get { return _fromAirline; }
			set
			{
				if (_fromAirline != value)
				{
					_fromAirline = value;
					PropertyHasChanged("FromAirline");
				}
			}
		}

		public string FromFlightNumber
		{
			get { return _fromFlightNumber; }
			set
			{
				if (_fromFlightNumber != value)
				{
					_fromFlightNumber = value;
					PropertyHasChanged("FromFlightNumber");
				}
			}
		}

		public string FromOriginatingAirport
		{
			get { return _fromOriginatingAirport; }
			set
			{
				if (_fromOriginatingAirport != value)
				{
					_fromOriginatingAirport = value;
					PropertyHasChanged("FromOriginatingAirport");
				}
			}
		}

		public DateTime? FromFlightArrivalTime
		{
			get { return _fromFlightArrivalTime; }
			set
			{
				if (_fromFlightArrivalTime != value)
				{
					_fromFlightArrivalTime = value;
					PropertyHasChanged("FromFlightArrivalTime");
				}
			}
		}

		public string ToDropOfPoint
		{
			get { return _toDropOfPoint; }
			set
			{
				if (_toDropOfPoint != value)
				{
					_toDropOfPoint = value;
					PropertyHasChanged("ToDropOfPoint");
				}
			}
		}

		

		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ContactName", "ContactName", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ContactSurname", "ContactSurname", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EmailAddress", "EmailAddress", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LeadPassengerMobile", "LeadPassengerMobile", 15));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FromAirline", "FromAirline", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FromFlightNumber", "FromFlightNumber", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FromOriginatingAirport", "FromOriginatingAirport", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ToDropOfPoint", "ToDropOfPoint", 150));
		}

		#endregion

	}
}
