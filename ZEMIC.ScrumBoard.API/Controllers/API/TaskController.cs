using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class TaskController : BaseApiController
    {
        private readonly ITaskLogic _taskLogic;

        public TaskController(ITaskLogic taskLogic)
        {
            _taskLogic = taskLogic;
        }

        [Route("api/tasks")]
        [HttpPost]
        public void Post([FromBody]CreateTaskUICommand command)
        {
            Execute(() => { _taskLogic.Create(command); });
        }

        [Route("api/tasks")]
        [HttpGet]
        public IEnumerable<WorkInfoViewModel> GetWorkInfos()
        {
            return Execute(() => _taskLogic.GetWorkInfos());
        }
    }
}