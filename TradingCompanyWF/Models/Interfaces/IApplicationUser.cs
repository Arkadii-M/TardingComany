using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyWF.Models.Interfaces
{
    public interface IApplicationUser
    {
        int UserId { get; set; }
        string Login { get; set; }
    }
}
