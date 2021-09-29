using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
     class CustomerPricesSql:DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public CustomerPricesSql()
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
		public bool Insert(Customer_Prices businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Customer_Prices_Insert]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyID));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CarID));
                sqlCommand.Parameters.Add(new SqlParameter("@TransferID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GeneralTransferID));
                sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Price));
                sqlCommand.Parameters.Add(new SqlParameter("@SellingPrice", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SellingPrice));
               


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
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
        public bool Update(Customer_Prices businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Customer_Prices_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyID));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CarID));
                sqlCommand.Parameters.Add(new SqlParameter("@TransferID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GeneralTransferID));
                sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Price));
                sqlCommand.Parameters.Add(new SqlParameter("@SellingPrice", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SellingPrice));

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
        public Customer_Prices SelectSingle(Customer_Prices businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Customer_Prices_GetSingle]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyID));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CarID));
                sqlCommand.Parameters.Add(new SqlParameter("@TransferID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GeneralTransferID));


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
        public List<Customer_Prices> SelectTransferList(Customer_Prices businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[CustomerPricesTransfersList]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyID));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CarID));

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


        public List<Customer_Prices> SelectApprovedTransferList(Customer_Prices businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Customer_Prices_GetApprovedList]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyID));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CarID));

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
        public bool Delete(Customer_Prices businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Customer_Prices_Delete]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyID));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CarID));
                sqlCommand.Parameters.Add(new SqlParameter("@TransferID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GeneralTransferID));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
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
        internal void PopulateBusinessObjectFromReader(Customer_Prices businessObject, IDataReader dataReader)
        {


            businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.RowNumber.ToString()));

            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.ID.ToString()));

            businessObject.CompanyID = dataReader.GetInt32(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.CompanyID.ToString()));
            businessObject.CarID = dataReader.GetInt32(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.CarID.ToString()));
            businessObject.GeneralTransferID = dataReader.GetInt32(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.GeneralTransferID.ToString()));
            businessObject.Price = dataReader.GetDecimal(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.Price.ToString()));
            businessObject.FromLocation = dataReader.GetString(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.FromLocation.ToString()));
            businessObject.ToLocation = dataReader.GetString(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.ToLocation.ToString()));
            businessObject.SellingPrice = dataReader.GetDecimal(dataReader.GetOrdinal(Customer_Prices.CustomerPricesFields.SellingPrice.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Extras</returns>
        internal List<Customer_Prices> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Customer_Prices> list = new List<Customer_Prices>();

            while (dataReader.Read())
            {
                Customer_Prices businessObject = new Customer_Prices();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}