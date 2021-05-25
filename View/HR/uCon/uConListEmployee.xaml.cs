using Model;
using Model.Database;
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

namespace HRMS.HR.uCon
{
    public partial class uConListEmployee : UserControl
    {
        private ObservableCollection<EMPLOYEE> employees = new ObservableCollection<EMPLOYEE>();

        public uConListEmployee()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var customers = (from customer in HRMSEnities.hrmsEntity.EMPLOYEEs
                             select customer);

            dtgvEmployees.ItemsSource = customers.ToArray();    
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            EMPLOYEE employee = (dtgvEmployees.SelectedItem as EMPLOYEE);
            contentControlMain.Content = new uConModifyEmployee(employee);
        

        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            contentControlMain.Content = new uConAddEmployee();
        }

        private void dtgvA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    
    
    }
}
