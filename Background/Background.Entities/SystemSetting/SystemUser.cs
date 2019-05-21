using Background.Common;
using Background.Entities.Enum;
using System;

namespace Background.Entities.SystemSetting
{
    public class SystemUser:Entity
    {
        private const int AuthTokenValidDays = 7;

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// 身份验证Token
        /// </summary>
        public string AuthenticationToken { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuthenticationTokenValidTo { get; private set; }
       
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginDate { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifiedTime { get; private set; }

        /// <summary>
        /// 系统角色
        /// </summary>
        public virtual SystemRole SystemRole { get; private set; }

        /// <summary>
        /// 系统角色Id
        /// </summary>
        public Guid SystemRoleId { get; private set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        public bool IsActive { get; private set; }

        public static SystemUser Create(string name, string email,string password , Guid systemRoleId, UserStatus userStatus, DateTime creatTime)
        {
            return new SystemUser
            {
                Name = name,
                IsActive = Convert.ToBoolean(userStatus),
                PasswordHash = PasswordHasher.CreateHash(password),
                Email = email,
                CreateTime = creatTime,
                SystemRoleId = systemRoleId
            };
        }

        public void UpdateLogin(string token, DateTime loginTime)
        {
            AuthenticationToken = token;
            AuthenticationTokenValidTo = loginTime.AddDays(AuthTokenValidDays);
            LastLoginDate = loginTime;
        }

    }
}
