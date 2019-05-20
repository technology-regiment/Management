using Background.Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background.Logic
{
    public interface ISystemUserLogic
    {
        AuthenticatedViewModel Login(string email, string password);
    }
}
