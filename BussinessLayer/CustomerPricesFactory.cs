using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transfer.City.DataLayer;
using Transfer.City.Models;

namespace Transfer.City.BusinessLayer
{
     public class CustomerPricesFactory
    {
        #region data Members

        CustomerPricesSql _dataObject = null;

        #endregion

        #region Constructor

        public CustomerPricesFactory()
        {
            _dataObject = new CustomerPricesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Cars
        /// </summary>
        /// <param name="businessObject">Cars object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Customer_Prices businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        public bool Update(Customer_Prices businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);

        }


        public Customer_Prices GetSingle(Customer_Prices businessObject)
        {
            return _dataObject.SelectSingle(businessObject);
        }

        public List<Customer_Prices> GetTransferList(Customer_Prices businessObject)
        {
            return _dataObject.SelectTransferList(businessObject);
        }


        public List<Customer_Prices> GetApprovedTransferList(Customer_Prices businessObject)
        {
            return _dataObject.SelectApprovedTransferList(businessObject);
        }


        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Customer_Prices businessObject)
        {
            return _dataObject.Delete(businessObject);
        }

        #endregion
    }
}