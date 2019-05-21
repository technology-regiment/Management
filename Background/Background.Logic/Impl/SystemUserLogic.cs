using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Background.Common;
using Background.Common.Cache;
using Background.Common.CodeSection;
using Background.Logic.ViewModel;
using Background.Repository;
using Background.Repository.UnitOfWork;

namespace Background.Logic.Impl
{
    public class SystemUserLogic : ISystemUserLogic
    {
        private readonly ISystemUserRepository _systemUserRepository;
       
        private readonly ICacheManager _cacheManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ITimeSource _timeSource;


        public SystemUserLogic(ISystemUserRepository systemUserRepository,
            ICacheManager cacheManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            ITimeSource timeSource)
        {
            _systemUserRepository = systemUserRepository;
            _cacheManager = cacheManager;
            _unitOfWorkFactory = unitOfWorkFactory;
           
            _timeSource = timeSource;
           
        }
        public AuthenticatedViewModel Login(string email, string password)
        {

            if (string.IsNullOrEmpty(email))
            {
                throw new DomainException(ErrorMessage.UserEmailIsEmpty);
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new DomainException(ErrorMessage.PasswordIsRequired);
            }

            var user = _systemUserRepository.GetAll(x => x.Email == email).FirstOrDefault();
            if (user == null)
            {
                throw new DomainException(ErrorMessage.UserIsNotExist);
            }
            if (!user.IsActive)
            {
                throw new DomainException(ErrorMessage.UserWasDisabled);
            }

            if (!PasswordHasher.ValidateHash(password, user.PasswordHash))
            {
                throw new DomainException(ErrorMessage.UserLoginFault);
            }



            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                var authenticationToken = SHA256Hash.CreateHash(Guid.NewGuid().ToString());
                user.UpdateLogin(authenticationToken, _timeSource.LocalNow());


                _systemUserRepository.Edit(user);
                unitOfWork.Commit();

                _cacheManager.Add(authenticationToken, user.Id);
                var authenticatedViewModel = new AuthenticatedViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    AuthenticationToken = authenticationToken,
                    SystemRoleName = user.SystemRole.Name,
                    SystemRoleId = user.SystemRoleId
                };

                _cacheManager.Add(user.Id.ToString(), authenticatedViewModel);
                return authenticatedViewModel;
            }
        }

        public void Logout(string authenticationToken)
        {
            _cacheManager.Remove(authenticationToken);
        }

        public LoginUserInformationForCodeSection ValidateAuthenticationToken(string authenticationToken)
        {
            if (string.IsNullOrEmpty(authenticationToken))
            {
                throw new DomainException(ErrorMessage.UnauthorizedException);
            }

            if (!_cacheManager.Contains(authenticationToken))
            {
                var user = _systemUserRepository.GetAll(x => x.AuthenticationToken == authenticationToken)
                    .FirstOrDefault();

                if (user == null)
                {
                    throw new UnauthorizedException(ErrorMessage.AuthenticationTokenMissing);
                }

                var authenticatedViewModel = new AuthenticatedViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    AuthenticationToken = user.AuthenticationToken,
                    SystemRoleName = user.SystemRole.Name,
                    SystemRoleId = user.SystemRole.Id
                };

                _cacheManager.Add(user.AuthenticationToken, user.Id);
                _cacheManager.Add(user.Id.ToString(), authenticatedViewModel);

                return new LoginUserInformationForCodeSection
                {
                    UserId = authenticatedViewModel.Id,
                    LoginUserName = authenticatedViewModel.Name,
                    AuthenticationToken = authenticatedViewModel.AuthenticationToken,
                    LoginUserEmail = authenticatedViewModel.Email,
                    SystemRoleName = authenticatedViewModel.SystemRoleName,
                    SystemRoleId = authenticatedViewModel.SystemRoleId
                };
            }
            var userId = _cacheManager.Get<Guid>(authenticationToken).ToString();

            var cachedAuthenticatedViewModel = _cacheManager.Get<AuthenticatedViewModel>(userId);
            return new LoginUserInformationForCodeSection
            {
                UserId = cachedAuthenticatedViewModel.Id,
                LoginUserName = cachedAuthenticatedViewModel.Name,
                LoginUserEmail = cachedAuthenticatedViewModel.Email,
                AuthenticationToken = cachedAuthenticatedViewModel.AuthenticationToken,
                SystemRoleName = cachedAuthenticatedViewModel.SystemRoleName,
                SystemRoleId = cachedAuthenticatedViewModel.SystemRoleId
            };
        }
    }
}
