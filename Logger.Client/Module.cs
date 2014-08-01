using System;
using System.Web;

namespace Logger.Client
{
    public sealed class HandleExceptionModule : IHttpModule
    {
        void IHttpModule.Init(HttpApplication application)
        {
            application.Error += ApplicationOnError;
        }

        public void Dispose()
        {
        }

        private static void ApplicationOnError(object sender, EventArgs eventArgs)
        {
            HttpContext current = HttpContext.Current;
            if (current == null)
                return;

            LoggerClient.SendError(HttpContext.Current.Server.GetLastError());
        }
    }
}