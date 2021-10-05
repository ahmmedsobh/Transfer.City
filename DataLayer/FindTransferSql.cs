using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transfer.City.Models;

namespace Transfer.City.DataLayer
{
     class FindTransferSql:DataLayerBase
    {
        public List<FindTransfer> SearchResult(FindTransfer businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[Booking_FindTransfer]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@LocationFrom", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LocationFrom));
                sqlCommand.Parameters.Add(new SqlParameter("@LocationTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LocationTo));
                sqlCommand.Parameters.Add(new SqlParameter("@PassngersCount", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PassngersCount));


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

        internal void PopulateBusinessObjectFromReader(FindTransfer businessObject, IDataReader dataReader)
        {


            businessObject.RowNumber = dataReader.GetInt64(dataReader.GetOrdinal(FindTransfer.FindTransferFields.RowNumber.ToString()));

            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(FindTransfer.FindTransferFields.ID.ToString()));

            businessObject.Name = dataReader.GetString(dataReader.GetOrdinal(FindTransfer.FindTransferFields.Name.ToString()));

            businessObject.Max_Passengers = dataReader.GetInt32(dataReader.GetOrdinal(FindTransfer.FindTransferFields.Max_Passengers.ToString()));

            businessObject.Max_Suitcases = dataReader.GetInt32(dataReader.GetOrdinal(FindTransfer.FindTransferFields.Max_Suitcases.ToString()));
            businessObject.Img = dataReader.GetString(dataReader.GetOrdinal(FindTransfer.FindTransferFields.Img.ToString()));
            businessObject.EstimatedTime = dataReader.GetInt32(dataReader.GetOrdinal(FindTransfer.FindTransferFields.EstimatedTime.ToString()));
            businessObject.SellingPrice = dataReader.GetDecimal(dataReader.GetOrdinal(FindTransfer.FindTransferFields.SellingPrice.ToString()));
            businessObject.LocationFrom = dataReader.GetInt32(dataReader.GetOrdinal(FindTransfer.FindTransferFields.LocationFrom.ToString()));
            businessObject.LocationTo = dataReader.GetInt32(dataReader.GetOrdinal(FindTransfer.FindTransferFields.LocationTo.ToString()));
            businessObject.PassngersCount = dataReader.GetInt32(dataReader.GetOrdinal(FindTransfer.FindTransferFields.PassngersCount.ToString()));


        }

        internal List<FindTransfer> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<FindTransfer> list = new List<FindTransfer>();

            while (dataReader.Read())
            {
                FindTransfer businessObject = new FindTransfer();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }
    }
}