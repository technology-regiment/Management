using Management.WebAPI;
using Management.WebAPI.Installer;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Management.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WindsorBootstrapper.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
              new WindsorCompositionRoot(WindsorBootstrapper.Container));
        }
    }
}
//using System.Web.Http;
//using System.Web.Http.Dispatcher;
//using System.Web.Mvc;
//using System.Web.Optimization;
//using System.Web.Routing;
//using Management.API;
//using Management.WebAPI;
//using Management.WebAPI.Installer;

//namespace StudentManagement.WebAPI
//{
//    public class WebApiApplication : System.Web.HttpApplication
//    {
//        protected void Application_Start()
//        {
//            WindsorBootstrapper.Initialize();
//            AreaRegistration.RegisterAllAreas();
//            GlobalConfiguration.Configure(WebApiConfig.Register);

//            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
//              new WindsorCompositionRoot(WindsorBootstrapper.Container));
//            RouteConfig.RegisterRoutes(RouteTable.Routes);
//            BundleConfig.RegisterBundles(BundleTable.Bundles);
//            //Database.SetInitializer<StudentManagementContext>(null);
//        }
//    }
//}