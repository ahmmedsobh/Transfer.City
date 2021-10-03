using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for Companies
	/// </summary>
	class CompaniesSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CompaniesSql()
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
		public bool Insert(Companies businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Companies_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Company_Name", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company_Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Trading_Name", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Trading_Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Account_Administrator", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Account_Administrator));
				sqlCommand.Parameters.Add(new SqlParameter("@Account_Administrator_Email", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Account_Administrator_Email));
				sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Password));
				sqlCommand.Parameters.Add(new SqlParameter("@Admin_Email", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Admin_Email));
				sqlCommand.Parameters.Add(new SqlParameter("@Finance_Email", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Finance_Email));
				sqlCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Country));
				sqlCommand.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Phone));
				sqlCommand.Parameters.Add(new SqlParameter("@WebSite", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WebSite));
				sqlCommand.Parameters.Add(new SqlParameter("@Billing_Address", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Billing_Address));
				sqlCommand.Parameters.Add(new SqlParameter("@Registration_Number", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Registration_Number));
				sqlCommand.Parameters.Add(new SqlParameter("@Currency", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Currency));
				sqlCommand.Parameters.Add(new SqlParameter("@VAT_Number", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VAT_Number));
				sqlCommand.Parameters.Add(new SqlParameter("@RegisteredDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RegisteredDate));
				sqlCommand.Parameters.Add(new SqlParameter("@ApprovedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ApprovedDate));
				sqlCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.UserID));

								
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
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(Companies businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Companies_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Company_Name", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Company_Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Trading_Name", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Trading_Name));
				sqlCommand.Parameters.Add(new SqlParameter("@Account_Administrator", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Account_Administrator));
				sqlCommand.Parameters.Add(new SqlParameter("@Account_Administrator_Email", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Account_Administrator_Email));
				sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Password));
				sqlCommand.Parameters.Add(new SqlParameter("@Admin_Email", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Admin_Email));
				sqlCommand.Parameters.Add(new SqlParameter("@Finance_Email", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Finance_Email));
				sqlCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Country));
				sqlCommand.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Phone));
				sqlCommand.Parameters.Add(new SqlParameter("@WebSite", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WebSite));
				sqlCommand.Parameters.Add(new SqlParameter("@Billing_Address", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Billing_Address));
				sqlCommand.Parameters.Add(new SqlParameter("@Registration_Number", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Registration_Number));
				sqlCommand.Parameters.Add(new SqlParameter("@Currency", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Currency));
				sqlCommand.Parameters.Add(new SqlParameter("@VAT_Number", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VAT_Number));
				sqlCommand.Parameters.Add(new SqlParameter("@RegisteredDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RegisteredDate));
				sqlCommand.Parameters.Add(new SqlParameter("@ApprovedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ApprovedDate));
				sqlCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.UserID));

                
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
        /// <returns>Companies business object</returns>
        public Companies SelectByID(Companies businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Companies_SelectByID]";
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

        public Companies SelectByUserId(Companies businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Companies_SelectByUserId]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.UserID));

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
        /// <returns>list of Companies</returns>
        public List<Companies> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Companies_SelectAll]";
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
        public bool Delete(Companies businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Companies_Delete]";
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
        internal void PopulateBusinessObjectFromReader(Companies businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Companies.CompaniesFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Companies.CompaniesFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Company_Name.ToString())))
				{
					businessObject.Company_Name = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Company_Name.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Trading_Name.ToString())))
				{
					businessObject.Trading_Name = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Trading_Name.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Account_Administrator.ToString())))
				{
					businessObject.Account_Administrator = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Account_Administrator.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Account_Administrator_Email.ToString())))
				{
					businessObject.Account_Administrator_Email = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Account_Administrator_Email.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Password.ToString())))
				{
					businessObject.Password = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Password.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Admin_Email.ToString())))
				{
					businessObject.Admin_Email = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Admin_Email.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Finance_Email.ToString())))
				{
					businessObject.Finance_Email = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Finance_Email.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Country.ToString())))
				{
					businessObject.Country = dataReader.GetInt32(dataReader.GetOrdinal(Companies.CompaniesFields.Country.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Phone.ToString())))
				{
					businessObject.Phone = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Phone.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.WebSite.ToString())))
				{
					businessObject.WebSite = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.WebSite.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Billing_Address.ToString())))
				{
					businessObject.Billing_Address = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Billing_Address.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Registration_Number.ToString())))
				{
					businessObject.Registration_Number = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.Registration_Number.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.Currency.ToString())))
				{
					businessObject.Currency = dataReader.GetInt32(dataReader.GetOrdinal(Companies.CompaniesFields.Currency.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.VAT_Number.ToString())))
				{
					businessObject.VAT_Number = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.VAT_Number.ToString()));
				}

				businessObject.RegisteredDate = dataReader.GetDateTime(dataReader.GetOrdinal(Companies.CompaniesFields.RegisteredDate.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Companies.CompaniesFields.ApprovedDate.ToString())))
				{
					businessObject.ApprovedDate = dataReader.GetDateTime(dataReader.GetOrdinal(Companies.CompaniesFields.ApprovedDate.ToString()));
				}

				businessObject.UserID = dataReader.GetInt32(dataReader.GetOrdinal(Companies.CompaniesFields.UserID.ToString()));
			    businessObject.CurrencyName = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.CurrencyName.ToString()));
                businessObject.CountryName = dataReader.GetString(dataReader.GetOrdinal(Companies.CompaniesFields.CountryName.ToString()));


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Companies</returns>
        internal List<Companies> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Companies> list = new List<Companies>();

            while (dataReader.Read())
            {
                Companies businessObject = new Companies();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
