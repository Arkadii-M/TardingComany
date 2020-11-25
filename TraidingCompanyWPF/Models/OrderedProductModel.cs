using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraidingCompanyWPF.Models
{
    public class OrderedProductModel
    {
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string ItemTitle { get; set; }
        public int Amount { get; set; }
        public int UserID { get; set; }
        public string Ordernumber { get; set; }
        public DateTime Date { get; set; }
        public string StatusName { get; set; }

    }
}
