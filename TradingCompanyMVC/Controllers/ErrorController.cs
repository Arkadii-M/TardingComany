using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradingCompanyMVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccesDenied()
        {
            return View();
        }
    }
}