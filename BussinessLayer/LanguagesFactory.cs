using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class LanguagesFactory
    {

        #region data Members

        LanguagesSql _dataObject = null;

        #endregion

        #region Constructor

        public LanguagesFactory()
        {
            _dataObject = new LanguagesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Languages
        /// </summary>
        /// <param name="businessObject">Languages object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Languages businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Languages
        /// </summary>
        /// <param name="businessObject">Languages object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Languages businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Languages by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Languages GetByID(Languages businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Languagess
        /// </summary>
        /// <returns>list</returns>
        public List<Languages> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Languages businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
