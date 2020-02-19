﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Inventory
{
    class ManageBooks
    {
        public static List<Book> BookStream(List<Book> bookList)
        {
            //saves to file 
            StreamReader reader = new StreamReader("../../../BookList.txt");
            string part = reader.ReadLine();

            //checks for information
            while (part != null)
            {
                //breaks up the book prop into obj parts
                string[] books = part.Split('|');
                bookList.Add(new Book(books[0], books[1], books[2], bool.Parse(books[3]), DateTime.Parse(books[4])));
                part = reader.ReadLine();
            }
            reader.Close();
            return bookList;
        }
        //prints list of book(title, author, and about
        public static void ListBooks()
        {
            List<Book> books = new List<Book>();
            BookStream(books);
            int i = 1;

            foreach(Book book in books)
            {
                Console.WriteLine("---- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n" +
                    ""+i+ " ||\t"+"[ "+book.Title+" ] BY [ "+book.Author+" ]\t About the Book:");
                Console.WriteLine("----\t \n"+book.About+"");
                i++;
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
        }
        //adds a new book to inventory used in a foreach()
        public static void Add(Book newBook)
        {
            using(StreamWriter write = new StreamWriter("../../../BookList.txt", true))
            {
                write.WriteLine(newBook);
            }
        }
        //checks out a book / change inventory, status, and duedate
        public static void CheckOut(List<Book> books)
        {
            
            bool search = true;
            while (search)
            {
                bool other = true;
                int bCount = books.Count-1;
                Console.WriteLine("Enter the title of the book you want to checkout or enter X to go back to the menu.");
                string utitle = Console.ReadLine().ToLower();
                if (utitle == "x")
                {
                    search = false;
                    break;
                }
                foreach (Book b in books)
                {
                    //is not checked out : changes to checkedout and duedate = today + 2 weeks
                    if (utitle.Contains(b.Title.ToLower())&&b.StatusCheck==true)
                    {
                        Console.WriteLine("Is "+b.Title+" by "+b.Author+" the book you want to checkout?\n\t\t[ Y ]\t[ N ]");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            b.StatusCheck = false;
                            b.Due = DateTime.Today.AddDays(14);
                            Console.WriteLine("\n\tOkay! "+b.Title+" is due back on "+b.Due.Month+"-"+b.Due.Day+"-"+b.Due.Year);
                            search = true;
                            other = false; //if no books match
                        } 
                    }
                    //show matching books checked out with duedate
                    else if (utitle.Contains(b.Title.ToLower()) && b.StatusCheck == false)
                    {
                        Console.WriteLine("We do have a title matching that but it's currently checked out:\n" +
                            "\n" + b.Title + " by " + b.Author + " but is due back " + b.Due.Month + "-" + b.Due.Day + "-" + b.Due.Year+"\n");
                             other = false;
                    }
                    else if (b==books[bCount]&& other!=false)
                    {
                        Console.WriteLine("Sorry we dont have a title matching that. \n" +
                            "Check the spelling and try again or enter X to go back to the menu.");
                        if (Console.ReadLine().ToLower() == "x")
                        {
                            search = false;
                        }
                    }
                }
            }

        }
        //returns a book to inventory
        public static void Return(List<Book> books)
        {
            bool isfound = false;
            Console.WriteLine("Enter the title of the book you'd like to return.");
            string title = Console.ReadLine().ToLower();
            
            foreach(Book book in books)//check for title match(only show titles checked out, check if returned ontime
            {
                if (title.Contains(book.Title.ToLower())&&book.StatusCheck==false)
                {
                    isfound = true;
                    Console.WriteLine("Is "+book.StatusCheck+" by "+book.Author+" the book you are returning? [ Y ]  [ N ]");
                    string returning = Console.ReadLine().ToLower();
                    if (returning == "y" || returning == "yes")
                    {
                        if (book.Due.Ticks < DateTime.Now.Ticks) //not returned on time = late fees & hold on checkouts(name)
                        {
                            var daysLate = Book.DueDate().Subtract(book.Due);
                            Console.WriteLine("Thank you for returning this but it is " + (daysLate.Days - 1) + " days passed the due date.\n" +
                                "We charge a quarter a day, so that totals to " + (daysLate.Days - 1) * .250 + " in late fees\n" +
                                "If you want to checkout another book you must first take care of the fee in your account.");
                        }
                        book.StatusCheck = true;
                        book.Due = Book.DueDate();
                        Console.WriteLine(book.ToString());
                    }  
                }
            }
            if (!isfound)
                {
                    Console.WriteLine("Sorry, we dont have a title checked out in our library by that name.");
                    isfound = false;
                }
            }
        //search for a book by title / author / about


    }
}
