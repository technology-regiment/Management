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
            if (_systemRoleRepository.GetAll(x => x.Name == command.Name && !x.IsDeleted).Any())
            {
                throw new DomainException(ErrorMessage.RoleNameIsExist);
            }
            var systemRole = SystemRole.Create(command.Name, command.Description, new Guid(), _timeSource.LocalNow());
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _systemRoleRepository.Add(systemRole);
                unitOfWork.Commit();
            }
        }

        public void Update(UpdateRoleUICommand command)
        {
            var role = _systemRoleRepository.Get(command.Id);
            if (role == null)
            {
                throw new DomainException(ErrorMessage.RoleIsNotExist);
            }
            role.Edit(command.Name, command.Description, new Guid(), _timeSource.LocalNow());
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _systemRoleRepository.Edit(role);
                unitOfWork.Commit();
            }
        }
        public void Delete(Guid id)
        {
            var role = _systemRoleRepository.Get(id);
            if (role == null)
            {
                throw new DomainException(ErrorMessage.RoleIsNotExist);
            }
         

            //role.LogicDelete(new Guid(LoginUserSection.CurrentUser.UserId), DateTime.Now);
            role.LogicDelete(new Guid("0882EF4C-9367-4781-A686-7A0D40B32AC2"), _timeSource.LocalNow());
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _systemRoleRepository.Edit(role);
                unitOfWork.Commit();
            }
        }

        public PagedCollection<RoleDataGridViewModel> GetAllByPageAndSorting(RolePageAndSortingUICommand pageAndSorting)
        {
          

            var roles = _systemRoleRepository.GetPagingData(
                x => (pageAndSorting.Filter.Name == null || x.Name.Contains(pageAndSorting.Filter.Name)) && x.IsDeleted==false,
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
