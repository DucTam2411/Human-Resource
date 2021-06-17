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

namespace HRMS.Director
{
    using ButtonContent = Tuple<TextBlock, PackIcon>;
    /// <summary>
    /// Interaction logic for uConSideBarDirector.xaml
    /// </summary>
    public partial class uConSideBarDirector : UserControl
    {

        public const string HOME = "Info";
        public const string TIMEKEEPING = "TimeKeeping";
        public const string REPORTEMPLOYEE = "Report Employee";
        public const string REPORTTIMEKEEPING = "Report TimeKeeping";

        public event EventHandler UserControlClicked;
        public event RoutedEventHandler RoutedUserControlClicked;

        List<ButtonContent> buttonPackages = new List<ButtonContent>();
        public uConSideBarDirector()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            buttonPackages.Add(getChildren(btnHome));
            buttonPackages.Add(getChildren(btnTimeKeeping));
            buttonPackages.Add(getChildren(btnReportEmployee));
            buttonPackages.Add(getChildren(btnReportTimeKeeping));
        }


        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            int rowIndex = Grid.GetRow((sender as Button));
            MoveCursor(rowIndex);

            Button btn = sender as Button;
            ButtonContent content = getChildren(btn);
            TextBlock textBlock = content.Item1;
            PackIcon pack = content.Item2; ;

            ChangeColorInButtonList(content);

            textBlock.Foreground = new SolidColorBrush(Colors.White);
            pack.Foreground = new SolidColorBrush(Colors.White);


            //MessageBox.Show(buttonPackages.Count.ToString());


           



            if (UserControlClicked != null)
            {
                UserControlClicked(this, EventArgs.Empty);
            }
            // raise event
            if (RoutedUserControlClicked != null)
            {
                RoutedUserControlClicked(this, e);
            }

        }
        private ButtonContent getChildren(Button myButtonInSidebar)
        {
            StackPanel stack = (StackPanel)myButtonInSidebar.Content;

            TextBlock textBlock = (TextBlock)stack.Children[1];
            PackIcon pack = (PackIcon)stack.Children[0];


            return new ButtonContent(textBlock, pack);
        }

        private void MoveCursor(int index)
        {
            Grid.SetRow(GridCursor, index);
        }

        private void ChangeColorInButtonList(ButtonContent content)
        {
            foreach (ButtonContent c in buttonPackages)
            {
                if (!c.Equals(content))
                {
                    c.Item1.Foreground = new SolidColorBrush(Colors.Black);
                    c.Item2.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                }
            }
        }


    }
}
