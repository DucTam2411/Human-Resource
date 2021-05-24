using HRMS.Accouting.ViewModel;
using Model;
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
    /// Interaction logic for uConEmployeeSalary.xaml
    /// </summary>
    /// 
    public partial class uConEmployeeSalary : UserControl
    {
        private SalaryData _SelectedItem;
        public SalaryData SelectedItem { get => _SelectedItem ; set { _SelectedItem = value; } }
        public uConEmployeeSalary()
        {
            InitializeComponent();
        }

        public uConEmployeeSalary(SalaryData selectedItem)
        {
            SelectedItem = new SalaryData();
            this.SelectedItem = selectedItem;
            DetailedSalaryViewModel.data = selectedItem; 
            InitializeComponent();
        }

        public uConEmployeeSalary(UserControl uCon)
        {
            InitializeComponent();
            uCon.Width = 300;
            uConRequest.Content = uCon;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new uConListEmployeeAccounting();
        }
    }
}
