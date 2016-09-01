using Autofac;
using Autofac.Integration.WebApi;
using CCH.BCL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace CCH.BCL.Infrastructure {

    /// <summary>
    /// IoC conatinaer using Autofac
    /// </summary>
    public class IocContainer : IIocContainer {

        private readonly ContainerBuilder builder;
        private readonly HttpConfiguration _config;
        private IContainer container;

        public IocContainer(HttpConfiguration config) {
            builder = new ContainerBuilder();
            _config = config;
        }

        public void RegisterApiControllers(Assembly assembly) {
            builder.RegisterApiControllers(assembly);
        }

        public void RegisterFilters() {
            builder.RegisterWebApiFilterProvider(_config);
        }

        public void RegisterSqlClient(string connectionString) {
            builder.RegisterType<SQLClient>()
                .As<ISQLClient>()
                .WithParameter("connectionString", connectionString);
        }

        public void RegisterType<T>() {
            builder.RegisterType<T>().AsSelf();
        }

        public void RegisterType(Type t) {
            builder.RegisterType(t).AsSelf();
        }

        public void Build() {
            container = builder.Build();
        }

        public IDependencyResolver GetResolver() {
            return new AutofacWebApiDependencyResolver(container);
        }

    }
}
