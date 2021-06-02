using HRMS.HR.uCon;
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

namespace HRMS.Accouting.uCon
{
    /// <summary>
    /// Interaction logic for Accouting_EmployeeWindow.xaml
    /// </summary>
    /// 
    using ButtonContent = Tuple<TextBlock, PackIcon>;

    public partial class Accouting_EmployeeWindow : Window
    {
        public Accouting_EmployeeWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void uConSideBarAccouting_RoutedUserControlClicked(object sender, RoutedEventArgs e)
        {

            ButtonContent btn = getChildren(e.Source as Button);



            string str = btn.Item1.Text;



            if (str == uConSideBarAccouting.EMPLOYEE)
            {
                uConMain.Content = new uConListEmployeeAccounting();
                uConMain.Margin = new Thickness(0, 10, 0, 0);

            }
            else if (str == uConSideBarAccouting.HOME)
            {
                uConMain.Content = new uConDashboardAccouting();
                uConMain.Margin = new Thickness(20, 20, 20, 20);
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
