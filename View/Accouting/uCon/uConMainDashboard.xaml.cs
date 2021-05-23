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

namespace HRMS.Accouting.uCon
{
    /// <summary>
    /// Interaction logic for uConMainDashboard.xaml
    /// </summary>
    public partial class uConMainDashboard : UserControl
    {
        public uConMainDashboard()
        {
            InitializeComponent();
        }

        private void uConRequestBoard_RoutedUserControlClicked(object sender, RoutedEventArgs e)
        {
            StackNewemployee.Children.Remove(sender as UserControl);
            this.Content = new uConEmployeeSalary(sender as UserControl);
        }

        private void uConChangeInSalary_RoutedUserControlClicked(object sender, RoutedEventArgs e)
        {
            StackEmployeeChanges.Children.Remove(sender as UserControl);
            this.Content = new uConEmployeeSalary(sender as UserControl);
        }
    }
}
