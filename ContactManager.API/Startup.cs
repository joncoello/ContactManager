using Autofac;
using Autofac.Integration.WebApi;
using CCH.BCL.Data;
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

            // IoC - autofac
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            // custom types
            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";
            builder.RegisterType<SQLClient>()
                .As<ISQLClient>()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<ContactRepository>().AsSelf();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // web api
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);  
                 
        }

    }
}