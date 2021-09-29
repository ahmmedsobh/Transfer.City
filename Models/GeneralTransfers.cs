using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transfer.City.Extensions;

namespace Transfer.City.Models
{
	public class GeneralTransfers : BusinessObjectBase
	{

		#region InnerClass
		public enum GeneralTransfersFields
		{
			RowNumber,
			ID,
			LocationFrom,
			LocationTo,
			EstimatedDistance,
			EstimatedTime,
			LocationFromName,
			LocationToName,
		}
		#endregion

		#region Data Members

		long _RowNumber;
		int _iD;
		int _locationFrom;
		int _locationTo;
		int _estimatedDistance;
		int _estimatedTime;
		string _locationToName;
		string _locationFromName;

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

		//[Required(AllowEmptyStrings = false, ErrorMessage = "GROUPNAMEERROR")]
		//[DescriptionSiteText("Hello Estimated")]
		//[DisplaySiteText("test text")]
		//[MaxLength(30)]
		public int EstimatedDistance
		{
			get { return _estimatedDistance; }
			set
			{
				if (_estimatedDistance != value)
				{
					_estimatedDistance = value;
					PropertyHasChanged("EstimatedDistance");
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

		public string LocationFromName
		{
			get { return _locationFromName; }
			set
			{
				if (_locationFromName != value)
				{
					_locationFromName = value;
					PropertyHasChanged("LocationFromName");
				}
			}
		}

		public string LocationToName
		{
			get { return _locationToName; }
			set
			{
				if (_locationToName != value)
				{
					_locationToName = value;
					PropertyHasChanged("LocationToName");
				}
			}
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LocationFrom", "LocationFrom"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LocationTo", "LocationTo"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EstimatedDistance", "EstimatedDistance"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EstimatedTime", "EstimatedTime"));
		}

		#endregion

	}
}