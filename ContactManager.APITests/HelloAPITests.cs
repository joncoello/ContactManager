using ContactManager.API;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.APITests {

    [TestClass]
    public class HelloAPITests {

        [TestMethod]
        public void API_Hello_Get() {

            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress)) {

                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/hello").Result;

                var result = response.Content.ReadAsStringAsync().Result;

                Assert.AreEqual("\"hello world\"", result);

            }

        }

    }
}
