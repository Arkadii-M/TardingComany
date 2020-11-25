using BusinessLogic;
using BusinessLogic.Interfaces;
using NLog.Fluent;
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
    public partial class LoginForm : Form
    {
        protected readonly IAuthManager _manager;
        protected readonly IRegisterManager _registerManager;
        protected readonly IAdressManager _adressManager;
        protected readonly IBankManager _bankManager;
        protected readonly ICountryManager _countryManager;
        protected readonly IApplicationUser _user;
        protected readonly IUserInfoManager _userInfoManager;
        public LoginForm(IAuthManager manager, IRegisterManager registerManager, IAdressManager adressManager, IBankManager bankManager, ICountryManager countryManager,IUserInfoManager userInfoManager,IApplicationUser user)
        {
            InitializeComponent();
            _manager = manager;
            this._registerManager = registerManager;
            this._adressManager = adressManager;
            this._bankManager = bankManager;
            this._countryManager = countryManager;
            this._user = user;
            this._userInfoManager = userInfoManager;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            doLogin();
        }
        private void doLogin()
        {
            try
            {


                if (_manager.Login(Login.Text, Password.Text))
                {
                    this._user.Login = Login.Text;
                    this._user.UserId = this._userInfoManager.GetUserInfoByLogin(Login.Text).UserID;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    Program.log.Warn("Logined failed. Login: {0}", (string)Login.Text);
                    MessageBox.Show("User name or password is incorrect");
                    Password.Clear();
                }
            }
            catch(Exception exp)
            {
                Program.log.Error(exp);
            }
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }

        private void ShowRegister()
        {
            Program.log.Info("User open register page");
            RegisterForm reg = Program.Container.Resolve<RegisterForm>(new ResolverOverride[] { new ParameterOverride("user", _user) });
            if(reg.ShowDialog() == DialogResult.OK)
            {
                Program.log.Info("Registration DialogResult OK");
                this.Login.Text = _user.Login;
            }
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ShowRegister();
        }
    }
}
