using Background.Entities.SystemSetting;

namespace Background.Repository.Impl
{
   
    public class SystemRoleRepository : BaseRepository<SystemRole>, ISystemRoleRepository
    {
        public SystemRoleRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
