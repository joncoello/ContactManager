using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CCH.BCL.Data {

    /// <summary>
    /// transient fault sql client
    /// </summary>
    public class TransientFaultHandlingSQLClient : ISQLClient {

        static public List<int> TransientErrorNumbers =
          new List<int> { 4060, 40197, 40501, 40613,
          49918, 49919, 49920, 11001 };

        private readonly ISQLClient _client;

        public TransientFaultHandlingSQLClient(ISQLClient client) {
            _client = client;
        }

        public async Task<IEnumerable<T>> RunSpReturnGraph<T>(string storedProcedureName, object parameters) where T : class {
            return await RunMethodWithTransintProtection<IEnumerable<T>>(async () =>
                await _client.RunSpReturnGraph<T>(storedProcedureName, parameters)
                );
        }

        public async Task<T> RunSpReturnSingle<T>(string storedProcedureName, object parameters) where T : class {
            return await RunMethodWithTransintProtection<T>(async () =>
                await _client.RunSpReturnSingle<T>(storedProcedureName, parameters)
                );
        }

        private async Task<T> RunMethodWithTransintProtection<T>(Func<Task<T>> method) where T : class {

            T result = null;

            int totalNumberOfTimesToTry = 4;
            int retryIntervalSeconds = 10;

            for (int tries = 1; tries <= totalNumberOfTimesToTry; tries++) {

                try {
                    if (tries > 1) {
                        Console.WriteLine
                          ("Transient error encountered. Will begin attempt number {0} of {1} max...",
                          tries, totalNumberOfTimesToTry
                          );
                        Thread.Sleep(1000 * retryIntervalSeconds);
                        retryIntervalSeconds = Convert.ToInt32
                          (retryIntervalSeconds * 1.5);
                    }
                    result = await method();
                    break;
                }

                catch (SqlException sqlExc) {
                    if (TransientErrorNumbers.Contains
                      (sqlExc.Number) == true) {
                        //Console.WriteLine("{0}: transient occurred.", sqlExc.Number);
                        continue;
                    } else {
                        throw;
                    }
                }

                catch (Exception Exc) {
                    Console.WriteLine(Exc);
                    throw;
                }

            }

            if (result == null) {
                throw new Exception("too many transient faults");
            }

            return result;

        }

    }
}
