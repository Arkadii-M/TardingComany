using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalEF.Interfaces;
using DalEF.Concrete;
using DAL.Interfaces;
using DalEF;

namespace BusinessLogic.Concrete
{
    public class RegisterManager : IRegisterManager
    {
        private readonly IAccountDal _accountDal;
        private readonly IUserInfoDal _userInfoDal;
        private readonly IAdressDal _adressDal;
        private readonly IBankCardInfoDal _cardinfoDal;
        public RegisterManager(IAccountDal accountDal, IUserInfoDal userInfoDal, IAdressDal adressDal, IBankCardInfoDal cardinfoDal)
        {
            this._accountDal = accountDal;
            this._userInfoDal = userInfoDal;
            this._adressDal = adressDal;
            this._cardinfoDal = cardinfoDal;
        }
        public bool Register(string username,string password, UserInfoDTO userinfo, BankCardInfoDTO cardInfo,AdressDTO addres)
        {
            try
            {
                var acc = this._accountDal.CreateAccount(username, password);

                addres = _adressDal.CreateAdress(addres);
                cardInfo = _cardinfoDal.CreateBankCardInfo(cardInfo);

                userinfo.UserID = acc.UserID;
                userinfo.BankCardInfoID = (int)cardInfo.BankCardInfoID;
                userinfo.AdressID = (int)addres.AdressID;

                this._userInfoDal.CreateUserInfo(userinfo);
                // transaction?
            }
            catch(Exception exp)
            {
                if(exp.Message == "User already exists!")
                {
                    return false;
                }
                throw exp;
            }
            return true;
        }
    }
}
