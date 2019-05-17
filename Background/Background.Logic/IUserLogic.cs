using Background.Entities;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;


namespace Background.Logic
{
    public interface IUserLogic
    {
       
        void Create(CreateUserUICommand command);
        void Update(UpdateUserUICommand command);
        void Delete(int id);
        PagedCollection<UserDataGridViewModel> GetAllByPageAndSorting(UserPageAndSortingUICommand pageAndSorting);
        User GetById(int id);
    }
}