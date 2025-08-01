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
    public class DAUnits : IUnits
    {
        public Response AddUnitsDetails(Units addUnits)
        {
            Response res = new Response();
            try
            {
                string Query = "INSERT INTO units " +
                                            "(UnitId, " +
                                            "UnitName) " +
                               "VALUES('" + addUnits.U_UnitId + "', " +
                                      "'" + addUnits.U_UnitName + "')";


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


        public Response GetAllUnits()
        {
            Response res = new Response();
            List<Units> UnitsList = new List<Units>();

            string Query = "SELECT " +
                                  "UnitId," +
                                  "UnitName " +
                            "FROM " +
                                  "Units";

            using (var DBconnect = new DBconnect())
            {
                using (SqlDataReader reader = DBconnect.ReadTable(Query))
                {
                    while (reader.Read())
                    {
                        Units unit = new Units();

                        unit.U_UnitID = reader["UnitId"].ToString();
                        unit.U_UnitName = reader["UnitName"].ToString();


                        UnitsList.Add(unit);
                    }
                }
            }

            res.StatusCode = 200;
            res.ResultSet = UnitsList;
            return res;

        }

        public Response GetUnitsByUnitId(string unitId)
        {
            throw new NotImplementedException();
        }
    }
}