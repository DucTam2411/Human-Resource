using HRMS.HR.ViewModel;
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

namespace HRMS.HR.View
{
    /// <summary>
    /// Interaction logic for uConHRInformation.xaml
    /// </summary>
    public partial class uConHRInformation : UserControl
    {
        public uConHRInformation(int ID)
        {
            InitializeComponent();
            DataContext = new InformationViewModel(ID);
        }
        //public uConHRInformation()
        //{
        //    InitializeComponent();
        //    DataContext = new InformationViewModel();
        //}
    }
}
