using System;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class DashboardController : BaseApiController
    {
        private readonly IDashboardLogic _dashboardLogic;

        public DashboardController(IDashboardLogic dashboardLogic)
        {
            _dashboardLogic = dashboardLogic;
        }

        [Route("api/dashboards/{id}")]
        [HttpGet]
        public DashboardInfoViewModel GetDashboardInfos(Guid? id)
        {
            return Execute(() => _dashboardLogic.GetDashboardInfos(id));
        }

        [Route("api/dashboards/updateStates")]
        [HttpPut]
        public void UpdateStates(UpdateStateUICommand command)
        {
            Execute(() => { _dashboardLogic.UpdateStates(command); });
        }

        [Route("api/dashboards/pagination")]
        [HttpPost]
        public DashboardInfoViewModel GetDashboardInfosBySorting(DashboardPageAndSortingUICommand command)
        {
            return Execute(() => _dashboardLogic.GetDashboardInfosBySorting(command));
        }
    }
}