using System.Web.Http;
using Background.Common.CodeSection;

namespace Background.API.Controllers.API
{
    public abstract class BaseApiController : ApiController
    {
        internal LoginUserInformationForCodeSection CurrentUser { get; set; }
    }
}
