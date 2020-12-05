using AutoMapper;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingCompanyMVC.App.Security;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderManager _orderManager;
        private readonly IItemManager _itemManager;
        private readonly IOrderStatusManager _orderStatusManager;
        private readonly IOrderedManager _orderedManager;
        public OrderController(IMapper mapper,
            IOrderManager orderManager,
            IItemManager itemManager,
            IOrderStatusManager orderStatusManager,
            IOrderedManager orderedManager)
        {
            _mapper = mapper;
            _orderManager = orderManager;
            _itemManager = itemManager;
            _orderManager = orderManager;
            _orderedManager = orderedManager;
            _orderStatusManager = orderStatusManager;

        }
        // GET: Order
        [CustomAuthorize(Roles ="User")]
        public ActionResult Index()
        {   
            var user = HttpContext.User as CustomPrincipal;
            var orders = _orderManager.GetAllOrdersByUserId(user.UserID);

           
            return View(orders);
        }

        // GET: Order/Details/5
        [CustomAuthorize(Roles = "User")]
        public ActionResult Details(int id)
        {

            FullOrderInfo order = _mapper.Map<FullOrderInfo>(this._orderManager.GetOrderById(id));
            order.OrderedProducts = new List<OrderedInfo>();

            order.StatusName = this._orderStatusManager.GetOrderStatusById(order.StatusID).Name;

            var all_ordered = _orderedManager.GetOrderedListById(order.OrderID);

            OrderedInfo temp;
            foreach (var o in all_ordered)
            {
                temp = _mapper.Map<OrderedInfo>(o);
                
                temp.ItemTitle = _itemManager.GetItemById(temp.ItemID).ItemTitle;
                order.OrderedProducts.Add(temp);
            }


            return View(order);
        }
       
    }
}
