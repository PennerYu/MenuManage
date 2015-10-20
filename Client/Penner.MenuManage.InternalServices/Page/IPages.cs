using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.InternalServices.Page
{
    public interface IPages
    {
        string MenuPages(PagesFilter filter);
    }
}
