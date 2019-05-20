using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background.Common
{
    public  static class EntityExtensions
    {
        public static void ForceId(this Entity entity, Guid id)
        {
            PrivateAccess.SetPrivate(entity, "Id", id);
        }
    }
}
