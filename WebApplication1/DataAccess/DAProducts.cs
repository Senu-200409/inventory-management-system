using biZTrack.Static;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Unity.Policy;
using WebApplication1.Controllers;
using WebApplication1.Database_Layer;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class DAProducts : IProducts
    {
        public Response AddProductsDetails(ProductsModel addProducts)
        {
            Response res = new Response();
            try
            {
                string Query = "INSERT INTO product " +
                                            "(ProductId, " +
                                            "ProductName, " +
                                            "CategoryId, " +
                                            "UnitId, " +
                                            "UnitPrice, " +
                                            "ReorderLevel, " +
                                            "ProductImage) " +
                               "VALUES('" + addProducts.P_ProductID + "', " +
                                      "'" + addProducts.P_ProductName + "', " +
                                      "'" + addProducts.P_CategoryID + "'," +
                                      "'" + addProducts.P_UnitID + "'," +
                                      "'" + addProducts.P_UnitPrice + "', " +
                                      "'" + addProducts.P_ReorderLevel + "'," +
                                      "'" + addProducts.P_ProductImage + "')";


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

        public object GetAllProducts(ProductsModel addProducts)
        {
            throw new NotImplementedException();
        }

        public Response GetAllProducts()
        {
            Response res = new Response();
            List<ProductsModel> ProductsList = new List<ProductsModel>();

            string Query = "SELECT " +
                                   "ProductId, " +
                                   "ProductName, " +
                                   "CategoryId, " +
                                   "UnitId, " +
                                   "UnitPrice, " +
                                   "ReorderLevel, " +
                                   "ProductImage " +
                           "FROM " +
                                  "Products";

            //string Query = "SELECT * FROM Products";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {
                        ProductsModel Product = new ProductsModel();

                        Product.P_ProductID = reader["ProductId"].ToString();
                        Product.P_ProductName = reader["ProductName"].ToString();
                        Product.P_CategoryID = reader["CategoryId"].ToString();
                        Product.P_UnitID = reader["UnitId"].ToString();
                        Product.P_UnitPrice = reader["UnitPrice"].ToString();
                        Product.P_ReorderLevel = reader["ReorderLevel"].ToString();
                        Product.P_ProductImage = reader["ProductImage"].ToString();

                        ProductsList.Add(Product);
                    }
                }
            }

            res.StatusCode = 200;
            res.ResultSet = ProductsList;
            return res;

        }

        public Response GetProductsByProductId(string productId)
        {
            throw new NotImplementedException();
        }
    }
}