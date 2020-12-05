using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC.App.Security
{
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {

        protected virtual CustomPrincipal CurrentUser
        {
            get {
                return HttpContext.Current.User as CustomPrincipal; 
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return ((CurrentUser != null && !CurrentUser.IsInRole(Roles)) || CurrentUser == null) ? false : true;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            var returnUrl = string.Empty;

            if(filterContext.HttpContext.Request.Url != null)
            {
                returnUrl = filterContext.HttpContext.Request.Url.LocalPath;
            }
            if(CurrentUser == null)
            {
                routeData = new RedirectToRouteResult ( new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl = returnUrl }) );
            }
            else
            {
                routeData = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccesDenied"}));
            }

            filterContext.Result = routeData;
        }

    }
}