using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class Company_LocationsFactory
    {

        #region data Members

        Company_LocationsSql _dataObject = null;

        #endregion

        #region Constructor

        public Company_LocationsFactory()
        {
            _dataObject = new Company_LocationsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Company_Locations
        /// </summary>
        /// <param name="businessObject">Company_Locations object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Company_Locations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Company_Locations
        /// </summary>
        /// <param name="businessObject">Company_Locations object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Company_Locations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Company_Locations by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Company_Locations GetByID(Company_Locations businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        public List<Company_Locations> GetByCompanyID(Company_Locations businessObject)
        {
            return _dataObject.SelectByCompanyID(businessObject);
        }

        public List<Company_Locations> GetCompanyEnabledLocationsByCompanyID(Company_Locations businessObject)
        {
            return _dataObject.CompanyEnabledLocationsByCompanyID(businessObject);
        }

        /// <summary>
        /// get list of all Company_Locationss
        /// </summary>
        /// <returns>list</returns>
        public List<Company_Locations> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Company_Locations businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
