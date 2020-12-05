using AutoMapper;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingCompanyMVC.App.Security;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC.Controllers
{
    public class ItemController : Controller
    {
        protected readonly IItemManager _manager;
        protected readonly ICategoryManager _categoryManager;
        protected readonly IMapper _mapper;

        public ItemController(IMapper mapper, IItemManager manager,ICategoryManager categoryManager)
        {
            _mapper = mapper;
            _manager = manager;
            _categoryManager = categoryManager;
        }
        // GET: Item
        public ActionResult Index()
        {

            List<ItemDTO> all_items =_manager.GetAllItems();

            var converted = new List<ItemModel>();
            foreach (var p in all_items)
            {
                converted.Add(_mapper.Map<ItemModel>(p));
            }
            return View(converted);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            var item = this._manager.GetItemById(id);
            return View(item);
        }

        // GET: Item/Create
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var create_item = new EditItemModel();
            create_item.Categories = new List<SelectListItem>();
            foreach (var cat in _categoryManager.GetAllCategories())
            {
                create_item.Categories.Add(_mapper.Map<SelectListItem>(cat));
            }
            return View(create_item);
        }

        // POST: Item/Create
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(EditItemModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                this._manager.AddItem(_mapper.Map<ItemDTO>(collection));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var item = this._manager.GetItemById(id);
            var edit_item = _mapper.Map<EditItemModel>(item);
            edit_item.Categories = new List<SelectListItem>();
            foreach(var cat in _categoryManager.GetAllCategories())
            {
                edit_item.Categories.Add(_mapper.Map<SelectListItem>(cat));
            }
            return View("~/Views/Item/EditItemView.cshtml",edit_item);
        }

        // POST: Item/Edit/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id, ItemDTO collection)
        {
            try
            {
                // TODO: Add update logic here
                this._manager.UpdateItem(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var item = this._manager.GetItemById(id);
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                this._manager.DeleteItemById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
