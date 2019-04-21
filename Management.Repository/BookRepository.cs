using Management.Data.Model;
using Management.IRepository;
using Management.Data;


namespace Management.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbfactory) : base(dbfactory)
        {
        }
    }
}