using System;
using System.Web.Mvc;

namespace Logger.Client
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class LoggerFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
                return;
            LoggerClient.SendError(filterContext.Exception);
        }
    }
}