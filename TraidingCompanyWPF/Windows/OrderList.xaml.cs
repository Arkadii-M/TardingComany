using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TraidingCompanyWPF.ViewModels;

namespace TraidingCompanyWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Window
    {
        public OrderList(OrdersViewModel _vm)
        {
            DataContext = _vm;
            InitializeComponent();

            _vm.MyView = (CollectionViewSource)(Resources["OrderCollection"]);
            _vm.MyView.Filter += _vm.TextFilter;
            txtFilter.TextChanged += _vm.TextChanged;
        }
    }
}
