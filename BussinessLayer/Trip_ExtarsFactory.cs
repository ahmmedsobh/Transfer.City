using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class Trip_ExtarsFactory
    {

        #region data Members

        Trip_ExtarsSql _dataObject = null;

        #endregion

        #region Constructor

        public Trip_ExtarsFactory()
        {
            _dataObject = new Trip_ExtarsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Trip_Extars
        /// </summary>
        /// <param name="businessObject">Trip_Extars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Trip_Extars businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Trip_Extars
        /// </summary>
        /// <param name="businessObject">Trip_Extars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Trip_Extars businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Trip_Extars by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Trip_Extars GetByID(Trip_Extars businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Trip_Extarss
        /// </summary>
        /// <returns>list</returns>
        public List<Trip_Extars> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        public List<Trip_Extars> GetByTripId(Trip_Extars businessObject)
        {
            return _dataObject.SelectByTripId(businessObject);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Trip_Extars businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
