using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.InternalServices.Catalog
{
    public interface ICatalogs
    {
        string MenuCatalog(CatalogFilter filter);
    }
}
