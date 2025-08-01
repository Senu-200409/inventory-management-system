using biZTrack.Static;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Database_Layer;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class DASalesOrders : ISalesOrders
    {
        public Response AddSalesOrdersDetails(SalesOrdersModel addSalesOrders)
        {
            Response res = new Response();
            try
            {
                string Query = "INSERT INTO salesorders " +
                                            "(SalesOrderId, " +
                                            "CustomerId, " +
                                            "OrderDate, " +
                                            "Status) " +
                               "VALUES('" + addSalesOrders.S_SalesOrderID + "', " +
                                      "'" + addSalesOrders.S_CustomerID + "', " +
                                      "'" + addSalesOrders.S_OrderDate + "'," +
                                      "'" + addSalesOrders.S_Status + "')";

                using (var dbConnect = new DBconnect())
                {
                    if (dbConnect.AddEditDel(Query))
                    {
                        res.StatusCode = 200;
                        res.Result = "Success!!";
                    }
                }
            }
            catch (Exception ex)
            {
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                res.StatusCode = 500;
                res.Result = "Failed!!";
            }
            return res;
        }

        public object GetAllSalesOrders(SalesOrdersModel addSalesOrders)
        {
            throw new NotImplementedException();
        }

        public Response GetAllSalesOrders()
        {
            Response res = new Response();
            List<SalesOrdersModel> SalesOrdersList = new List<SalesOrdersModel>();

            string Query = "SELECT " +
                                   "SalesOrderId, " +
                                   "CustomerId, " +
                                   "OrderDate, " +
                                   "Status " +
                           "FROM " +
                                  "SalesOrders";

            //string Query = "SELECT * FROM SalesOrders";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {
                        SalesOrdersModel salesorders = new SalesOrdersModel();

                        salesorders.S_SalesOrderID = reader["SalesOrderId"].ToString();
                        salesorders.S_CustomerID = reader["CustomerId"].ToString();
                        salesorders.S_OrderDate = reader["OrderDate"].ToString();
                        salesorders.S_Status = reader["Status"].ToString();

                        SalesOrdersList.Add(salesorders);
                    }
                }
            }

            res.StatusCode = 200;
            res.ResultSet = SalesOrdersList;
            return res;

        }

        public Response GetSalesOrdersBySalesOrderId(string SalesOrderId)
        {
            throw new NotImplementedException();
        }
    }
}