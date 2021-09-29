using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
	public class Company_Cars : BusinessObjectBase
	{

		#region InnerClass
		public enum Company_CarsFields
		{
			RowNumber,
			ID,
			Company,
			Car,
			Approved,
			ApprovedDate,
			CarName,
			Max_Passengers,
			Max_Suitcases
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		int _company;
		int _car;
		bool _approved;
		DateTime? _approvedDate;
		string _carName;
		int _max_Passengers;
		int _max_Suitcases;

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

		public int Car
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

		public bool Approved
		{
			get { return _approved; }
			set
			{
				if (_approved != value)
				{
					_approved = value;
					PropertyHasChanged("Approved");
				}
			}
		}

		public DateTime? ApprovedDate
		{
			get { return _approvedDate; }
			set
			{
				if (_approvedDate != value)
				{
					_approvedDate = value;
					PropertyHasChanged("ApprovedDate");
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

		public int Max_Passengers
		{
			get { return _max_Passengers; }
			set
			{
				if (_max_Passengers != value)
				{
					_max_Passengers = value;
					PropertyHasChanged("Max_Passengers");
				}
			}
		}

		public int Max_Suitcases
		{
			get { return _max_Suitcases; }
			set
			{
				if (_max_Suitcases != value)
				{
					_max_Suitcases = value;
					PropertyHasChanged("Max_Suitcases");
				}
			}
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Company", "Company"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Car", "Car"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Approved", "Approved"));
		}

		#endregion

	}
}