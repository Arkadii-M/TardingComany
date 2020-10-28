using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DalEF.Interfaces
{
    public interface IItemDal
    {
        ItemDTO GetItemByID(int id);
        List<ItemDTO> GetAllItems();
        ItemDTO CreateItem(ItemDTO item);
        ItemDTO UpdateItem(ItemDTO item);
        bool DeleteItem(int id);
    }
}
