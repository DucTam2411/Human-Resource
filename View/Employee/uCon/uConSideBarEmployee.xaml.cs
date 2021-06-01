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
    /// 
    using ButtonContent = Tuple<TextBlock, PackIcon>;
    public partial class uConSideBarEmployee : UserControl
    {
        public const string INFORMATION = "Information";
        public const string TIMEKEEPING = "TimeKeeping";
        public const string      SALARY = "Salary          ";


        public uConSideBarEmployee()
        {
            InitializeComponent();
        }

      

        // buttonList
        List<ButtonContent> buttonPackages = new List<ButtonContent>();

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    buttonPackages.Add(getChildren(btnInformation));
        //    buttonPackages.Add(getChildren(btnTimekeeping));
        //    buttonPackages.Add(getChildren(btnSalary));
        //}

        //private void btn_Click(object sender, RoutedEventArgs e)
        //{
        //    int rowIndex = Grid.GetRow((sender as Button));
        //    MoveCursor(rowIndex);

        //    Button btn = sender as Button;
        //    ButtonContent content = getChildren(btn);
        //    TextBlock textBlock = content.Item1;
        //    PackIcon pack = content.Item2; ;

        //    textBlock.Foreground = new SolidColorBrush(Colors.White);
        //    pack.Foreground = new SolidColorBrush(Colors.White);


        //    //MessageBox.Show(buttonPackages.Count.ToString());


        //    ChangeColorInButtonList(content);

        //    // raise event
        //    if (UserControlClicked != null)
        //    {
        //        UserControlClicked(this, EventArgs.Empty);
        //    }


        //    if (RoutedUserControlClicked != null)
        //    {
        //        RoutedUserControlClicked(this, e);
        //    }

        //}

        //private ButtonContent getChildren(Button myButtonInSidebar)
        //{
        //    StackPanel stack = (StackPanel)myButtonInSidebar.Content;

        //    TextBlock textBlock = (TextBlock)stack.Children[1];
        //    PackIcon pack = (PackIcon)stack.Children[0];


        //    return new ButtonContent(textBlock, pack);
        //}

        //private void MoveCursor(int index)
        //{
        //    Grid.SetRow(GridCursor, index);
        //}

        //// change color buttons
        //private void ChangeColorInButtonList(ButtonContent content)
        //{
        //    foreach (ButtonContent c in buttonPackages)
        //    {
        //        if (!c.Equals(content))
        //        {
        //            c.Item1.Foreground = new SolidColorBrush(Colors.Black);
        //            c.Item2.Foreground = new SolidColorBrush(Colors.Black);
        //        }
        //        else
        //        {
        //        }
        //    }
        //}
    }
}
