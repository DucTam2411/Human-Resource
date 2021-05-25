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
using LiveCharts;
using LiveCharts.Wpf;
using Model.Database;

namespace HRMS.HR.uCon
{
    /// <summary>
    /// Interaction logic for uConReport.xaml
    /// </summary>
    public partial class uConReport : UserControl
    {
        public uConReport()
        {
            InitializeComponent();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Content = new uConDetailTimeKeeping();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var customers = (from customer in HRMSEnities.hrmsEntity.EMPLOYEEs
                             select customer);

            dtgvEmployees.ItemsSource = customers.ToArray();
        }
    }
}
