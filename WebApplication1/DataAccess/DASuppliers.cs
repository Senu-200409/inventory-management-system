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
    public class DASuppliers : ISuppliers
    {
        public Response AddSuppliersDetails(SuppliersModel addSuppliers)
        {
            Response res = new Response();
            try
            {
                string Query = "INSERT INTO supplier " +
                                            "(SupplierId, " +
                                            "SupplierName, " +
                                            "ContactPerson, " +
                                            "Phone, " +
                                            "Email, " +
                                            "Address) " +
                               "VALUES('" + addSuppliers.S_SupplierID + "', " +
                                      "'" + addSuppliers.S_SupplierName + "', " +
                                      "'" + addSuppliers.S_ContactPerson + "'," +
                                      "'" + addSuppliers.S_Phone + "'," +
                                      "'" + addSuppliers.S_Email + "'," +
                                      "'" + addSuppliers.S_Address + "')";

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

        public object GetAllSuppliers(SuppliersModel addSuppliers)
        {
            throw new NotImplementedException();
        }

        public Response GetAllSuppliers()
        {
            Response res = new Response();
            List<SuppliersModel> SuppliersList = new List<SuppliersModel>();

            string Query = "SELECT " +
                                   "SupplierId, " +
                                   "SupplierName, " +
                                   "ContactPerson, " +
                                   "Phone, " +
                                   "Email, " +
                                   "Address " +
                           "FROM " +
                                  "Suppliers";

            //string Query = "SELECT * FROM Suppliers";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {
                        SuppliersModel supplier = new SuppliersModel();

                        supplier.S_SupplierID = reader["SupplierId"].ToString();
                        supplier.S_SupplierName = reader["SupplierName"].ToString();
                        supplier.S_ContactPerson = reader["ContactPerson"].ToString();
                        supplier.S_Phone = reader["Phone"].ToString();
                        supplier.S_Email = reader["Email"].ToString();
                        supplier.S_Address = reader["Address"].ToString();
                      
                        SuppliersList.Add(supplier);
                    }
                }
            }

            res.StatusCode = 200;
            res.ResultSet = SuppliersList;
            return res;

        }

        public Response GetSuppliersBySupplierId(string supplierId)
        {
            throw new NotImplementedException();
        }
    }
}