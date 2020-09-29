using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AdressDTO
    {
        public long AdressID { get; set; }
        public int CountryID { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
