using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Penner.MenuManage.InternalServices.Catalog
{
    using Penner.MenuManage.InternalServices.Utils;

    public class CatalogFilter : FilterBase
    {
        public CatalogFilter()
        {
            if (HttpContext.Current != null)
            {
                MenuId = ResponseUtils.FormatIntNotNull(HttpContext.Current.Request.QueryString["id"], "id");
            }
        }

        public int MenuId { get; set; }
    }
}
