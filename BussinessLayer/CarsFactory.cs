using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class CarsFactory
    {

        #region data Members

        CarsSql _dataObject = null;

        #endregion

        #region Constructor

        public CarsFactory()
        {
            _dataObject = new CarsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Cars
        /// </summary>
        /// <param name="businessObject">Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Cars businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Cars
        /// </summary>
        /// <param name="businessObject">Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Cars businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Cars by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Cars GetByID(Cars businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Carss
        /// </summary>
        /// <returns>list</returns>
        public List<Cars> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Cars businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
