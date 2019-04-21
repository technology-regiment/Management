using System.Data.Entity;

namespace Management.Data
{
    public interface IDbFactory
    {
        DbContext GetContext();
    }
}
