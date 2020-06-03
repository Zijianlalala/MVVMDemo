using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Commands
{
    public class ButtonCommand : ICommand
    {
        private Action WhattoExecute;
        private Func<bool> WhentoExecute;
        
        public event EventHandler CanExecuteChanged;


        public ButtonCommand(Action what, Func<bool> when)
        {
            WhattoExecute = what;
            WhentoExecute = when;
        }

        public bool CanExecute(object parameter)
        {
            return WhentoExecute();
        }

        public void Execute(object parameter)
        {
            WhattoExecute();
        }
    }
}
