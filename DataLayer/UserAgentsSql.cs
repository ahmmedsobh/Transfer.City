using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for UserAgents
	/// </summary>
	class UserAgentsSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public UserAgentsSql()
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
		public bool Insert(UserAgents businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[UserAgents_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Browser));
				sqlCommand.Parameters.Add(new SqlParameter("@OperatingSystem", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OperatingSystem));

								
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
        public bool Update(UserAgents businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[UserAgents_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Browser));
				sqlCommand.Parameters.Add(new SqlParameter("@OperatingSystem", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OperatingSystem));

                
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
        /// <returns>UserAgents business object</returns>
        public UserAgents SelectByID(UserAgents businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[UserAgents_SelectByID]";
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
        /// <returns>list of UserAgents</returns>
        public List<UserAgents> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[UserAgents_SelectAll]";
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
        public bool Delete(UserAgents businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[UserAgents_Delete]";
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
        internal void PopulateBusinessObjectFromReader(UserAgents businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(UserAgents.UserAgentsFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(UserAgents.UserAgentsFields.ID.ToString()));

				businessObject.Name = dataReader.GetString(dataReader.GetOrdinal(UserAgents.UserAgentsFields.Name.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(UserAgents.UserAgentsFields.Browser.ToString())))
				{
					businessObject.Browser = dataReader.GetString(dataReader.GetOrdinal(UserAgents.UserAgentsFields.Browser.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(UserAgents.UserAgentsFields.OperatingSystem.ToString())))
				{
					businessObject.OperatingSystem = dataReader.GetString(dataReader.GetOrdinal(UserAgents.UserAgentsFields.OperatingSystem.ToString()));
				}


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of UserAgents</returns>
        internal List<UserAgents> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<UserAgents> list = new List<UserAgents>();

            while (dataReader.Read())
            {
                UserAgents businessObject = new UserAgents();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
