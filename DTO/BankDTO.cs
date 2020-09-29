using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace DTO
{
    public class BankDTO
    {
        [Required]
        [Key]
        public int BankID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Swift { get; set; }
    }
}
