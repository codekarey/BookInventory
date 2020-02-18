using System;
using System.Collections.Generic;
using System.IO;
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
            List<Book> bookList = new List<Book>();
            BookStream(bookList);
            int i = 1;

            foreach(Book book in bookList)
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
        //checks out a book / change inventory, status, duedate, and amount

        //returns a book to inventory

        //search for a book by title / author / about


    }
}
