using AutoMapper;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraidingCompanyWPF.Models.Profiles
{
    public class OrderedProductModelProfile:Profile
    {
        private readonly IItemManager _itemManager;
        private readonly OrderStatusManager _orderStatusManager;
        private readonly IOrderedManager _orderedManager;
        public OrderedProductModelProfile(OrderStatusManager orderStatusManager, IItemManager itemManager, IOrderedManager orderedManager)
        {
            this._itemManager = itemManager;
            this._orderStatusManager = orderStatusManager;
            this._orderedManager = orderedManager;
            CreateMap<OrderDTO, OrderedProductModel>()
                .ForMember(dest => dest.OrderID,scr => scr.MapFrom(p => p.OrderID))
                .ForMember(dest => dest.Ordernumber, scr => scr.MapFrom(p => p.Ordernumber))
                .ForMember(dest => dest.Date, scr => scr.MapFrom(p => p.Date))
                .ForMember(dest => dest.UserID, scr => scr.MapFrom(p => p.UserID))
                .ForMember(dest => dest.StatusName, scr => scr.MapFrom(p => GetItemStatus(p.StatusID) ))

                .ForMember(dest => dest.ItemID, scr => scr.MapFrom(p => GetItemIdByOrderId(p.OrderID)))
                .ForMember(dest => dest.ItemTitle, scr => scr.MapFrom(p => GetItemTitleByOrderId(p.OrderID) ))
                .ForMember(dest => dest.Amount, scr => scr.MapFrom(p => GetAmmountByOrderId(p.OrderID)));
        }

        private string GetItemTitle(int itemId)
        {

            return this._itemManager.GetItemById(itemId).ItemTitle;
        }
        private string GetItemStatus(int itemId)
        {
            return this._orderStatusManager.GetOrderStatusById(itemId).Name;
        }
        private int GetItemIdByOrderId(int id)
        {
            return this._orderedManager.GetOrderedById(id).ItemID;
        }

        private string GetItemTitleByOrderId(int id)
        {
            return this._itemManager.GetItemById( this._orderedManager.GetOrderedById(id).ItemID).ItemTitle;
        }
        private int GetAmmountByOrderId(int id)
        {
            return this._orderedManager.GetOrderedById(id).Amount;
        }
    }
}
