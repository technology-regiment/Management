using System.Web.Http;
using Background.Logic;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;

namespace Background.API.Controllers.API
{
    public class UserController : ApiController
    {
        private readonly IUserLogic _userLogic;


        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

       

        [Route("api/users")]
        [HttpPost]
        public void Post(CreateUserUICommand command)
        {

            _userLogic.Create(command);

        }

        [Route("api/users")]
        [HttpPut]
        public void Put([FromBody]UpdateUserUICommand command)
        {
            _userLogic.Update(command);
        }

        [Route("api/users/pagination")]
        [HttpPost]
        public PagedCollection<UserDataGridViewModel> Pagination([FromBody]UserPageAndSortingUICommand pageAndSorting)
        {
            return _userLogic.GetAllByPageAndSorting(pageAndSorting);
        }

        [Route("api/users/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
                _userLogic.Delete(id);

        }
    }
}