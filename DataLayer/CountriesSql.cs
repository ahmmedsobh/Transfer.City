using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for Countries
	/// </summary>
	class CountriesSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CountriesSql()
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
		public bool Insert(Countries businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Countries_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Country));
				sqlCommand.Parameters.Add(new SqlParameter("@PhoneCode", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PhoneCode));
				sqlCommand.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Latitude));
				sqlCommand.Parameters.Add(new SqlParameter("@Longitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Longitude));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

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
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(Countries businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Countries_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Country));
				sqlCommand.Parameters.Add(new SqlParameter("@PhoneCode", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PhoneCode));
				sqlCommand.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 10,8, "", DataRowVersion.Proposed, businessObject.Latitude));
				sqlCommand.Parameters.Add(new SqlParameter("@Longitude", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 10,8, "", DataRowVersion.Proposed, businessObject.Longitude));

                
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

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>Countries business object</returns>
        public Countries SelectByID(Countries businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Countries_SelectByID]";
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
        /// Select all rescords
        /// </summary>
        /// <returns>list of Countries</returns>
        public List<Countries> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Countries_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

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
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(Countries businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Countries_Delete]";
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
        internal void PopulateBusinessObjectFromReader(Countries businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Countries.CountriesFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Countries.CountriesFields.ID.ToString()));

				businessObject.Country = dataReader.GetString(dataReader.GetOrdinal(Countries.CountriesFields.Country.ToString()));

				businessObject.PhoneCode = dataReader.GetString(dataReader.GetOrdinal(Countries.CountriesFields.PhoneCode.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Countries.CountriesFields.Latitude.ToString())))
				{
					businessObject.Latitude = dataReader.GetDecimal(dataReader.GetOrdinal(Countries.CountriesFields.Latitude.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Countries.CountriesFields.Longitude.ToString())))
				{
					businessObject.Longitude = dataReader.GetDecimal(dataReader.GetOrdinal(Countries.CountriesFields.Longitude.ToString()));
				}


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Countries</returns>
        internal List<Countries> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Countries> list = new List<Countries>();

            while (dataReader.Read())
            {
                Countries businessObject = new Countries();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
