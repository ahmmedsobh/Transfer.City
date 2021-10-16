using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class Trip_Extars: BusinessObjectBase
	{

		#region InnerClass
		public enum Trip_ExtarsFields
		{RowNumber,
			ID,
			Trip,
			Extra,
			Info,
			Name,
			Fees,
			Icon,
			RequiredInfoValue
		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			int _trip;
			int _extra;
			int _info;
			decimal _fees;
			string _name;
		string _icon;
		string _requiredInfoValue;

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

		public int  Trip
		{
			 get { return _trip; }
			 set
			 {
				 if (_trip != value)
				 {
					_trip = value;
					 PropertyHasChanged("Trip");
				 }
			 }
		}

		public int  Extra
		{
			 get { return _extra; }
			 set
			 {
				 if (_extra != value)
				 {
					_extra = value;
					 PropertyHasChanged("Extra");
				 }
			 }
		}

		public int  Info
		{
			 get { return _info; }
			 set
			 {
				 if (_info != value)
				 {
					_info = value;
					 PropertyHasChanged("Info");
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

		public decimal Fees
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

		public string Icon
		{
			get { return _icon; }
			set
			{
				if (_icon != value)
				{
					_icon = value;
					PropertyHasChanged("Icon");
				}
			}
		}

		public string RequiredInfoValue
		{
			get { return _requiredInfoValue; }
			set
			{
				if (_requiredInfoValue != value)
				{
					_requiredInfoValue = value;
					PropertyHasChanged("RequiredInfoValue");
				}
			}
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Trip", "Trip"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Extra", "Extra"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Info", "Info"));
		}

		#endregion

	}
}
