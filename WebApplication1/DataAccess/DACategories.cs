using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Database_Layer;
using biZTrack.Static;

namespace WebApplication1.DataAccess
{
    public class DACategories : ICategories
    {
        public Response AddCategoriesDetails(Categories addCategories)
        {
            Response res = new Response();
            try
            {
                string Query = "INSERT INTO categories " +
                                            "(CategoryId, " +
                                            "CategoryName) " +
                               "VALUES('" + addCategories.C_CategoryId + "', " +
                                      "'" + addCategories.C_CategoryName + "')";


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


        public Response GetAllCategories()
        {
            Response res = new Response();
            List<Categories> CategoriesList = new List<Categories>();

            string Query = "SELECT " +
                                  "CategoryId," +
                                  "CategoryName " +
                            "FROM " +
                                  "categories";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {
                        Categories category = new Categories();

                        category.C_CategoryID = reader["CategoryId"].ToString();
                        category.C_CategoryName = reader["CategoryName"].ToString();


                        CategoriesList.Add(category);
                    }
                }
            }

            res.StatusCode = 200;
            res.ResultSet = CategoriesList;
            return res;

        }

        public Response GetCategoriesByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }
    }

    //internal class Response
    //{
    //    internal string Result;

    //    public Response()
    //    {
    //    }

    //    public int StatusCode { get; internal set; }
    //    public List<GetCategoriesModel> ResultSet { get; internal set; }
    //}
}

//public Response AddCategoriesDetails(Categories addCategories)
//{
//    Response res = new Response();
//    try
//    {
//        //string Query = "INSERT INTO categories" +
//        // "(CategoryId,"+
//        //"CategoryName)" +
//        // "VALUES("" + addCategories.C_CategoryId + "," +
//        // "" + addCategories.C_CategoryName + ")";

//        string query = "INSERT INTO categories (CategoryId, CategoryName) " +
//                  "VALUES ('{addCategories.C_CategoryId}', '{addCategories.C_CategoryName}')";


//        using (var dbConnect = new DBconnect())
//        {
//            if (dbConnect.AddEditDel(Query))
//            {
//                res.StatusCode = 200;
//                res.Result = "Success!!";
//            }
//            else
//            {
//                res.StatusCode = 400;
//                res.Result = "Insert failed.";
//            }
//        }
//    }

//    catch (Exception ex)
//    {
//        // LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
//        res.StatusCode = 500;
//        res.Result = "Failed!!";
//    }
//    return res;
//}

//public Response GetAllCategories()
//{
//    Response res = new Response();
//    List<GetCategoriesModel> CategoriesList = new List<GetCategoriesModel>();

//    string Query = "SELECT" +
//                 "CategoryId," +
//                 "CategoryName" +
//              "FROM" +
//                 "categories";

//    using (var DBconnect = new DBconnect())
//    {
//        using (SqlDataReader reader = DBconnect.ReadTable(Query))
//        {
//            while (reader.Read())
//            {
//                GetCategoriesModel Category = new GetCategoriesModel();

//                C_CategoryId = reader["CategoryId"].ToString();
//                C_CategoryName = reader["CategoryName"].ToString();
//            };


//                CategoriesList.Add(Category);
//            }
//        }

//    res.StatusCode = 200;
//    res.ResultSet = CategoriesList;
//    return res;
//}
//public Response GetCategoriesByCategoryId(string CategoryId)
//{
//    Response res = new Response();
//    List<GetCategoriesModel> VehicleList = new List<GetCategoriesModel>();
//    string Query = "SELECT " +
//                        "CategoryId, " +
//                        "CategoryName " +
//                    "FROM " +
//                        "Categories " +
//                    "WHERE " +
//                        "CategoryId = '" + CategoryId + "'";
//    using (var DBconnect = new DBconnect())
//    {
//        using (SqlDataReader reader = DBconnect.ReadTable(Query))
//        {
//            while (reader.Read())
//            {
//                GetCategoriesModel Category = new GetCategoriesModel();
//                {
//                    C_CategoryId = reader["CategoryId"].ToString();
//                    C_CategoryName = reader["CategoriesName"].ToString();
//                };
//                CategoriesList.Add(Category);
//            }
//        }
//    }
//    res.StatusCode = 200;
//    res.ResultSet = CategoriesList;
//    return res;
//}
//public Response GetCategoriesByCategoryId(string CategoryId)
//{
//    Response res = new Response();
//    List<GetCategoriesModel> CategoriesList = new List<GetCategoriesModel>();
//    string Query = "SELECT " +
//                        "CategoryId, " +
//                        "CategoryName " +
//                    "FROM " +
//                        "categories " +
//                    "WHERE " +
//                        "CategoryId = '" + CategoryId + "'";
//    using (var DBconnect = new DBconnect())
//    {
//        using (SqlDataReader reader = DBconnect.ReadTable(Query))
//        {
//            while (reader.Read())
//            {
//                GetCategoriesModel Categories = new GetCategoriesModel();
//                Categories.C_Categories = reader["CategoryId"].ToString();
//                Categories.C_Categories = reader["CategoryName"].ToString();
//                CategoriesList.Add(Categories);
//            }
//        }
//    }
//    res.StatusCode = 200;
//    res.ResultSet = CategoriesList;
//    return res;
//}