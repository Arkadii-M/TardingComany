using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using DTO;
using DalEF;
using DAL.Interfaces;
using DalEF.Concrete;
using DalEF.Interfaces;
using BusinessLogic;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using TradingCompanyWF.Models.Interfaces;
using TradingCompanyWF.Models.Concrete;
using Unity.Resolution;

namespace TradingCompanyWF
{
    static class Program
    {
        public static UnityContainer Container;
        public static IApplicationUser _user;
        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _user = new ApplicationUser();

            //Container.AddExtension(new Diagnostic());
            LoginForm lf = Container.Resolve<LoginForm>(new ResolverOverride[] { new ParameterOverride("user", _user) });
            if (lf.ShowDialog() == DialogResult.OK)
            {
                Application.Run(Container.Resolve<UserStartPage>(new ResolverOverride[] {new ParameterOverride("user", _user)}));
            }
            else
            {
               Application.Exit();
            }



        }
        private static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(BankDalEf).Assembly);
                });

            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container.RegisterType<IAccountDal, AccountDalEf>()
                     .RegisterType<IAdressDal, AdressDalEf>()
                     .RegisterType<IBankCardInfoDal, BankCardInfoDalEf>()
                     .RegisterType<IBankDal, BankDalEf>()
                     .RegisterType<ICategoryDal, CategoryDalEf>()
                     .RegisterType<ICountryDal, CountryDalEf>()
                     .RegisterType<IItemDal, ItemDalEf>()
                     .RegisterType<IOrderDal, OrderDalEf>()
                     .RegisterType<IOrderedDal, OrderedDalEf>()
                     .RegisterType<IOrderStatusDal, OrderStatusDalEf>()
                     .RegisterType<IUserInfoDal, UserInfoDalEf>()
                     .RegisterType<IAuthManager,AuthManager>()
                     .RegisterType<IUserInfoManager,UserInfoManager>()
                     .RegisterType<IAdressManager, AdressManager>()
                     .RegisterType<IBankManager, BankManager>()
                     .RegisterType<ICountryManager, CountryManager>()
                     .RegisterType<ICategoryManager,CategoryManager>()
                     .RegisterType<IItemManager,ItemManager>()
                     .RegisterType<IOrderedManager,OrderedManager>()
                     .RegisterType<IOrderManager,OrderManager>()
                     .RegisterType<IOrderStatusManager,OrderStatusManager>()
                     .RegisterType<IRegisterManager, RegisterManager>()
                     .RegisterType<ICardInfoMananger,CardInfoMananger>()
                     .RegisterType<IApplicationUser,ApplicationUser>();
        }
    }
}
