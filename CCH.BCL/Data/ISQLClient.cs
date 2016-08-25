using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCH.BCL.Data {
    public interface ISQLClient {
        Task<IEnumerable<T>> RunSpReturnGraph<T>(string storedProcedureName);
    }
}