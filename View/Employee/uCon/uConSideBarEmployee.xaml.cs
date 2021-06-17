using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for uConSideBarEmployee.xaml
    /// </summary>
    using ButtonContent = Tuple<TextBlock, PackIcon>;
    public partial class uConSideBarEmployee : UserControl
    {
        public const string INFORMATION = "Information";
        public const string TIMEKEEPING = "TimeKeeping";
        public const string SALARY = "Salary          ";


        public uConSideBarEmployee()
        {
            InitializeComponent();
        }



        // buttonList
        List<ButtonContent> buttonPackages = new List<ButtonContent>();
    }
}
