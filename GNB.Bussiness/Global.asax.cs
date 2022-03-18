using GNB.Bussinsess.Utils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace GNB.Bussiness
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutomapperConfiguration.Configure();
            FilesOffline.GenerateFiles();
        }
    }
}
