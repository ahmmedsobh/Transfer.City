using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
    public class Customer_Prices:BusinessObjectBase
    {
		#region InnerClass
		public enum CustomerPricesFields
		{
			RowNumber,
			ID,
			CompanyID,
			CarID,
			GeneralTransferID,
			Price,
			FromLocation,
			ToLocation,
			SellingPrice
		}
		#endregion

		#region Data Members

		long _rowNumber;
		int _iD;
		int _companyID;
		int _carID;
		int _generalTransferID;
		decimal _price;
		string	_fromLocation;
		string	_toLocatio;
		decimal _sellingPrice;

		#endregion

		#region Properties

		public long RowNumber
		{
			get { return _rowNumber; }
			set
			{
				if (_rowNumber != value)
				{
					_rowNumber = value;
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

		public int CompanyID
		{
			get { return _companyID; }
			set
			{
				if (_companyID != value)
				{
					_companyID = value;
					PropertyHasChanged("CompanyID");
				}
			}
		}

		public int CarID
		{
			get { return _carID; }
			set
			{
				if (_carID != value)
				{
					_carID = value;
					PropertyHasChanged("CarID");
				}
			}
		}

		public int GeneralTransferID
		{
			get { return _generalTransferID; }
			set
			{
				if (_generalTransferID != value)
				{
					_generalTransferID = value;
					PropertyHasChanged("GeneralTransferID");
				}
			}
		}

		public decimal Price
		{
			get { return _price; }
			set
			{
				if (_price != value)
				{
					_price = value;
					PropertyHasChanged("Price");
				}
			}
		}

		public string FromLocation
		{
			get { return _fromLocation; }
			set
			{
				if (_fromLocation != value)
				{
					_fromLocation = value;
					PropertyHasChanged("FromLocation");
				}
			}
		}

		public string ToLocation
		{
			get { return _toLocatio; }
			set
			{
				if (_toLocatio != value)
				{
					_toLocatio = value;
					PropertyHasChanged("ToLocation");
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