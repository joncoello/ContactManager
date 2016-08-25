using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCH.BCL.Data {
    public class SQLClient : ISQLClient {

        private readonly string _connectionString;

        public SQLClient(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> RunSpReturnGraph<T>(string storedProcedureName) {
            using (var conn = new SqlConnection(_connectionString)) {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<T> RunSpReturnSingle<T>(string storedProcedureName, object parameters) {
            using (var conn = new SqlConnection(_connectionString)) {
                await conn.OpenAsync();
                return conn.QuerySingle<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure, param: parameters);
            }
        }

    }
}
