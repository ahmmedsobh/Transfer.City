using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class PaymentViewModel: BusinessObjectBase
	{
        string _cardNumber;
        string _cardHolder;
        int? _expiryMonth;
        int? _expireYear;
        int? _cCV;

		public string CardNumber
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

		public string CardHolder
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

		public int? ExpiryMonth
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

		public int? ExpireYear
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

		public int? CCV
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


		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CardNumber", "CardNumber", 16));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CardHolder", "CardHolder", 150));
		}
	}
}