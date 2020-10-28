using BusinessLogic.Interfaces;
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
using Unity;
using Unity.Resolution;

namespace TradingCompanyWF
{
    public partial class UserStartPage : Form
    {
        protected readonly ICategoryManager _categoryManager;
        protected readonly IItemManager _itemManager;
        protected readonly IOrderManager _orderManager;
        protected readonly IOrderedManager _orderedManager;
        protected readonly IOrderStatusManager _orderStatusManager;
        protected readonly IUserInfoManager _userInfoManager;
        protected readonly IApplicationUser _user;
        public UserStartPage(IApplicationUser user,
            ICategoryManager categoryManager,
            IItemManager itemManager,
            IOrderManager orderManager,
            IOrderedManager orderedManager,
            IOrderStatusManager orderStatusManager,
            IUserInfoManager userInfoManager)
        {
            InitializeComponent();
            this._user = user;
            this._itemManager = itemManager;
            this._orderManager = orderManager;
            this._orderedManager = orderedManager;
            this._orderStatusManager = orderStatusManager;
            this._userInfoManager = userInfoManager;
            InitFields();

        }
        private void InitFields()
        {
           var current = this._userInfoManager.GetUserInfoByLogin(_user.Login);
           this._user.UserId = current.UserID;
           UserName.Text = current.FirstName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Catalog cat = Program.Container.Resolve<Catalog>(new ResolverOverride[] { new ParameterOverride("user", _user) });
            cat.ShowDialog();
        }

        private void OrderHistoryButton_Click(object sender, EventArgs e)
        {

            OrderHistory orders = Program.Container.Resolve<OrderHistory>(new ResolverOverride[] { new ParameterOverride("user", _user) });
            orders.ShowDialog();
        }

        private void MyPageButton_Click(object sender, EventArgs e)
        {
           
            UserPage form = Program.Container.Resolve<UserPage>(new ResolverOverride[] { new ParameterOverride("user", _user) });
            form.ShowDialog();
        }
    }
}
