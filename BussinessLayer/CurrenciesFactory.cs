using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class CurrenciesFactory
    {

        #region data Members

        CurrenciesSql _dataObject = null;

        #endregion

        #region Constructor

        public CurrenciesFactory()
        {
            _dataObject = new CurrenciesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Currencies
        /// </summary>
        /// <param name="businessObject">Currencies object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Currencies businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Currencies
        /// </summary>
        /// <param name="businessObject">Currencies object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Currencies businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Currencies by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Currencies GetByID(Currencies businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Currenciess
        /// </summary>
        /// <returns>list</returns>
        public List<Currencies> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Currencies businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
