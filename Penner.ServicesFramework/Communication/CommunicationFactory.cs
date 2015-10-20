using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ServiceModel;

namespace Penner.ServicesFramework.Communication
{
    public class CommunicationFactory : IServiceFactory
    {
        public object ServiceInit()
        {
            string configPath = string.Format("{0}/Config/CommunicationService.xml", AppDomain.CurrentDomain.BaseDirectory);
            var root = XElement.Load(configPath);
            var query = from data in root.Elements("service") select (string)data.Attribute("name");
            foreach (string service in query)
            {
                Type stype = Type.GetType(service);
                if (stype != null)
                {
                    ServiceHost host = new ServiceHost(stype);
                    host.Open();
                }
            }
            return null;
        }
    }
}
