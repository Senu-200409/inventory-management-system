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
    public class DACustomers : ICustomers
    {
        public Response AddCustomersDetails(CustomersModel addCustomers)
        {
            Response res = new Response();
            try
            {
                string Query = "INSERT INTO customer " +
                                            "(CustomerId, " +
                                            "CustomerName, " +
                                            "Phone, " +
                                            "Email, " +
                                            "Address) " +
                               "VALUES('" + addCustomers.C_CustomerID + "', " +
                                      "'" + addCustomers.C_CustomerName + "', " +
                                      "'" + addCustomers.C_Phone + "'," +
                                      "'" + addCustomers.C_Email + "'," +
                                      "'" + addCustomers.C_Address + "')";

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

        public object GetAllCustomers(CustomersModel addCustomers)
        {
            throw new NotImplementedException();
        }

        public Response GetAllCustomers()
        {
            Response res = new Response();
            List<CustomersModel> CustomersList = new List<CustomersModel>();

            string Query = "SELECT " +
                                   "CustomerId, " +
                                   "CustomerName, " +
                                   "Phone, " +
                                   "Email, " +
                                   "Address " +
                           "FROM " +
                                  "Customers";

            //string Query = "SELECT * FROM Customers";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {
                        CustomersModel customers = new CustomersModel();

                        customers.C_CustomerID = reader["CustomerId"].ToString();
                        customers.C_CustomerName = reader["CustomerName"].ToString();
                        customers.C_Phone = reader["Phone"].ToString();
                        customers.C_Email = reader["Email"].ToString();
                        customers.C_Address = reader["Address"].ToString();

                        CustomersList.Add(customers);
                    }
                }
            }

            res.StatusCode = 200;
            res.ResultSet = CustomersList;
            return res;

        }

        public Response GetCustomersByCustomerId(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}