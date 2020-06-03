using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMDemo.Views
{
    /// <summary>
    /// UserInfoUC.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoUC : UserControl
    {
        public UserInfoUC()
        {
            InitializeComponent();
            //DisplayUI(new CustomerViewModel());
        }

        private void DisplayUI(CustomerViewModel o)
        {
            txtCustomerName.Text = o.TxtCustomerName;
            txtAmount.Text = o.TxtAmount;
            BrushConverter brushConverter = new BrushConverter();
            lblBuyingHabits.Background = brushConverter.ConvertFromString(o.LblAmountColor) as SolidColorBrush; //???
            chxMarried.IsChecked = o.IsMarried;
        }
    }
}
