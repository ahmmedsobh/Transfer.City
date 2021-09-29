using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;
using System.Linq;

namespace Transfer.City.BusinessLayer
{
    public class LocationsFactory
    {

        #region data Members

        LocationsSql _dataObject = null;

        #endregion

        #region Constructor

        public LocationsFactory()
        {
            _dataObject = new LocationsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Locations
        /// </summary>
        /// <param name="businessObject">Locations object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Locations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Locations
        /// </summary>
        /// <param name="businessObject">Locations object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Locations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Locations by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Locations GetByID(Locations businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Locationss
        /// </summary>
        /// <returns>list</returns>
        public List<Locations> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        public List<Locations> FilterLocations(int CountryId = 0 , int LocationType = 0)
        {
            List<Locations> LocationsList = _dataObject.SelectAll();
            if (CountryId != 0 && LocationType != 0)
            {
                LocationsList = (from c in _dataObject.SelectAll()
                                 where c.Country == CountryId && c.LocationType == LocationType
                                 select c).ToList();
            }
            else if (CountryId != 0)
            {
                LocationsList = (from c in _dataObject.SelectAll()
                                 where c.Country == CountryId
                                 select c).ToList();
            }
            else if (LocationType != 0)
            {
                LocationsList = (from c in _dataObject.SelectAll()
                                 where c.LocationType == LocationType
                                 select c).ToList();
            }
            return LocationsList;
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Locations businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
