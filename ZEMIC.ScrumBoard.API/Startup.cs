using System.IO;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.Owin;
using Owin;
using ZEMIC.ScrumBoard.API;

[assembly: OwinStartup(typeof(Startup))]

namespace ZEMIC.ScrumBoard.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
