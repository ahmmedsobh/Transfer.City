using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.Models.ViewModels;

namespace Transfer.City.Models
{
    public class FindTransfer: BusinessObjectBase
    {
		#region InnerClass
		public enum FindTransferFields
		{
			RowNumber,
			ID,
			Name,
			Max_Passengers,
			Max_Suitcases,
			Img,
			EstimatedTime,
			SellingPrice,
			LocationFrom,
			LocationTo,
			PassngersCount
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _name;
		int _max_Passengers;
		int _max_Suitcases;
		string _img;
		int _estimatedTime;
		decimal _sellingPrice;
		int _locationFrom;
		int _locationTo;
		int _passngersCount;
		bool _tripType;
		List<SelectDataAndTransferViewModel> _dateAndTransfer;
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

		public string Img
		{
			get { return _img; }
			set
			{
				if (_img != value)
				{
					_img = value;
					PropertyHasChanged("Img");
				}
			}
		}

		public int EstimatedTime
		{
			get { return _estimatedTime; }
			set
			{
				if (_estimatedTime != value)
				{
					_estimatedTime = value;
					PropertyHasChanged("EstimatedTime");
				}
			}
		}

		public decimal SellingPrice
		{
			get { return _sellingPrice; }
			set
			{
				if (_sellingPrice != value)
				{
					_sellingPrice = value;
					PropertyHasChanged("SellingPrice");
				}
			}
		}

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

		public List<SelectDataAndTransferViewModel> DateAndTransfer
		{
			get { return _dateAndTransfer; }
			set
			{
				if (_dateAndTransfer != value)
				{
					_dateAndTransfer = value;
					PropertyHasChanged("DateAndTransfer");
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