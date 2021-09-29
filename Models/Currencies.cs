using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
	public class Currencies : BusinessObjectBase
	{

		#region InnerClass
		public enum CurrenciesFields
		{
			RowNumber,
			ID,
			Name,
			Symbol
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _name;
		string _symbol;

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

		public string Symbol
		{
			get { return _symbol; }
			set
			{
				if (_symbol != value)
				{
					_symbol = value;
					PropertyHasChanged("Symbol");
				}
			}
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name", 50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Symbol", "Symbol"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Symbol", "Symbol", 5));
		}

		#endregion

	}
}