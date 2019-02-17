using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IBuyServer.Domain.DataModel.Context;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Engines;
using StructureMap;

namespace IBuyServer.Service.IoC
{
    public class IBuyRegistry : Registry
    {
        public IBuyRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            For<IPurchaseRecordsEngine>().Use<PurchaseRecordsEngine>();
            For<IPurchaseRecordsRepository>().Use<PurchaseRecordsRepository>();
            For<DbContext>().Use<IBuyContext>();
        }
    }
}