
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Infrastructure.DataAccess;
using IBuyServer.Infrastructure.MediatR;
using IBuyServer.Logic.Handlers.PurchaseRecords;
using IBuyServer.Service.App_Start;
using MediatR;
using Unity;

namespace IBuyServer.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterTypesImplementingType(Assembly.GetAssembly(typeof(IPurchaseRecordsRepository)),
                typeof(IRepository<>));
            RegisterMediatR(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.AspNet.WebApi.UnityDependencyResolver(container);
        }


        public static void RegisterMediatR(UnityContainer container)
        {
            container.RegisterMediator(new Unity.Lifetime.HierarchicalLifetimeManager())
                .RegisterMediatorHandlers(Assembly.GetAssembly(typeof(GetPurchaseRecordsHandler)));
        }

        public static void RegisterRepositories(UnityContainer container)
        {

        }
    }
}