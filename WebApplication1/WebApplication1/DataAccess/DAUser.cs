using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Database_Layer;

namespace WebApplication1.DataAccess
{
    public class DAUser : IUser
    {
        public Response GetbyUserID(string id)
        {
            Response res = new Response();
            List<UserModel> userList = new List<UserModel>();

            string Query = @"SELECT userId,
                                    name,
                                    role,
                                    password,
                                    amount,
                                    phoneNo,
                                    date
                             FROM [USER]
                             where userId = '"+ id + "'";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {

                        UserModel user = new UserModel();


                        user.UserId = reader["userId"].ToString();
                        user.UserName = reader["name"].ToString();
                        user.Role = reader["role"].ToString();
                        user.Password = reader["password"].ToString();
                        user.Amount = reader["amount"].ToString();
                        user.PhoneNo = reader["phoneNo"].ToString();
                        user.Date = reader["date"].ToString();

                        userList.Add(user);
                    }
                }
            }
            res.StatusCode = 200;
            res.ResultSet = userList;
            return res;
        }

        public Response User()
        {
            Response res = new Response();
            List<UserModel> userList = new List<UserModel>();

            string Query = @"SELECT userId,
                                    name,
                                    role,
                                    password,
                                    amount,
                                    phoneNo,
                                    date
                             FROM [USER]";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {

                        UserModel user = new UserModel();


                        user.UserId = reader["userId"].ToString();
                        user.UserName = reader["name"].ToString();
                        user.Role = reader["role"].ToString();
                        user.Password = reader["password"].ToString();
                        user.Amount = reader["amount"].ToString();
                        user.PhoneNo = reader["phoneNo"].ToString();
                        user.Date = reader["date"].ToString();

                        userList.Add(user);
                    }
                }
            }
            res.StatusCode = 200;
            res.ResultSet = userList;
            return res;
        }
    }
}