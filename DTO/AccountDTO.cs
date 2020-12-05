using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace DTO
{
    public class AccountDTO
    {
        [Required]
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public Byte[] UserPassword { get; set; }
        [Required]
        public string Salt { get; set; }

        public List<PrivilegeDTO> Privileges {get;set;}
    }
}
