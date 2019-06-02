using Background.Logic.UICommands;
using Background.Logic.ViewModel;

namespace Background.Logic
{
    public interface ISystemRoleLogic
    {

        void Create(CreateRoleUICommand command);
        
        PagedCollection<RoleDataGridViewModel> GetAllByPageAndSorting(RolePageAndSortingUICommand pageAndSorting);
    
    }
}
