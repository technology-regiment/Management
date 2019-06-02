using Background.Common;
using System;
using System.Collections.Generic;

namespace Background.Entities.SystemSetting
{
    public class SystemRole : Entity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }

       
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; private set; }
        /// <summary>
        /// 最后一次修改日期
        /// </summary>
        public DateTime? LastModifiedTime { get; private set; }
        /// <summary>
        /// 创建者Id
        /// </summary>
        public Guid CreatorId { get; private set; }

        /// <summary>
        /// 最后一次修改者Id
        /// </summary>
        public Guid? LastModifiedUserId { get; private set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// 系统用户
        /// </summary>
        public virtual ICollection<SystemUser> SystemUsers { get; private set; }

        /// <summary>
        /// 系统功能
        /// </summary>
        public virtual ICollection<SystemFunction> SystemFunctions { get; private set; }
        public SystemRole()
        {
            SystemUsers = new List<SystemUser>();
        }

        public static SystemRole Create(string name, string description, Guid creatorId, DateTime createTime)
        {
            
            return new SystemRole
            {
                Name = name,
                Description = description,
                CreatorId = creatorId,
                CreateTime = createTime,
                IsDeleted = false
            };
        }

        public SystemRole Edit(string name, string description, Guid lastModifiedUserId, DateTime lastModifiedTime)
        {
            
            Name = name;
            Description = description;
            LastModifiedUserId = lastModifiedUserId;
            LastModifiedTime = lastModifiedTime;
            return this;
        }
        public SystemRole LogicDelete(Guid lastModifiedUserId, DateTime lastModifiedTime)
        {
            IsDeleted = true;
            LastModifiedUserId = lastModifiedUserId;
            LastModifiedTime = lastModifiedTime;
            return this;
        }
    }


}
