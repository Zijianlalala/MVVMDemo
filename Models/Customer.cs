using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MVVMDemo.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }

        public double Amount { get; set; }
        public string Married { get; set; }
        private double _Tax;
        public double Tax
        {
            get { return _Tax; }
        }

        public Customer(string name, double amount, string married)
        {
            CustomerName = name;
            Amount = amount;
            Married = married;
        }

        public Customer() { }

        public void CalculateTax()
        {
            if (Amount > 2000)
            {
                _Tax = 20;
            } 
            else if (Amount > 1000)
            {
                _Tax = 10;
            } 
            else
            {
                _Tax = 5;
            }
            Trace.WriteLine("算钱了" + Tax);
        }

        public bool IsValid()
        {
            if (Amount == 0)
            {
                return false;
            }
            return true;
        }
    }
}
