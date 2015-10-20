using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Penner.MenuManage.InternalServices.Page
{
    using Penner.MenuManage.InternalServices.Utils;

    public class PagesFilter
    {
        public PagesFilter()
        {
            c = ResponseUtils.FormatIntNotNull(HttpContext.Current.Request.QueryString["c"], 200, "c");
            s = ResponseUtils.FormatIntNotNull(HttpContext.Current.Request.QueryString["s"], "s");
            MenuId = ResponseUtils.FormatIntNotNull(HttpContext.Current.Request.QueryString["id"], "id");
            CatalogId = ResponseUtils.FormatIntAllowNull(HttpContext.Current.Request.QueryString["cid"]);
        }

        public int MenuId { get; set; }

        public int CatalogId { get; set; }

        public int c { get; set; }

        public int s { get; set; }
    }
}
