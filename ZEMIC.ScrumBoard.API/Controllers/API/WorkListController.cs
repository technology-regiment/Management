using System;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class WorkListController : BaseApiController
    {
        private readonly IWorkListLogic _workListLogic;

        public WorkListController(IWorkListLogic workListLogic)
        {
            _workListLogic = workListLogic;
        }

        [Route("api/workLists/{id}")]
        [HttpGet]
        public WorkListViewModel GetWorkListInfos(Guid? id)
        {
            return Execute(() => _workListLogic.GetWorkListInfos(id));
        }

        [Route("api/workLists/updateStates")]
        [HttpPut]
        public void UpdateStates(UpdateSprintStateUICommand command)
        {
            Execute(() => { _workListLogic.UpdateStates(command); });
        }

        [Route("api/workLists/pagination")]
        [HttpPost]
        public WorkListViewModel GetWorkListInfosBySorting(WorkListPageAndSortingUICommand command)
        {
            return Execute(() => _workListLogic.GetWorkListInfosBySorting(command));
        }
    }
}