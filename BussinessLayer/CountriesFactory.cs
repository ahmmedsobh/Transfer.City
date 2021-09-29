using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class CountriesFactory
    {

        #region data Members

        CountriesSql _dataObject = null;

        #endregion

        #region Constructor

        public CountriesFactory()
        {
            _dataObject = new CountriesSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Countries
        /// </summary>
        /// <param name="businessObject">Countries object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Countries businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Countries
        /// </summary>
        /// <param name="businessObject">Countries object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Countries businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Countries by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Countries GetByID(Countries businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Countriess
        /// </summary>
        /// <returns>list</returns>
        public List<Countries> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Countries businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
