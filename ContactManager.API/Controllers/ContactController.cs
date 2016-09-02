using CCH.BCL.Data;
using CCH.BCL.Extensions;
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
        public async Task<IHttpActionResult> Get(int page = 0, int pageSize = 20) {

            int offset = page * pageSize;
            var results = await _contactRepository.GetContactsAsync(offset, pageSize);
            
            var responseBody = results.GetResponseBody(Request.RequestUri.AbsolutePath, page, pageSize);

            return Ok(responseBody);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id) {
            var results = await _contactRepository.GetContactsAsync(0, 20);
            return Ok<Contact>(results.FirstOrDefault(c => c.ContactID == id));
        }

        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]Contact contact) {
            var result = await _contactRepository.InsertContactAsync(contact);
            return Created<Contact>("", result);
        }
        
    }

}
