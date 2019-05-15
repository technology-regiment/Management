
using System.Collections.Generic;
using Background.Logic.UICommands;
using Background.Logic.ViewModels;


namespace Background.Logic
{
    public interface IUserLogic
    {
        UserViewModel Get(int userId);
        void Create(CreateUserUICommand command);
        void Update(UpdateUserUICommand command);
        IEnumerable<UserViewModel> GetAll();
        void Delete(int id);
    }
}