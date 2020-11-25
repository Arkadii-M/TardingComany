using AutoMapper;
using BusinessLogic;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DalEF.Concrete;
using DalEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TraidingCompanyWPF.Models;
using TraidingCompanyWPF.Models.Profiles;
using TraidingCompanyWPF.ViewModels;
using TraidingCompanyWPF.Windows;
using Unity;

namespace TraidingCompanyWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UnityContainer Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);
            
            RegisterUnity();
            RegisterAutoMapper();


            Login lf = Container.Resolve<Login>();
            bool result = lf.ShowDialog() ?? false;
            if (result)
            {
                var app = Container.Resolve<OrderList>();
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = app;   
                app.Show();
            }
            else
            {
                Current.Shutdown();
            }

        }
        private void RegisterAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(AccountDalEf).Assembly);
                });
            Container.RegisterInstance(config.CreateMapper());
        }
        private void RegisterUnity()
        {
            Container = new UnityContainer();

            Container.RegisterInstance<ApplicationUser>(new ApplicationUser());


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
                     .RegisterType<IUserInfoDal, UserInfoDalEf>();

            Container.RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<IUserInfoManager, UserInfoManager>()
                     .RegisterType<IAdressManager, AdressManager>()
                     .RegisterType<IBankManager, BankManager>()
                     .RegisterType<ICountryManager, CountryManager>()
                     .RegisterType<ICategoryManager, CategoryManager>()
                     .RegisterType<IItemManager, ItemManager>()
                     .RegisterType<IOrderedManager, OrderedManager>()
                     .RegisterType<IOrderManager, OrderManager>()
                     .RegisterType<IOrderStatusManager, OrderStatusManager>()
                     .RegisterType<IRegisterManager, RegisterManager>()
                     .RegisterType<ICardInfoMananger, CardInfoMananger>();
            

                     //.RegisterType<IApplicationUser, ApplicationUser>();

        }
       
    }
}
