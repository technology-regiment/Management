using Background.Common.CodeSection;
using Background.Logic.ViewModel;

namespace Background.Logic
{
    public interface ISystemUserLogic
    {
        AuthenticatedViewModel Login(string email, string password);
        void Logout(string authenticationToken);
        LoginUserInformationForCodeSection ValidateAuthenticationToken(string authenticationToken);
    }
}
