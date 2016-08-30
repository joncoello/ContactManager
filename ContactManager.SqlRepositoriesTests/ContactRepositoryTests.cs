using System;
using ContactManager.SqlRepositories;
using System.Threading.Tasks;
using CCH.BCL.Data;
using Xunit;

namespace ContactManager.SqlRepositoriesTests {

    public class ContactRepositoryTests {

        [Fact]
        public async Task Repo_GetContacts_ReturnsList() {

            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";

            var sqlClient = new CCH.BCL.Data.SQLClient(connectionString);

            var sut = new ContactRepository(sqlClient);

            var results = await sut.GetContactsAsync();

            Assert.NotNull(results);

        }

        [Fact]
        public async Task Repo_InsertContact_UpdatesID() {

            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";

            var sqlClient = new CCH.BCL.Data.SQLClient(connectionString);

            var sut = new ContactRepository(sqlClient);

            var result = await sut.InsertContactAsync(new DomainModel.Models.Contact() {
                FirstName = "Brian",
                LastName = "White"
            });

            Assert.NotEqual(0, result.ContactID);

        }

    }

}
