using Background.Entities;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using System;

namespace Background.Logic
{
    public interface IUserLogic
    {

        void Create(CreateUserUICommand command);
        void Update(UpdateUserUICommand command);
        void Delete(Guid id);
        PagedCollection<UserDataGridViewModel> GetAllByPageAndSorting(UserPageAndSortingUICommand pageAndSorting);
        User GetById(Guid id);
    }
        
}