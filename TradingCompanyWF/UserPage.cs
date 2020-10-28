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
    public partial class UserPage : Form
    {
        protected readonly IUserInfoManager _userInfoManager;
        protected readonly IApplicationUser _user;
        protected readonly ICountryManager _countryManager;
        protected readonly IAdressManager _adressManager;
        protected readonly ICardInfoMananger _cardInfoMananger;
        public UserPage(IUserInfoManager userInfoManager, IApplicationUser user,ICountryManager countryManager,IAdressManager adressManager,ICardInfoMananger cardInfoMananger)
        {
            this._user = user;
            this._userInfoManager = userInfoManager;
            this._countryManager = countryManager;
            this._adressManager = adressManager;
            this._cardInfoMananger = cardInfoMananger;
            InitializeComponent();
            InitFields();

        }
        private void InitFields()
        {
            var userinfo = this._userInfoManager.GetUserInfoById(this._user.UserId);
            this.LoginField.Text = this._user.Login;
            this.NameField.Text = userinfo.FirstName;
            this.LastNameField.Text = userinfo.LastName;
            this.EmailField.Text = userinfo.Email;
            this.MobilePhoneField.Text = userinfo.MobilePhone;

            var cardinfo = this._cardInfoMananger.GetCardInfoById(userinfo.BankCardInfoID);

            var adress_list = this._adressManager.GetAllAdresses();
            var country_list = _countryManager.GetAllCountries();

            var address = adress_list.FirstOrDefault<AdressDTO>(a => a.AdressID == userinfo.AdressID);
            var country = country_list.FirstOrDefault<CountryDTO>(c => c.CountryID == address.CountryID);


            this.CardNumberField.Text = cardinfo.CardNumber;
            this.CountryField.Text = country.Name;
            this.CityField.Text = address.City;
            this.StreetField.Text = address.Street;


        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
