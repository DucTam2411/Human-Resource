using HRMS.Employee.ViewModel;
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
using System.Windows.Shapes;

namespace HRMS.Employee.uCon
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        //int employee_id;
        public EmployeeWindow()
        {
            InitializeComponent();
        }


        public EmployeeWindow(int employee_id)
        {
            InitializeComponent();
            DataContext = new InterfaceViewModel(employee_id);
            

        }








        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


    }
}
