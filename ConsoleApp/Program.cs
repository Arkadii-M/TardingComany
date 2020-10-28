using System;
using DTO;
using DalEF;
using ConsoleApplicationTC.Menu;
using DalEF.Concrete;


namespace ConsoleApplicationTC
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMenu My_Menu = new MyMenu();
            int item;
            while (true)
            {
                try
                {
                    Console.Write("Enter number: ");
                    item = Convert.ToInt32(Console.ReadLine());

                    
                   if (My_Menu.Go_To(item))
                    {
                        return;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

            }
            
        }
    }
}
