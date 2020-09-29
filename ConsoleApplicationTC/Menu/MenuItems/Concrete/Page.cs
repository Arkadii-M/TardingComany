using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApplicationTC.Menu.MenuItems.Interface;

namespace ConsoleApplicationTC.Menu.MenuItems.Concrete
{
    class Page : IMenuItem
    {
        private string Title;
        Menu_Item_Type type;
        private List<IMenuItem> Items = new List<IMenuItem>();

        public Page(string title = "")
        {
            this.type = Menu_Item_Type.Page;
            this.Title = title;
        }
        public void Add_Item(IMenuItem rhs)
        {
            this.Items.Add(rhs);
        }

        public IMenuItem Get_Item(int index)
        {
            try
            {
                return this.Items[index - 1];
            }
            catch (Exception exp)
            {

                Console.WriteLine(exp.ToString());
                throw new Exception("Invaild item position,try again");
            }


        }
        public string Get_Title() { return this.Title; }
        public int Get_Size() { return this.Items.Count; }
        public  Menu_Item_Type Get_Type() { return this.type; }
        public string Get_Name()
        {
            return this.Title;
        }
    }
}
