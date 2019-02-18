
using System.Web.Http;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Handlers;
using MediatR;
using Unity;

namespace IBuyServer.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IPurchaseRecordsRepository, PurchaseRecordsRepository>();
            RegisterMediatR(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.AspNet.WebApi.UnityDependencyResolver(container);
        }


        public static void RegisterMediatR(UnityContainer container)
        {
            container.RegisterType<IMediator, Mediator>();
            HandlersRegistrator.RegisterHandlers(container);
        }
    }
}