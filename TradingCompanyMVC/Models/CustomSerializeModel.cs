using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingCompanyMVC.Models
{
    public class CustomSerializeModel
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public List<string> Roles { get; set; }
    }
}