using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HelloWorldWeb.Utilities
{
    public class DBUtility
    {

        public static MySqlConnection DBConnection() {

            MySql.Data.MySqlClient.MySqlConnection conn =null;
            string myConnectionString;

            // myConnectionString = "server=127.0.0.1;uid=root;" + "pwd=awadhbihari; database=movies;";

            myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
               // LogUitlity.Writelog(ex.Message);
            }
            return conn;
        }
    }
}