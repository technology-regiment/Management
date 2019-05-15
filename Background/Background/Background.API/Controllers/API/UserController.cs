using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Background.Logic;
using Background.Logic.UICommands;
using Background.Logic.ViewModels;

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
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _userLogic.GetAll();
        }

        [Route("api/users1")]
        [HttpPost]
        public void Post(CreateUserUICommand command)
        {

            _userLogic.Create(command);

        }

        [Route("api/users")]
        [HttpPut]
        public void Put([FromBody]UpdateUserUICommand command)
        {
            {
                _userLogic.Update(command);
            }
        }

        [Route("api/users/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {

            _userLogic.Delete(id);

        }

    }
}