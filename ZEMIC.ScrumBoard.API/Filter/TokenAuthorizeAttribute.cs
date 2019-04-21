using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ZEMIC.Common;
using ZEMIC.Common.CodeSection;
using ZEMIC.ScrumBoard.API.Controllers.API;
using ZEMIC.ScrumBoard.API.Installer;
using ZEMIC.ScrumBoard.Logic;

namespace ZEMIC.ScrumBoard.API.Filter
{
    public class TokenAuthorizeAttribute : ActionFilterAttribute
    {
        private const string TokenName = "X-AuthenticationToken";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                string token = null;

                if (actionContext.Request.Headers.Contains(TokenName))
                {
                    token = actionContext.Request.Headers.GetValues(TokenName).FirstOrDefault();
                }

                var controller = actionContext.ControllerContext.Controller as BaseApiController;
                Authorize(token, string.Empty, controller);
            }
            catch (UnauthorizedException e)
            {
                HttpResponseMessage response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e.Message);
                throw new HttpResponseException(response);
            }
            catch (DomainException e)
            {
                HttpResponseMessage response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                throw new HttpResponseException(response);
            }
            catch (Exception)
            {
                HttpResponseMessage response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ErrorMessage.InternalServerError);
                throw new HttpResponseException(response);
            }

            base.OnActionExecuting(actionContext);
        }

        public static void Authorize(string token, string language, BaseApiController controller)
        {
            ExecuteManager.Execute(() =>
            {
                var systemUser = ValidateToken(token);

                if (controller == null) return;
                controller.CurrentUser = systemUser;
            });
        }

        private static LoginUserInformationForCodeSection ValidateToken(string token)
        {
            return WindsorBootstrapper.Container.Resolve<IUserLogic>().ValidateAuthenticationToken(token);
        }
    }
}