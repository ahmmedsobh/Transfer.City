using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models
{
	public class Cars : BusinessObjectBase
	{

		#region InnerClass
		public enum CarsFields
		{
			RowNumber,
			ID,
			Name,
			Max_Passengers,
			Max_Suitcases,
			Img,
			File
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		string _name;
		int _max_Passengers;
		int _max_Suitcases;
		string _img;
		HttpPostedFileBase _file;
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

		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Name", "Name"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Name", "Name", 100));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Max_Passengers", "Max_Passengers"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Max_Suitcases", "Max_Suitcases"));
		}

		#endregion

	}
}