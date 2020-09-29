using ConsoleApplicationTC.Menu.MenuFunctions;
using ConsoleApplicationTC.Menu.MenuItems;
using ConsoleApplicationTC.Menu.MenuItems.Concrete;
using ConsoleApplicationTC.Menu.MenuItems.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplicationTC.Menu
{
    class MyMenu
    {

        private MenuItemWorker p;
        public MyMenu()
        {
            this.Create_Menus();
            this.Print_Menu();


        }
        private void Print_Menu()
        {
            this.p.Show();
        }

        public bool Go_To(int index)
        {
            try
            {
                return this.p.Next(index);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return false;
            }
        }

        private void Create_Menus()
        {
            Page Main = new Page("Main");
            Item Back = new Item(Menu_Item_Type.Back, "Back");
            Item Exit = new Item(Menu_Item_Type.Exit, "Exit");


            // Users
            Page Users = new Page("User Dal");
            Function CreateUser = new Function(Menu_Item_Type.Func, UserFunctions.Create, "Create");
            Function DeleteUser = new Function(Menu_Item_Type.Func, UserFunctions.Delete, "Delete");
            Function PrintAllUsers = new Function(Menu_Item_Type.Func, UserFunctions.GetAll, "GetAll");
            Function PrintUser = new Function(Menu_Item_Type.Func, UserFunctions.GetById, "GetById");
            Function UpdateUser= new Function(Menu_Item_Type.Func, UserFunctions.Update, "Update");
            Users.Add_Item(CreateUser);
            Users.Add_Item(DeleteUser);
            Users.Add_Item(PrintAllUsers);
            Users.Add_Item(PrintUser);
            Users.Add_Item(UpdateUser);
            Users.Add_Item(Back);






            Main.Add_Item(Users);
            Main.Add_Item(Exit);
            


            p = new MenuItemWorker(Main);
        }




    }



    

}