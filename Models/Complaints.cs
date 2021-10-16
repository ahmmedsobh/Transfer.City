using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
    public class Complaints: BusinessObjectBase
    {
		#region InnerClass
		public enum ComplaintsFields
		{
			RowNumber,
			ID,
			Title,
			Decription,
			TripId

		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _title;
		string _decription;
		int _tripId;
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

		public string Title
		{
			get { return _title; }
			set
			{
				if (_title != value)
				{
					_title = value;
					PropertyHasChanged("Title");
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

		public int TripId
		{
			get { return _tripId; }
			set
			{
				if (_tripId != value)
				{
					_tripId = value;
					PropertyHasChanged("Decription");
				}
			}
		}



		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Title", "Title"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Decription", "Decription"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TripId", "TripId"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Title", "Title",100));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Decription", "Decription",1000));
		}

		#endregion
	}
}