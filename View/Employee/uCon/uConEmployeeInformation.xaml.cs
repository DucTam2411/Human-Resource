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
    /// Interaction logic for uConEmployeeInformation.xaml
    /// </summary>
    public partial class uConEmployeeInformation : UserControl
    {
        public uConEmployeeInformation()
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel();
        }

    }
}
