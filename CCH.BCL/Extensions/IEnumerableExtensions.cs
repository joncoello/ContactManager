using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCH.BCL.Extensions {
    public static class IEnumerableExtensions {

        public static object GetResponseBody<T>(this IEnumerable<T> data, string basePath, int page, int pageSize) {

            int prevPage = page == 0 ? 0 : page - 1;

            // if the row count is less than page size assume this is the last page
            int nextPage = data.Count() < pageSize ? page : page + 1;

            string prevArgs = $"?page={prevPage}&pageSize={pageSize}";
            string nextArgs = $"?page={nextPage}&pageSize={pageSize}";

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
