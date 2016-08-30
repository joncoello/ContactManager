using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace CCH.BCL.Test {
    public class UseDatabaseAttribute : BeforeAfterTestAttribute {

        public override void Before(MethodInfo methodUnderTest) {

            string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";
            using (var conn = new SqlConnection(connectionString)) {

                conn.Open();

                using (var command = new SqlCommand("delete from Contact", conn)) {

                    command.ExecuteNonQuery();

                }

            }

        }

    }
}
