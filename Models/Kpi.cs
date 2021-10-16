using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
    public class Kpi: BusinessObjectBase
    {
		#region InnerClass
		public enum KpiFields
		{
			RowNumber,
			ID,
			Name,
			Weight,
			
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _name;
		int _weight;
	
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

		public int Weight
		{
			get { return _weight; }
			set
			{
				if (_weight != value)
				{
					_weight = value;
					PropertyHasChanged("Weight");
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
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Weight", "Weight"));
		}

		#endregion
	}
}