using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyWF.Models.Interfaces;

namespace TradingCompanyWF.Models.Concrete
{
    public class ApplicationUser : IApplicationUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
    }
}
