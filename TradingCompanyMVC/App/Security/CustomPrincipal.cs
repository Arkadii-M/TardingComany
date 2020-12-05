using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace TradingCompanyMVC.App.Security
{
    public class CustomPrincipal : IPrincipal
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string[] Roles { get; set; }
        public IIdentity Identity
        {
            get;
            set;
        }


        public bool IsInRole(string role)
        {
            if(Roles.Any(r => r.Contains(role)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}