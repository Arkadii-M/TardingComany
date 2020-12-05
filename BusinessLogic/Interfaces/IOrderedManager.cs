using DalEF;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IOrderedManager
    {
        List<OrderedDTO> GetAllOrderedItems();

        List<OrderedDTO> GetOrderedListById(int id);
        OrderedDTO GetOrderedById(int id);
    }
}
