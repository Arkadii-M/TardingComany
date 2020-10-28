using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DalEF.Interfaces;
using DTO;

namespace DalEF.Concrete
{
    public class OrderedDalEf:IOrderedDal
    {
        private readonly IMapper _mapper;
        public OrderedDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderedDTO CreateOrdered(OrderedDTO order)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                Ordered o = _mapper.Map<Ordered>(order);
                e.Ordered.Add(o);
                e.SaveChanges();
                return _mapper.Map<OrderedDTO>(o);
            }
        }

        public bool DeleteOrdered(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var o = e.Ordered.SingleOrDefault(a => a.OrderID == id);
                if (o == null)
                {
                    return false;
                }
                e.Ordered.Remove(o);
                e.SaveChanges();
                return true;
            }
        }

        public List<OrderedDTO> GetAllOrdered()
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                return _mapper.Map<List<OrderedDTO>>(e.Ordered.ToList());
            }
        }

        public OrderedDTO GetOrderedByID(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var o = e.Ordered.SingleOrDefault(a => a.OrderID == id);
                if (o == null)
                {
                    return null;
                }
                return _mapper.Map<OrderedDTO>(o);
            }
        }

        public OrderedDTO UpdateOrdered(OrderedDTO order)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                e.Ordered.AddOrUpdate(_mapper.Map<Ordered>(order));
                e.SaveChanges();
                var o = e.Order.Single(p => p.OrderID == order.OrderID);
                return _mapper.Map<OrderedDTO>(o);
            }
        }
    }
}
