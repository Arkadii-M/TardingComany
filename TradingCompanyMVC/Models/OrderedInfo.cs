using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingCompanyMVC.Models
{
    public class OrderedInfo
    {
        public int ItemID { get; set; }
        public string ItemTitle { get; set; }
        public int Amount { get; set; }
    }
}