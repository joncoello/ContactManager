using CCH.BCL.Data;
using CCH.BCL.Infrastructure;
using CCH.BCL.Middleware;
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

            app.UseCchWebApi(config, this.GetType().Assembly, typeof(ContactRepository));

            app.UseWebApi(config);  
     
        }

    }
}