using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transfer.City.DataLayer;
using Transfer.City.Models;
using System.Linq;

namespace Transfer.City.BusinessLayer
{
    public class TripsFactory
    {

        #region data Members

        TripsSql _dataObject = null;

        #endregion

        #region Constructor

        public TripsFactory()
        {
            _dataObject = new TripsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Trips
        /// </summary>
        /// <param name="businessObject">Trips object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Trips businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Trips
        /// </summary>
        /// <param name="businessObject">Trips object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Trips businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Trips by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Trips GetByID(Trips businessObject)
        {
            return _dataObject.SelectByID(businessObject); 
        }

        /// <summary>
        /// get list of all Tripss
        /// </summary>
        /// <returns>list</returns>
        public List<Trips> GetByCompanyId(Trips businessObject)
        {
            return _dataObject.SelectByCompanyId(businessObject); 
        }

        public List<Trips> GetAll()
        {
            return _dataObject.SelectAll();
        }

        public List<Trips> FilterTrips(Trips trip)
        {
            List<Trips> TripsList = _dataObject.SelectAll();
            if (trip.LocationFromId != 0 && trip.LocationToId != 0 && trip.Car != 0 && trip.TripStatus != 0)
            {
                TripsList = (from t in _dataObject.SelectAll()
                                 where t.LocationFromId == trip.LocationFromId && t.LocationToId == trip.LocationToId && t.Car == trip.Car && t.TripStatus == trip.TripStatus
                                 select t).ToList();
            }
            else if (trip.LocationFromId != 0)
            {
                TripsList = (from t in _dataObject.SelectAll()
                             where t.LocationFromId == trip.LocationFromId 
                             select t).ToList();
            }
            else if (trip.LocationToId != 0)
            {
                TripsList = (from t in _dataObject.SelectAll()
                             where  t.LocationToId == trip.LocationToId 
                             select t).ToList();
            }
            else if (trip.Car != 0)
            {
                TripsList = (from t in _dataObject.SelectAll()
                             where  t.Car == trip.Car
                             select t).ToList();
            }
            else if (trip.TripStatus != 0)
            {
                TripsList = (from t in _dataObject.SelectAll()
                             where t.TripStatus == trip.TripStatus
                             select t).ToList();
            }
            return TripsList;
        }

        public List<Trips> FilterTripsForCompany(Trips trip)
        {

            List<Trips> TripsList = _dataObject.SelectByCompanyId(new Trips {CompanyId = trip.CompanyId });
            
            if (trip.LocationFromId != 0 && trip.LocationToId != 0 && trip.Car != 0 && trip.TripStatus != 0)
            {
                TripsList = (from t in TripsList
                             where t.LocationFromId == trip.LocationFromId && t.LocationToId == trip.LocationToId && t.Car == trip.Car && t.TripStatus == trip.TripStatus
                             select t).ToList();
            }
            else if (trip.LocationFromId != 0)
            {
                TripsList = (from t in TripsList
                             where t.LocationFromId == trip.LocationFromId
                             select t).ToList();
            }
            else if (trip.LocationToId != 0)
            {
                TripsList = (from t in TripsList
                             where t.LocationToId == trip.LocationToId
                             select t).ToList();
            }
            else if (trip.Car != 0)
            {
                TripsList = (from t in TripsList
                             where t.Car == trip.Car
                             select t).ToList();
            }
            else if (trip.TripStatus != 0)
            {
                TripsList = (from t in TripsList
                             where t.TripStatus == trip.TripStatus
                             select t).ToList();
            }
            return TripsList;
        }
        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(Trips businessObject)
        {
            return _dataObject.Delete(businessObject); 
        }

        #endregion

    }
}
