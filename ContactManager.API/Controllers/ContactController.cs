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

namespace ContactManager.API.Controllers {

    /// <summary>
    /// controller for contacts
    /// </summary>
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController {

        private readonly ContactRepository _contactRepository;

        public ContactController(ContactRepository contactRepository) {
            if (contactRepository == null) {
                throw new ArgumentNullException("contactRepository");
            }
            _contactRepository = contactRepository;
        }

        [Route("")]
        public async Task<IHttpActionResult> Get() {
            var results = await _contactRepository.GetContactsAsync();
            return Ok<IEnumerable<Contact>>(results);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id) {
            var result = await _contactRepository.GetContactAsync(id);
            return Ok<Contact>(result);
        }

        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]Contact contact) {
            var result = await _contactRepository.InsertContactAsync(contact);
            return Created<Contact>("", result);
        }

    }
}
