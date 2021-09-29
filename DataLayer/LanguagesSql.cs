using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for Languages
	/// </summary>
	class LanguagesSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public LanguagesSql()
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
		public bool Insert(Languages businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Languages_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Code));
				sqlCommand.Parameters.Add(new SqlParameter("@RTL", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RTL));
				sqlCommand.Parameters.Add(new SqlParameter("@Enabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Enabled));

								
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
        public bool Update(Languages businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Languages_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Code));
				sqlCommand.Parameters.Add(new SqlParameter("@RTL", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RTL));
				sqlCommand.Parameters.Add(new SqlParameter("@Enabled", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Enabled));

                
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
        /// <returns>Languages business object</returns>
        public Languages SelectByID(Languages businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Languages_SelectByID]";
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
        /// <returns>list of Languages</returns>
        public List<Languages> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Languages_SelectAll]";
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
        public bool Delete(Languages businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Languages_Delete]";
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
        internal void PopulateBusinessObjectFromReader(Languages businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Languages.LanguagesFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Languages.LanguagesFields.ID.ToString()));

				businessObject.Name = dataReader.GetString(dataReader.GetOrdinal(Languages.LanguagesFields.Name.ToString()));

				businessObject.Code = dataReader.GetString(dataReader.GetOrdinal(Languages.LanguagesFields.Code.ToString()));

				businessObject.RTL = dataReader.GetBoolean(dataReader.GetOrdinal(Languages.LanguagesFields.RTL.ToString()));

				businessObject.Enabled = dataReader.GetBoolean(dataReader.GetOrdinal(Languages.LanguagesFields.Enabled.ToString()));


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Languages</returns>
        internal List<Languages> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Languages> list = new List<Languages>();

            while (dataReader.Read())
            {
                Languages businessObject = new Languages();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
