using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.Data.SqlClient;

namespace HelloWorldWeb.Utilities
{
    public class DBSQL
    {
        public static System.Data.SqlClient.SqlConnection DBConnection()
        {

            System.Data.SqlClient.SqlConnection conn = null;
            string myConnectionString;
            myConnectionString = "Data Source=dtdogs.database.windows.net;Initial Catalog=dogswithcuddle;User ID=dtadm;Password=Tintin01!;";
            //sql = "Your SQL Statement Here , like Select * from product";
            // myConnectionString = "server=127.0.0.1;uid=root;" + "pwd=awadhbihari; database=movies;";

            myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            try
            {
                conn = new System.Data.SqlClient.SqlConnection(myConnectionString);
               
                conn.Open();


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                LogUitlity.Writelog(ex.Message);
            }
            return conn;
        }
    }
}
