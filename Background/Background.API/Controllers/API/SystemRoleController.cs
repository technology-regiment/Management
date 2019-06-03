using Background.API.Filter;
using Background.Logic;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using System;
using System.Web.Http;

namespace Background.API.Controllers.API
{
    [TokenAuthorize]
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

        [Route("api/roles")]
        [HttpPut]
        public void Put(UpdateRoleUICommand command)
        {
            Execute(() =>
            {
                _systemRoleLogic.Update(command);
            });
        }

        [Route("api/roles/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() =>
            {
                _systemRoleLogic.Delete(id);
            });
        }

        [Route("api/roles/pagination")]
        [HttpPost]
        public PagedCollection<RoleDataGridViewModel> Pagination(RolePageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _systemRoleLogic.GetAllByPageAndSorting(pageAndSorting));
           
            
        }
    }
}