using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace CCH.BCL.Test {

    /// <summary>
    /// test attribute to use test database
    /// </summary>
    public class UseDatabaseAttribute : BeforeAfterTestAttribute {
        
        public async override void Before(MethodInfo methodUnderTest) {

            string connectionString = ConfigurationManager.ConnectionStrings["contactManager"].ConnectionString;
            
            using (var conn = new SqlConnection(connectionString)) {

                await conn.OpenAsync();

                // delete data
                using (var command = new SqlCommand("delete from Contact", conn)) {
                    await command.ExecuteNonQueryAsync();
                }

                //insert test data
                string sql = CCH.BCL.Properties.Resources.InsertContactData;
                using (var command = new SqlCommand(sql, conn)) {
                    await command.ExecuteNonQueryAsync();
                }

            }

        }

    }
}
