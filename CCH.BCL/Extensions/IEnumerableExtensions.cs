using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCH.BCL.Extensions {
    public static class IEnumerableExtensions {

        public static object GetResponseBody<T>(this IEnumerable<T> data, string basePath, int page, int pageSize) {

            int p = page == 0 ? 0 : page - 1;
            string prevArgs = $"?page={(page == 0 ? 0 : page - 1)}&pageSize={pageSize}";
            string nextArgs = $"?page={(data.Count() < pageSize ? page : page + 1)}&pageSize={pageSize}";

            var responseBody = new {
                data = data,
                links = new {
                    previous = basePath + prevArgs,
                    next = basePath + nextArgs
                }
            };

            return responseBody;

        }

    }
}
