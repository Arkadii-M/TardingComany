using ConsoleApplicationTC.Menu.MenuItems;
using ConsoleApplicationTC.Menu.MenuItems.Concrete;
using ConsoleApplicationTC.Menu.MenuItems.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTC.Menu
{
    class MenuItemWorker
    {
        private List<IMenuItem> list_menus = new List<IMenuItem>();
        public MenuItemWorker(IMenuItem cur)
        {
            list_menus.Add(cur);
        }

        public bool Next(int index)
        {
            Page current = (Page)list_menus.Last();
            IMenuItem next = (IMenuItem)current.Get_Item(index);
            switch (next.Get_Type())
            {
                case Menu_Item_Type.Func:
                    Function call_func = (Function)next;
                    call_func.Call_Func();
                    this.Show();
                    break;
                case Menu_Item_Type.Page:
                    list_menus.Add(next);
                    this.Show();
                    break;
                case Menu_Item_Type.Back:
                    Console.WriteLine("Back....");
                    this.list_menus.Remove(this.list_menus.Last());
                    this.Show();
                    break;
                case Menu_Item_Type.Exit:
                    Console.WriteLine("Exit...");
                    return true;
                case Menu_Item_Type.Empty:
                    throw new Exception("Can't go to empty page");


            }
            return false;
        }

        public void Show()
        {
            if (list_menus.Count == 1)
                Console.Clear();
            Page current = (Page)list_menus.Last();
            Console.Write("\n\n");
            Console.Write("--------");
            Console.Write(current.Get_Title());
            Console.Write("--------");
            Console.Write("\n\n");




            for (int i = 0; i < current.Get_Size(); ++i)
            {
                IMenuItem next = current.Get_Item(i + 1);
                Console.Write("{0}) {1} \n", i + 1, next.Get_Name());
            }
            Console.WriteLine("------------------------");

        }


    }
}
