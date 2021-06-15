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
using MaterialDesignThemes.Wpf;
using HRMS.Director;

namespace HRMS.Director
{
    using ButtonContent = Tuple<TextBlock, PackIcon>;
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class uConDirector : Window
    {
        public uConDirector()
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


            if (str == uConSideBarDirector.REPORTEMPLOYEE)
            {
                uConMain.Content = new uConListEmployee();
                uConMain.Margin = new Thickness(0, 10, 0, 0);

            }
            else if (str == uConSideBarDirector.HOME)
            {
                uConMain.Content = new uConInfo();
                uConMain.Margin = new Thickness(0, 10, 0, 0);
            }
            else if (str == uConSideBarDirector.REPORTTIMEKEEPING)
            {
                uConMain.Content = new uConReportTimeKeeping();
                uConMain.Margin = new Thickness(0, 10, 0, 0);
            }
            else if (str == uConSideBarDirector.TIMEKEEPING)
            {
                uConMain.Content = new uConTimeKeeping();
                uConMain.Margin = new Thickness(0, 10, 0, 0);
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
