using Background.Entities;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using Background.Repository;
using Background.Repository.UnitOfWork;
using System;
using System.Linq;

namespace Background.Logic.Impl
{
    public class UserLogic : IUserLogic
    {
    

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        
        public UserLogic(IUserRepository userRepository,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

       

        public void Create(CreateUserUICommand command)
        {
            var user = new User
            {
                Name = command.Name,
            };
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _userRepository.Add(user);
                unitOfWork.Commit();
            }
        }

        public void Update(UpdateUserUICommand command)
        {
            var user = _userRepository.Get(command.Id);

            user.Name = command.Name;
           

            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _userRepository.Edit(user);
                unitOfWork.Commit();
            }
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public PagedCollection<UserDataGridViewModel> GetAllByPageAndSorting(UserPageAndSortingUICommand pageAndSorting)
        {
            var users = _userRepository.GetPagingData(
                x => pageAndSorting.Filter.Name == null || x.Name.Contains(pageAndSorting.Filter.Name),
                pageAndSorting.PageNumber, pageAndSorting.PageSize, pageAndSorting.OrderProperty, pageAndSorting.Ascending, out var totalRecordes)
                .Select(x => new UserDataGridViewModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                });

            return new PagedCollection<UserDataGridViewModel>(pageAndSorting.PageNumber, totalRecordes, 10, users);
        }

        public User GetById(Guid id)
        {
            return _userRepository.Get(id);
        }
    }
}