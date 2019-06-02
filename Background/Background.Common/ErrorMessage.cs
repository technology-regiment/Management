

namespace Background.Common
{
    public static class ErrorMessage
    {
        public const string UnauthorizedException = "操作失败，未验证";
        public const string AuthenticationTokenMissing = "Token无效或者已过期";
        public const string InternalServerError = "服务器内部错误，请联系管理员";
        public const string UserEmailIsEmpty = "Email不能为空";
        
        public const string PasswordIsRequired = "登录密码不能为空";
        //Public
       
        public const string UserLoginFault = "用户名或密码不正确";
       
        public const string UserIsNotExist = "当前用户不存在";
        public const string RoleNameIsExist = "已存在该角色";
        public const string RoleIsNotExist = "该角色不存在";
        
        public const string UserWasDisabled = "用户已停用，无法登录，如需登录请联系管理员";
      
    }
}
