using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace HelloWorldWeb
{
    public class LogUitlity
    {
        public static void Writelog(String strLog)
        {

            System.Configuration.AppSettingsReader objAppSetting = new System.Configuration.AppSettingsReader();

            StreamWriter objStrWriter = new StreamWriter(objAppSetting.GetValue("logpath", typeof(string)).ToString(),true);
            objStrWriter.WriteLine(strLog);
            objStrWriter.Close();

        }

    }
}