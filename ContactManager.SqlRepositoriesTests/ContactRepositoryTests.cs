using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.SqlRepositories;

namespace ContactManager.SqlRepositoriesTests {

    [TestClass]
    public class ContactRepositoryTests {

        [TestMethod]
        public void GetContacts_ReturnsList() {

            var sut = new ContactRepository();

            var results = sut.GetContacts();

            Assert.IsNotNull(results);

        }

    }

}
