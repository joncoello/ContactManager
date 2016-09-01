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
        
        public override void Before(MethodInfo methodUnderTest) {

            string connectionString = ConfigurationManager.ConnectionStrings["contactManager"].ConnectionString;
            
            using (var conn = new SqlConnection(connectionString)) {

                conn.Open();

                using (var command = new SqlCommand("delete from Contact", conn)) {

                    command.ExecuteNonQuery();

                }

            }

        }

    }
}
