//using System;
//using Microsoft.Owin.Hosting;
//using ContactManager.API;
//using System.Net.Http;
//using Xunit;
////using CCH.BCL.Test;
//using System.Net;
//using Newtonsoft.Json;
//using ContactManager.DomainModel.Models;
//using System.Configuration;

//namespace ContactManager.APITests {
    
//    public class ContactAPITests {

//        [Fact, UseDatabase]
//        public void API_Contact_CreateThenGet() {

//            string baseAddress = "http://localhost:9000/";

//            using (WebApp.Start<Startup>(baseAddress)) {

//                var client = new HttpClient();

//                // create
//                var newContact = new Contact {
//                    FirstName = "Greg",
//                    LastName = "Francis"
//                };

//                var json = JsonConvert.SerializeObject(newContact);

//                var response = client.PostAsync(baseAddress + "api/contact", new StringContent(json, System.Text.ASCIIEncoding.ASCII, "application/json")).Result;

//                Assert.Equal(HttpStatusCode.Created, response.StatusCode);

//                var createdJson = response.Content.ReadAsStringAsync().Result;

//                var createdContact = JsonConvert.DeserializeObject<Contact>(createdJson);

//                // get
//                var getResponse = client.GetAsync(baseAddress + "api/contact/" + createdContact.ContactID.ToString()).Result;

//                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

//                var getJson = getResponse.Content.ReadAsStringAsync().Result;

//                // test
//                Assert.Equal(createdJson, getJson);

//            }

//        }

//    }

//}
