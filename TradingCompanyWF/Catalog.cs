using BusinessLogic.Interfaces;
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
    public partial class Catalog : Form
    {
        protected readonly ICategoryManager _categoryManager;
        protected readonly IItemManager _itemManager;
        protected readonly IApplicationUser _user;
        protected BindingList<ItemDTO> blItems;
        public Catalog(ICategoryManager categoryManager, IItemManager itemManager, IApplicationUser user)
        {
            this._categoryManager = categoryManager;
            this._itemManager = itemManager;
            this._user = user;
            InitializeComponent();
            initData();
            RefreshGrid();
            
        }
        private void initData()
        {
            var _items = _itemManager.GetAllItems();
            blItems = new BindingList<ItemDTO>(_items);
            BindingSourceItems.DataSource = blItems;
        }
        private void RefreshGrid()
        {
            BindingNavigatorItems.BindingSource = BindingSourceItems;
            GridViewItems.DataSource = BindingSourceItems;

            foreach (DataGridViewColumn column in this.GridViewItems.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                
            }

        }
        private void Catalog_Load(object sender, EventArgs e)
        {
        }
        private void SortColumn(int column_index)
        {
            if(column_index == 3)
            {
                BindingSourceItems.DataSource = blItems.OrderBy(o => o.Price);
            }
            else if(column_index == 4)
            {
                BindingSourceItems.DataSource = blItems.OrderBy(o => o.InStock);
            }
        }
        private void GridViewItems_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column_id = e.ColumnIndex;
            SortColumn(column_id);
            RefreshGrid();

        }
    }
}
