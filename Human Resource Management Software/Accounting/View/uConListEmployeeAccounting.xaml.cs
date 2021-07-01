using HRMS.Accouting.ViewModel;
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

namespace HRMS.Accounting.View
{
    /// <summary>
    /// Interaction logic for uConListEmployeeAccounting.xaml
    /// </summary>
    public partial class uConListEmployeeAccounting : UserControl
    {
        public uConListEmployeeAccounting(int ID)
        {
            DataContext = new AccountingViewModel(ID);
            InitializeComponent();
        }
    }
}
