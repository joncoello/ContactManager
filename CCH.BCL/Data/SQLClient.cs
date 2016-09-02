using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCH.BCL.Data {

    /// <summary>
    /// Sql client ussing dapper
    /// </summary>
    public class SQLClient : ISQLClient {

        private readonly string _connectionString;

        public SQLClient(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> RunSpReturnGraph<T>(string storedProcedureName, object parameters) {
            using (var conn = new SqlConnection(_connectionString)) {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure, param: parameters);
            }
        }

        public async Task<T> RunSpReturnSingle<T>(string storedProcedureName, object parameters) {
            using (var conn = new SqlConnection(_connectionString)) {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure, param: parameters);
            }
        }

    }
}
