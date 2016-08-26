using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Owin.Hosting;
using ContactManager.API;
using System.Net.Http;

namespace ContactManager.APITests {

    [TestClass]
    public class ContactAPITests {

        [TestMethod]
        public void Starter() {

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
