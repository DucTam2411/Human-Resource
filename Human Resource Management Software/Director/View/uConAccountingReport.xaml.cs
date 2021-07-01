using HRMS.Director.ViewModel;
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

namespace HRMS.Director.View
{
    /// <summary>
    /// Interaction logic for uConAccountingReport.xaml
    /// </summary>
    public partial class uConAccountingReport : UserControl
    {
        public uConAccountingReport()
        {
            InitializeComponent();
            DataContext = new AccountingViewModel();
        }
    }
}
