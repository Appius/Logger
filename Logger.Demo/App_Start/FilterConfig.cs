using System;
using System.Web.Mvc;
using Logger.Client;

namespace Logger.Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggerFilter());
        }
    }
}