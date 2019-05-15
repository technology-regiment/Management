
using System.Collections.Generic;
using System.Linq;
using Background.Entities;
using Background.Logic.Converter;
using Background.Logic.UICommands;
using Background.Logic.ViewModels;
using Background.Repository;
using Background.Repository.UnitOfWork;

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

        public UserViewModel Get(int userId)
        {
            return _userRepository.Get(userId).ToViewModel();
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

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().Select(x => x.ToViewModel());
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        

        

       

      

       

       

       

    

     

       


       

       
    }
}