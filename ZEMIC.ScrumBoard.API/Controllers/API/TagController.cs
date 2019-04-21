using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class TagController : BaseApiController
    {
        private readonly ITagLogic _tagLogic;

        public TagController(ITagLogic tagLogic)
        {
            _tagLogic = tagLogic;
        }

        [Route("api/tags")]
        [HttpPost]
        public void Post([FromBody]CreateTagUICommand command)
        {
            Execute(() => { _tagLogic.Create(command); });
        }
    }
}