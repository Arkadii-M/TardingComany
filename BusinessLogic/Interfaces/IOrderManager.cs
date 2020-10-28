using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IOrderManager
    {
        List<OrderDTO> GetAllOrders();
        List<OrderDTO> GetAllOrdersByUserId(int id);
        void SetOrderStatus(int OrderStatusId, int OrderId);
    }
}
