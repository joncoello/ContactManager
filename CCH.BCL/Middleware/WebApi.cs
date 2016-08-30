using CCH.BCL.Infrastructure;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CCH.BCL.Middleware {
    public static class WebApi {
        public static void UseCchWebApi(this IAppBuilder app, HttpConfiguration config, Assembly controllersAssembly, params Type[] typesToRegister) {

            //IoC
            var factory = new IocContainerFactory();
            var container = factory.Create(config);

            container.RegisterApiControllers(controllersAssembly);
            container.RegisterFilters();

            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";
            container.RegisterSqlClient(connectionString);
            typesToRegister.ToList().ForEach(t=> container.RegisterType(t));

            container.Build();
            config.DependencyResolver = container.GetResolver();

            // web api
            config.MapHttpAttributeRoutes();

        }
    }
}
