using System;
using Microsoft.Owin.Hosting;
using ContactManager.API;
using System.Net.Http;
using Xunit;
using CCH.BCL.Test;

namespace ContactManager.APITests {
    
    public class ContactAPITests {

        [Fact, UseDatabase]
        public void API_Contact_Get() {

            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress)) {

                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/contact").Result;

                var result = response.Content.ReadAsStringAsync().Result;

                Assert.Equal("\"hello world\"", result);

            }

        }

    }

}
