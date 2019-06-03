using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Background.API.Filter
{
    public class ActionValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if ((actionContext.Request.Method == HttpMethod.Post || actionContext.Request.Method == HttpMethod.Put) && actionContext.ModelState.IsValid == false)
            {
                var errors = (new { Code = HttpStatusCode.BadRequest, Errors = actionContext.ModelState.Where(x => x.Value.Errors.Any()).Select(x => new { Name = x.Key, Error = x.Value.Errors.Last().ErrorMessage }) });
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}