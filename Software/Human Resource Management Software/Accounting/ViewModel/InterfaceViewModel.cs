using HRMS.Accounting.View;
using HRMS.Accouting.Model;
using HRMS.HR.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace HRMS.Accouting.ViewModel
{
    using ButtonContent = Tuple<TextBlock, PackIcon>;
    public class InterfaceViewModel : BaseViewModel
    {
        //Những BACKGROUND và FOREGROUND cho từng button để đổi màu khi click
        #region Data Binding cho Side Bar

        private SideBarDatabase _HOMETAB;
        public SideBarDatabase HOMETAB { get => _HOMETAB; set { _HOMETAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _REPORTTAB;
        public SideBarDatabase REPORTTAB { get => _REPORTTAB; set { _REPORTTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _SALARYINFOTAB;
        public SideBarDatabase SALARYINFOTAB { get => _SALARYINFOTAB; set { _SALARYINFOTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _INFORMATIONTAB;
        public SideBarDatabase INFORMATIONTAB { get => _INFORMATIONTAB; set { _INFORMATIONTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _TIMEKEEPINGTAB;
        public SideBarDatabase TIMEKEEPINGTAB { get => _TIMEKEEPINGTAB; set { _TIMEKEEPINGTAB = value; OnPropertyChanged(); } }

        private Grid _GRIDCURSOR;
        public Grid GRIDCURSOR { get => _GRIDCURSOR; set { _GRIDCURSOR = value; OnPropertyChanged(); } }

        private SolidColorBrush _FOREGROUNDHOME;
        public SolidColorBrush FOREGROUNDHOME { get => _FOREGROUNDHOME; set { _FOREGROUNDHOME = value; OnPropertyChanged(); } }


        private SolidColorBrush _FOREGROUNDREPORT;
        public SolidColorBrush FOREGROUNDREPORT { get => _FOREGROUNDREPORT; set { _FOREGROUNDREPORT = value; OnPropertyChanged(); } }

        private SolidColorBrush _FOREGROUNDINFORMATION;
        public SolidColorBrush FOREGROUNDINFORMATION { get => _FOREGROUNDINFORMATION; set { _FOREGROUNDINFORMATION = value; OnPropertyChanged(); } }

        private SolidColorBrush _FOREGROUNDTIMEKEEPING;
        public SolidColorBrush FOREGROUNDTIMEKEEPING { get => _FOREGROUNDTIMEKEEPING; set { _FOREGROUNDTIMEKEEPING = value; OnPropertyChanged(); } }

        private SolidColorBrush _FOREGROUNDSALARY;
        public SolidColorBrush FOREGROUNDSALARY { get => _FOREGROUNDSALARY; set { _FOREGROUNDSALARY = value; OnPropertyChanged(); } }

        private SolidColorBrush _BACKGROUNDHOME;
        public SolidColorBrush BACKGROUNDHOME { get => _BACKGROUNDHOME; set { _BACKGROUNDHOME = value; OnPropertyChanged(); } }

        private SolidColorBrush _BACKGROUNDREPORT;
        public SolidColorBrush BACKGROUNDREPORT { get => _BACKGROUNDREPORT; set { _BACKGROUNDREPORT = value; OnPropertyChanged(); } }

        private SolidColorBrush _BACKGROUNDINFORMATION;
        public SolidColorBrush BACKGROUNDINFORMATION { get => _BACKGROUNDINFORMATION; set { _BACKGROUNDINFORMATION = value; OnPropertyChanged(); } }

        private SolidColorBrush _BACKGROUNDTIMEKEEPING;
        public SolidColorBrush BACKGROUNDTIMEKEEPING { get => _BACKGROUNDTIMEKEEPING; set { _BACKGROUNDTIMEKEEPING = value; OnPropertyChanged(); } }

        private SolidColorBrush _BACKGROUNDSALARY;
        public SolidColorBrush BACKGROUNDSALARY { get => _BACKGROUNDSALARY; set { _BACKGROUNDSALARY = value; OnPropertyChanged(); } }

        private ContentControl _CONTENTCONTROL;
        public ContentControl CONTENTCONTROL { get => _CONTENTCONTROL; set { _CONTENTCONTROL = value; OnPropertyChanged(); } }

        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }

        #endregion

        //Những command cho từng button
        #region Command
        public ICommand HomeCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand InformationCommand { get; set; }
        public ICommand TimekeepingCommand { get; set; }
        public ICommand SalaryCommand { get; set; }
        public ICommand MorningCommand { get; set; }
        public ICommand AfternoonCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        #endregion

        //Constructor mặc định của InterfaceViewModel (cần ID của người dùng để chia sẽ cho các User Control khác)
        public InterfaceViewModel(int employee_id)
        {
            if (employee_id == 0)
                EMPLOYEE_ID = 2;
            else { EMPLOYEE_ID = employee_id; }
            LoadCommand();
            LoadAttentdance(employee_id);
        }

        //Constructor mặc định của InterfaceViewModel
        public InterfaceViewModel()
        {
            EMPLOYEE_ID = 2;
            LoadCommand();
            LoadAttentdance(EMPLOYEE_ID);
        }

        //Load những command để đưa vào constructor
        private void LoadCommand()
        {
            LoadNameSideBar();
            HomeCommand = new RelayCommand<object>(p => { return true; }, p => HomeClick());
            ReportCommand = new RelayCommand<object>(p => { return true; }, p => ReportClick());
            InformationCommand = new RelayCommand<object>(p => { return true; }, p => InformationClick());
            TimekeepingCommand = new RelayCommand<object>(p => { return true; }, p => TimekeepingClick());
            SalaryCommand = new RelayCommand<object>(p => { return true; }, p => SalaryClick());
            ExitCommand = new RelayCommand<Window>(p => { return true; }, p => { this.CloseWindow(p); });
        }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        //Load data vào side bar
        private void LoadNameSideBar()
        {
            HOMETAB = new SideBarDatabase("ViewDashboard", "Home");
            REPORTTAB = new SideBarDatabase("FileReport", "Report");
            INFORMATIONTAB = new SideBarDatabase("FolderAccountOutline", "Information");
            SALARYINFOTAB = new SideBarDatabase("Money", "Salary");
            TIMEKEEPINGTAB = new SideBarDatabase("ClockOutline", "Timekeeping");

            BACKGROUNDHOME = new SolidColorBrush(Colors.Black);
            FOREGROUNDHOME = new SolidColorBrush(Colors.White);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConDashBoard(EMPLOYEE_ID);
        }

        //Command khi click vào button (khi nhấn vào button thì BACKGROUND và FOREGROUND của chính button đó đổi màu còn những button còn lại giữ nguyên)
        #region Giải quyết command
        //Command cho button Home
        private void HomeClick()
        {
            BACKGROUNDHOME = new SolidColorBrush(Colors.Black);
            FOREGROUNDHOME = new SolidColorBrush(Colors.White);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConDashBoard(EMPLOYEE_ID);
        }

        //Command cho button Report
        private void ReportClick()
        {
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Black);
            FOREGROUNDREPORT = new SolidColorBrush(Colors.White);

            FOREGROUNDHOME = new SolidColorBrush(Colors.Black);
            BACKGROUNDHOME = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConListEmployeeAccounting(EMPLOYEE_ID);
        }

        //Command cho button Information
        private void InformationClick()
        {
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.White);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDHOME = new SolidColorBrush(Colors.Black);
            BACKGROUNDHOME = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConAccountingEmployeeInformation(EMPLOYEE_ID);
        }

        //Command cho button Timekeeping
        private void TimekeepingClick()
        {
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.White);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDHOME = new SolidColorBrush(Colors.Black);
            BACKGROUNDHOME = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConAccountingTimekeepingInformation(EMPLOYEE_ID);
        }

        //Command cho button Salary
        private void SalaryClick()
        {
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Black);
            FOREGROUNDSALARY = new SolidColorBrush(Colors.White);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDHOME = new SolidColorBrush(Colors.Black);
            BACKGROUNDHOME = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConAccountingSalaryInformation(EMPLOYEE_ID);
        }
        #endregion


        private void LoadAttentdance(int id)
        {
            hrmsEntities db = new hrmsEntities();
            var timekeepingdetail1 = db.TIMEKEEPING_DETAIL.Where(x => x.EMPLOYEE_ID == id && x.CHECK_DATE.Value.Day == DateTime.Now.Day && x.CHECK_DATE.Value.Month == DateTime.Now.Month && x.CHECK_DATE.Value.Year == DateTime.Now.Year && x.SESSION == 1).SingleOrDefault();
            var timekeepingdetail2 = db.TIMEKEEPING_DETAIL.Where(x => x.EMPLOYEE_ID == id && x.CHECK_DATE.Value.Day == DateTime.Now.Day && x.CHECK_DATE.Value.Month == DateTime.Now.Month && x.CHECK_DATE.Value.Year == DateTime.Now.Year && x.SESSION == 2).SingleOrDefault();
            var timekeeping = db.TIMEKEEPINGs.Where(x => x.EMPLOYEE_ID == id && x.MONTH.Value.Month == DateTime.Now.Month && x.MONTH.Value.Year == DateTime.Now.Year).SingleOrDefault();

            MorningCommand = new RelayCommand<object>(p =>
            {
                if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour < 11)
                {
                    if (timekeepingdetail1 == null || timekeepingdetail1.TIMEKEEPING_DETAIL_TYPE == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                { return false; }
            },
            p =>
            {
                if (AccountingClass.IsHoliday(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
                {
                    var timekeepingdetail = new TIMEKEEPING_DETAIL();
                    timekeepingdetail.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                    timekeepingdetail.CHECK_DATE = DateTime.Now;
                    timekeepingdetail.SESSION = 1;
                    timekeepingdetail.EMPLOYEE_ID = id;
                    timekeepingdetail.TIMEKEEPING_DETAIL_TYPE = 3;
                    timekeepingdetail1 = timekeepingdetail;
                    db.TIMEKEEPING_DETAIL.Add(timekeepingdetail);
                }
                else
                {
                    timekeepingdetail1.TIMEKEEPING_DETAIL_TYPE = 1;
                    timekeeping.NUMBER_OF_ABSENT_DAY = (float?)(timekeeping.NUMBER_OF_ABSENT_DAY - 0.5);
                    timekeeping.NUMBER_OF_WORK_DAY = (float)(timekeeping.NUMBER_OF_WORK_DAY + 0.5);
                }
                db.SaveChanges();
            }
            );
            AfternoonCommand = new RelayCommand<object>(p =>
            {
                if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour < 23)
                {
                    if (timekeepingdetail2 == null || timekeepingdetail2.TIMEKEEPING_DETAIL_TYPE == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                { return false; }
            },
            p =>
            {
                if (AccountingClass.IsHoliday(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year) || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                {
                    var timekeepingdetail = new TIMEKEEPING_DETAIL();
                    timekeepingdetail.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                    timekeepingdetail.CHECK_DATE = DateTime.Now;
                    timekeepingdetail.SESSION = 2;
                    timekeepingdetail.EMPLOYEE_ID = id;
                    timekeepingdetail.TIMEKEEPING_DETAIL_TYPE = 3;
                    timekeepingdetail2 = timekeepingdetail;
                    db.TIMEKEEPING_DETAIL.Add(timekeepingdetail);
                }
                else
                {
                    timekeepingdetail2.TIMEKEEPING_DETAIL_TYPE = 2;
                    timekeeping.NUMBER_OF_ABSENT_DAY = (float?)(timekeeping.NUMBER_OF_ABSENT_DAY - 0.5);
                    timekeeping.NUMBER_OF_WORK_DAY = (float)(timekeeping.NUMBER_OF_WORK_DAY + 0.5);
                }
                db.SaveChanges();
            }
            );
        }
    }
}

