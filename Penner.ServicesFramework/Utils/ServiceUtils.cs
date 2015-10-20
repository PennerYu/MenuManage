using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.ServicesFramework.Utils
{
    using log4net;

    public static class ServiceUtils
    {
        public static ILog GetLogger(string name)
        {
            log4net.Config.XmlConfigurator.Configure();
            return LogManager.GetLogger(name);
        }
    }
}
