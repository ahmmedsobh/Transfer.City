using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class TripsKpiFactory
    {
        #region data Members

        TripsKpiSql _dataObject = null;

        #endregion

        #region Constructor

        public TripsKpiFactory()
        {
            _dataObject = new TripsKpiSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Cars
        /// </summary>
        /// <param name="businessObject">Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(TripsKpi businessObject)
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
        public bool Update(TripsKpi businessObject)
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
        public TripsKpi GetByID(TripsKpi businessObject)
        {
            return _dataObject.SelectByID(businessObject);
        }

        /// <summary>
        /// get list of all Carss
        /// </summary>
        /// <returns>list</returns>
        public List<TripsKpi> GetAll()
        {
            return _dataObject.SelectAll();
        }

        public List<TripsKpi> GetByTripId(TripsKpi businessObject)
        {
            return _dataObject.SelectByTripId(businessObject);
        }
        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(TripsKpi businessObject)
        {
            return _dataObject.Delete(businessObject);
        }

        #endregion
    }
}