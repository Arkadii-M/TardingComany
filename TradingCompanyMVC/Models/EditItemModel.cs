using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradingCompanyMVC.Models
{
    public class EditItemModel
    {
        [DisplayName("Item id")]
        public int ItemID { get; set; }
        [DisplayName("Title")]
        public string ItemTitle { get; set; }
        [DisplayName("Categories")]
        public List<SelectListItem> Categories { get; set; }
        public int CategoryID { get; set; }
        [DisplayName("Price")]
        public int Price { get; set; }
        [DisplayName("In stock")]
        public int InStock { get; set; }
    }
}