using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;
using System.Linq;

namespace Transfer.City.BusinessLayer
{
    public class TransferInvitationsFactory
    {

        #region data Members

        TransferInvitationsSql _dataObject = null;

        #endregion

        #region Constructor

        public TransferInvitationsFactory()
        {
            _dataObject = new TransferInvitationsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new TransferInvitations
        /// </summary>
        /// <param name="businessObject">TransferInvitations object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(TransferInvitations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing TransferInvitations
        /// </summary>
        /// <param name="businessObject">TransferInvitations object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(TransferInvitations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get TransferInvitations by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public TransferInvitations GetByID(TransferInvitations businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all TransferInvitationss
        /// </summary>
        /// <returns>list</returns>
        public List<TransferInvitations> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        public List<TransferInvitations> FilterInvitations(TransferInvitations invitations)
        {
            List<TransferInvitations> InvitationsList = _dataObject.SelectAll();
            if (invitations.AcceptionStatus != 0 && invitations.Company != 0 )
            {
                InvitationsList = (from t in _dataObject.SelectAll()
                             where t.AcceptionStatus == invitations.AcceptionStatus && t.Company == invitations.Company 
                             select t).ToList();
            }
            else if (invitations.AcceptionStatus != 0)
            {
                InvitationsList = (from t in _dataObject.SelectAll()
                                   where t.AcceptionStatus == invitations.AcceptionStatus 
                                   select t).ToList();
            }
            else if (invitations.Company != 0)
            {
                InvitationsList = (from t in _dataObject.SelectAll()
                                   where t.Company == invitations.Company
                                   select t).ToList();
            }
            
            return InvitationsList;
        }
        public List<TransferInvitations> GetCompanyList(TransferInvitations businessObject)
        {
            return _dataObject.SelectCompanyList(businessObject);
        }

        public List<TransferInvitations> GetSentInvitations(TransferInvitations businessObject)
        {
            return _dataObject.SelectSentInvitations(businessObject);
        }
        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(TransferInvitations businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
