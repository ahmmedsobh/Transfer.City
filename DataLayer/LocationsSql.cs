using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for Locations
	/// </summary>
	class LocationsSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public LocationsSql()
		{
			// Nothing for now.
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
		/// <param name="businessObject">business object</param>
		/// <returns>true of successfully insert</returns>
		public bool Insert(Locations businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Locations_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@LocationType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LocationType));
				sqlCommand.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Latitude));
				sqlCommand.Parameters.Add(new SqlParameter("@Longitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Longitude));
				sqlCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Country));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

				return true;
			}
			catch
			{				
				return false;
			}
			finally
			{			
				MainConnection.Close();
				sqlCommand.Dispose();
			}
		}

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Locations_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@LocationType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LocationType));
				sqlCommand.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Latitude));
				sqlCommand.Parameters.Add(new SqlParameter("@Longitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Longitude));
				sqlCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Country));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>Locations business object</returns>
        public Locations SelectByID(Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Locations_SelectByID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));

                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    PopulateBusinessObjectFromReader(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {             
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of Locations</returns>
        public List<Locations> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Locations_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch 
            {                
                return null;
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Locations_Delete]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {                
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(Locations businessObject, IDataReader dataReader)
        {


			    businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Locations.LocationsFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Locations.LocationsFields.ID.ToString()));

				businessObject.Name = dataReader.GetString(dataReader.GetOrdinal(Locations.LocationsFields.Name.ToString()));

				businessObject.LocationType = dataReader.GetInt32(dataReader.GetOrdinal(Locations.LocationsFields.LocationType.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Locations.LocationsFields.Latitude.ToString())))
				{
					businessObject.Latitude = dataReader.GetDecimal(dataReader.GetOrdinal(Locations.LocationsFields.Latitude.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Locations.LocationsFields.Longitude.ToString())))
				{
					businessObject.Longitude = dataReader.GetDecimal(dataReader.GetOrdinal(Locations.LocationsFields.Longitude.ToString()));
				}

				businessObject.Country = dataReader.GetInt32(dataReader.GetOrdinal(Locations.LocationsFields.Country.ToString()));

                businessObject.CountryName = dataReader.GetString(dataReader.GetOrdinal(Locations.LocationsFields.CountryName.ToString()));
                
                businessObject.LocationTypeName = dataReader.GetString(dataReader.GetOrdinal(Locations.LocationsFields.LocationTypeName.ToString()));


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Locations</returns>
        internal List<Locations> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Locations> list = new List<Locations>();

            while (dataReader.Read())
            {
                Locations businessObject = new Locations();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
