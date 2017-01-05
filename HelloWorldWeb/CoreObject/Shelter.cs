using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldWeb.CoreObject
{
    public class Shelter
    {
        
        public String id { get; set; }
        public String name { get; set; }
        public String address1 { get; set; }
        public String address2 { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zip { get; set; }
        public String country { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
    }
}