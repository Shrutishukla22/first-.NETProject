using HelloWorldWeb.CoreObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace HelloWorldWeb.Models
{
    public class DogInfo
    {
        public List<Dog> getDog()
        {
            string appid = "Change this to your APPID from openweathermap.org";
            List<Dog> dogs = new List<Dog>();
            // string url = "http://api.petfinder.com/pet.get?id=36419919&&format=xml&key=688cf0271f4f3125175bf1d9a9f8973f";
            string url = "http://api.petfinder.com/pet.find?format=xml&key=688cf0271f4f3125175bf1d9a9f8973f&location=48326&animal=dog&output=basic";
            //synchronous client.
            var client = new System.Net.WebClient();
            var content = client.DownloadString(url);
            XmlDocument doc = new XmlDocument();
            //ystem.IO.Stream(content);
            //byte[] arrayOfMyString = Encoding.UTF8.GetBytes(content.ToString());
            doc.LoadXml(content.ToString());
            /* XmlNodeList nl = doc.GetElementsByTagName("id");//<text is what we are getting, we could get images, or whatever
               XmlNodeList n2 = doc.GetElementsByTagName("name");
               XmlNodeList n3 = doc.GetElementsByTagName("breed");
               XmlNodeList n4 = doc.GetElementsByTagName("sex");
               XmlNodeList n5 = doc.GetElementsByTagName("age");
               XmlNodeList n6 = doc.GetElementsByTagName("size");
               XmlNodeList n7 = doc.GetElementsByTagName("option");
               XmlNodeList n8 = doc.GetElementsByTagName("photo");
               XmlNodeList n9 = doc.GetElementsByTagName("description");
               XmlNodeList n10 = doc.GetElementsByTagName("shelterId"); */
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/petfinder/pets/pet");

            foreach (XmlNode node in nodes)
            {
                Dog dog = new Dog();

                dog.id = node.SelectSingleNode("id").InnerText;
                dog.name = node.SelectSingleNode("name").InnerText;
                dog.sex = node.SelectSingleNode("sex").InnerText;
                dog.size = node.SelectSingleNode("size").InnerText;
                XmlDocument doc1 = new XmlDocument();
                String s = node.SelectSingleNode("breeds").InnerXml;

                /*
                doc1.Load(s);
                XmlNodeList breednodes = doc.DocumentElement.SelectNodes("/breed");
                foreach (XmlNode node1 in breednodes)
                {
                    dog.breed = node1.SelectSingleNode("breed").InnerText;
                }
                */
                try
                {
                    XmlDocument doc2 = new XmlDocument();
                    String s2 = node.SelectSingleNode("media").InnerXml;
                    int j = s2.IndexOf(":");
                    // int z = s2.Length;
                    String s3 = s2.Substring(j, s2.Length - j);
                    int k = s3.IndexOf("<");

                    String s4 = s3.Substring(0, k);
                    String photo = "http" + s4;
                    dog.photo = photo;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                }

                //XmlNodeList photonodes = doc.DocumentElement.SelectNodes("/media/photos/photo");
                dogs.Add(dog);

            }
            foreach (Dog dog in dogs)
            {
                //LogUitlity.Writelog(" dog id is " + dog.id);
               // LogUitlity.Writelog(" dog breed is " + dog.breed);
               // LogUitlity.Writelog(" dog  isphoto " + dog.photo);
            }
            return dogs;
        }


        public Dog getDogDetail(String id)
        {

            Dog dog = new Dog();

            string url = "http://api.petfinder.com//pet.get?id=" + id + "&&format=xml&key=688cf0271f4f3125175bf1d9a9f8973f";
            //synchronous client.
            var client = new System.Net.WebClient();
            var content = client.DownloadString(url);
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(content.ToString());

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/petfinder/pet");

            foreach (XmlNode node in nodes)
            {


                dog.id = node.SelectSingleNode("id").InnerText;
                dog.name = node.SelectSingleNode("name").InnerText;
                dog.sex = node.SelectSingleNode("sex").InnerText;
                dog.size = node.SelectSingleNode("size").InnerText;
                dog.shelterID = node.SelectSingleNode("shelterId").InnerText;
                dog.desc = node.SelectSingleNode("description").InnerText;
                try
                {
                    XmlDocument doc1 = new XmlDocument();
                    String s = node.SelectSingleNode("breeds").InnerXml;
                    int start = s.IndexOf(">");
                    String sd = s.Substring(start, s.Length - start);
                    start = sd.IndexOf("<");
                    String breed = sd.Substring(1, start - 1);

                    dog.breed = breed;
                    XmlDocument doc2 = new XmlDocument();
                    String s2 = node.SelectSingleNode("media").InnerXml;
                    int j = s2.IndexOf(":");
                    // int z = s2.Length;
                    String s3 = s2.Substring(j, s2.Length - j);
                    int k = s3.IndexOf("<");

                    String s4 = s3.Substring(0, k);
                    String photo = "http" + s4;
                    dog.photo = photo;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                }

                //XmlNodeList photonodes = doc.DocumentElement.SelectNodes("/media/photos/photo");


            }

            return dog;
        }


        
 public List<Dog> getDogsbyBreed(String breed)
        {
            
            List<Dog> dogs = new List<Dog>();
            // string url = "http://api.petfinder.com/pet.get?id=36419919&&format=xml&key=688cf0271f4f3125175bf1d9a9f8973f";
            string url = "http://api.petfinder.com/pet.find?format=xml&key=688cf0271f4f3125175bf1d9a9f8973f&location=48326&animal=dog&breed="+breed +"&output=basic";
            //synchronous client.
            var client = new System.Net.WebClient();
            var content = client.DownloadString(url);
            XmlDocument doc = new XmlDocument();
         
            doc.LoadXml(content.ToString());
              XmlNodeList nodes = doc.DocumentElement.SelectNodes("/petfinder/pets/pet");

            foreach (XmlNode node in nodes)
            {
                Dog dog = new Dog();

                dog.id = node.SelectSingleNode("id").InnerText;
                dog.name = node.SelectSingleNode("name").InnerText;
                dog.sex = node.SelectSingleNode("sex").InnerText;
                dog.size = node.SelectSingleNode("size").InnerText;
                XmlDocument doc1 = new XmlDocument();
                String s = node.SelectSingleNode("breeds").InnerXml;

                /*
                doc1.Load(s);
                XmlNodeList breednodes = doc.DocumentElement.SelectNodes("/breed");
                foreach (XmlNode node1 in breednodes)
                {
                    dog.breed = node1.SelectSingleNode("breed").InnerText;
                }
                */
                try
                {
                    XmlDocument doc2 = new XmlDocument();
                    String s2 = node.SelectSingleNode("media").InnerXml;
                    int j = s2.IndexOf(":");
                    // int z = s2.Length;
                    String s3 = s2.Substring(j, s2.Length - j);
                    int k = s3.IndexOf("<");

                    String s4 = s3.Substring(0, k);
                    String photo = "http" + s4;
                    dog.photo = photo;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                }

                //XmlNodeList photonodes = doc.DocumentElement.SelectNodes("/media/photos/photo");
                dogs.Add(dog);

            }
            foreach (Dog dog in dogs)
            {
                //LogUitlity.Writelog(" dog id is " + dog.id);
                //LogUitlity.Writelog(" dog breed is " + dog.breed);
               // LogUitlity.Writelog(" dog  isphoto " + dog.photo);
            }
            return dogs;
        }
    }
}