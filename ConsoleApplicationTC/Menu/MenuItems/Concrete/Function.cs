using ConsoleApplicationTC.Menu.MenuItems.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuItems.Concrete
{
    delegate void Func();

    class Function : IMenuItem
    {
        private Func function;
        private Menu_Item_Type type;
        private string Name;


        public Function(Menu_Item_Type t, Func f, string name)
        {
            this.function = f;
            this.type = t;
            this.Name = name;
        }
        public void Call_Func()
        {
            if (this.type == Menu_Item_Type.Func)
            {
                this.function();
            }
            else
            {
                throw new Exception("Invalid type to call func");
            }
        }

        public  Menu_Item_Type Get_Type() { return this.type; }
        public string Get_Name() { return this.Name; }

    }
}
