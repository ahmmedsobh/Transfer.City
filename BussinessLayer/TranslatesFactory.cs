using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class TranslatesFactory
    {

        #region data Members

        TranslatesSql _dataObject = null;

        #endregion

        #region Constructor

        public TranslatesFactory()
        {
            _dataObject = new TranslatesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Translates
        /// </summary>
        /// <param name="businessObject">Translates object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Translates businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Translates
        /// </summary>
        /// <param name="businessObject">Translates object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Translates businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Translates by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Translates GetByID(Translates businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Translatess
        /// </summary>
        /// <returns>list</returns>
        public List<Translates> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Translates businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
