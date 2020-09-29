using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO
{
    public class BankCardInfoDTO
    {
        public long BankCardInfoID { get; set; }
        public int BankID { get; set; }
        public string CardNumber { get; set; }
        public int CVV { get; set; }
       
        public System.DateTime ExtendDate { get; set; }

    }
}
