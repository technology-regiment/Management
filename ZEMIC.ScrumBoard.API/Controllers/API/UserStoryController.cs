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
    public class UserStoryController : BaseApiController
    {
        private readonly IUserStoryLogic _userStoryLogic;

        public UserStoryController(IUserStoryLogic userStoryLogic)
        {
            _userStoryLogic = userStoryLogic;
        }

        [Route("api/userstorys")]
        [HttpPost]
        public Guid Post([FromBody]CreateUserStoryUICommand command)
        {
            return Execute(() =>  _userStoryLogic.Create(command));
        }

        [Route("api/userstorys/dropdown")]
        [HttpGet]
        public IEnumerable<UserStorysDropDownListItem> GetUserStorysByDropDown()
        {
            return Execute(() => _userStoryLogic.GetUserStorysByDropDown());
        }

        [Route("api/userstorys/tasks/{id}")]
        [HttpGet]
        public IEnumerable<WorkTableInfoViewModel> GetTaskInfos(Guid id)
        {
            return Execute(() => _userStoryLogic.GetTaskInfos(id));
        }
        [Route("api/userstorys/bugs/{id}")]
        [HttpGet]
        public IEnumerable<WorkTableInfoViewModel> GetBugInfos(Guid id)
        {
            return Execute(() => _userStoryLogic.GetBugInfos(id));
        }
    }
}