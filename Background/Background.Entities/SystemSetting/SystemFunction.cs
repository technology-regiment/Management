using Background.Common;
using Background.Entities.Enum;
using System.Collections.Generic;

namespace Background.Entities.SystemSetting
{
    public class SystemFunction:Entity
    {
        /// <summary>
        /// 父级节点
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 元素类型
        /// </summary>
        public FunctionType FunctionType{get;set;}

        /// <summary>
        /// 系统角色
        /// </summary>
        public virtual ICollection<SystemRole> SystemRoles { get; set; }
    }
}
