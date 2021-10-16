using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class ConfirmationViewModel: BusinessObjectBase
    {
        string _customerFirstName;
        string _customerLastName;
        string _customerPhone;
        bool? _subscribed;
        bool _cancellationProtection;
        int _paymentType;

		public string CustomerFirstName
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

		public string CustomerLastName
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

		public string CustomerPhone
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

		public bool CancellationProtection
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

		public bool? Subscribed
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

		public int PaymentType
		{
			get { return _paymentType; }
			set
			{
				if (_paymentType != value)
				{
					_paymentType = value;
					PropertyHasChanged("PaymentType");
				}
			}
		}

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CustomerFirstName", "CustomerFirstName", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CustomerLastName", "CustomerLastName", 150));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CustomerPhone", "CustomerPhone", 15));
		}
	}
}