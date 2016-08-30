using CCH.BCL.Data;
using CCH.BCL.Infrastructure;
using ContactManager.SqlRepositories;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ContactManager.API {

    /// <summary>
    /// main owin startup class
    /// </summary>
    public class Startup {

        public void Configuration(IAppBuilder app) {

            // use attribute routing
            var config = new HttpConfiguration();

            //IoC
            var factory = new IocContainerFactory();
            var container = factory.Create(config);
            container.RegisterApiControllers(this.GetType().Assembly);
            container.RegisterFilters();
            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";
            container.RegisterSqlClient(connectionString);
            container.RegisterType<ContactRepository>();
            container.Build();
            config.DependencyResolver = container.GetResolver();
            
            // web api
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);  
                 
        }

    }
}