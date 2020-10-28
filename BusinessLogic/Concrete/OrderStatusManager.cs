using BusinessLogic.Interfaces;
using DalEF.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class OrderStatusManager: IOrderStatusManager
    {
        private readonly IOrderStatusDal _orderStatusDal;
        public OrderStatusManager(IOrderStatusDal orderStatusDal)
        {
            this._orderStatusDal = orderStatusDal;
        }

        public List<OrderStatusDTO> GetAllOrderStatuses()
        {
            return this._orderStatusDal.GetAllOrderStatuses();
        }

        public OrderStatusDTO GetOrderStatusById(int id)
        {
            return this._orderStatusDal.GetOrderStatusByID(id);
        }
    }
}
