using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
    public class UserAgentsFactory
    {

        #region data Members

        UserAgentsSql _dataObject = null;

        #endregion

        #region Constructor

        public UserAgentsFactory()
        {
            _dataObject = new UserAgentsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new UserAgents
        /// </summary>
        /// <param name="businessObject">UserAgents object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(UserAgents businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing UserAgents
        /// </summary>
        /// <param name="businessObject">UserAgents object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(UserAgents businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get UserAgents by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public UserAgents GetByID(UserAgents businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all UserAgentss
        /// </summary>
        /// <returns>list</returns>
        public List<UserAgents> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(UserAgents businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
