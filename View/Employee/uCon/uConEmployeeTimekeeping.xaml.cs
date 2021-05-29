using HRMS.Accouting.Model;
using HRMS.Employee.ViewModel;
using MaterialDesignThemes.Wpf;

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

namespace HRMS.Employee.uCon
{
    /// <summary>
    /// Interaction logic for uConEmployeeTimekeeping.xaml
    /// </summary>
    /// 
    
    public partial class uConEmployeeTimekeeping : UserControl
    {
        private ObservableCollection<TimekeepingData> TimekeepingList;

        public uConEmployeeTimekeeping()
        {
            TimekeepingList = new ObservableCollection<TimekeepingData>();
            InitializeComponent();
            DataContext = new EmployeeViewModel();

        }

    }
}
