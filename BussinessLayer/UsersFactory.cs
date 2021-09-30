using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;
using System.Linq;

namespace Transfer.City.BusinessLayer
{
    public class UsersFactory
    {

        #region data Members

        UsersSql _dataObject = null;

        #endregion

        #region Constructor

        public UsersFactory()
        {
            _dataObject = new UsersSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Users
        /// </summary>
        /// <param name="businessObject">Users object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Users businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Users
        /// </summary>
        /// <param name="businessObject">Users object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Users businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        public bool ChangePassword(Users businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.ChangePassword(businessObject);
        }

        /// <summary>
        /// get Users by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Users GetByID(Users businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        public Users GetByUserNameAndPassword(Users businessObject)
        {
            return _dataObject.SelectByUserNameAndPassword(businessObject);
        }

        public Users GetByUserNameOrEmail(Users businessObject)
        {
            return _dataObject.SelectByUserNameOrEmail(businessObject);
        }

        /// <summary>
        /// get list of all Userss
        /// </summary>
        /// <returns>list</returns>
        public List<Users> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        public List<Users> FilterUsers(UserPermissions businessObject)
        {
            return _dataObject.UsersFilter(businessObject);
        }


        

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Users businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
