using Background.Logic;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using System.Web.Http;

namespace Background.API.Controllers.API
{
    public class SystemRoleController: BaseApiController
    {
        private readonly ISystemRoleLogic _systemRoleLogic;

        public SystemRoleController(ISystemRoleLogic systemRoleLogic)
        {
            _systemRoleLogic = systemRoleLogic;
        }

        [Route("api/roles")]
        [HttpPost]
        public void Post(CreateRoleUICommand command)
        {
            Execute(() =>
            {
                _systemRoleLogic.Create(command);
            });
            

        }

        [Route("api/roles/pagination")]
        [HttpPost]
        public PagedCollection<RoleDataGridViewModel> Pagination(RolePageAndSortingUICommand pageAndSorting)
        {
            return _systemRoleLogic.GetAllByPageAndSorting(pageAndSorting);
        }
    }
}