using AutoMapper;
using BusinessLogic;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DalEF.Concrete;
using DalEF.Interfaces;
using System;
using System.Web.Mvc;
using TradingCompanyMVC;
using TradingCompanyMVC.App.Profiles;
using Unity;

namespace TradingCompanyMVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            MapperConfiguration config = new MapperConfiguration(
               cfg =>
               {
                   cfg.AddMaps(typeof(AccountDalEf).Assembly);
                   cfg.AddMaps(typeof(SelectListItem).Assembly);
                   cfg.AddProfile(new ItemProfile());
                   cfg.AddProfile(new SelectedListItemProfile());
                   cfg.AddProfile(new FullOrderInfoProfile());
                   cfg.AddProfile(new OrderedInfoProfile());
               });
            container.RegisterInstance(config.CreateMapper());

            container.RegisterType<IAccountDal, AccountDalEf>()
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

            container.RegisterType<IAuthManager, AuthManager>()
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
                     .RegisterType<ICardInfoMananger, CardInfoMananger>()
                     .RegisterType<IAccountManager, AccountManager>();
        }
    }
}