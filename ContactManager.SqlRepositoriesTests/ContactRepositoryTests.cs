using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.SqlRepositories;
using System.Threading.Tasks;
using CCH.BCL.Data;

namespace ContactManager.SqlRepositoriesTests {

    [TestClass]
    public class ContactRepositoryTests {

        [TestMethod]
        public async Task GetContacts_ReturnsList() {

            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";

            var sqlClient = new CCH.BCL.Data.SQLClient(connectionString);

            var sut = new ContactRepository(sqlClient);

            var results = await sut.GetContactsAsync();

            Assert.IsNotNull(results);

        }

        [TestMethod]
        public async Task InsertContact_UpdatesID() {

            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";

            var sqlClient = new CCH.BCL.Data.SQLClient(connectionString);

            var sut = new ContactRepository(sqlClient);

            var result = await sut.InsertContactAsync(new DomainModel.Models.Contact() {
                FirstName = "Brian",
                LastName = "White"
            });

            Assert.AreNotEqual(0, result.ContactID);

        }

    }

}
