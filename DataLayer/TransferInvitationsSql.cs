using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for TransferInvitations
	/// </summary>
	class TransferInvitationsSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public TransferInvitationsSql()
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
		public bool Insert(TransferInvitations businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[TransferInvitations_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Trip", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Trip));
				sqlCommand.Parameters.Add(new SqlParameter("@Company", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));
				sqlCommand.Parameters.Add(new SqlParameter("@SentDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SentDate));
				sqlCommand.Parameters.Add(new SqlParameter("@AcceptionStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AcceptionStatus));
				sqlCommand.Parameters.Add(new SqlParameter("@ActionTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ActionTime));
				sqlCommand.Parameters.Add(new SqlParameter("@IsCancelled", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IsCancelled));
				sqlCommand.Parameters.Add(new SqlParameter("@AgentFees", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AgentFees));
				sqlCommand.Parameters.Add(new SqlParameter("@Sanctions", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Sanctions));
				sqlCommand.Parameters.Add(new SqlParameter("@QOS", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.QOS));
				sqlCommand.Parameters.Add(new SqlParameter("@LatingTime", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LatingTime));
				sqlCommand.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Description));

								
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
        public bool Update(TransferInvitations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[TransferInvitations_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Trip", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Trip));
				sqlCommand.Parameters.Add(new SqlParameter("@Company", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));
				sqlCommand.Parameters.Add(new SqlParameter("@SentDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SentDate));
				sqlCommand.Parameters.Add(new SqlParameter("@AcceptionStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AcceptionStatus));
				sqlCommand.Parameters.Add(new SqlParameter("@ActionTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ActionTime));
				sqlCommand.Parameters.Add(new SqlParameter("@IsCancelled", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IsCancelled));
				sqlCommand.Parameters.Add(new SqlParameter("@AgentFees", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AgentFees));
				sqlCommand.Parameters.Add(new SqlParameter("@Sanctions", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Sanctions));
				sqlCommand.Parameters.Add(new SqlParameter("@QOS", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.QOS));
				sqlCommand.Parameters.Add(new SqlParameter("@LatingTime", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LatingTime));
				sqlCommand.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Description));

                
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
        /// <returns>TransferInvitations business object</returns>
        public TransferInvitations SelectByID(TransferInvitations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[TransferInvitations_SelectByID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@TripId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Trip));
				sqlCommand.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company));

                
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
        /// <returns>list of TransferInvitations</returns>
        public List<TransferInvitations> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[TransferInvitations_SelectAll]";
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


        public List<TransferInvitations> SelectCompanyList(TransferInvitations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[TransferInvitations_CompanyList]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@TripId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Trip));
                sqlCommand.Parameters.Add(new SqlParameter("@CarId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CarId));
                sqlCommand.Parameters.Add(new SqlParameter("@TransferId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GeneralTransferID));


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

        public List<TransferInvitations> SelectSentInvitations(TransferInvitations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[TransferInvitations_SentInvitations]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@TripId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Trip));


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
        public bool Delete(TransferInvitations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[TransferInvitations_Delete]";
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
        internal void PopulateBusinessObjectFromReader(TransferInvitations businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.ID.ToString()));

				businessObject.Trip = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.Trip.ToString()));

				businessObject.Company = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.Company.ToString()));

				businessObject.SentDate = dataReader.GetDateTime(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.SentDate.ToString()));

				businessObject.AcceptionStatus = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.AcceptionStatus.ToString()));

				businessObject.ActionTime = dataReader.GetDateTime(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.ActionTime.ToString()));

				businessObject.IsCancelled = dataReader.GetDateTime(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.IsCancelled.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.AgentFees.ToString())))
				{
					businessObject.AgentFees = dataReader.GetDecimal(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.AgentFees.ToString()));
				}

				businessObject.Sanctions = dataReader.GetDecimal(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.Sanctions.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.QOS.ToString())))
				{
					businessObject.QOS = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.QOS.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.LatingTime.ToString())))
				{
					businessObject.LatingTime = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.LatingTime.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.Description.ToString())))
				{
					businessObject.Description = dataReader.GetString(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.Description.ToString()));
				}

                businessObject.CompanyName = dataReader.GetString(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.CompanyName.ToString()));
                businessObject.AcceptionStatusTitle = dataReader.GetString(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.AcceptionStatusTitle.ToString()));
                businessObject.Price = dataReader.GetDecimal(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.Price.ToString()));
                businessObject.CarId = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.CarId.ToString()));
                businessObject.GeneralTransferID = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.GeneralTransferID.ToString()));
                businessObject.CompanyQOS = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.CompanyQOS.ToString()));
                businessObject.ElapsedTime = dataReader.GetInt32(dataReader.GetOrdinal(TransferInvitations.TransferInvitationsFields.ElapsedTime.ToString()));



        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of TransferInvitations</returns>
        internal List<TransferInvitations> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<TransferInvitations> list = new List<TransferInvitations>();

            while (dataReader.Read())
            {
                TransferInvitations businessObject = new TransferInvitations();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
