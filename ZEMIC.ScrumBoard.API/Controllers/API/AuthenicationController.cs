using System;
using System.Web.Http;
using ZEMIC.Common;
using ZEMIC.Common.Cache;
using ZEMIC.Common.CodeSection;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    public class AuthenicationController : BaseApiController
    {
        private readonly IUserLogic _userLogic;
        private readonly ICacheManager _cacheManager;
        private const string TokenName = "X-AuthenticationToken";

        public AuthenicationController(IUserLogic userLogic, ICacheManager cacheManager)
        {
            _userLogic = userLogic;
            _cacheManager = cacheManager;
        }

        [HttpPost]
        [Route("api/login")]
        public AuthenticatedViewModel Login([FromBody]LoginUICommand command)
        {
            return Execute(() =>
            {
                var authenticatedViewModel = _userLogic.Login(command.Email, command.Password);

                return authenticatedViewModel;
            });
        }

        [HttpPost]
        [Route("api/logout")]
        public void Logout([FromBody] LogoutUICommand command)
        {
            Execute(() =>
            {
                _userLogic.Logout(command.AuthenticationToken);
            });
        }

        [HttpPost]
        [Route("api/verification")]
        public AuthenticatedViewModel VerificationToken([FromBody]VerificationTokenUICommand command)
        {
            return Execute(() =>
            {
                var user = _userLogic.ValidateAuthenticationToken(command.AuthenticationToken);
                return new AuthenticatedViewModel
                {
                    Id = user.UserId,
                    Name = user.LoginUserName,
                    Email = user.LoginUserEmail,
                    AuthenticationToken = user.AuthenticationToken,
                    RoleName = user.RoleName,
                    RoleId = user.RoleId
                };
            });
        }

        [Route("api/initiatepasswordreset")]
        [HttpPost]
        public void InitiatePasswordReset([FromBody]InitiatePasswordResetUICommand command)
        {
            Execute(() =>
            {
                _userLogic.InitiatePasswordReset(command.Email);
            });
        }

        [Route("api/checkresetpasswordtoken")]
        [HttpPost]
        public void CheckResetPasswordToken([FromBody]CheckResetPasswordTokenUICommand checkResetPasswordTokenRequest)
        {
            Execute(() => _userLogic.CheckResetPasswordToken(checkResetPasswordTokenRequest.ResetPasswordToken));
        }
    }
}