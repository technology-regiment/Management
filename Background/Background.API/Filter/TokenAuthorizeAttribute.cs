using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Background.API.Controllers.API;
using Background.API.Installer;
using Background.Logic;

namespace Background.API.Filter
{
   
        public class TokenAuthorizeAttribute : ActionFilterAttribute
        {
            private const string TokenName = "X-AuthenticationToken";

            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                string token = null;

                if (actionContext.Request.Headers.Contains(TokenName))
                {
                    token = actionContext.Request.Headers.GetValues(TokenName).FirstOrDefault();
                }

                var controller = actionContext.ControllerContext.Controller as BaseApiController;
                Authorize(token, controller);

                base.OnActionExecuting(actionContext);
            }

            public static void Authorize(string token, BaseApiController controller)
            {
                var user = WindsorBootstrapper.Container.Resolve<ISystemUserLogic>().ValidateAuthenticationToken(token);

                if (controller == null)
                {
                    return;
                }

                controller.CurrentUser = user;
            }
        }
    
}