using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CCH.BCL.Infrastructure {

    /// <summary>
    /// Factory to create IoC container so we can control which IoC framework is used
    /// </summary>
    public class IocContainerFactory {
        public IIocContainer Create(HttpConfiguration config) {
            return new IocContainer(config);
        }
    }
}
