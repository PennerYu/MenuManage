using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Penner.CommonManage.Client.Handler
{
    using log4net;

    using Penner.CommonManage.Client.Utis;

    public class ErrorHandler : Page
    {
        private string _error;
        private string _usrError;

        private static ILog logger = ClientUtils.GetLogger("App.log");

        public ErrorHandler(string error, string usrError)
        {
            _error = error;
            _usrError = usrError;
        }

        public override void ProcessRequest(System.Web.HttpContext context)
        {
            logger.Error(_error);
            //context.Response.StatusCode = 500;
            context.Response.Write(JsonUtils.FormatErrorMsg(_error, _usrError));
        }
    }
}
