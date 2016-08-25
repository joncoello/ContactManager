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

        private readonly ContactRepository _contactRepository;

        public ContactController(ContactRepository contactRepository) {
            if (contactRepository == null) {
                throw new ArgumentNullException("contactRepository");
            }
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> Get() {

            var results = await _contactRepository.GetContactsAsync();

            return results;
        }

    }
}
