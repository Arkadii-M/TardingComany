using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuItems.Interface
{

    interface IMenuItem
    {
        Menu_Item_Type Get_Type();
        string Get_Name();
    }
}
