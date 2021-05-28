using HRMS.Accouting.Model;
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

namespace HRMS.HR.uCon
{
    /// <summary>
    /// Interaction logic for uConModifyEmployee.xaml
    /// </summary>
    public partial class uConModifyEmployee : UserControl
    {
        public uConModifyEmployee()
        {
            InitializeComponent();
        }

        public uConModifyEmployee(EMPLOYEE e)
        {
            InitializeComponent();
            this.DataContext = e;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new uConListEmployee();
        }
    }
}
