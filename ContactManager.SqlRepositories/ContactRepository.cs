using ContactManager.DomainModel.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.SqlRepositories {

    public class ContactRepository {

        public IEnumerable<Contact> GetContacts() {
            using (var conn = new SqlConnection("server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td")) {
                conn.Open();
                return conn.Query<Contact>("select * from contact");
            }
        }

    }

}
