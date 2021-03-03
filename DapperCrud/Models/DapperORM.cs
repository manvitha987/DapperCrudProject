using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DapperCrud.Models
{
    public static class DapperORM
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["employcon"].ConnectionString;
        
        //private static string connectionString = @"Data Source=DESKTOP-R6EOG0D;Initial Catalog=MVCDapperDB;Integrated Security=true";
        public static void ExecuteWithoutReturn(string procedureName,DynamicParameters param=null)//for not returning anyvalue.
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
                }

            }
            catch (SqlException ex)
            {

                throw;
            }
            catch (Exception ex){

                throw;
            
            }
           
        }
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param=null)//for returning Scalar values i.e.,integer values
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return (T) Convert.ChangeType(con.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure),typeof(T));
            }
        }

        public static IEnumerable<T> ReturList<T>(string procedureName, DynamicParameters param=null)//for returning all values 
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(procedureName, param, commandType:CommandType.StoredProcedure);
            }
        }
    }
}