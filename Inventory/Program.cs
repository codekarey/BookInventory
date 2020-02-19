using System;
using System.Collections.Generic;

namespace Inventory
{
    class Program
    {
        static List<Book> books = new List<Book>();
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, please enter the name that will be used for your account.");
            string name = Console.ReadLine();
            UserFees user = new UserFees(name, 0, true);
            //public book list to add/edit/delete items
            ManageBooks.BookStream(books);

            bool menu = true;
            while (menu)
            {
                Console.WriteLine("\n Welcome to your inventory menu, please enter the # matching the option you want.\n\n" +
                    "[ 1 ]List Books  [ 2 ]Add Book  [ 3 ]Checkout  [ 4 ]Return  [ 5 ]Search [ 6 ] Fees");
                int menuNum = TryParse();//validate input is int
                switch (menuNum)
                {
                    case 1://List all book
                        ManageBooks.Update(books);
                        ManageBooks.ListBooks();
                        break;
                    case 2://Adds a new book 
                        string title = Get("Enter the Title:");
                        string author = Get("Enther the Author:");
                        string about = Get("What the book is about?");
                        Book newBook = new Book(title, author, about, true, DateTime.Today);
                        books.Add(ManageBooks.Add(newBook));
                        ManageBooks.Update(books);
                        Console.WriteLine("Thank you for adding "+title+" by "+author+" to our library");
                        break;
                    case 3://Checkout a book : get name
                        if (name.Contains(user.Name) && user.Good)
                        {
                            ManageBooks.CheckOut(books);
                        }
                        else
                        {
                            Console.WriteLine("Sorry "+user.Name+" but you have to pay your late fees before you check out a new book.");
                        }
                        break;
                    case 4://Return a book: get name
                        user = ManageBooks.Return(books, user);
                        break;
                    case 5://Search
                        break;
                    case 6:
                        Console.WriteLine(user.Name+" Account\n***************\n" +
                            " : \n-Can Checkout: "+user.Good+"\n-Fees: "+user.LateFee);
                        if (!user.Good)
                        {
                            Console.WriteLine("Would you like to pay your late fee of "+user.LateFee+"  [ Y ]  [ N ]");
                            if (Console.ReadLine().ToLower() == "y")
                            {
                                user.LateFee = 0;
                                user.Good = true;
                                Console.WriteLine("Thank you for taking care of that, now you can checkout books.");
                            }
                        }
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
