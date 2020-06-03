using MVVMDemo.Commands;
using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;

namespace MVVMDemo.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private Customer obj = new Customer("Tom", 1700, "Married");

        private ButtonCommand buttonCommand;

        public CustomerViewModel()
        {
            buttonCommand = new ButtonCommand(Calculate, obj.IsValid);
        }

        public ICommand OnClick
        {
            get
            {
                return buttonCommand;
            }
        }

        public string TxtCustomerName
        {
            get { return obj.CustomerName; }
            set { obj.CustomerName = value; }
        }

        public string TxtAmount
        {
            get { return Convert.ToString(obj.Amount); }
            set { obj.Amount = Convert.ToDouble(value); }
        }

        public string TxtTax
        {
            get { return Convert.ToString(obj.Tax); }

        }

        public string LblAmountColor
        {
            get
            {
                if(obj.Amount > 2000)
                {
                    return "Blue";
                } 
                else if (obj.Amount > 1500)
                {
                    return "Red";
                }
                return "Yellow";
            }
        }

        public bool IsMarried
        {
            get
            {
                if (obj.Married == "Married")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                IsMarried = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Calculate() 
        {
            obj.CalculateTax();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("TxtTax"));
            }
        }





    }
}
