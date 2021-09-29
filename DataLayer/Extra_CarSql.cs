using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
     class Extra_CarSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public Extra_CarSql()
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
		public bool Insert(Extra_Car businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extra_Cars_Insert]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@Car", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Car));
                sqlCommand.Parameters.Add(new SqlParameter("@Extra", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Extra));
                sqlCommand.Parameters.Add(new SqlParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Count));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;


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

        public List<Extra_Car> SelectByExtraID(Extra_Car businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extra_Cars_SelectByExtraID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ExtraID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Extra));


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

        public List<Extra_Car> ExtraAprovedCarsByExtraID(Extra_Car businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extra_Approved_Cars_ByExtraID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ExtraID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Extra));


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

        public Extra_Car SelectByID(Extra_Car businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extra_Cars_GetByExtraIDAndCarID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ExtraID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Extra));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Car));


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
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(Extra_Car businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Extra_Cars_Delete]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ExtraID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Extra));
                sqlCommand.Parameters.Add(new SqlParameter("@CarID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Car));


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
        internal void PopulateBusinessObjectFromReader(Extra_Car businessObject, IDataReader dataReader)
        {


            businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Extra_Car.CarsFields.RowNumber.ToString()));

            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Extra_Car.CarsFields.ID.ToString()));

            businessObject.Name = dataReader.GetString(dataReader.GetOrdinal(Extra_Car.CarsFields.Name.ToString()));

            businessObject.Max_Passengers = dataReader.GetInt32(dataReader.GetOrdinal(Extra_Car.CarsFields.Max_Passengers.ToString()));

            businessObject.Max_Suitcases = dataReader.GetInt32(dataReader.GetOrdinal(Extra_Car.CarsFields.Max_Suitcases.ToString()));

            businessObject.Car = dataReader.GetInt32(dataReader.GetOrdinal(Extra_Car.CarsFields.Car.ToString()));
            
            businessObject.Extra = dataReader.GetInt32(dataReader.GetOrdinal(Extra_Car.CarsFields.Extra.ToString()));
            
            businessObject.Count = dataReader.GetInt32(dataReader.GetOrdinal(Extra_Car.CarsFields.Count.ToString()));

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of Cars</returns>
        internal List<Extra_Car> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Extra_Car> list = new List<Extra_Car>();

            while (dataReader.Read())
            {
                Extra_Car businessObject = new Extra_Car();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}