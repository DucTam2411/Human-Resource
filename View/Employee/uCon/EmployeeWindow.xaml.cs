using HRMS.Employee.ViewModel;
using HRMS.Model;
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
using System.Windows.Shapes;

namespace HRMS.Employee.uCon
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>

    using ButtonContent = Tuple<TextBlock, PackIcon>;
    public partial class EmployeeWindow : Window
    {

        //int employee_id;
        NavigationViewModel a { get; set; }
        public EmployeeWindow()
        {
            InitializeComponent();
        }


        public EmployeeWindow(int employee_id)
        {
            InitializeComponent();

            a = new NavigationViewModel(employee_id);
            Sidebar.DataContext = a;
            sss.DataContext = a;


            // this will handle check attendance
            this.DataContext = new TimerViewModel(employee_id);

        }



       

   


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private ButtonContent getChildren(Button myButtonInSidebar)
        {
            StackPanel stack = (StackPanel)myButtonInSidebar.Content;

            TextBlock textBlock = (TextBlock)stack.Children[1];
            PackIcon pack = (PackIcon)stack.Children[0];


            return new ButtonContent(textBlock, pack);
        }
    }
}
