using HelloWorldWeb.CoreObject;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldWeb.Controllers
{
    public class ShelterController : Controller
    {
        // GET: Shelter
        public ActionResult ShelterInfo()
        {

            String id = Request.Params["shelterid"];
            SheltorInfo sinfo = new SheltorInfo();

            Shelter s =sinfo.getShelterDetail(id);
            return View("ShelterInfo",s);
        }
    }
}