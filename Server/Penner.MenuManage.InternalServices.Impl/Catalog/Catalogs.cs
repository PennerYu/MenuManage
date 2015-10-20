using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.InternalServices.Impl.Catalog
{
    using Penner.MenuManage.Core.Entity;
    using Penner.MenuManage.InternalServices.Catalog;

    using Penner.NHibernateActiveRecord;
    using Penner.NHibernateActiveRecord.Query;

    public class Catalogs : ICatalogs
    {
        public string MenuCatalog(CatalogFilter filter)
        {
            try
            {
                var hql = string.Format("from CatalogInfo c where c.MenuId = {0}", filter.MenuId);
                var catalogs = CatalogInfo.Execute(new HqlReadQuery<CatalogInfo>(hql)) as IList<CatalogInfo>;

                var builder = new StringBuilder(100);
                builder.Append("{\"catalogs\": [");

                foreach (var catalog in catalogs)
                {
                    builder.AppendFormat("{{\"id\":\"{0}\",\"name\":\"{1}\"}},", catalog.Id, catalog.Name);
                }
                if (catalogs.Count > 0)
                    builder.Remove(builder.Length - 1, 1);
                builder.Append("]}");
                return builder.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
