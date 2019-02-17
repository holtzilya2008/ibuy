﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using IBuyServer.Service.IoC;
using WebApi.StructureMap;

namespace IBuyServer.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.UseStructureMap<IBuyRegistry>();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
