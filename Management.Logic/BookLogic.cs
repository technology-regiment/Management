using System.Collections.Generic;
using System.Linq;
using Management.Data.Model;

using Management.ILogic;
using Management.IRepository;
using Management.Repository.UnitOfWork;

namespace Management.Logic
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public BookLogic(IBookRepository bookRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _bookRepository = bookRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(Book model)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _bookRepository.Create(model);
                unitOfWork.Commit();
            }
        }
       
    }
}
