using CCH.BCL.Test;
using ContactManager.API;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactManager.APITests {

    public class HelloAPITests {

        [Fact, UseDatabase]
        public void API_Hello_Get() {

            string baseAddress = "http://localhost:9001/";

            using (WebApp.Start<Startup>(baseAddress)) {

                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/hello").Result;

                var result = response.Content.ReadAsStringAsync().Result;

                Assert.Equal("\"hello world\"", result);

            }

        }

    }
}
