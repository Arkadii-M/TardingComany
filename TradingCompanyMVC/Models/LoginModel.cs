using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradingCompanyMVC.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Login")]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public string Login {get;set;}

        [Required]
        [DisplayName("Password")]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public string Password { get; set; }

    }
}