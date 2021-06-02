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
using HRMS.HR.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace HRMS.HR.uCon
{
    /// <summary>
    /// Interaction logic for uConReport.xaml
    /// </summary>
    public partial class uConReport : UserControl
    {
        public uConReport(int ID)
        {
            InitializeComponent();
            DataContext = new ReportViewModel(ID);
        }
    }
}
