using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Background.Entities;

namespace Background.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        
    }
}