using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class KpiFactory
    {
        #region data Members

        KpiSql _dataObject = null;

        #endregion

        #region Constructor

        public KpiFactory()
        {
            _dataObject = new KpiSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Cars
        /// </summary>
        /// <param name="businessObject">Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Kpi businessObject)
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
        public bool Update(Kpi businessObject)
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
        public Kpi GetByID(Kpi businessObject)
        {
            return _dataObject.SelectByID(businessObject);
        }

        /// <summary>
        /// get list of all Carss
        /// </summary>
        /// <returns>list</returns>
        public List<Kpi> GetAll()
        {
            return _dataObject.SelectAll();
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Kpi businessObject)
        {
            return _dataObject.Delete(businessObject);
        }

        #endregion
    }
}