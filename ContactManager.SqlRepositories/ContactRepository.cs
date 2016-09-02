using CCH.BCL.Data;
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

        private readonly ISQLClient _sqlClient;

        public ContactRepository(ISQLClient sqlClient) {
            if (sqlClient == null) {
                throw new ArgumentNullException("sqlClient");
            }
            _sqlClient = sqlClient;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(int offset, int pageSize) {
            return await _sqlClient.RunSpReturnGraph<Contact>("spGetContacts", new { Offset = offset, PageSize = pageSize });
        }

        public async Task<Contact> InsertContactAsync(Contact contact) {
            return await _sqlClient.RunSpReturnSingle<Contact>("spInsertContact", new { FirstName = contact.FirstName, LastName = contact.LastName } );
        }

    }

}
