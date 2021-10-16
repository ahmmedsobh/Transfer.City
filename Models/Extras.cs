using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
	public class Extras : BusinessObjectBase
	{

		#region InnerClass
		public enum ExtrasFields
		{
			RowNumber,
			ID,
			Name,
			Description,
			Fees,
			Icon,
			RequiredInfoName,
			RequiredInfoDescription,
			Count,
			ExtraType,
			File,
			RequiredInfoValue,

		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _name;
		string _description;
		decimal _fees;
		string _icon;
		string _requiredInfoName;
		string _requiredInfoDescription;
		int _count;
		bool _extraType;
		HttpPostedFileBase _file;
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

		public string Description
		{
			get { return _description; }
			set
			{
				if (_description != value)
				{
					_description = value;
					PropertyHasChanged("Description");
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

		public string RequiredInfoName
		{
			get { return _requiredInfoName; }
			set
			{
				if (_requiredInfoName != value)
				{
					_requiredInfoName = value;
					PropertyHasChanged("RequiredInfoName");
				}
			}
		}

		public string RequiredInfoDescription
		{
			get { return _requiredInfoDescription; }
			set
			{
				if (_requiredInfoDescription != value)
				{
					_requiredInfoDescription = value;
					PropertyHasChanged("RequiredInfoDescription");
				}
			}
		}

		public int Count
		{
			get { return _count; }
			set
			{
				if (_count != value)
				{
					_count = value;
					PropertyHasChanged("Count");
				}
			}
		}

		public bool ExtraType
		{
			get { return _extraType; }
			set
			{
				if (_extraType != value)
				{
					_extraType = value;
					PropertyHasChanged("ExtraType");
				}
			}
		}

		public HttpPostedFileBase File
		{
			get { return _file; }
			set
			{
				if (_file != value)
				{
					_file = value;
					PropertyHasChanged("File");
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
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name", 100));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Description", "Description", 1000));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Fees", "Fees"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Icon", "Icon", 50));
		}

		#endregion

	}
}