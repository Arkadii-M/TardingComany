using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DalEF.Interfaces;
using DTO;

namespace BusinessLogic.Concrete
{
    public class ItemManager:IItemManager
    {
        private readonly IItemDal _itemDal;
        public ItemManager(IItemDal itemDal)
        {
            _itemDal = itemDal;
        }

        public List<ItemDTO> GetAllItems()
        {
            return this._itemDal.GetAllItems();
        }
    }
}
