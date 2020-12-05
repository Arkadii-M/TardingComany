using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IItemManager
    {
        List<ItemDTO> GetAllItems();
        ItemDTO GetItemById(int id);

        bool DeleteItemById(int id);

        ItemDTO AddItem(ItemDTO item);
        ItemDTO UpdateItem(ItemDTO item);
    }
}
