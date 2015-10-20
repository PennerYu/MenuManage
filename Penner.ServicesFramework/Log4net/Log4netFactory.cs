using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Penner.ServicesFramework.Log4net
{
    public class Log4netFactory : IServiceFactory
    {
        public object ServiceInit()
        {
            string xmlPath = string.Format("{0}/Config/log.config", AppDomain.CurrentDomain.BaseDirectory);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(xmlPath));
            return null;
        }
    }
}
