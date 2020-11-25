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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly LoginViewModel _loginViewModel;
        public Login(LoginViewModel loginViewModel)
        {
            this._loginViewModel = loginViewModel;
            DataContext = _loginViewModel;

            loginViewModel.CloseHandlerOk += (sender, args) => {
                DialogResult = true;
                this.Close();  };

            loginViewModel.CloseHandlerCancel += (sender, args) => {
                DialogResult = false;
                this.Close();
            };

            InitializeComponent();
        }
    }
}
