using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
	/// <summary>
	/// Data access layer class for Trips
	/// </summary>
	class TripsSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public TripsSql()
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
		public bool Insert(Trips businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Trips_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Transfer", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Transfer));
				sqlCommand.Parameters.Add(new SqlParameter("@Car", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Car));
				sqlCommand.Parameters.Add(new SqlParameter("@ContactName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ContactName));
				sqlCommand.Parameters.Add(new SqlParameter("@ContactSurname", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ContactSurname));
				sqlCommand.Parameters.Add(new SqlParameter("@SaveQuota", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SaveQuota));
				sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EmailAddress));
				sqlCommand.Parameters.Add(new SqlParameter("@LeadPassengerMobile", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LeadPassengerMobile));
				sqlCommand.Parameters.Add(new SqlParameter("@SMS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SMS));
				sqlCommand.Parameters.Add(new SqlParameter("@FromAirline", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromAirline));
				sqlCommand.Parameters.Add(new SqlParameter("@FromFlightNumber", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromFlightNumber));
				sqlCommand.Parameters.Add(new SqlParameter("@FromOriginatingAirport", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromOriginatingAirport));
				sqlCommand.Parameters.Add(new SqlParameter("@FromFlightArrivalTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromFlightArrivalTime));
				sqlCommand.Parameters.Add(new SqlParameter("@ToDropOfPoint", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ToDropOfPoint));
				sqlCommand.Parameters.Add(new SqlParameter("@CustomerFirstName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CustomerFirstName));
				sqlCommand.Parameters.Add(new SqlParameter("@CustomerLastName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CustomerLastName));
				sqlCommand.Parameters.Add(new SqlParameter("@CustomerPhone", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CustomerPhone));
				sqlCommand.Parameters.Add(new SqlParameter("@IsAccepted", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IsAccepted));
				sqlCommand.Parameters.Add(new SqlParameter("@Subscribed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Subscribed));
				sqlCommand.Parameters.Add(new SqlParameter("@CardNumber", SqlDbType.NVarChar, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CardNumber));
				sqlCommand.Parameters.Add(new SqlParameter("@CardHolder", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CardHolder));
				sqlCommand.Parameters.Add(new SqlParameter("@ExpiryMonth", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ExpiryMonth));
				sqlCommand.Parameters.Add(new SqlParameter("@ExpireYear", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ExpireYear));
				sqlCommand.Parameters.Add(new SqlParameter("@CCV", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CCV));
				sqlCommand.Parameters.Add(new SqlParameter("@RegisteredDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RegisteredDate));
				sqlCommand.Parameters.Add(new SqlParameter("@TripStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TripStatus));
				sqlCommand.Parameters.Add(new SqlParameter("@IsPayed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IsPayed));
				sqlCommand.Parameters.Add(new SqlParameter("@PayementDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PayementDate));
				sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TransactionID));
				sqlCommand.Parameters.Add(new SqlParameter("@Fees", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Fees));
				sqlCommand.Parameters.Add(new SqlParameter("@CancellationProtection", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CancellationProtection));
				sqlCommand.Parameters.Add(new SqlParameter("@BookingReference", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BookingReference));

								
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
        public bool Update(Trips businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Trips_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@Transfer", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Transfer));
				sqlCommand.Parameters.Add(new SqlParameter("@Car", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Car));
				sqlCommand.Parameters.Add(new SqlParameter("@ContactName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ContactName));
				sqlCommand.Parameters.Add(new SqlParameter("@ContactSurname", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ContactSurname));
				sqlCommand.Parameters.Add(new SqlParameter("@SaveQuota", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SaveQuota));
				sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EmailAddress));
				sqlCommand.Parameters.Add(new SqlParameter("@LeadPassengerMobile", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LeadPassengerMobile));
				sqlCommand.Parameters.Add(new SqlParameter("@SMS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SMS));
				sqlCommand.Parameters.Add(new SqlParameter("@FromAirline", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromAirline));
				sqlCommand.Parameters.Add(new SqlParameter("@FromFlightNumber", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromFlightNumber));
				sqlCommand.Parameters.Add(new SqlParameter("@FromOriginatingAirport", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromOriginatingAirport));
				sqlCommand.Parameters.Add(new SqlParameter("@FromFlightArrivalTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FromFlightArrivalTime));
				sqlCommand.Parameters.Add(new SqlParameter("@ToDropOfPoint", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ToDropOfPoint));
				sqlCommand.Parameters.Add(new SqlParameter("@CustomerFirstName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CustomerFirstName));
				sqlCommand.Parameters.Add(new SqlParameter("@CustomerLastName", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CustomerLastName));
				sqlCommand.Parameters.Add(new SqlParameter("@CustomerPhone", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CustomerPhone));
				sqlCommand.Parameters.Add(new SqlParameter("@IsAccepted", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IsAccepted));
				sqlCommand.Parameters.Add(new SqlParameter("@Subscribed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Subscribed));
				sqlCommand.Parameters.Add(new SqlParameter("@CardNumber", SqlDbType.NVarChar, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CardNumber));
				sqlCommand.Parameters.Add(new SqlParameter("@CardHolder", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CardHolder));
				sqlCommand.Parameters.Add(new SqlParameter("@ExpiryMonth", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ExpiryMonth));
				sqlCommand.Parameters.Add(new SqlParameter("@ExpireYear", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ExpireYear));
				sqlCommand.Parameters.Add(new SqlParameter("@CCV", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CCV));
				sqlCommand.Parameters.Add(new SqlParameter("@RegisteredDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RegisteredDate));
				sqlCommand.Parameters.Add(new SqlParameter("@TripStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TripStatus));
				sqlCommand.Parameters.Add(new SqlParameter("@IsPayed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IsPayed));
				sqlCommand.Parameters.Add(new SqlParameter("@PayementDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PayementDate));
				sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TransactionID));
				sqlCommand.Parameters.Add(new SqlParameter("@Fees", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Fees));
				sqlCommand.Parameters.Add(new SqlParameter("@CancellationProtection", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CancellationProtection));
				sqlCommand.Parameters.Add(new SqlParameter("@BookingReference", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BookingReference));


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
        /// <returns>Trips business object</returns>
        public Trips SelectByID(Trips businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Trips_SelectByID]";
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
        /// <returns>list of Trips</returns>
        public List<Trips> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Trips_SelectAll]";
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

		public List<Trips> SelectByReferenceAndEmail(Trips businessObject)
		{
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Trips_SelectByReferenceAndEmail]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
				sqlCommand.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BookingReference));
				sqlCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EmailAddress));


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

		public List<Trips> SelectByCompanyId(Trips businessObject)
		{
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[Trips_SelectByCompanyId]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
				sqlCommand.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyId));

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
		/// Delete by primary key
		/// </summary>
		/// <param name="keys">primary keys</param>
		/// <returns>true for successfully deleted</returns>
		public bool Delete(Trips businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Trips_Delete]";
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
        internal void PopulateBusinessObjectFromReader(Trips businessObject, IDataReader dataReader)
        {


			businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(Trips.TripsFields.RowNumber.ToString()));

				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.ID.ToString()));

				businessObject.Transfer = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.Transfer.ToString()));

				businessObject.Car = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.Car.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.ContactName.ToString())))
				{
					businessObject.ContactName = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.ContactName.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.ContactSurname.ToString())))
				{
					businessObject.ContactSurname = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.ContactSurname.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.SaveQuota.ToString())))
				{
					businessObject.SaveQuota = dataReader.GetBoolean(dataReader.GetOrdinal(Trips.TripsFields.SaveQuota.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.EmailAddress.ToString())))
				{
					businessObject.EmailAddress = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.EmailAddress.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.LeadPassengerMobile.ToString())))
				{
					businessObject.LeadPassengerMobile = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.LeadPassengerMobile.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.SMS.ToString())))
				{
					businessObject.SMS = dataReader.GetBoolean(dataReader.GetOrdinal(Trips.TripsFields.SMS.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.FromAirline.ToString())))
				{
					businessObject.FromAirline = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.FromAirline.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.FromFlightNumber.ToString())))
				{
					businessObject.FromFlightNumber = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.FromFlightNumber.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.FromOriginatingAirport.ToString())))
				{
					businessObject.FromOriginatingAirport = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.FromOriginatingAirport.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.FromFlightArrivalTime.ToString())))
				{
					businessObject.FromFlightArrivalTime = dataReader.GetDateTime(dataReader.GetOrdinal(Trips.TripsFields.FromFlightArrivalTime.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.ToDropOfPoint.ToString())))
				{
					businessObject.ToDropOfPoint = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.ToDropOfPoint.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.CustomerFirstName.ToString())))
				{
					businessObject.CustomerFirstName = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.CustomerFirstName.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.CustomerLastName.ToString())))
				{
					businessObject.CustomerLastName = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.CustomerLastName.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.CustomerPhone.ToString())))
				{
					businessObject.CustomerPhone = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.CustomerPhone.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.IsAccepted.ToString())))
				{
					businessObject.IsAccepted = dataReader.GetBoolean(dataReader.GetOrdinal(Trips.TripsFields.IsAccepted.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.Subscribed.ToString())))
				{
					businessObject.Subscribed = dataReader.GetBoolean(dataReader.GetOrdinal(Trips.TripsFields.Subscribed.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.CardNumber.ToString())))
				{
					businessObject.CardNumber = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.CardNumber.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.CardHolder.ToString())))
				{
					businessObject.CardHolder = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.CardHolder.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.ExpiryMonth.ToString())))
				{
					businessObject.ExpiryMonth = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.ExpiryMonth.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.ExpireYear.ToString())))
				{
					businessObject.ExpireYear = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.ExpireYear.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.CCV.ToString())))
				{
					businessObject.CCV = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.CCV.ToString()));
				}

				businessObject.RegisteredDate = dataReader.GetDateTime(dataReader.GetOrdinal(Trips.TripsFields.RegisteredDate.ToString()));

				businessObject.TripStatus = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.TripStatus.ToString()));

				businessObject.IsPayed = dataReader.GetBoolean(dataReader.GetOrdinal(Trips.TripsFields.IsPayed.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.PayementDate.ToString())))
				{
					businessObject.PayementDate = dataReader.GetDateTime(dataReader.GetOrdinal(Trips.TripsFields.PayementDate.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.TransactionID.ToString())))
				{
					businessObject.TransactionID = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.TransactionID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.Fees.ToString())))
				{
					businessObject.Fees = dataReader.GetDecimal(dataReader.GetOrdinal(Trips.TripsFields.Fees.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(Trips.TripsFields.CancellationProtection.ToString())))
				{
					businessObject.CancellationProtection = dataReader.GetDecimal(dataReader.GetOrdinal(Trips.TripsFields.CancellationProtection.ToString()));
				}

				businessObject.LocationFrom = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.LocationFrom.ToString()));
				businessObject.LocationTo = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.LocationTo.ToString()));
				businessObject.TripStatusTitle = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.TripStatusTitle.ToString()));
				businessObject.LocationFromId = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.LocationFromId.ToString()));
				businessObject.LocationToId = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.LocationToId.ToString()));
				businessObject.CarName = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.CarName.ToString()));
				businessObject.CompanyId = dataReader.GetInt32(dataReader.GetOrdinal(Trips.TripsFields.CompanyId.ToString()));
				businessObject.BookingReference = dataReader.GetString(dataReader.GetOrdinal(Trips.TripsFields.BookingReference.ToString()));
		}

		/// <summary>
		/// Populate business objects from the data reader
		/// </summary>
		/// <param name="dataReader">data reader</param>
		/// <returns>list of Trips</returns>
		internal List<Trips> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<Trips> list = new List<Trips>();

            while (dataReader.Read())
            {
                Trips businessObject = new Trips();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
