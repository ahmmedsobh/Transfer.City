using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for Company_Locations
	/// </summary>
	class Company_LocationsSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public Company_LocationsSql()
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
		public bool Insert(Company_Locations businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Company_Locations_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Company", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));
				sqlCommand.Parameters.Add(new SqlParameter("@Location", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Location));
				sqlCommand.Parameters.Add(new SqlParameter("@Enabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Enabled));
				sqlCommand.Parameters.Add(new SqlParameter("@EnabledDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EnabledDate));

								
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
        public bool Update(Company_Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Company_Locations_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Company", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));
				sqlCommand.Parameters.Add(new SqlParameter("@Location", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Location));
				sqlCommand.Parameters.Add(new SqlParameter("@Enabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Enabled));
				sqlCommand.Parameters.Add(new SqlParameter("@EnabledDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EnabledDate));

                
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
        /// <returns>Company_Locations business object</returns>
        public Company_Locations SelectByID(Company_Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Company_Locations_SelectByID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@LocationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Location));
				sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));

                
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

        public List<Company_Locations> SelectByCompanyID(Company_Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Company_Locations_SelectByCompanyID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));


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

        public List<Company_Locations> CompanyEnabledLocationsByCompanyID(Company_Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Company_Enabled_Locations_By_CompanyID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
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
        /// <returns>list of Company_Locations</returns>
        public List<Company_Locations> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Company_Locations_SelectAll]";
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
        public bool Delete(Company_Locations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Company_Locations_Delete]";
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
        internal void PopulateBusinessObjectFromReader(Company_Locations businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.ID.ToString()));

				businessObject.Company = dataReader.GetInt32(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.Company.ToString()));

				businessObject.Location = dataReader.GetInt32(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.Location.ToString()));

				businessObject.Enabled = dataReader.GetBoolean(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.Enabled.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.EnabledDate.ToString())))
				{
					businessObject.EnabledDate = dataReader.GetDateTime(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.EnabledDate.ToString()));
				}

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.LocationName.ToString())))
                {
                    businessObject.LocationName = dataReader.GetString(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.LocationName.ToString()));
                }

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.CountryName.ToString())))
                {
                    businessObject.CountryName = dataReader.GetString(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.CountryName.ToString()));
                }

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.LocationType.ToString())))
                {
                    businessObject.LocationType = dataReader.GetInt32(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.LocationType.ToString()));
                }

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.LocationTypeName.ToString())))
                {
                    businessObject.LocationTypeName = dataReader.GetString(dataReader.GetOrdinal(Company_Locations.Company_LocationsFields.LocationTypeName.ToString()));
                }






        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Company_Locations</returns>
        internal List<Company_Locations> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Company_Locations> list = new List<Company_Locations>();

            while (dataReader.Read())
            {
                Company_Locations businessObject = new Company_Locations();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
