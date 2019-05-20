using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Background.Common;
using Background.Logic.ViewModel;

namespace Background.Logic.Impl
{
    public class SystemUserLogic : ISystemUserLogic
    {
        public AuthenticatedViewModel Login(string email, string password)
        {

            return new AuthenticatedViewModel();

            //using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            //{
            //    var authenticationToken = SHA256Hash.CreateHash(Guid.NewGuid().ToString());
            //    user.UpdateLogin(authenticationToken, _timeSource.LocalNow());


            //    _userRepository.Edit(user);
            //    unitOfWork.Commit();

            //    _cacheManager.Add(authenticationToken, user.Id);
            //    var authenticatedViewModel = new AuthenticatedViewModel
            //    {
            //        Id = user.Id,
            //        Name = user.Name,
            //        Email = user.Email,
            //        AuthenticationToken = authenticationToken,
            //        RoleName = user.Role.Name,
            //        RoleId = user.RoleId
            //    };

            //    _cacheManager.Add(user.Id.ToString(), authenticatedViewModel);
            //    return authenticatedViewModel;
            //}
        }
    }
}
