using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CCH.BCL.Infrastructure {
    public class IocContainerFactory {
        public IIocContainer Create(HttpConfiguration config) {
            return new IocContainer(config);
        }
    }
}
