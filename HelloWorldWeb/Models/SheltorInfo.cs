using HelloWorldWeb.CoreObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace HelloWorldWeb.Models
{
    public class SheltorInfo
    {
        public Shelter getShelterDetail(String id)
        {

            Shelter sh = new Shelter();
            string url = "http://api.petfinder.com/shelter.get?id="+id+"&&format=xml&key=688cf0271f4f3125175bf1d9a9f8973f";
            //synchronous client.
            var client = new System.Net.WebClient();
            var content = client.DownloadString(url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content.ToString());
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/petfinder/shelter");
            foreach (XmlNode node in nodes)
            {
                sh.id = node.SelectSingleNode("id").InnerText;
                sh.name = node.SelectSingleNode("name").InnerText;
                sh.address1 = node.SelectSingleNode("address1").InnerText;
                sh.address2 = node.SelectSingleNode("address2").InnerText;
                sh.city = node.SelectSingleNode("city").InnerText;
                sh.zip = node.SelectSingleNode("zip").InnerText;
                sh.country = node.SelectSingleNode("country").InnerText;
                sh.phone = node.SelectSingleNode("phone").InnerText;
                // sh.city = node.SelectSingleNode("city").InnerText;
            }
            return sh;
        }
    }
}