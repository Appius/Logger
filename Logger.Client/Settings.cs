using System;
using System.Configuration;

namespace Logger.Client
{
    internal static class Settings
    {
        public static string ServiceUrl
        {
            get { return ConfigurationManager.AppSettings["ServiceUrl"]; }
        }

        public static string ApiKey
        {
            get { return ConfigurationManager.AppSettings["Apikey"]; }
        }

        public static bool DisableInDebugMode
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["DisableInDebugMode"]); }
        }
    }
}