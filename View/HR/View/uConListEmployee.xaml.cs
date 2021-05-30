using HRMS.HR.Model.Database;
using HRMS.HR.ViewModel;
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
            DataContext = new ListEmployeeViewModel();
        }

       
    }
}
