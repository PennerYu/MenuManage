using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace Penner.CommonManage.Client.Model
{
    using log4net;

    using Penner.CommonManage.Client.Utis;
    
    public class CommonModel : IHttpModule
    {
        private static ILog logger = ClientUtils.GetLogger("App.log");

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(context_Error);
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        private void context_Error(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var ex = application.Context.Server.GetLastError();
            logger.Error(ex);
            application.CompleteRequest();
            application.Context.Response.ContentType = "application/json";
            //application.Context.Response.StatusCode = 500;
            application.Context.Response.Write(JsonUtils.FormatErrorMsg(ex.Message, Constants.ServerErrorTip));
            //application.Context.Server.ClearError();
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            application.Context.Response.ContentType = "application/json";
            string auth = application.Context.Request.QueryString["platform"];
            if (string.IsNullOrEmpty(auth))
            {
                application.CompleteRequest();
                //application.Context.Response.StatusCode = 500;
                application.Context.Response.Write(JsonUtils.FormatErrorMsg(Constants.UnPlatformTip, Constants.UnPlatformTip));
            }
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;
            var filepath = context.Request.FilePath;
            var filename = Path.GetFileNameWithoutExtension(VirtualPathUtility.GetFileName(filepath));
            if (application.Context.Server.GetLastError() == null)
            {
                var value = 10;
                context.Response.Expires = value;
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetMaxAge(TimeSpan.FromMinutes(value));
            }
            else
            {
                application.Context.Server.ClearError();
                context.Response.Expires = 1;
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetMaxAge(TimeSpan.FromMinutes(1));
            }
        }
    }
}
