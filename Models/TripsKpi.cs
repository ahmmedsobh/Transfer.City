using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
    public class TripsKpi: BusinessObjectBase
    {
		#region InnerClass
		public enum TripsKpiFields
		{
			RowNumber,
			ID,
			TripId,
			KpiId,
			PercentValue,
			Decription,
			Details
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		int _tripId;
		int _kpiId;
		int _percentValue;
		string _decription;
		string _details;
		string _name;
		string _referenceId;
		decimal _value;
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

		public int TripId
		{
			get { return _tripId; }
			set
			{
				if (_tripId != value)
				{
					_tripId = value;
					PropertyHasChanged("TripId");
				}
			}
		}

		public int KpiId
		{
			get { return _kpiId; }
			set
			{
				if (_kpiId != value)
				{
					_kpiId = value;
					PropertyHasChanged("KpiId");
				}
			}
		}

		public int PercentValue
		{
			get { return _percentValue; }
			set
			{
				if (_percentValue != value)
				{
					_percentValue = value;
					PropertyHasChanged("PercentValue");
				}
			}
		}

		public string Decription
		{
			get { return _decription; }
			set
			{
				if (_decription != value)
				{
					_decription = value;
					PropertyHasChanged("Decription");
				}
			}
		}

		public string Details
		{
			get { return _details; }
			set
			{
				if (_details != value)
				{
					_details = value;
					PropertyHasChanged("Details");
				}
			}
		}

		public string Name
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

		public string ReferenceId
		{
			get { return _referenceId; }
			set
			{
				if (_referenceId != value)
				{
					_referenceId = value;
					PropertyHasChanged("ReferenceId");
				}
			}
		}

		public decimal Value
		{
			get { return _value; }
			set
			{
				if (_value != value)
				{
					_value = value;
					PropertyHasChanged("Value");
				}
			}
		}



		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TripId", "TripId"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("KpiId", "KpiId"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PercentValue", "PercentValue"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Decription", "Decription"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Details", "Details"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Decription", "Decription",1000));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Details", "Details",1000));
		}

		#endregion
	}
}