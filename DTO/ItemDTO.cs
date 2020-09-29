using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ItemDTO
    {
        public int ItemID { get; set; }
        public string ItemTitle { get; set; }

        public int CategoryID { get; set; }

        public int Price { get; set; }

        public int InStock { get; set; }
    }
}
