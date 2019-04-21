using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.Enums;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class UserStoryTypeController : BaseApiController
    {
        private readonly IUserStoryTypeLogic _userStoryTypeLogic;

        public UserStoryTypeController(IUserStoryTypeLogic userStoryTypeLogic)
        {
            _userStoryTypeLogic = userStoryTypeLogic;
        }

        [Route("api/userStoryTypes")]
        [HttpGet]
        public IEnumerable<UserStoryTypeDropDownListItem> GetUserStoryTypeDropDown()
        {
            return Execute(() => _userStoryTypeLogic.GetUserStoryTypeDropDown());
        }
    }
}