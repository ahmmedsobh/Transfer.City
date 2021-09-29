using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class ExtrasFactory
    {

        #region data Members

        ExtrasSql _dataObject = null;

        #endregion

        #region Constructor

        public ExtrasFactory()
        {
            _dataObject = new ExtrasSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Extras
        /// </summary>
        /// <param name="businessObject">Extras object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Extras businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Extras
        /// </summary>
        /// <param name="businessObject">Extras object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Extras businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Extras by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Extras GetByID(Extras businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Extrass
        /// </summary>
        /// <returns>list</returns>
        public List<Extras> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Extras businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
