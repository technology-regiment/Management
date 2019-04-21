using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Management.WebAPI
{
    public class ManagementExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, new
            {
                Code = HttpStatusCode.BadRequest,
                Error = actionExecutedContext.Exception.ToString(),
                actionExecutedContext.Exception.Message
            });
            base.OnException(actionExecutedContext);
        }
    }
}
