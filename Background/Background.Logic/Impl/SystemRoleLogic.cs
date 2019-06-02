using Background.Common;
using Background.Common.CodeSection;
using Background.Entities.SystemSetting;
using Background.Logic.UICommands;
using Background.Logic.ViewModel;
using Background.Repository;
using Background.Repository.UnitOfWork;
using System;
using System.Linq;

namespace Background.Logic.Impl
{
    public class SystemRoleLogic: ISystemRoleLogic
    {
        private readonly ISystemRoleRepository _systemRoleRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ITimeSource _timeSource;

        public SystemRoleLogic(ISystemRoleRepository systemRoleRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            ITimeSource timeSource)
        {
            _systemRoleRepository = systemRoleRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            _timeSource = timeSource;
        }



        public void Create(CreateRoleUICommand command)
        {
            var systemRole = SystemRole.Create(command.Name, command.Description, new Guid(), _timeSource.LocalNow());
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _systemRoleRepository.Add(systemRole);
                unitOfWork.Commit();
            }
        }

       
       

        public PagedCollection<RoleDataGridViewModel> GetAllByPageAndSorting(RolePageAndSortingUICommand pageAndSorting)
        {
            var roles = _systemRoleRepository.GetPagingData(
                x => pageAndSorting.Filter.Name == null || x.Name.Contains(pageAndSorting.Filter.Name),
                pageAndSorting.PageNumber, pageAndSorting.PageSize, pageAndSorting.OrderProperty, pageAndSorting.Ascending, out var totalRecordes)
                .Select(x => new RoleDataGridViewModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Description=x.Description,
                });

            return new PagedCollection<RoleDataGridViewModel>(pageAndSorting.PageNumber, totalRecordes, 10, roles);
        }
    }

}
