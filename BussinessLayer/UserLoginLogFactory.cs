using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class UserLoginLogFactory
    {

        #region data Members

        UserLoginLogSql _dataObject = null;

        #endregion

        #region Constructor

        public UserLoginLogFactory()
        {
            _dataObject = new UserLoginLogSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new UserLoginLog
        /// </summary>
        /// <param name="businessObject">UserLoginLog object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(UserLoginLog businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing UserLoginLog
        /// </summary>
        /// <param name="businessObject">UserLoginLog object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(UserLoginLog businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get UserLoginLog by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public UserLoginLog GetByID(UserLoginLog businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all UserLoginLogs
        /// </summary>
        /// <returns>list</returns>
        public List<UserLoginLog> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(UserLoginLog businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
