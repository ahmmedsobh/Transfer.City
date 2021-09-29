using System;
using System.Collections.Generic;
using System.Text;
namespace Transfer.City.Models
{
	public class TransferInvitations: BusinessObjectBase
	{

		#region InnerClass
		public enum TransferInvitationsFields
		{RowNumber,
			ID,
			Trip,
			Company,
			SentDate,
			AcceptionStatus,
			ActionTime,
			IsCancelled,
			AgentFees,
			Sanctions,
			QOS,
			LatingTime,
			Description,
			CompanyName,
            Price,
			AcceptionStatusTitle,
			CarId,
			GeneralTransferID,
			CompanyQOS,
		    ElapsedTime

		}
		#endregion

		#region Data Members

			long _RowNumber;
			int _iD;
			int _trip;
			int _company;
			DateTime _sentDate;
			int _acceptionStatus;
			DateTime _actionTime;
			DateTime _isCancelled;
			decimal? _agentFees;
			decimal _sanctions;
			int? _qOS;
			int? _latingTime;
			string _description;
			string _companyName;
			decimal _price;
			string _acceptionStatusTitle;
			int _carId;
			int _generalTransferID;
			int? _companyQOS;
			int _elapsedTime;

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

		public int  Company
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

		public DateTime  SentDate
		{
			 get { return _sentDate; }
			 set
			 {
				 if (_sentDate != value)
				 {
					_sentDate = value;
					 PropertyHasChanged("SentDate");
				 }
			 }
		}

		public int  AcceptionStatus
		{
			 get { return _acceptionStatus; }
			 set
			 {
				 if (_acceptionStatus != value)
				 {
					_acceptionStatus = value;
					 PropertyHasChanged("AcceptionStatus");
				 }
			 }
		}

		public DateTime  ActionTime
		{
			 get { return _actionTime; }
			 set
			 {
				 if (_actionTime != value)
				 {
					_actionTime = value;
					 PropertyHasChanged("ActionTime");
				 }
			 }
		}

		public DateTime  IsCancelled
		{
			 get { return _isCancelled; }
			 set
			 {
				 if (_isCancelled != value)
				 {
					_isCancelled = value;
					 PropertyHasChanged("IsCancelled");
				 }
			 }
		}

		public decimal?  AgentFees
		{
			 get { return _agentFees; }
			 set
			 {
				 if (_agentFees != value)
				 {
					_agentFees = value;
					 PropertyHasChanged("AgentFees");
				 }
			 }
		}

		public decimal  Sanctions
		{
			 get { return _sanctions; }
			 set
			 {
				 if (_sanctions != value)
				 {
					_sanctions = value;
					 PropertyHasChanged("Sanctions");
				 }
			 }
		}

		public int?  QOS
		{
			 get { return _qOS; }
			 set
			 {
				 if (_qOS != value)
				 {
					_qOS = value;
					 PropertyHasChanged("QOS");
				 }
			 }
		}

		public int?  LatingTime
		{
			 get { return _latingTime; }
			 set
			 {
				 if (_latingTime != value)
				 {
					_latingTime = value;
					 PropertyHasChanged("LatingTime");
				 }
			 }
		}

		public string  Description
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

		public string CompanyName
		{
			get { return _companyName; }
			set
			{
				if (_companyName != value)
				{
					_companyName = value;
					PropertyHasChanged("CompanyName");
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

		public string AcceptionStatusTitle
		{
			get { return _acceptionStatusTitle; }
			set
			{
				if (_acceptionStatusTitle != value)
				{
					_acceptionStatusTitle = value;
					PropertyHasChanged("AcceptionStatusTitle");
				}
			}
		}

		public int CarId
		{
			get { return _carId; }
			set
			{
				if (_carId != value)
				{
					_carId = value;
					PropertyHasChanged("CarId");
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

		public int? CompanyQOS
		{
			get { return _companyQOS; }
			set
			{
				if (_companyQOS != value)
				{
					_companyQOS = value;
					PropertyHasChanged("CompanyQOS");
				}
			}
		}

		public int ElapsedTime
		{
			get { return _elapsedTime; }
			set
			{
				if (_elapsedTime != value)
				{
					_elapsedTime = value;
					PropertyHasChanged("ElapsedTime");
				}
			}
		}

		

		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Trip", "Trip"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Company", "Company"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SentDate", "SentDate"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AcceptionStatus", "AcceptionStatus"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ActionTime", "ActionTime"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IsCancelled", "IsCancelled"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Sanctions", "Sanctions"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Description", "Description",1000));
		}

		#endregion

	}
}
