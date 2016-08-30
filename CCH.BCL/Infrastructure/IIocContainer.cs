﻿using System.Reflection;
using System.Web.Http.Dependencies;

namespace CCH.BCL.Infrastructure {
    public interface IIocContainer {
        void Build();
        IDependencyResolver GetResolver();
        void RegisterApiControllers(Assembly assembly);
        void RegisterFilters();
        void RegisterSqlClient(string connectionString);
        void RegisterType<T>();
    }
}