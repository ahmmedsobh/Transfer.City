using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Trips: BusinessObjectBase
	{

		#region InnerClass
		public enum TripsFields
		{RowNumber,
			ID,
			Transfer,
			Car,
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
			ToDropOfPoint,
			CustomerFirstName,
			CustomerLastName,
			CustomerPhone,
			IsAccepted,
			Subscribed,
			CardNumber,
			CardHolder,
			ExpiryMonth,
			ExpireYear,
			CCV,
			RegisteredDate,
			TripStatus,
			IsPayed,
			PayementDate,
			TransactionID,
			Fees,
			LocationFrom,
			LocationTo,
			TripStatusTitle,
			LocationFromId,
			LocationToId,
			CarName,
			CompanyId,
			CancellationProtection,
			BookingReference

		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			int _transfer;
			int _car;
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
			string _customerFirstName;
			string _customerLastName;
			string _customerPhone;
			bool? _isAccepted;
			bool? _subscribed;
			string _cardNumber;
			string _cardHolder;
			int? _expiryMonth;
			int? _expireYear;
			int? _cCV;
			DateTime _registeredDate;
			int _tripStatus;
			bool _isPayed;
			DateTime? _payementDate;
			int? _transactionID;
			decimal? _fees;
			string _locationFrom;
			string _locationTo;
			string _tripStatusTitle;
			int _locationFromId;
			int _locationToId;
		string _carName;
		int _companyId;
		decimal _cancellationProtection;
		string _bookingReference;
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

		public int  Transfer
		{
			 get { return _transfer; }
			 set
			 {
				 if (_transfer != value)
				 {
					_transfer = value;
					 PropertyHasChanged("Transfer");
				 }
			 }
		}

		public int  Car
		{
			 get { return _car; }
			 set
			 {
				 if (_car != value)
				 {
					_car = value;
					 PropertyHasChanged("Car");
				 }
			 }
		}

		public string  ContactName
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

		public string  ContactSurname
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

		public bool?  SaveQuota
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

		public string  EmailAddress
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

		public string  LeadPassengerMobile
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

		public bool?  SMS
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

		public string  FromAirline
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

		public string  FromFlightNumber
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

		public string  FromOriginatingAirport
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

		public DateTime?  FromFlightArrivalTime
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

		public string  ToDropOfPoint
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

		public string  CustomerFirstName
		{
			 get { return _customerFirstName; }
			 set
			 {
				 if (_customerFirstName != value)
				 {
					_customerFirstName = value;
					 PropertyHasChanged("CustomerFirstName");
				 }
			 }
		}

		public string  CustomerLastName
		{
			 get { return _customerLastName; }
			 set
			 {
				 if (_customerLastName != value)
				 {
					_customerLastName = value;
					 PropertyHasChanged("CustomerLastName");
				 }
			 }
		}

		public string  CustomerPhone
		{
			 get { return _customerPhone; }
			 set
			 {
				 if (_customerPhone != value)
				 {
					_customerPhone = value;
					 PropertyHasChanged("CustomerPhone");
				 }
			 }
		}

		public bool?  IsAccepted
		{
			 get { return _isAccepted; }
			 set
			 {
				 if (_isAccepted != value)
				 {
					_isAccepted = value;
					 PropertyHasChanged("IsAccepted");
				 }
			 }
		}

		public bool?  Subscribed
		{
			 get { return _subscribed; }
			 set
			 {
				 if (_subscribed != value)
				 {
					_subscribed = value;
					 PropertyHasChanged("Subscribed");
				 }
			 }
		}

		public string  CardNumber
		{
			 get { return _cardNumber; }
			 set
			 {
				 if (_cardNumber != value)
				 {
					_cardNumber = value;
					 PropertyHasChanged("CardNumber");
				 }
			 }
		}

		public string  CardHolder
		{
			 get { return _cardHolder; }
			 set
			 {
				 if (_cardHolder != value)
				 {
					_cardHolder = value;
					 PropertyHasChanged("CardHolder");
				 }
			 }
		}

		public int?  ExpiryMonth
		{
			 get { return _expiryMonth; }
			 set
			 {
				 if (_expiryMonth != value)
				 {
					_expiryMonth = value;
					 PropertyHasChanged("ExpiryMonth");
				 }
			 }
		}

		public int?  ExpireYear
		{
			 get { return _expireYear; }
			 set
			 {
				 if (_expireYear != value)
				 {
					_expireYear = value;
					 PropertyHasChanged("ExpireYear");
				 }
			 }
		}

		public int?  CCV
		{
			 get { return _cCV; }
			 set
			 {
				 if (_cCV != value)
				 {
					_cCV = value;
					 PropertyHasChanged("CCV");
				 }
			 }
		}

		public DateTime  RegisteredDate
		{
			 get { return _registeredDate; }
			 set
			 {
				 if (_registeredDate != value)
				 {
					_registeredDate = value;
					 PropertyHasChanged("RegisteredDate");
				 }
			 }
		}

		public int  TripStatus
		{
			 get { return _tripStatus; }
			 set
			 {
				 if (_tripStatus != value)
				 {
					_tripStatus = value;
					 PropertyHasChanged("TripStatus");
				 }
			 }
		}

		public bool  IsPayed
		{
			 get { return _isPayed; }
			 set
			 {
				 if (_isPayed != value)
				 {
					_isPayed = value;
					 PropertyHasChanged("IsPayed");
				 }
			 }
		}

		public DateTime?  PayementDate
		{
			 get { return _payementDate; }
			 set
			 {
				 if (_payementDate != value)
				 {
					_payementDate = value;
					 PropertyHasChanged("PayementDate");
				 }
			 }
		}

		public int?  TransactionID
		{
			 get { return _transactionID; }
			 set
			 {
				 if (_transactionID != value)
				 {
					_transactionID = value;
					 PropertyHasChanged("TransactionID");
				 }
			 }
		}

		public decimal?  Fees
		{
			 get { return _fees; }
			 set
			 {
				 if (_fees != value)
				 {
					_fees = value;
					 PropertyHasChanged("Fees");
				 }
			 }
		}

		public string LocationFrom
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

		public string LocationTo
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

		public string TripStatusTitle
		{
			get { return _tripStatusTitle; }
			set
			{
				if (_tripStatusTitle != value)
				{
					_tripStatusTitle = value;
					PropertyHasChanged("TripStatusTitle");
				}
			}
		}

		public int LocationFromId
		{
			get { return _locationFromId; }
			set
			{
				if (_locationFromId != value)
				{
					_locationFromId = value;
					PropertyHasChanged("LocationFromId");
				}
			}
		}

		public int LocationToId
		{
			get { return _locationToId; }
			set
			{
				if (_locationToId != value)
				{
					_locationToId = value;
					PropertyHasChanged("LocationToId");
				}
			}
		}

		public string CarName
		{
			get { return _carName; }
			set
			{
				if (_carName != value)
				{
					_carName = value;
					PropertyHasChanged("CarName");
				}
			}
		}
		public int CompanyId
		{
			get { return _companyId; }
			set
			{
				if (_companyId != value)
				{
					_companyId = value;
					PropertyHasChanged("CompanyId");
				}
			}
		}

		public decimal CancellationProtection
		{
			get { return _cancellationProtection; }
			set
			{
				if (_cancellationProtection != value)
				{
					_cancellationProtection = value;
					PropertyHasChanged("CancellationProtection");
				}
			}
		}

		public string BookingReference
		{
			get { return _bookingReference; }
			set
			{
				if (_bookingReference != value)
				{
					_bookingReference = value;
					PropertyHasChanged("BookingReference");
				}
			}
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Transfer", "Transfer"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Car", "Car"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ContactName", "ContactName",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ContactSurname", "ContactSurname",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EmailAddress", "EmailAddress",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LeadPassengerMobile", "LeadPassengerMobile",15));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FromAirline", "FromAirline",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FromFlightNumber", "FromFlightNumber",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FromOriginatingAirport", "FromOriginatingAirport",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ToDropOfPoint", "ToDropOfPoint",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CustomerFirstName", "CustomerFirstName",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CustomerLastName", "CustomerLastName",150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CustomerPhone", "CustomerPhone",15));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CardNumber", "CardNumber",16));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CardHolder", "CardHolder",150));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("RegisteredDate", "RegisteredDate"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TripStatus", "TripStatus"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IsPayed", "IsPayed"));
		}

		#endregion

	}
}
