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
    public class DAPurchaseOrders : IPurchaseOrders
    {
        public Response AddPurchaseOrdersDetails(PurchaseOrdersModel addPurchaseOrders)
        {
            Response res = new Response();
            try
            {
                string Query = "INSERT INTO purchaseorders " +
                                            "(PurchaseOrderId, " +
                                            "SupplierId, " +
                                            "OrderDate, " +
                                            "Status) " +
                               "VALUES('" + addPurchaseOrders.P_PurchaseOrderID + "', " +
                                      "'" + addPurchaseOrders.P_SupplierID + "', " +
                                      "'" + addPurchaseOrders.P_OrderDate + "'," +
                                      "'" + addPurchaseOrders.P_Status + "')";

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

        public object GetAllPurchaseOrders(PurchaseOrdersModel addPurchaseOrders)
        {
            throw new NotImplementedException();
        }

        public Response GetAllPurchaseOrders()
        {
            Response res = new Response();
            List<PurchaseOrdersModel> PurchaseOrdersList = new List<PurchaseOrdersModel>();

            string Query = "SELECT " +
                                   "PurchaseOrderId, " +
                                   "SupplierId, " +
                                   "OrderDate, " +
                                   "Status " +
                           "FROM " +
                                  "PurchaseOrders";

            //string Query = "SELECT * FROM PurchaseOrders";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {
                        PurchaseOrdersModel purchaseorders = new PurchaseOrdersModel();

                        purchaseorders.P_PurchaseOrderID = reader["PurchaseOrderId"].ToString();
                        purchaseorders.P_SupplierID = reader["SupplierId"].ToString();
                        purchaseorders.P_OrderDate = reader["OrderDate"].ToString();
                        purchaseorders.P_Status = reader["Status"].ToString();

                        PurchaseOrdersList.Add(purchaseorders);
                    }
                }
            }

            res.StatusCode = 200;
            res.ResultSet = PurchaseOrdersList;
            return res;

        }

        public Response GetPurchaseOrdersByPurchaseOrderId(string purchaseorderId)
        {
            throw new NotImplementedException();
        }
    }
}