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

            //a = new NavigationViewModel(employee_id);
            //Sidebar.DataContext = a;
            //sss.DataContext = a;

            //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            //dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            //dispatcherTimer.Start();
        }


        public EmployeeWindow(int employee_id)
        {
            InitializeComponent();

            a = new NavigationViewModel(employee_id);
            Sidebar.DataContext = a;
            sss.DataContext = a;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();
        }



        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {


            /* Compare today with last day in the TIMEKEEPING.MONTH
             *  if (today.MONTH > lastday.MONTH && today.YEAR > lastday.YEAR)   -> need a new timekeeping record */

            DateTime today = DateTime.Now;
            DateTime lastday = (from t in HRMSDatabase.Ins.TIMEKEEPINGs
                                orderby t.MONTH descending
                                select t.MONTH.Value
                                ).Take(1).Single();
            
            if(lastday != null && today.Month > lastday.Month && today.Year > lastday.Year)
            {
                insertNewTimekeepingAsync(3);
            }



            if (isNormalWorkday(DateTime.Now))
            {
                insertNewTimekeepingAsync(4);
            }
            else
            {
                   
            }

        }


        public async Task insertNewTimekeepingAsync(int emplopyee_id)
        {
            TIMEKEEPING record = new TIMEKEEPING();
            record.EMPLOYEE_ID = emplopyee_id;
            record.NUMBER_OF_ABSENT_DAY = 0;
            record.NUMBER_OF_OVERTIME_DAY= 0;
            record.NUMBER_OF_WORK_DAY = 0;

            HRMSDatabase.Ins.TIMEKEEPINGs.Add(record);
            await HRMSDatabase.Ins.SaveChangesAsync();
        }


        private bool isNormalWorkday(DateTime a)
        {

            switch (a.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    return true;

                case DayOfWeek.Saturday:
                    string strHour = a.ToString("HH");
                    int hour = 0;

                    //i will use 24h 
                    if (Int32.TryParse(strHour, out hour))
                    {

                        // 1h is still A.M
                        if (hour <= 1)
                        {
                            return true;
                        }

                        // else if it  > 1h AM -> not a normal day
                        return false;
                    }

                    break;

                default:
                    // Sunday -> not a normal day 
                    return false;
            }
            return false;
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //DragMove();
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
