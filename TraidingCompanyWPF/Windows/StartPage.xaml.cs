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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        public StartPage(StartViewModel _vm)
        {
            DataContext = _vm;
            _vm.CloseHandler += (sender, args) => { this.Close();  };
            InitializeComponent();
        }
    }
}
