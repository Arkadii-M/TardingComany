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

            // Countries
            Page Country = new Page("Countries Dal");
            Function CreateCountry = new Function(Menu_Item_Type.Func, CountryFunctions.Create, "Create");
            Function DeleteCountry = new Function(Menu_Item_Type.Func, CountryFunctions.Delete, "Delete");
            Function PrintAllCountries = new Function(Menu_Item_Type.Func, CountryFunctions.GetAll, "GetAll");
            Function PrintCountry = new Function(Menu_Item_Type.Func, CountryFunctions.GetById, "GetById");
            Function UpdateCountry = new Function(Menu_Item_Type.Func, CountryFunctions.Update, "Update");
            Country.Add_Item(CreateCountry);
            Country.Add_Item(DeleteCountry);
            Country.Add_Item(PrintAllCountries);
            Country.Add_Item(PrintCountry);
            Country.Add_Item(UpdateCountry);
            Country.Add_Item(Back);

            // Bank
            Page Bank = new Page("Bank Dal");
            Function CreateBank = new Function(Menu_Item_Type.Func, BankFunctions.Create, "Create");
            Function DeleteBank = new Function(Menu_Item_Type.Func, BankFunctions.Delete, "Delete");
            Function PrintAllBanks = new Function(Menu_Item_Type.Func, BankFunctions.GetAll, "GetAll");
            Function PrintBank = new Function(Menu_Item_Type.Func, BankFunctions.GetById, "GetById");
            Function UpdateBank = new Function(Menu_Item_Type.Func, BankFunctions.Update, "Update");
            Bank.Add_Item(CreateBank);
            Bank.Add_Item(DeleteBank);
            Bank.Add_Item(PrintAllBanks);
            Bank.Add_Item(PrintBank);
            Bank.Add_Item(UpdateBank);
            Bank.Add_Item(Back);
            //BankCard
            Page BankCard = new Page("Bank Card Info Dal");
            Function CreateBankCard = new Function(Menu_Item_Type.Func, BankCardInfoFunctions.Create, "Create");
            Function DeleteBankCard = new Function(Menu_Item_Type.Func, BankCardInfoFunctions.Delete, "Delete");
            Function PrintAllBankCards= new Function(Menu_Item_Type.Func, BankCardInfoFunctions.GetAll, "GetAll");
            Function PrintBankCard = new Function(Menu_Item_Type.Func, BankCardInfoFunctions.GetById, "GetById");
            Function UpdateBankCard = new Function(Menu_Item_Type.Func, BankCardInfoFunctions.Update, "Update");
            BankCard.Add_Item(CreateBankCard);
            BankCard.Add_Item(DeleteBankCard);
            BankCard.Add_Item(PrintAllBankCards);
            BankCard.Add_Item(PrintBankCard);
            BankCard.Add_Item(UpdateBankCard);
            BankCard.Add_Item(Back);
            //Adress
            Page Adress = new Page("Adress Dal");
            Function CreateAdress = new Function(Menu_Item_Type.Func, AdressFunctions.Create, "Create");
            Function DeleteAdress = new Function(Menu_Item_Type.Func, AdressFunctions.Delete, "Delete");
            Function PrintAllAdresses= new Function(Menu_Item_Type.Func, AdressFunctions.GetAll, "GetAll");
            Function PrintAdress = new Function(Menu_Item_Type.Func, AdressFunctions.GetById, "GetById");
            Function UpdateAdress = new Function(Menu_Item_Type.Func, AdressFunctions.Update, "Update");
            Adress.Add_Item(CreateAdress);
            Adress.Add_Item(DeleteAdress);
            Adress.Add_Item(PrintAllAdresses);
            Adress.Add_Item(PrintAdress);
            Adress.Add_Item(UpdateAdress);
            Adress.Add_Item(Back);




            Main.Add_Item(Users);
            Main.Add_Item(Country);
            Main.Add_Item(Bank);
            Main.Add_Item(BankCard);
            Main.Add_Item(Adress);
            Main.Add_Item(Exit);
            p = new MenuItemWorker(Main);
        }

    }



    

}