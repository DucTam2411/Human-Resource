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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRMS.Employee.uCon
{
    /// <summary>
    /// Interaction logic for uConEmployeeTimekeepingWhole.xaml
    /// </summary>
    public partial class uConEmployeeTimekeepingWhole : UserControl
    {
        public uConEmployeeTimekeepingWhole(int employee_id, NavigationViewModel nav)
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel(employee_id, nav);
        }

       
    }
}
