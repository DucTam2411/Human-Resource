using HRMS.HR.ViewModel;
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

namespace HRMS.HR.uCon
{
    /// <summary>
    /// Interaction logic for HR_EmployeeWindow.xaml
    /// </summary>
    
    using ButtonContent = Tuple<TextBlock, PackIcon>;
    public partial class HR_EmployeeWindow : Window
    {
        public HR_EmployeeWindow()
        {
            
            InitializeComponent();
            DataContext = new ListEmployeeViewModel();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            
        }

        private void uConSideBar_RoutedUserControlClicked(object sender, RoutedEventArgs e)
        {

            ButtonContent btn = getChildren(e.Source as Button);



            string str = btn.Item1.Text;



            if (str == uConSideBar.HOME)
            {
                uConMain.Content = new uConListEmployee();
            }
            else
            {
                uConMain.Content = new uConReport();

            }
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
