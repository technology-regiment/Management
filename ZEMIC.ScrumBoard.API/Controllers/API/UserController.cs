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
    public class UserController : BaseApiController
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public UserViewModel Get(Guid id)
        {
            return Execute(() => _userLogic.Get(id));
        }

        [Route("api/users")]
        [HttpPost]
        public void Post([FromBody]CreateUserUICommand command)
        {
            Execute(() =>
            {
                _userLogic.Create(command);
            });
        }

        [Route("api/users/pagination")]
        [HttpPost]
        public PagedCollection<UserDataGridViewModel> Pagination([FromBody]UserPageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _userLogic.GetAllByPageAndSorting(pageAndSorting));
        }

        [Route("api/users")]
        [HttpPut]
        public void Put([FromBody]UpdateUserUICommand command)
        {
            Execute(() =>
            {
                _userLogic.Update(command);
            });
        }
        [Route("api/usersPassword")]
        [HttpPut]
        public void ChangePassword([FromBody]ChangePasswordUICommand command)
        {
            Execute(() =>
            {
                _userLogic.ChangePassword(command);
            });
        }
        [Route("api/users/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() =>
            {
                _userLogic.Delete(id);
            });
        }

        [Route("api/users/{id}")]
        [HttpPut]
        public void ResetPassword(Guid id)
        {
            Execute(() =>
            {
                _userLogic.ResetPassword(id);
            });
        }

        [Route("api/users/userStatusSelects")]
        [HttpGet]
        public IEnumerable<UserStatusDropDownListItem> GetUserStatusSelects()
        {
            return Execute(DropDownListItemsCreator.GetUserStatusDropDownListItems);
        }

        [Route("api/users/userSelects")]
        [HttpGet]
        public IEnumerable<UserDropDownListItem> GetUserSelects()
        {
            return Execute(() => _userLogic.GetUserSelects());
        }

        [Route("api/users/allLog/{id}")]
        [HttpGet]
        public List<EventViewModel> GetAllLog(Guid id)
        {
            return Execute(() => _userLogic.GetAllLog(id));
        }

        [Route("api/users/dropdown/{id}")]
        [HttpGet]
        public IEnumerable<UserDropDownListItem> GetUserDropsDropDown(Guid id)
        {
            return Execute(() => _userLogic.GetUserDropsDropDown(id));
        }

        [Route("api/users/selects/{id}")]
        [HttpGet]
        public IEnumerable<UserDropDownListItem> GetUserSelectsForBug(Guid id)
        {
            return Execute(() => _userLogic.GetUserSelectsForBug(id));
        }
    }

}
