using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompanyWF.Models.Interfaces;

namespace TradingCompanyWF
{
    public partial class OrderHistory : Form
    {
        protected readonly ICategoryManager _categoryManager;
        protected readonly IItemManager _itemManager;
        protected readonly IOrderManager _orderManager;
        protected readonly IOrderedManager _orderedManager;
        protected readonly IOrderStatusManager _orderStatusManager;
        protected readonly IApplicationUser _user;
        protected BindingList<OrderDTO> blOrders;
        public OrderHistory(IApplicationUser user,
            ICategoryManager categoryManager,
            IItemManager itemManager,
            IOrderManager orderManager,
            IOrderedManager orderedManager,
            IOrderStatusManager orderStatusManager
            )
        {
            this._user = user;
            this._itemManager = itemManager;
            this._orderManager = orderManager;
            this._orderedManager = orderedManager;
            this._orderStatusManager = orderStatusManager;
            InitializeComponent();
            initData();
            RefreshGrid();
        }
        private void initData()
        {
            var _orders = _orderManager.GetAllOrdersByUserId(this._user.UserId);
            blOrders = new BindingList<OrderDTO>(_orders);
            OrdersBindingSource.DataSource = blOrders;
        }
        private void RefreshGrid()
        {
            OrdersNavigator.BindingSource = OrdersBindingSource;
            OrdersGridView.DataSource = OrdersBindingSource;
        }
    }
}
