using CCH.BCL.Data;
using ContactManager.DomainModel.Models;
using ContactManager.SqlRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactManager.API.Controllers
{
    [Route("api/contact")]
    public class ContactController : ApiController
    {
        public async Task<IEnumerable<Contact>> Get() {

            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";

            var sqlClient = new SQLClient(connectionString);

            var sut = new ContactRepository(sqlClient);

            var results = await sut.GetContactsAsync();

            return results;
        }

    }
}
