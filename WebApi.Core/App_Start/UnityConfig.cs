namespace WebApi.Core.Configurations
{
    using Microsoft.Practices.Unity;
    using WebApi.Core.Models;
    using WebApi.Core.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebApi.Core.UnityDepandency;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.Controllers;
    

    public class UnityConfig
    {
        public static IUnityContainer Initialize(HttpConfiguration config)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IMongoDBRepository, MongoDBRepository>(new HierarchicalLifetimeManager());
            DependencyResolver.SetResolver(new UnityDepandencyResolver(container));
            return container;
        }
    }
}