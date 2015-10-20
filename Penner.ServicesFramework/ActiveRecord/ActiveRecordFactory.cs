using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Linq;

namespace Penner.ServicesFramework.ActiveRecord
{
    using Castle.ActiveRecord;
    using Castle.ActiveRecord.Framework;
    using Castle.ActiveRecord.Framework.Config;

    public class ActiveRecordFactory : IServiceFactory
    {
        public object ServiceInit()
        {
            string configPath = string.Format("{0}/Config/Appconfig.xml", AppDomain.CurrentDomain.BaseDirectory);
            string assemblyPath = string.Format("{0}/Config/ActiveRecordAssemblies.xml", AppDomain.CurrentDomain.BaseDirectory);
            IConfigurationSource source = new XmlConfigurationSource(configPath);
            Assembly[] assemblies = LoadAssemblies(assemblyPath);
            ActiveRecordStarter.Initialize(assemblies, source);
            return null;
        }

        private Assembly[] LoadAssemblies(string file)
        {
            XElement root = XElement.Load(file);
            var query = from data in root.Elements("assembly") select (string)data.Attribute("name");
            List<Assembly> assemblies = new List<Assembly>();
            foreach (var name in query)
            {
                assemblies.Add(Assembly.Load(name));
            }
            return assemblies.ToArray();
        }
    }
}
