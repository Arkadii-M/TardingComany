using AutoMapper;
using DalEF.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalEF.Concrete
{
   public  class OrderStatusDalEf : IOrderStatusDal
    {
        private readonly IMapper _mapper;
        public OrderStatusDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }
        public OrderStatusDTO CreateOrderStatus(OrderStatusDTO status)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                OrderStatus o = _mapper.Map<OrderStatus>(status);
                e.OrderStatus.Add(o);
                e.SaveChanges();
                return _mapper.Map<OrderStatusDTO>(o);
            }
        }

        public bool DeleteOrderStatus(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var o = e.OrderStatus.SingleOrDefault(a => a.StatusID == id);
                if (o == null)
                {
                    return false;
                }
                e.OrderStatus.Remove(o);
                e.SaveChanges();
                return true;
            }
        }

        public List<OrderStatusDTO> GetAllOrderStatuses()
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                return _mapper.Map<List<OrderStatusDTO>>(e.OrderStatus.ToList());
            }
        }

        public OrderStatusDTO GetOrderStatusByID(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var o = e.OrderStatus.SingleOrDefault(a => a.StatusID == id);
                if (o == null)
                {
                    return null;
                }
                return _mapper.Map<OrderStatusDTO>(o);
            }
        }

        public OrderStatusDTO UpdateOrderStatus(OrderStatusDTO status)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                e.OrderStatus.AddOrUpdate(_mapper.Map<OrderStatus>(status));
                e.SaveChanges();
                var o = e.OrderStatus.Single(p => p.StatusID == status.StatusID);
                return _mapper.Map<OrderStatusDTO>(o);
            }
        }
    }
}
