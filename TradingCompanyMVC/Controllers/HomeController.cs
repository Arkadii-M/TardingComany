using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TradingCompanyMVC.App.Security;

namespace TradingCompanyMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Item", action = "Index" }));
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}