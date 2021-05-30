using HRMS.HR.Model.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for uConListEmployeeAccounting.xaml
    /// </summary>
    public partial class uConListEmployeeAccounting : UserControl
    {
        private ObservableCollection<EMPLOYEE> employees = new ObservableCollection<EMPLOYEE>();

        public uConListEmployeeAccounting()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            dtgvA.ItemsSource = employees;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            contentControlMain.Content = new uConEmployeeSalary();
            contentControlMain.Margin = new Thickness(0, -20, 0, 0);
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
