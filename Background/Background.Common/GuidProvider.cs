using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background.Common
{
    public class GuidProvider
    {
        public static class UserIdProvider
        {
            public static Guid Admin = new Guid("701f30e1-3c2c-4415-862c-a2fcc547ac1e");
        }

        public static class RoleIdProvider
        {
           
            public static Guid Manager = new Guid("F2B145FF-0002-4B4E-AB74-41FA5C7BA630");

        }
    }
}
