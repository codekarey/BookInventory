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
                    case 1://List all books
                        ManageBooks.ListBooks();
                        break;
                    case 2://Adds a new book
                        string title = Get("Enter the Title:");
                        string author = Get("Enther the Author:");
                        string about = Get("What the book is about?");
                        Book newBook = new Book(title, author, about, true, DateTime.Today);
                        ManageBooks.Add(newBook);
                        Console.WriteLine("Thank you for adding "+title+" by "+author+" to our library");
                        break;
                    case 3://Checkout a book
                        break;
                    case 4://Return a book
                        break;
                    case 5://Search
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
        public static string Get(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
