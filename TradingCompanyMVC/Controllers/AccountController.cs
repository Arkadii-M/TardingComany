using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TradingCompanyMVC.App.Security;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("SecurityCookie", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home",null);

        }


        // GET: Account
        [HttpGet]
        public ActionResult Login(string returnUrl= "")
        {
            if(User.Identity.IsAuthenticated)
            {
                return LogOut();
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginModel());

        }
        [HttpPost]
        public ActionResult Login(LoginModel model,string returnUrl = "")
        {
            if(ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Login, model.Password))
                {

                    var user = (CustomMembershipUser)Membership.GetUser(model.Login, false);
                    if (user != null)
                    {
                        CustomSerializeModel userModel = new CustomSerializeModel()
                        {
                            UserID = user.UserID,

                            Login = user.UserName,
                            Roles = user.Roles.Select(r => r.Name).ToList()
                        };
                        string UserData = JsonConvert.SerializeObject(userModel);

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.Login, DateTime.Now, DateTime.Now.AddMinutes(20), false, UserData);
                        string enTicket = FormsAuthentication.Encrypt(authTicket);

                        HttpCookie faCookie = new HttpCookie("SecurityCookie", enTicket);
                        Response.Cookies.Add(faCookie);


                    }

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login or password");
            return View(model);

        }
    }

}