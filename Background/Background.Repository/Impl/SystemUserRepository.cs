
using Background.Entities.SystemSetting;

namespace Background.Repository.Impl
{
   
    public class SystemUserRepository : BaseRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
