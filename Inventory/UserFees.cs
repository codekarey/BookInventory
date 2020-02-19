using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class UserFees
    {
        public string Name { get; set; }
        public double LateFee { get; set; }
        public bool Good { get; set; }
        public List<Book> CheckedOut { get; set; }

        public UserFees(string name, double lateFee, bool good, List<Book> checkedOut)
        {
            Name = name;
            LateFee = lateFee;
            Good = good;
            CheckedOut = checkedOut;
        }
    }
}
