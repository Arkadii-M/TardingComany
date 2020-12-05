using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using TradingCompanyMVC.App.Security;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_PostAuthenticateRequest(Object sender,EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["SecurityCookie"];
            if(authCookie != null)
            {
                FormsAuthenticationTicket authTicket =FormsAuthentication.Decrypt(authCookie.Value);

                var serealizedModel = JsonConvert.DeserializeObject<CustomSerializeModel>(authTicket.UserData);


                CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

                principal.UserID = serealizedModel.UserID;
                principal.UserName = serealizedModel.Login;
                principal.Roles = serealizedModel.Roles.ToArray();

                HttpContext.Current.User = principal;
            }

        }
        
    }
}
