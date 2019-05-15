
using System.Collections.Generic;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using Background.Logic.ViewModels;


namespace Background.Logic
{
    public interface IUserLogic
    {
       
        void Create(CreateUserUICommand command);
        void Update(UpdateUserUICommand command);
        void Delete(int id);
        PagedCollection<UserDataGridViewModel> GetAllByPageAndSorting(UserPageAndSortingUICommand pageAndSorting);
    }
}