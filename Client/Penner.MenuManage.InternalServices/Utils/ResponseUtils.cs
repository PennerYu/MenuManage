using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Penner.MenuManage.InternalServices.Utils
{
    using Penner.CommonManage.Client.Handler;

    public static class ResponseUtils
    {
        public static int FormatIntNotNull(string source, string name)
        {
            int fsource = 0;
            if (!int.TryParse(source, out fsource) || fsource <= 0)
            {
                var error = string.Format("输入的参数{0}非法或为空", name);
                ResponseError(error, error);
            }
            return fsource;
        }

        public static int FormatIntNotNull(string source, int maxValue, string name)
        {
            int fsource = 0;
            if (!int.TryParse(source, out fsource) || fsource <= 0)
            {
                var error = string.Format("输入的参数{0}非法或为空", name);
                ResponseError(error, error);
            }
            if (fsource > maxValue)
                return maxValue;
            return fsource;
        }

        public static int FormatIntAllowNull(string source)
        {
            int fsource;
            if (!int.TryParse(source, out fsource) || fsource < 0)
                return 0;
            return fsource;
        }

        public static int FormatIntAllowNull(string source, int maxValue)
        {
            int fsource = 0;
            int.TryParse(source, out fsource);
            if (fsource > maxValue)
                return maxValue;
            return fsource;
        }

        public static string FormatStringNotNull(string source, string name)
        {
            if (string.IsNullOrEmpty(source))
            {
                var error = string.Format("输入的参数{0}非法或为空", name);
                ResponseError(error, error);
            }
            return source;
        }

        public static void ResponseError(string error, string userError)
        {
            HttpContext.Current.Server.Transfer(new ErrorHandler(error, userError), false);
        }
    }
}
