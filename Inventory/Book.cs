using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string About { get; set; } //short description or keywords for search option
        public bool StatusCheck { get; set; } //checks if the book is/isnt ready for check out 
        public DateTime Due { get; set; } //if status=checkedOut will show date to be returned

        public Book(string title, string author, string about, bool statusCheck, DateTime due)
        {
            Title = title;
            Author = author;
            About = about;
            StatusCheck = statusCheck;
            Due = due;
        }

        public DateTime DueDate()
        {
            return DateTime.Today;
        }

        //public override string Status()
        //{
        //    return null;
        //}

        public override string ToString() //format to store book/list inventory
        {
            return $"{Title}|{Author}|{About}|{StatusCheck}|{Due}";
        }
    }
}
