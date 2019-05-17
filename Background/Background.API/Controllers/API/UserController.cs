using System.Web.Http;
using Background.Entities;
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
        public void Put(UpdateUserUICommand command)
        {
            _userLogic.Update(command);
        }

        [Route("api/users/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _userLogic.Delete(id);

        }

        [Route("api/users/{id}")]
        [HttpGet]
        public User GetById(int id)
        {
            return  _userLogic.GetById(id);
        }

        [Route("api/users/pagination")]
        [HttpPost]
        public PagedCollection<UserDataGridViewModel> Pagination(UserPageAndSortingUICommand pageAndSorting)
        {
            return _userLogic.GetAllByPageAndSorting(pageAndSorting);
        }

       
    }
}