using System;
using System.Configuration;

namespace Logger
{
    internal static class Settings
    {
        public static string ServerUrl
        {
            get { return ConfigurationManager.AppSettings["ServerUrl"]; }
        }
    }
}