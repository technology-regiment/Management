using System;

namespace Background.Entities.SystemSetting
{
    public class SystemUser:Entity
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        public string EmployeeNo { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 系统角色
        /// </summary>
        public virtual SystemRole SystemRole { get; set; }

        /// <summary>
        /// 系统角色Id
        /// </summary>
        public int SystemRoleId { get; private set; }

    }
}
