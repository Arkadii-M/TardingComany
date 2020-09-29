using ConsoleApplicationTC.Menu.MenuItems.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuItems.Concrete
{
    class Item : IMenuItem
    {
        private Menu_Item_Type type;
        private string Name;
        public Item(Menu_Item_Type t, string name)
        {
            this.type = t;
            this.Name = name;
        }

        public Menu_Item_Type Get_Type() { return this.type; }
        public  string Get_Name() { return this.Name; }

    }
}
