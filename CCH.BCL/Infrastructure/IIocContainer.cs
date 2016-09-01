using System;
using System.Reflection;
using System.Web.Http.Dependencies;

namespace CCH.BCL.Infrastructure {

    /// <summary>
    /// IoC interface
    /// </summary>
    public interface IIocContainer {
        void Build();
        IDependencyResolver GetResolver();
        void RegisterApiControllers(Assembly assembly);
        void RegisterFilters();
        void RegisterSqlClient(string connectionString);
        void RegisterType<T>();
        void RegisterType(Type t);

    }
}