using System.Web.Http;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Engines;
using Unity;
using Unity.WebApi;

namespace IBuyServer.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IPurchaseRecordsEngine, PurchaseRecordsEngine>();
            container.RegisterType<IPurchaseRecordsRepository, PurchaseRecordsRepository>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            System.Diagnostics.Debug.WriteLine("Unity Container initialized!");
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}