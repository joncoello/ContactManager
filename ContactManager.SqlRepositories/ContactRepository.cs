using ContactManager.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.SqlRepositories {

    public class ContactRepository {

        public IEnumerable<Contact> GetContacts() {
            return new List<Contact>();
        }

    }

}
