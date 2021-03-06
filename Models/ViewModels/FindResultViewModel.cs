using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class FindResultViewModel: BusinessObjectBase
	{
		

		#region Data Members

		
		int _passngersCount = 1;
		bool _tripType;
		List<SelectDataAndTransferViewModel> _dateAndLocations;
		PaymentViewModel _payment;
		string _bookingReference;
		#endregion

		#region Properties



		public int PassngersCount
		{
			get { return _passngersCount; }
			set
			{
				if (_passngersCount != value)
				{
					_passngersCount = value;
					PropertyHasChanged("LocationTo");
				}
			}
		}

		public bool TripType
		{
			get { return _tripType; }
			set
			{
				if (_tripType != value)
				{
					_tripType = value;
					PropertyHasChanged("TripType");
				}
			}
		}

		public List<SelectDataAndTransferViewModel> DateAndLocations
		{
			get { return _dateAndLocations; }
			set
			{
				if (_dateAndLocations != value)
				{
					_dateAndLocations = value;
					PropertyHasChanged("DateAndLocations");
				}
			}
		}

		public PaymentViewModel Payment
		{
			get { return _payment; }
			set
			{
				if (_payment != value)
				{
					_payment = value;
					PropertyHasChanged("Payment");
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
			//ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			//ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			//ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name", 100));
			//ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Max_Passengers", "Max_Passengers"));
			//ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Max_Suitcases", "Max_Suitcases"));
		}

		#endregion
	}
}