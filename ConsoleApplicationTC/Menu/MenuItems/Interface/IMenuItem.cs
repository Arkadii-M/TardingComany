using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuItems.Interface
{

    interface IMenuItem
    {
        public Menu_Item_Type Get_Type();
        public string Get_Name();
    }
}
