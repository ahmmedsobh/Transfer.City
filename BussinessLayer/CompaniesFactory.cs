using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;
using System.Linq;

namespace Transfer.City.BusinessLayer
{
    public class CompaniesFactory
    {

        #region data Members

        CompaniesSql _dataObject = null;

        #endregion

        #region Constructor

        public CompaniesFactory()
        {
            _dataObject = new CompaniesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Companies
        /// </summary>
        /// <param name="businessObject">Companies object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Companies businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Companies
        /// </summary>
        /// <param name="businessObject">Companies object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Companies businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Companies by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Companies GetByID(Companies businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Companiess
        /// </summary>
        /// <returns>list</returns>
        public List<Companies> GetAll()
        {
            return _dataObject.SelectAll(); 
        }


        public List<Companies> FilterCompanies(int CountryId = 0 , int CurrencyId = 0)
        {
            List<Companies> CompaniesList = _dataObject.SelectAll();
            if(CountryId != 0 && CurrencyId != 0)
            {
                CompaniesList = (from c in _dataObject.SelectAll()
                                 where c.Country == CountryId && c.Currency == CurrencyId
                                 select c).ToList();
            }
            else if(CountryId != 0)
            {
                CompaniesList = (from c in _dataObject.SelectAll()
                                 where c.Country == CountryId 
                                 select c).ToList();
            }
            else if (CurrencyId != 0)
            {
                CompaniesList = (from c in _dataObject.SelectAll()
                                 where c.Currency == CurrencyId
                                 select c).ToList();
            }
            return CompaniesList;
        }
        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Companies businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
