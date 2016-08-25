using ContactManager.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.SqlRepositories {

    public class ContactRepository {

        public async Task<IEnumerable<Contact>> GetContactsAsync() {
            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";
            var client = new CCH.BCL.Data.SQLClient(connectionString);
            return await client.RunSpReturnGraph<Contact>("spGetContacts");
        }

    }

}
