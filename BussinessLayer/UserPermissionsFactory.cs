using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class UserPermissionsFactory
    {

        #region data Members

        UserPermissionsSql _dataObject = null;

        #endregion

        #region Constructor

        public UserPermissionsFactory()
        {
            _dataObject = new UserPermissionsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new UserPermissions
        /// </summary>
        /// <param name="businessObject">UserPermissions object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(UserPermissions businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing UserPermissions
        /// </summary>
        /// <param name="businessObject">UserPermissions object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(UserPermissions businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get UserPermissions by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public UserPermissions GetByID(UserPermissions businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        public UserPermissions GetByUserIdAndPermissionId(UserPermissions businessObject)
        {
            return _dataObject.SelectByUserIdAndPermissionId(businessObject);
        }

        /// <summary>
        /// get list of all UserPermissionss
        /// </summary>
        /// <returns>list</returns>
        public List<UserPermissions> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        public List<UserPermissions> GetPermissionsList(UserPermissions businessObject)
        {
            return _dataObject.SelectPermissionsList(businessObject);
        }

        public List<UserPermissions> GetEnabledPermissionsList(UserPermissions businessObject)
        {
            return _dataObject.SelectEnabledPermissionsList(businessObject);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(UserPermissions businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
