using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class Extra_CarsFactory
    {
        #region data Members

        Extra_CarSql _dataObject = null;

        #endregion

        #region Constructor

        public Extra_CarsFactory()
        {
            _dataObject = new Extra_CarSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Cars
        /// </summary>
        /// <param name="businessObject">Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Extra_Car businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }


        public Extra_Car GetByID(Extra_Car businessObject)
        {
            return _dataObject.SelectByID(businessObject);
        }

        public List<Extra_Car> GetCarsByExtraID(Extra_Car businessObject)
        {
            return _dataObject.SelectByExtraID(businessObject);
        }


        public List<Extra_Car> GetApprovedCarsByExtraID(Extra_Car businessObject)
        {
            return _dataObject.ExtraAprovedCarsByExtraID(businessObject);
        }


        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Extra_Car businessObject)
        {
            return _dataObject.Delete(businessObject);
        }

        #endregion
    }
}