﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CCH.BCL.Data {

    /// <summary>
    /// main interface for client to SQL
    /// </summary>
    public interface ISQLClient {
        Task<IEnumerable<T>> RunSpReturnGraph<T>(string storedProcedureName);
        Task<T> RunSpReturnSingle<T>(string storedProcedureName, object parameters);
    }
}