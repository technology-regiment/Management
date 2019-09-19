using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Background.API.Installer;
using Background.Common;

namespace Background.API.Filter
{
    public class GlobalExceptionAttribute : ExceptionFilterAttribute
    {
    public override void OnException(HttpActionExecutedContext actionExecutedContext)
    {
        var exception = actionExecutedContext.Exception;
        if (exception is UnauthorizedException)
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.Unauthorized, exception.Message);
        }
        else if (exception is DomainException)
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
        }
        else
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorMessage.InternalServerError);
        }

        WindsorBootstrapper.Container.Resolve<ILogger>().Error(exception.Message, exception);

        base.OnException(actionExecutedContext);
    }
}
}