using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorldWeb.Models;
using HelloWorldWeb.Utilities;
using HelloWorldWeb.CoreObject;
using MySql.Data.MySqlClient;


namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewData["color"] = "Red";
            return View();
        }


        public ActionResult dogsearch()

        {
            String id = Request.Params["id"];
            DogInfo doginfo = new DogInfo();
            Dog dog = doginfo.getDogDetail(id);
            return View("dogsearch", dog);
        }
        public ActionResult GotoHome()
        {

            return View();
        }
        public ActionResult login()
        {

            String id = Request.Form["userid"];
            String pwd = Request.Form["password"];
            User user = new User();

            user.firstname = "shruti";
            user.lastname = "shukla";
            user.userid = "abc@g";
            user.password = "abcd";
            HttpContext.Session["user"] = user;

            /*
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            //System.Data.SqlClient.SqlConnection conn;
            //start


            // String  myConnectionString = "server=us-cdbr-azure-southcentral-f.cloudapp.net;uid=b52aabffb6d29e;pwd=aafec641;database=acsm_fddaeb623f9fd67;";

            //String myConnectionString = "detroitdogsdbinstance.ce7pgizq4pbf.us - east - 2.rds.amazonaws.com:3306";
            String myConnectionString = "server=127.0.0.1;uid=root;pwd=awadhbihari;database=dogswithcuddle;";
           // string myConnectionString = "Server=tcp:dtdogs.database.windows.net,1433;Initial Catalog=dogswithcuddle;Persist Security Info=False;User ID=dtadm;Password=Tintin01!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                //conn = DBUtility.DBConnection();
                conn = new MySql.Data.MySqlClient.MySqlConnection();
               // System.Data.SqlClient.SqlConnection  conn = new SqlConnection(myConnectionString);
                conn.ConnectionString = myConnectionString;
               conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                LogUitlity.Writelog(ex.GetBaseException().ToString());
            }
            //string con = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            // string sql = "SELECT * FROM acsm_fddaeb623f9fd67.user where iduser ='" + id +"'";
            
           string sql = "SELECT * FROM dbo.UserInfo where email ='" + id + "'";
            //string sql = "SELECT * FROM dogswithcuddle.user where email ='" + id + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            //User user = null;
           
            if (rdr.Read())
            {
                if (pwd.Equals(rdr[3].ToString()))
                {
                    LogUitlity.Writelog(rdr[0].ToString());
                    
                    user.firstname = rdr[0].ToString();
                    user.lastname = rdr[1].ToString();
                    user.userid = rdr[2].ToString();
                    user.password = rdr[3].ToString();
                    HttpContext.Session["user"] = user;
            //return View("login", user);
            */
            DogInfo doginfo = new DogInfo();
            //return Json(doginfo.getDog(), JsonRequestBehavior.AllowGet);
            // return  RedirectToAction("getDog","DogController");
            // ViewData["dog"] = Json(doginfo.getDog(), JsonRequestBehavior.AllowGet);
            // ViewData["dog"] = Json(doginfo.getDog(), JsonRequestBehavior.AllowGet);
            // ViewData["dog"] = Json(doginfo.getDog(), JsonRequestBehavior.AllowGet);

            List<Dog> dogs = doginfo.getDog();
            foreach (Dog dog in dogs)
            {
               // LogUitlity.Writelog(" inside home controller dog id is " + dog.id);
                //LogUitlity.Writelog(" inside home controller dog name is " + dog.name);
                //LogUitlity.Writelog(" inside home controller dog  is " + dog.sex);
            }
            //ViewData["dog"] = dogs;
            return View("DogsView", dogs);
            /* 
                }

                 else
                 {
                     ViewData["message"] = "Incorrect Passord";
                     return View("GotoHome");
                 }


             }
             else
             {
                 //there is no user send it to register
                 ViewData["message"] = "User does not exist. Please click signup to register";
                 return View("GotoHome");
             }
             rdr.Close();
              return View("login", user);
 */


        }


        public ActionResult getdogbybreed()
        {
            String breed = Request.Params["breed"];
            DogInfo doginfo = new DogInfo();

            List<Dog> dogs = doginfo.getDogsbyBreed(breed);

            //ViewData["dog"] = dogs;
            return View("DogsView", dogs);
            //return View();
        }
    }
}