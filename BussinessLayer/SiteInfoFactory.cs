using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class SiteInfoFactory
    {

        #region data Members

        SiteInfoSql _dataObject = null;

        #endregion

        #region Constructor

        public SiteInfoFactory()
        {
            _dataObject = new SiteInfoSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new SiteInfo
        /// </summary>
        /// <param name="businessObject">SiteInfo object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(SiteInfo businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing SiteInfo
        /// </summary>
        /// <param name="businessObject">SiteInfo object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(SiteInfo businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get SiteInfo by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public SiteInfo GetByID(SiteInfo businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all SiteInfos
        /// </summary>
        /// <returns>list</returns>
        public List<SiteInfo> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(SiteInfo businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
