using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string Ordernumber { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int StatusID { get; set; }
        public string Comment { get; set; }

    }
}
