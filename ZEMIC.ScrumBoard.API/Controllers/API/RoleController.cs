using System;
using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.Enums;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class RoleController : BaseApiController
    {
        private readonly IRoleLogic _roleLogic;

        public RoleController(IRoleLogic roleLogic)
        {
            _roleLogic = roleLogic;
        }

        [Route("api/roles/{id}")]
        [HttpGet]
        public RoleViewModel Get(Guid id)
        {
            return Execute(() => _roleLogic.Get(id));
        }

        [Route("api/roles")]
        [HttpPost]
        public void Post([FromBody]CreateRoleUICommand command)
        {
            Execute(() =>
            {
                _roleLogic.Create(command);
            });
        }

        [Route("api/roles/pagination")]
        [HttpPost]
        public PagedCollection<RoleViewModel> Pagination([FromBody]RolePageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _roleLogic.GetAllByPageAndSorting(pageAndSorting));
        }

        [Route("api/roles")]
        [HttpPut]
        public void Put([FromBody]UpdateRoleUICommand command)
        {
            Execute(() =>
            {
                _roleLogic.Update(command);
            });
        }

        [Route("api/roles/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() =>
            {
                _roleLogic.Delete(id);
            });
        }
        [Route("api/roles/userRole/")]
        [HttpGet]
        public IEnumerable<RolesDropDownListItem> GetRoles()
        {
            return Execute(() => _roleLogic.GetRolesDropDownListItems());
        }
    }
}
