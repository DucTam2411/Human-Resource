using HRMS.Accounting.View;
using HRMS.Accouting.Model;
using HRMS.Director.View;
using HRMS.HR.ViewModel;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HRMS.Employee.ViewModel
{
    class InterfaceViewModel : BaseViewModel
    {
        #region Data Binding cho Side Bar

        private SideBarDatabase _SALARYINFOTAB;
        public SideBarDatabase SALARYINFOTAB { get => _SALARYINFOTAB; set { _SALARYINFOTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _INFORMATIONTAB;
        public SideBarDatabase INFORMATIONTAB { get => _INFORMATIONTAB; set { _INFORMATIONTAB = value; OnPropertyChanged(); } }

        private SideBarDatabase _TIMEKEEPINGTAB;
        public SideBarDatabase TIMEKEEPINGTAB { get => _TIMEKEEPINGTAB; set { _TIMEKEEPINGTAB = value; OnPropertyChanged(); } }
        private Grid _GRIDCURSOR;
        public Grid GRIDCURSOR { get => _GRIDCURSOR; set { _GRIDCURSOR = value; OnPropertyChanged(); } }

        private SolidColorBrush _FOREGROUNDSALARYINFO;
        public SolidColorBrush FOREGROUNDSALARYINFO { get => _FOREGROUNDSALARYINFO; set { _FOREGROUNDSALARYINFO = value; OnPropertyChanged(); } }


        private SolidColorBrush _FOREGROUNDINFORMATION;
        public SolidColorBrush FOREGROUNDINFORMATION { get => _FOREGROUNDINFORMATION; set { _FOREGROUNDINFORMATION = value; OnPropertyChanged(); } }

        private SolidColorBrush _FOREGROUNDTIMEKEEPING;
        public SolidColorBrush FOREGROUNDTIMEKEEPING { get => _FOREGROUNDTIMEKEEPING; set { _FOREGROUNDTIMEKEEPING = value; OnPropertyChanged(); } }


        private SolidColorBrush _BACKGROUNDINFORMATION;
        public SolidColorBrush BACKGROUNDINFORMATION { get => _BACKGROUNDINFORMATION; set { _BACKGROUNDINFORMATION = value; OnPropertyChanged(); } }

        private SolidColorBrush _BACKGROUNDTIMEKEEPING;
        public SolidColorBrush BACKGROUNDTIMEKEEPING { get => _BACKGROUNDTIMEKEEPING; set { _BACKGROUNDTIMEKEEPING = value; OnPropertyChanged(); } }

        private SolidColorBrush _BACKGROUNDSALARYINFO;
        public SolidColorBrush BACKGROUNDSALARYINFO { get => _BACKGROUNDSALARYINFO; set { _BACKGROUNDSALARYINFO = value; OnPropertyChanged(); } }

        private ContentControl _CONTENTCONTROL;
        public ContentControl CONTENTCONTROL { get => _CONTENTCONTROL; set { _CONTENTCONTROL = value; OnPropertyChanged(); } }

        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }

        #endregion

        #region Command
        public ICommand HRReportCommand { get; set; }
        public ICommand AccountingReportCommand { get; set; }
        public ICommand InformationCommand { get; set; }
        public ICommand TimekeepingCommand { get; set; }
        public ICommand MorningCommand { get; set; }
        public ICommand AfternoonCommand { get; set; }
        public ICommand SalaryInfoCommand { get; set; }

        #endregion
        public InformationViewModel INFORMATIONVM { get; set; }

        public InterfaceViewModel(int employee_id)
        {
            if (employee_id == 0)
                EMPLOYEE_ID = 4;
            else { EMPLOYEE_ID = employee_id; }
            LoadCommand();
            LoadCommandAttendance(employee_id);
        }

        public InterfaceViewModel()
        {
            EMPLOYEE_ID = 4;
            LoadCommand();
        }
        private void LoadCommand()
        {
            LoadNameSideBar();
            InformationCommand = new RelayCommand<object>(p => { return true; }, p => InformationClick());
            TimekeepingCommand = new RelayCommand<object>(p => { return true; }, p => TimekeepingClick());
            SalaryInfoCommand = new RelayCommand<object>(p => { return true; }, p => SalaryClick());
        }
        //Load data vào side bar
        private void LoadNameSideBar()
        {
            INFORMATIONTAB = new SideBarDatabase("User", "Information");
            TIMEKEEPINGTAB = new SideBarDatabase("ClockOutline", "Timekeeping");
            SALARYINFOTAB = new SideBarDatabase("Dollar", "Salary");

            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.White);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARYINFO = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARYINFO = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConAccountingEmployeeInformation(EMPLOYEE_ID);
        }

        private void InformationClick()
        {
            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.White);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Black);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARYINFO = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARYINFO = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConAccountingEmployeeInformation(EMPLOYEE_ID);
        }

        private void SalaryClick()
        {

            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDSALARYINFO = new SolidColorBrush(Colors.White);
            BACKGROUNDSALARYINFO = new SolidColorBrush(Colors.Black);

            CONTENTCONTROL = new uConAccountingSalaryInformation(EMPLOYEE_ID);
        }
        private void TimekeepingClick()
        {
            FOREGROUNDINFORMATION = new SolidColorBrush(Colors.Black);
            BACKGROUNDINFORMATION = new SolidColorBrush(Colors.Transparent);

            FOREGROUNDTIMEKEEPING = new SolidColorBrush(Colors.White);
            BACKGROUNDTIMEKEEPING = new SolidColorBrush(Colors.Black);

            FOREGROUNDSALARYINFO = new SolidColorBrush(Colors.Black);
            BACKGROUNDSALARYINFO = new SolidColorBrush(Colors.Transparent);

            CONTENTCONTROL = new uConAccountingTimekeepingInformation(EMPLOYEE_ID);
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
    }
}
