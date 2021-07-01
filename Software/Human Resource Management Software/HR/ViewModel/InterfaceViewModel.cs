using HRMS.Accounting.View;
using HRMS.HR.Model;
using HRMS.HR.uCon;
using HRMS.HR.View;
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

namespace HRMS.HR.ViewModel
{
    public class InterfaceViewModel : BaseViewModel
    {
        #region Data Binding cho Side Bar

        private SideBarDatabase _HOMETAB;
        public SideBarDatabase HOMETAB { get => _HOMETAB; set { _HOMETAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _INFORMATIONTAB;
        public SideBarDatabase INFORMATIONTAB { get => _INFORMATIONTAB; set { _INFORMATIONTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _MODIFYTAB;
        public SideBarDatabase MODIFYTAB { get => _MODIFYTAB; set { _MODIFYTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _REPORTTAB;
        public SideBarDatabase REPORTTAB { get => _REPORTTAB; set { _REPORTTAB = value; OnPropertyChanged(); } }
        
        private SideBarDatabase _TIMEKEEPINGTAB;
        public SideBarDatabase TIMEKEEPINGTAB { get => _TIMEKEEPINGTAB; set { _TIMEKEEPINGTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _SALARYTAB;
        public SideBarDatabase SALARYTAB { get => _SALARYTAB; set { _SALARYTAB = value; OnPropertyChanged(); } }

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

        private SolidColorBrush _FOREGROUNDMODIFY;
        public SolidColorBrush FOREGROUNDMODIFY { get => _FOREGROUNDMODIFY; set { _FOREGROUNDMODIFY = value; OnPropertyChanged(); } }

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

        private SolidColorBrush _BACKGROUNDMODIFY;
        public SolidColorBrush BACKGROUNDMODIFY { get => _BACKGROUNDMODIFY; set { _BACKGROUNDMODIFY = value; OnPropertyChanged(); } }
        private SolidColorBrush _BACKGROUNDSALARY;
        public SolidColorBrush BACKGROUNDSALARY { get => _BACKGROUNDSALARY; set { _BACKGROUNDSALARY = value; OnPropertyChanged(); } }

        private ContentControl _CONTENTCONTROL;
        public ContentControl CONTENTCONTROL { get => _CONTENTCONTROL; set { _CONTENTCONTROL = value; OnPropertyChanged(); } }

        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }

        #endregion

        #region Command
        public ICommand HomeCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand InformationCommand { get; set; }
        public ICommand TimekeepingCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand MorningCommand { get; set; }
        public ICommand AfternoonCommand { get; set; }
        public ICommand SalaryCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        #endregion
        public InformationViewModel INFORMATIONVM { get; set; }

        public InterfaceViewModel(int employee_id)
        {
            if (employee_id == 0)
                EMPLOYEE_ID = 4;
            else { EMPLOYEE_ID = employee_id; }
            LoadCommand();
            LoadCommandAttendance(employee_id);
            CreateAttendanceDays();
        }

        public InterfaceViewModel()
        {
            EMPLOYEE_ID = 4;
            LoadCommand();
        }
        private void LoadCommand()
        {
            LoadNameSideBar();
            HomeCommand = new RelayCommand<object>(p => { return true; }, p => HomeClick());
            ReportCommand = new RelayCommand<object>(p => { return true; }, p => ReportClick());
            InformationCommand = new RelayCommand<object>(p => { return true; }, p => InformationClick());
            TimekeepingCommand = new RelayCommand<object>(p => { return true; }, p => TimekeepingClick());
            ModifyCommand = new RelayCommand<object>(p => { return true; }, p => ModifyClick());
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
            MODIFYTAB = new SideBarDatabase("Settings", "Manage");
            TIMEKEEPINGTAB = new SideBarDatabase("ClockOutline", "Timekeeping");
            SALARYTAB = new SideBarDatabase("Money","Salary");

            BACKGROUNDHOME = new SolidColorBrush(Colors.Black);
            FOREGROUNDHOME = new SolidColorBrush(Colors.White);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDMODIFY = new SolidColorBrush(Colors.Black);
            BACKGROUNDMODIFY = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConDashboard(EMPLOYEE_ID);
        }

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

            FOREGROUNDMODIFY = new SolidColorBrush(Colors.Black);
            BACKGROUNDMODIFY = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConDashboard(EMPLOYEE_ID);
        }

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

            FOREGROUNDMODIFY = new SolidColorBrush(Colors.Black);
            BACKGROUNDMODIFY = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConReport(EMPLOYEE_ID);
        }

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

            FOREGROUNDMODIFY = new SolidColorBrush(Colors.Black);
            BACKGROUNDMODIFY = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConHRInformation(EMPLOYEE_ID);
        }

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

            FOREGROUNDMODIFY = new SolidColorBrush(Colors.Black);
            BACKGROUNDMODIFY = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConTimekeepingInformation(EMPLOYEE_ID);
        }

        private void ModifyClick()
        {
            BACKGROUNDMODIFY = new SolidColorBrush(Colors.Black);
            FOREGROUNDMODIFY = new SolidColorBrush(Colors.White);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDHOME = new SolidColorBrush(Colors.Black);
            BACKGROUNDHOME = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARY = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConListEmployee(EMPLOYEE_ID);
        }

        private void SalaryClick()
        {
            
            BACKGROUNDSALARY = new SolidColorBrush(Colors.Black);
            FOREGROUNDSALARY = new SolidColorBrush(Colors.White);

            FOREGROUNDHOME = new SolidColorBrush(Colors.Black);
            BACKGROUNDHOME = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDREPORT = new SolidColorBrush(Colors.Black);
            BACKGROUNDREPORT = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            BACKGROUNDMODIFY = new SolidColorBrush(Colors.Transparent);
            FOREGROUNDMODIFY = new SolidColorBrush(Colors.Black);

            CONTENTCONTROL = new uConAccountingSalaryInformation(EMPLOYEE_ID);
        }
        private void LoadCommandAttendance(int id)
        {
            hrmsEntities db = new hrmsEntities();
            var timekeepingdetail1 = db.TIMEKEEPING_DETAIL.Where(x => x.EMPLOYEE_ID == id && x.CHECK_DATE.Value.Day == DateTime.Now.Day && x.CHECK_DATE.Value.Month == DateTime.Now.Month && x.CHECK_DATE.Value.Year == DateTime.Now.Year && x.SESSION == 1).SingleOrDefault();
            var timekeepingdetail2 = db.TIMEKEEPING_DETAIL.Where(x => x.EMPLOYEE_ID == id && x.CHECK_DATE.Value.Day == DateTime.Now.Day && x.CHECK_DATE.Value.Month == DateTime.Now.Month && x.CHECK_DATE.Value.Year == DateTime.Now.Year && x.SESSION == 2).SingleOrDefault();
            var timekeeping = db.TIMEKEEPINGs.Where(x => x.EMPLOYEE_ID == id && x.MONTH.Value.Month == DateTime.Now.Month && x.MONTH.Value.Year == DateTime.Now.Year).SingleOrDefault();
            MorningCommand = new RelayCommand<object>(p =>
            {
                if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 11)
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
                if (ReportViewModel.IsHoliday(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
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
                if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour <= 17)
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
                if (ReportViewModel.IsHoliday(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year) || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
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
        public static void CreateAttendanceDays()
        {
            hrmsEntities db = new hrmsEntities();
            var list = (from emp in db.EMPLOYEEs
                        join
                        del in db.DELETEs on emp.EMPLOYEE_ID equals del.EMPLOYEE_ID
                        where del.ISDELETED == false
                        select new { id = emp.EMPLOYEE_ID }).Distinct();
            foreach (var item in list)
            {
                TIMEKEEPING temp = db.TIMEKEEPINGs.Where(x => x.EMPLOYEE_ID == item.id && x.MONTH.Value.Month == DateTime.Now.Month && x.MONTH.Value.Year == DateTime.Now.Year).FirstOrDefault();
                if (temp == null)
                {
                    DateTime date = DateTime.Now;

                    var timekeeping = new TIMEKEEPING()
                    {
                        TIMEKEEPING_ID = DateTime.Now.Month + DateTime.Now.Year + item.id,
                        DATE_START = DateTime.Now,
                        MONTH = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                        DATE_END = new DateTime(DateTime.Now.Year, DateTime.Now.Month, ListEmployeeViewModel.GetDaybyMonth(DateTime.Now.Month, DateTime.Now.Year)),
                        EMPLOYEE_ID = item.id,
                        NUMBER_OF_ABSENT_DAY = ReportViewModel.CalculateAverageDay(DateTime.Now.Month, DateTime.Now.Year),
                        NUMBER_OF_OVERTIME_DAY = 0,
                        NUMBER_OF_WORK_DAY = 0,
                        NUMBER_OF_STANDARD_DAY = ReportViewModel.CalculateAverageDay(DateTime.Now.Month, DateTime.Now.Year)
                    };

                    db.TIMEKEEPINGs.Add(timekeeping);
                    for (int i = date.Day; i <= ListEmployeeViewModel.GetDaybyMonth(DateTime.Now.Month, DateTime.Now.Year); i++)
                    {
                        if (ReportViewModel.IsHoliday(date.Day, date.Month, date.Year) == false)
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday)
                            {
                                TIMEKEEPING_DETAIL timedetail = new TIMEKEEPING_DETAIL();
                                timedetail.EMPLOYEE_ID = item.id;
                                timedetail.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                                timedetail.CHECK_DATE = date;
                                timedetail.SESSION = 1;
                                timedetail.TIMEKEEPING_DETAIL_TYPE = 0;
                                db.TIMEKEEPING_DETAIL.Add(timedetail);
                            }
                            else
                            {
                                TIMEKEEPING_DETAIL timedetail1 = new TIMEKEEPING_DETAIL();
                                timedetail1.EMPLOYEE_ID = item.id;
                                timedetail1.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                                timedetail1.CHECK_DATE = date;
                                timedetail1.SESSION = 1;
                                timedetail1.TIMEKEEPING_DETAIL_TYPE = 0;
                                db.TIMEKEEPING_DETAIL.Add(timedetail1);

                                TIMEKEEPING_DETAIL timedetail2 = new TIMEKEEPING_DETAIL();
                                timedetail2.EMPLOYEE_ID = item.id;
                                timedetail2.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                                timedetail2.CHECK_DATE = date;
                                timedetail2.SESSION = 2;
                                timedetail2.TIMEKEEPING_DETAIL_TYPE = 0;
                                db.TIMEKEEPING_DETAIL.Add(timedetail2);
                            }
                        }
                        date = date.AddDays(1);
                    }

                }
            }
            db.SaveChanges();

        }
    }
}
