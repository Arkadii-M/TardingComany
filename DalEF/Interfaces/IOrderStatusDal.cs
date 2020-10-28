using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DalEF.Interfaces
{
    public interface IOrderStatusDal
    {
        OrderStatusDTO GetOrderStatusByID(int id);
        List<OrderStatusDTO> GetAllOrderStatuses();
        OrderStatusDTO CreateOrderStatus(OrderStatusDTO status);
        OrderStatusDTO UpdateOrderStatus(OrderStatusDTO status);
        bool DeleteOrderStatus(int id);
    }
}
