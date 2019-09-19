using Background.Logic;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using System.Web.Http;

namespace Background.API.Controllers.API
{
    public class AuthenicationController : BaseApiController
    {
        private readonly ISystemUserLogic _systemUserLogic;
      

        public AuthenicationController(ISystemUserLogic systemUserLogic)
        {
            _systemUserLogic = systemUserLogic;
        }

        [HttpPost]
        [Route("api/login")]
        public AuthenticatedViewModel Login([FromBody]LoginUICommand command)
        {
            var authenticatedViewModel = _systemUserLogic.Login(command.Email, command.Password);

            return authenticatedViewModel;
        }

        [HttpPost]
        [Route("api/logout")]
        public void Logout(LogoutUICommand command)
        {
            _systemUserLogic.Logout(command.AuthenticationToken);
        }

        [HttpPost]
        [Route("api/verification")]
        public AuthenticatedViewModel VerificationToken(VerificationTokenUICommand command)
        {
            var user = _systemUserLogic.ValidateAuthenticationToken(command.AuthenticationToken);
            return new AuthenticatedViewModel
            {
                Id = user.UserId,
                Name = user.LoginUserName,
                Email = user.LoginUserEmail,
                AuthenticationToken = user.AuthenticationToken,
                SystemRoleName = user.SystemRoleName,
                SystemRoleId = user.SystemRoleId
            };
        }
    }
}