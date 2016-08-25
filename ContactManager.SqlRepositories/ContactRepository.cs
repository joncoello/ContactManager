using ContactManager.DomainModel.Models;
using Dapper;
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
            using (var conn = new SqlConnection("server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td")) {
                await conn.OpenAsync();
                return await conn.QueryAsync<Contact>("spGetContacts", commandType: CommandType.StoredProcedure);
            }
        }

    }

}
