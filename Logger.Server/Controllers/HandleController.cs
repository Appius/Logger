using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logger.Core.Models;
using Logger.Core.Models.Tables;

namespace Logger.Server.Controllers
{
    public class HandleController : BaseController
    {
        // GET api/handle
        public Error Get([FromBody] ErrorRequest data)
        {
            switch (data.ErrorTypeRequest)
            {
                case ErrorTypeRequest.Next:
                    return ErrorRepository.GetNext(data.ApiKey ?? string.Empty, data.Id);
                case ErrorTypeRequest.Previous:
                    return ErrorRepository.GetPrev(data.ApiKey ?? string.Empty, data.Id);
                default:
                    return ErrorRepository.Get(data.ApiKey ?? string.Empty, data.Id);
            }
        }

        // POST api/handle
        public IEnumerable<Error> Post([FromBody] ErrorsRequest data)
        {
            return ErrorRepository.GetAll(data.ApiKey, data.OrderByDescending).Skip(data.Skip).Take(data.Take);
        }

        // PUT api/handle
        public HttpResponseMessage Put([FromBody] ErrorModel errorData)
        {   
            try
            {
                var model = new Error
                {
                    ApiKey = errorData.Key,
                    Browser = BrowserRepository.Merge(errorData.Browser),
                    OS = OsRepository.Merge(errorData.Os),
                    Data = errorData.Data,
                    DateTime = DateTime.Now,
                    HelpLink = errorData.HelpLink,
                    HResult = errorData.HResult,
                    Message = errorData.Message,
                    Name = errorData.Name,
                    Postdata = errorData.Postdata,
                    Referrer = errorData.Referrer,
                    Source = errorData.Source,
                    StackTrace = errorData.Stacktrace,
                    TargetSite = errorData.Targetsite,
                    Useragent = errorData.Useragent
                };

                ErrorRepository.Add(model);
            }
            catch (Exception ex)
            {
                // TODO: log
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message);

                return response;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/handle
        public HttpResponseMessage Delete(string apikey, int id)
        {
            try
            {
                ErrorRepository.Delete(apikey, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
