using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraidingCompanyWPF.Models;

namespace TraidingCompanyWPF.ViewModels
{
    public  class OrderDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private ApplicationUser _user;
        private readonly IOrderManager _orderManager;
        private readonly IOrderedManager _orderedManager;
        private readonly IItemManager _itemManager;
        private readonly IOrderStatusManager _statusManager;
        private readonly ICategoryManager _categoryManager;
        private OrderDTO _Order;
        public OrderDTO Order { get { return _Order; } private set { _Order=value; } }
        private ItemDTO _Item;
        public ItemDTO Item { get { return _Item; } private set { _Item = value; } }
        private OrderStatusDTO _Status;
        public OrderStatusDTO Status { get { return _Status; } private set { _Status = value; } }

        private OrderedDTO _Ordered;
        public OrderedDTO Ordered { get { return _Ordered; } private set { _Ordered = value; } }
        public OrderDetailsViewModel(IOrderManager orderManager,IOrderedManager orderedManager,IItemManager itemManager,IOrderStatusManager statusManager,ICategoryManager categoryManager, ApplicationUser user,OrderDTO order)
        {
            _orderManager = orderManager;
            _orderedManager = orderedManager;
            _itemManager = itemManager;
            _statusManager = statusManager;
            _categoryManager = categoryManager;
            Order = order;
            _user = user;
            Init();
        }
        private void Init()
        {
            Ordered = _orderedManager.GetOrderedById(Order.OrderID);
            Item = _itemManager.GetItemById(Ordered.ItemID);
            Status = _statusManager.GetOrderStatusById(Order.StatusID);
        }


    }
}
