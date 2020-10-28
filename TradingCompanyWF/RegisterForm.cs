using BusinessLogic.Interfaces;
using DalEF;
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
    public partial class RegisterForm : Form
    {
        protected readonly IRegisterManager _registerManager;
        protected readonly IAdressManager _adressManager;
        protected readonly IBankManager _bankManager;
        protected readonly ICountryManager _countryManager;
        protected readonly IApplicationUser _user;

        public RegisterForm(IRegisterManager registerManager, IAdressManager adressManager, IBankManager bankManager, ICountryManager countryManager, IApplicationUser user)
        {
            this._registerManager = registerManager;
            this._adressManager = adressManager;
            this._bankManager = bankManager;
            this._countryManager = countryManager;
            this._user = user;
            InitializeComponent();
            InitForm();
        }
        private void InitForm()
        {
            GenderComboBox.Items.AddRange(new string[] { "Male", "Female" });
            var banks_list = _bankManager.GetAllBanks();
            BankComboBox.DataSource = banks_list;
            BankComboBox.DisplayMember = "Name";
            BankComboBox.ValueMember = "BankID";

            var country_list =_countryManager.GetAllCountries();
            CountryComboBox.DataSource = country_list;
            CountryComboBox.DisplayMember = "Name";
            CountryComboBox.ValueMember = "CountryID";
        }

        private void RegisterUser()
        {
            try
            {
                UserInfoDTO userinfo = new UserInfoDTO()
                {
                    Email = Email.Text,
                    FirstName = FirstName.Text,
                    Gender = GenderComboBox.Text == "Male" ? 1 : 0,
                    LastName = LastName.Text,
                    MobilePhone = MobilePhone.Text
                };
                BankCardInfoDTO cardInfo = new BankCardInfoDTO()
                {
                    BankID = ((BankDTO)BankComboBox.SelectedItem).BankID,
                    CardNumber = CardNumber.Text,
                    CVV = Convert.ToInt32(CVV.Text),
                    ExtendDate = Convert.ToDateTime(ExtendDate.Text)
                };
                AdressDTO addres = new AdressDTO()
                {
                    CountryID = ((CountryDTO)CountryComboBox.SelectedItem).CountryID,
                    Street = Street.Text,
                    City = City.Text
                };
                if( !_registerManager.Register(
                    Login.Text,
                    Password.Text,
                    userinfo,
                    cardInfo,
                    addres))
                {
                    MessageBox.Show("This login already exist,please use another login.");
                }
                else
                {
                    this._user.Login = Login.Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.RegisterUser();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
