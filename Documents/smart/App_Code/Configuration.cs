using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

public class Configuration
{
    public static string Datetime()
    {
        string time = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

        return time;
    }

    public static string IPAddress()
    {
        HttpRequest request = HttpContext.Current.Request;
        string ipAdd = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (ipAdd == null || ipAdd.ToLower() == "unknown")
        {
            ipAdd = request.ServerVariables["REMOTE_ADDR"];
        }

        return ipAdd;
    }

    public static string SMTPHost
    {
        get { return ConfigurationManager.AppSettings["SMTPHost"].ToString(); }
    }

    public static int SMTPPort
    {
        get { return Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"].ToString()); }
    }

    public static string SMTPEmail
    {
        get { return ConfigurationManager.AppSettings["SMTPFromEmail"].ToString(); }
    }

    public static string SMTPName
    {
        get { return ConfigurationManager.AppSettings["SMTPFromName"].ToString(); }
    }

    public static string EmailUserName
    {
        get { return ConfigurationManager.AppSettings["SMTPUserName"].ToString(); }
    }

    public static string EmailPassword
    {
        get { return ConfigurationManager.AppSettings["SMTPPassword"].ToString(); }
    }
}