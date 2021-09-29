using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class Company_CarsFactory
    {

        #region data Members

        Company_CarsSql _dataObject = null;

        #endregion

        #region Constructor

        public Company_CarsFactory()
        {
            _dataObject = new Company_CarsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Company_Cars
        /// </summary>
        /// <param name="businessObject">Company_Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Company_Cars businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Company_Cars
        /// </summary>
        /// <param name="businessObject">Company_Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Company_Cars businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Company_Cars by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Company_Cars GetByID(Company_Cars businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        public Company_Cars GetSingle(Company_Cars businessObject)
        {
            return _dataObject.SelectSingle(businessObject);
        }

        public List<Company_Cars> GetByCompanyID(Company_Cars businessObject)
        {
            return _dataObject.SelectByCompanyID(businessObject);
        }

        /// <summary>
        /// get list of all Company_Carss
        /// </summary>
        /// <returns>list</returns>
        public List<Company_Cars> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Company_Cars businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
