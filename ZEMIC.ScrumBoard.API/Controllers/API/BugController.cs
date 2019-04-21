using System;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class BugController:BaseApiController
    {

        private readonly IBugLogic _bugLogic;

        public BugController(IBugLogic bugLogic)
        {
            _bugLogic = bugLogic;
        }

        [Route("api/bugs")]
        [HttpPost]
        public Guid Post([FromBody]CreateBugUICommand command)
        {
            return Execute(() => _bugLogic.Create(command));
        }
    }
}