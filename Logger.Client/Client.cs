using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Logger.Client
{
    public static class LoggerClient
    {
        public static async Task SendError(Exception e, HttpContextBase httpContext = null)
        {
            if (e == null)
                return;

            if (httpContext == null)
                httpContext = new HttpContextWrapper(HttpContext.Current);

            if (Settings.DisableInDebugMode && httpContext.IsDebuggingEnabled)
                return;

            Uri uriResult;
            if (Uri.TryCreate(Settings.ServiceUrl, UriKind.Absolute, out uriResult) && uriResult.Scheme != Uri.UriSchemeHttp)
            {
                return;
            }

            HttpRequestBase request = httpContext.Request;
            string name = (e is HttpException)
                ? "HTTP Error " + ((HttpException)e).GetHttpCode()
                : e.GetType().ToString();
            string refer = request.UrlReferrer != null ? request.UrlReferrer.AbsoluteUri : "";
            string postdata = request.Form.Cast<string>().Aggregate("",
                (current, aname) =>
                    current + aname + " = " + request.Form[aname] +
                    " ; ");
            if (request.Url != null)
            {
                var data = new ErrorModel(Settings.ApiKey, name, request.Browser.Platform, request.Browser.Browser,
                    e.Message, e.HelpLink, e.Data.ToString(), e.HResult, e.Source, e.TargetSite.ToString(),
                    e.StackTrace, postdata, request.UserAgent, refer);

                await RunAsync(data);
            }
        }

        private static async Task RunAsync(ErrorModel errorModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.ServiceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsJsonAsync("api/handle", errorModel);
                if (response.IsSuccessStatusCode)
                {
                }
            }
        }
    }
}