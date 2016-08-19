using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.SqlRepositories;
using System.Threading.Tasks;

namespace ContactManager.SqlRepositoriesTests {

    [TestClass]
    public class ContactRepositoryTests {

        [TestMethod]
        public async Task GetContacts_ReturnsList() {

            var sut = new ContactRepository();

            var results = await sut.GetContactsAsync();

            Assert.IsNotNull(results);

        }

    }

}
