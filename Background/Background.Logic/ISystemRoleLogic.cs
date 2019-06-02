using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using System;

namespace Background.Logic
{
    public interface ISystemRoleLogic
    {

        void Create(CreateRoleUICommand command);
        
        PagedCollection<RoleDataGridViewModel> GetAllByPageAndSorting(RolePageAndSortingUICommand pageAndSorting);
        void Update(UpdateRoleUICommand command);
        void Delete(Guid id);
    }
}
