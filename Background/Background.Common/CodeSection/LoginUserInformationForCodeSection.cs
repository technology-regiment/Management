using System;

namespace Background.Common.CodeSection
{
    public class LoginUserInformationForCodeSection
    {
        public Guid UserId { get; set; }
        public string LoginUserName { get; set; }
        public string LoginUserEmail { get; set; }
        public string AuthenticationToken { get; set; }
        public string SystemRoleName { get; set; }
        public Guid SystemRoleId { get; set; }
    }
}
