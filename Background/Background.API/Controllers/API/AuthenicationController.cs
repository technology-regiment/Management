using Background.Logic;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebGrease;

namespace Background.API.Controllers.API
{
    public class AuthenicationController : ApiController
    {
        private readonly ISystemUserLogic _systemUserLogic;
        private readonly ICacheManager _cacheManager;
        private const string TokenName = "X-AuthenticationToken";

        public AuthenicationController(ISystemUserLogic systemUserLogic, ICacheManager cacheManager)
        {
            _systemUserLogic = systemUserLogic;
            _cacheManager = cacheManager;
        }

        [HttpPost]
        [Route("api/login")]
        public AuthenticatedViewModel Login(LoginUICommand command)
        {
           
                var authenticatedViewModel = _systemUserLogic.Login(command.Email, command.Password);

                return authenticatedViewModel;
           
        }

        

       

      
    }
}