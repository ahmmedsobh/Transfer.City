using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class PermissionsFactory
    {

        #region data Members

        PermissionsSql _dataObject = null;

        #endregion

        #region Constructor

        public PermissionsFactory()
        {
            _dataObject = new PermissionsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Permissions
        /// </summary>
        /// <param name="businessObject">Permissions object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Permissions businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Permissions
        /// </summary>
        /// <param name="businessObject">Permissions object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Permissions businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Permissions by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Permissions GetByID(Permissions businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Permissionss
        /// </summary>
        /// <returns>list</returns>
        public List<Permissions> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Permissions businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
