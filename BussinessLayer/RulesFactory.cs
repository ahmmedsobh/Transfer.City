using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class RulesFactory
    {

        #region data Members

        RulesSql _dataObject = null;

        #endregion

        #region Constructor

        public RulesFactory()
        {
            _dataObject = new RulesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Rules
        /// </summary>
        /// <param name="businessObject">Rules object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Rules businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Rules
        /// </summary>
        /// <param name="businessObject">Rules object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Rules businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Rules by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Rules GetByID(Rules businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Ruless
        /// </summary>
        /// <returns>list</returns>
        public List<Rules> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Rules businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
