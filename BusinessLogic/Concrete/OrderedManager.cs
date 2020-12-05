using BusinessLogic.Interfaces;
using DalEF;
using DalEF.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class OrderedManager : IOrderedManager
    {
        private readonly IOrderedDal _orderedDal;
        public OrderedManager(IOrderedDal orderedDal)
        {
            this._orderedDal = orderedDal;
        }
        public List<OrderedDTO> GetAllOrderedItems()
        {
            return this._orderedDal.GetAllOrdered();
        }

        public OrderedDTO GetOrderedById(int id)
        {
            return this._orderedDal.GetOrderedByID(id);
        }

        public List<OrderedDTO> GetOrderedListById(int id)
        {
            return this._orderedDal.GetOrderedListByID(id);
        }
    }
}
