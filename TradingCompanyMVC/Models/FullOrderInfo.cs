using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingCompanyMVC.Models
{
    public class FullOrderInfo
    {
        public int OrderID { get; set; }
        public string Ordernumber { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string Comment { get; set; }


        public List<OrderedInfo> OrderedProducts { get; set; }
    }
}