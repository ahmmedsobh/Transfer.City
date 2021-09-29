using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for Extras
	/// </summary>
	class ExtrasSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ExtrasSql()
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
		public bool Insert(Extras businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Extras_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Description));
				sqlCommand.Parameters.Add(new SqlParameter("@Fees", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Fees));
				sqlCommand.Parameters.Add(new SqlParameter("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Icon));
				sqlCommand.Parameters.Add(new SqlParameter("@RequiredInfoName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RequiredInfoName));
				sqlCommand.Parameters.Add(new SqlParameter("@RequiredInfoDescription", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RequiredInfoDescription));
				sqlCommand.Parameters.Add(new SqlParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Count));

								
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
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(Extras businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extras_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Description));
				sqlCommand.Parameters.Add(new SqlParameter("@Fees", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Fees));
				sqlCommand.Parameters.Add(new SqlParameter("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Icon));
                sqlCommand.Parameters.Add(new SqlParameter("@RequiredInfoName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RequiredInfoName));
                sqlCommand.Parameters.Add(new SqlParameter("@RequiredInfoDescription", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RequiredInfoDescription));
                sqlCommand.Parameters.Add(new SqlParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Count));

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
        /// <returns>Extras business object</returns>
        public Extras SelectByID(Extras businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extras_SelectByID]";
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
        /// <returns>list of Extras</returns>
        public List<Extras> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extras_SelectAll]";
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
        public bool Delete(Extras businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extras_Delete]";
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

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(Extras businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Extras.ExtrasFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Extras.ExtrasFields.ID.ToString()));

				businessObject.Name = dataReader.GetString(dataReader.GetOrdinal(Extras.ExtrasFields.Name.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Extras.ExtrasFields.Description.ToString())))
				{
					businessObject.Description = dataReader.GetString(dataReader.GetOrdinal(Extras.ExtrasFields.Description.ToString()));
				}

				businessObject.Fees = dataReader.GetDecimal(dataReader.GetOrdinal(Extras.ExtrasFields.Fees.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Extras.ExtrasFields.Icon.ToString())))
				{
					businessObject.Icon = dataReader.GetString(dataReader.GetOrdinal(Extras.ExtrasFields.Icon.ToString()));
				}

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(Extras.ExtrasFields.RequiredInfoName.ToString())))
                {
                    businessObject.RequiredInfoName = dataReader.GetString(dataReader.GetOrdinal(Extras.ExtrasFields.RequiredInfoName.ToString()));
                }

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(Extras.ExtrasFields.RequiredInfoDescription.ToString())))
                {
                    businessObject.RequiredInfoDescription = dataReader.GetString(dataReader.GetOrdinal(Extras.ExtrasFields.RequiredInfoDescription.ToString()));
                }

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(Extras.ExtrasFields.Count.ToString())))
                {
                    businessObject.Count = dataReader.GetInt32(dataReader.GetOrdinal(Extras.ExtrasFields.Count.ToString()));
                }


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Extras</returns>
        internal List<Extras> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Extras> list = new List<Extras>();

            while (dataReader.Read())
            {
                Extras businessObject = new Extras();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
