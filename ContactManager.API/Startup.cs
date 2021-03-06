﻿using CCH.BCL.Data;
using CCH.BCL.Infrastructure;
using CCH.BCL.Middleware;
using ContactManager.SqlRepositories;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            var config = new HttpConfiguration();

            string connectionString = ConfigurationManager.ConnectionStrings["contactManager"].ConnectionString;

            app.UseCchWebApi(
                connectionString: connectionString,
                httpConfig: config,
                controllersAssembly: this.GetType().Assembly, // loaded in to current app domain or via MEF so maybe not required?
                typesToRegister:
                    typeof(ContactRepository)
                );

            app.UseWebApi(config);
        }

    }
}