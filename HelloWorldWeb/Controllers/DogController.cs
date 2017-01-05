using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HelloWorldWeb.CoreObject;
using Newtonsoft.Json;
using System.Web.Http.Results;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Controllers
{
    public class DogController : Controller
    {
        
        public ActionResult getDog()
                   
        {
            DogInfo doginfo = new DogInfo();
            return View("DogView", doginfo.getDog());
        }

       
    }
}

