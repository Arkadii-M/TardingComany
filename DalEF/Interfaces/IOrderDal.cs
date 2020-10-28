using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DalEF.Interfaces
{
    public interface IOrderDal
    {
        OrderDTO GetOrderByID(int id);
        List<OrderDTO> GetAllOrders();
        OrderDTO CreateOrder(OrderDTO order);
        OrderDTO UpdateOrder(OrderDTO order);
        bool DeleteOrder(int id);
    }
}
