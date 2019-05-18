using System;
using System.Collections.Generic;

namespace Background.Entities.SystemSetting
{
    public class SystemRole : Entity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 系统用户
        /// </summary>
        public virtual ICollection<SystemUser> SystemUsers { get; set; }

        /// <summary>
        /// 系统功能
        /// </summary>
        public virtual ICollection<SystemFunction> SystemFunctions { get; set; }
    }
}
