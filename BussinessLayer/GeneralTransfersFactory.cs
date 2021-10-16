using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class GeneralTransfersFactory
    {

        #region data Members

        GeneralTransfersSql _dataObject = null;

        #endregion

        #region Constructor

        public GeneralTransfersFactory()
        {
            _dataObject = new GeneralTransfersSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new GeneralTransfers
        /// </summary>
        /// <param name="businessObject">GeneralTransfers object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(GeneralTransfers businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing GeneralTransfers
        /// </summary>
        /// <param name="businessObject">GeneralTransfers object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(GeneralTransfers businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get GeneralTransfers by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public GeneralTransfers GetByID(GeneralTransfers businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        public GeneralTransfers GetByLocationToAndLocationFrom(GeneralTransfers businessObject)
        {
            return _dataObject.SelectByLocationToAndLocationFrom(businessObject);
        }

        /// <summary>
        /// get list of all GeneralTransferss
        /// </summary>
        /// <returns>list</returns>
        public List<GeneralTransfers> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(GeneralTransfers businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
