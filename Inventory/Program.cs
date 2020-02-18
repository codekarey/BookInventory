using System;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            //public book list to add/edit/delete items

            bool menu = true;
            while (menu)
            {
                Console.WriteLine("\n Welcome to your inventory menu, please enter the # matching the option you want.\n\n" +
                    "[ 1 ]List Books  [ 2 ]Add Book  [ 3 ]Checkout  [ 4 ]Return  [ 5 ]Search ");
                int menuNum = TryParse();//validate input is int
                switch (menuNum)
                {
                    case 1:
                        ManageBooks.ListBooks();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
        }
    
        public static int TryParse()
        {
            bool s = true;
            while (s)
            {
                string input = Console.ReadLine();
                try
                {
                    int num = int.Parse(input);
                    return num;
                    s = false;
                }
                catch
                {
                    Console.WriteLine("Sorry, please enter a number.");
                }
            }
            return 0;
        }
    }
}
