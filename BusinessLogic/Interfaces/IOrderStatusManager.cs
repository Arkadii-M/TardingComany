using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IOrderStatusManager
    {
        List<OrderStatusDTO> GetAllOrderStatuses();
        OrderStatusDTO GetOrderStatusById(int id);
    }
}
