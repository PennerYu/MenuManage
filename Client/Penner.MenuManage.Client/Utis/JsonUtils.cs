using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.CommonManage.Client.Utis
{
    public static class JsonUtils
    {
        public static string FormatErrorMsg(string msg, string userMsg)
        {
            return string.Format("{{\"error\":{{\"msg\":\"{0}\",\"usermsg\":\"{1}\"}}}}", msg, userMsg);
        }
    }
}
