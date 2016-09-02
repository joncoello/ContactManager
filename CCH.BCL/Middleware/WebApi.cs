using CCH.BCL.Infrastructure;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CCH.BCL.Middleware {
    public static class WebApi {

        /// <summary>
        /// middleware to add our standard settings for a web api
        /// </summary>
        /// <param name="app"></param>
        /// <param name="httpConfig"></param>
        /// <param name="controllersAssembly"></param>
        /// <param name="typesToRegister"></param>
        public static void UseCchWebApi(this IAppBuilder app, string connectionString,
            HttpConfiguration httpConfig, Assembly controllersAssembly, params Type[] typesToRegister) {

            //IoC
            var factory = new IocContainerFactory();
            var container = factory.Create(httpConfig);

            container.RegisterApiControllers(controllersAssembly);
            container.RegisterFilters();
                        
            container.RegisterSqlClient(connectionString);

            // custom types
            typesToRegister.ToList().ForEach(t=> container.RegisterType(t));

            container.Build();
            httpConfig.DependencyResolver = container.GetResolver();

            // web api
            httpConfig.MapHttpAttributeRoutes();

            //formatting
            httpConfig.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //httpConfig.Formatters.Clear();
            //httpConfig.Formatters.Add(new JsonMediaTypeFormatter());

        }
    }
}
