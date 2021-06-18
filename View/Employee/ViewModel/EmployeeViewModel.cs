using HRMS.Employee.uCon;
using HRMS.HR.ViewModel;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRMS.Employee.ViewModel
{
    class EmployeeViewModel : BaseViewModel
    {

        #region Handle uConSalary

        /// <summary>
        ///  PROPERTIES
        /// </summary>
        public DateTime[] SalaryMonthList { get; set; }

        // i need timekeeping to fill data into datagrid 
        private TIMEKEEPING[] _TimekeepingList;
        public TIMEKEEPING[] TimekeepingList
        {
            get
            {
                return _TimekeepingList;
            }
            set
            {
                _TimekeepingList = value;
                OnPropertyChanged();
            }
        }


        // salaryList for uCondEmployeeSalary
        private SALARY[] _SalaryList;
        public SALARY[] SalaryList
        {
            get
            {
                return _SalaryList;
            }
            set
            {
                _SalaryList = value;
                OnPropertyChanged();
            }
        }


        private SALARY _SalarySelected;
        public SALARY SalarySelected
        {
            get
            {
                return _SalarySelected;
            }

            set
            {
                _SalarySelected = value;
                OnPropertyChanged();
            }
        }

        private TIMEKEEPING _TimekeepingSelected;
        public TIMEKEEPING TimekeepingSelected
        {
            get
            {
                return _TimekeepingSelected;
            }
            set
            {
                _TimekeepingSelected = value;
                OnPropertyChanged();

            }
        }


        /// <summary>
        /// COMMANDS
        /// </summary>
        public ICommand MonthSelectionChangedCommand { get; set; } // get data in combobox


        /// <summary>
        /// FUNCTIONS
        /// </summary>
        /// <param name="a"></param>
        public void MonthSelectionChange(DateTime a)
        {
            // select month
            monthSelectInTimkeepingDetail = a;

            int day = a.Day, month = a.Month;
            hrmsEntities db = new hrmsEntities();
            TimekeepingSelected = ((from timekeeping in db.TIMEKEEPINGs
                                    where timekeeping.MONTH.Value.Month == month && timekeeping.MONTH.Value.Day == day
                                    select timekeeping).Take(1).Single());
            SalarySelected = ((from s in db.SALARies
                               where s.MONTH.Value.Month == month && s.MONTH.Value.Day == day
                               select s).Take(1).Single());

        }
        #endregion






        #region Handle uConDetailTimekeepingWhole

        /// <summary>
        ///  PROPERTIES
        /// </summary>
        private DateTime[] _TimekeepingMonthList;
        public DateTime[] TimekeepingMonthList
        {
            get
            {

                return _TimekeepingMonthList;
            }
            set
            {
                _TimekeepingMonthList = value;
                OnPropertyChanged();

            }

        }



        private DateTime _monthSelectInTimkeepingDetail;
        private DateTime monthSelectInTimkeepingDetail
        {
            get => _monthSelectInTimkeepingDetail;
            set
            {
                _monthSelectInTimkeepingDetail = value;
                OnPropertyChanged();
            }
        }

        private int _selectedIndex;
        public int selectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (SalaryMonthList.Length > 0)
                {
                    MonthSelectionChange(SalaryMonthList[0]);
                }
                OnPropertyChanged();
            }
        }

        private DateTime _selectValue;
        public DateTime selectValue
        {
            get
            {
                return _selectValue;
            }

            set
            {
                _selectValue = value;
                OnPropertyChanged();
            }

        }

        // search in dtgv
        private string _strSearchBy;
        public string strSearchBy
        {
            get
            {
                return _strSearchBy;
            }
            set
            {
                _strSearchBy = value;
                OnPropertyChanged();
            }
        }




        /// <summary>
        ///  COMMAND
        /// </summary>

        public ICommand SearchTextCommand { get; set; }
        public ICommand SearchTextChangedCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }


        /// <summary>
        ///  FUNCTION
        /// </summary>

        public void SearchBarChange(string text)
        {
            hrmsEntities db = new hrmsEntities();

            if (text != string.Empty)
            {

                switch (strSearchBy)
                {

                    case "System.Windows.Controls.ComboBoxItem: Month":
                        {
                            int intMonth = 0;
                            if (Int32.TryParse(text, out intMonth))
                            {
                                intMonth = Int32.Parse(text);
                                TimekeepingList = (from timekeeping in db.TIMEKEEPINGs
                                                   where timekeeping.MONTH.Value.Month == intMonth
                                                   select timekeeping).ToArray();
                            }
                            break;
                        }

                    case "System.Windows.Controls.ComboBoxItem: Day Start":
                        {
                            int intDay = 0;
                            if (Int32.TryParse(text, out intDay))
                            {

                                intDay = Int32.Parse(text);
                                TimekeepingList = (from timekeeping in db.TIMEKEEPINGs
                                                   where timekeeping.DATE_START.Value.Day == intDay
                                                   select timekeeping).ToArray();
                            }

                            break;
                        }

                    case "System.Windows.Controls.ComboBoxItem: Day End":
                        {
                            int intDay = 0;
                            if (Int32.TryParse(text, out intDay))
                            {

                                intDay = Int32.Parse(text);
                                TimekeepingList = (from timekeeping in db.TIMEKEEPINGs
                                                   where timekeeping.DATE_END.Value.Day == intDay
                                                   select timekeeping).ToArray();
                            }

                            break;

                        }
                    case "System.Windows.Controls.ComboBoxItem: Total Work Day":
                        int workday = 0;
                        if (Int32.TryParse(text, out workday))
                        {
                            workday = Int32.Parse(text);
                            TimekeepingList = (from timekeeping in db.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_WORK_DAY.Value == workday
                                               select timekeeping).ToArray();
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Total Overtime Day":
                        int overtimeday = 0;
                        if (Int32.TryParse(text, out overtimeday))
                        {
                            overtimeday = Int32.Parse(text);
                            TimekeepingList = (from timekeeping in db.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_OVERTIME_DAY.Value == overtimeday
                                               select timekeeping).ToArray();
                        }
                        break;



                    case "System.Windows.Controls.ComboBoxItem: Total Absent Day":
                        int absentday = 0;
                        if (Int32.TryParse(text, out absentday))
                        {
                            overtimeday = Int32.Parse(text);
                            TimekeepingList = (from timekeeping in db.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_ABSENT_DAY.Value.ToString().StartsWith(absentday.ToString())
                                               select timekeeping).ToArray();
                        }
                        break;
                }

            }
            else
            {
                TimekeepingList = (from t in db.TIMEKEEPINGs
                                   orderby t.MONTH descending
                                   select t).ToArray();
            }

        }

        #endregion




        #region Handle  uConInformation
        /// <summary>
        /// PROPERTIES
        /// </summary>
        private EMPLOYEE _employee;
        public EMPLOYEE Employee
        {
            get
            {
                return _employee;
            }


            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        #endregion





        #region uConEmployeeTimekeepingDetail
        /// <summary>
        /// PROPERTIES
        /// </summary>
        private ObservableCollection<string> _workdayList { get; set; }
        public ObservableCollection<string> workdayList
        {

            get { return _workdayList; }
            set
            {
                _workdayList = value;
                OnPropertyChanged();
            }

        }

        public ObservableCollection<string> _absentdayList { get; set; }
        public ObservableCollection<string> absentdayList
        {
            get
            {
                return _absentdayList;
            }
            set
            {
                _absentdayList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> _overtimeList { get; set; }
        public ObservableCollection<string> overtimeList
        {
            get
            {
                return _overtimeList;
            }
            set
            {
                _overtimeList = value;
                OnPropertyChanged();
            }
        }



        /// <summary>
        /// COMMANDS
        /// </summary>
        public ICommand MonthSelectionChangedDetailCommand { get; set; }
        public ICommand BackToWholeCommand { get; set; }


        /// <summary>
        /// FUNCTIONS
        /// </summary>
        public void getDayList(DateTime timekeeping_date, int id)
        {
            hrmsEntities db = new hrmsEntities();
            var GetWorkdayList = ((from t in db.TIMEKEEPING_DETAIL
                            where t.TIMEKEEPING.MONTH.Value.Month == timekeeping_date.Month &&
                            t.TIMEKEEPING.MONTH.Value.Year == timekeeping_date.Year &&
                            (t.TIMEKEEPING_DETAIL_TYPE == 1 || t.TIMEKEEPING_DETAIL_TYPE == 2) &&
                            t.EMPLOYEE_ID == id
                            orderby t.CHECK_DATE.Value.Day ascending
                            select t).Distinct());
            workdayList = new ObservableCollection<string>();
            absentdayList = new ObservableCollection<string>();
            overtimeList = new ObservableCollection<string>();
            foreach (var item in GetWorkdayList)
            {
                string Session = "";
                if (item != null)
                {
                    if (item.SESSION == 1)
                    {
                        Session = "Morning";
                        workdayList.Add(item.CHECK_DATE.Value.Day + "/" + item.CHECK_DATE.Value.Month + "/" + item.CHECK_DATE.Value.Year + "(" + Session + ")");
                    }
                    else
                    {
                        Session = "Afternoon";
                        workdayList.Add(item.CHECK_DATE.Value.Day + "/" + item.CHECK_DATE.Value.Month + "/" + item.CHECK_DATE.Value.Year + "(" + Session + ")");
                    }
                }
            }

            var GetAbsentdayList = ((from t in db.TIMEKEEPING_DETAIL
                                     where t.TIMEKEEPING.MONTH == timekeeping_date && t.TIMEKEEPING_DETAIL_TYPE == 0 && t.CHECK_DATE.Value.Day <= DateTime.Now.Day
                                     && t.EMPLOYEE_ID == id
                                     select t).Distinct()) ;
            foreach (var item in GetAbsentdayList)
            {
                string Session = "";
                if (item != null)
                {
                    if (item.SESSION == 1)
                    {
                        Session = "Morning";
                        absentdayList.Add(item.CHECK_DATE.Value.Day + "/" + item.CHECK_DATE.Value.Month + "/" + item.CHECK_DATE.Value.Year + "(" + Session + ")");
                    }
                    else
                    {
                        Session = "Afternoon";
                        absentdayList.Add(item.CHECK_DATE.Value.Day + "/" + item.CHECK_DATE.Value.Month + "/" + item.CHECK_DATE.Value.Year + "(" + Session + ")");
                    }
                }
                
            }

            var GetOvertimeList = ((from t in db.TIMEKEEPING_DETAIL
                             where t.TIMEKEEPING.MONTH == timekeeping_date && t.TIMEKEEPING_DETAIL_TYPE == 3
                             && t.EMPLOYEE_ID == id
                             select t).Distinct());
            foreach (var item in GetOvertimeList)
            {
                if (item != null)
                {
                    string Session = "";
                    if (item.SESSION == 1)
                    {
                        Session = "Morning";
                        overtimeList.Add(item.CHECK_DATE.Value.Day + "/" + item.CHECK_DATE.Value.Month + "/" + item.CHECK_DATE.Value.Year + "(" + Session + ")");
                    }
                    else
                    {
                        Session = "Afternoon";
                        overtimeList.Add(item.CHECK_DATE.Value.Day + "/" + item.CHECK_DATE.Value.Month + "/" + item.CHECK_DATE.Value.Year + "(" + Session + ")");
                    }
                }
            }
        }
        #endregion

        NavigationViewModel NavigationViewModel;
        public EmployeeViewModel(int employee_ID, NavigationViewModel navigationViewModel)
        {
            hrmsEntities db = new hrmsEntities();
            this.NavigationViewModel = navigationViewModel;

            Employee = ((from employee in db.EMPLOYEEs
                         where employee.EMPLOYEE_ID == employee_ID
                         select employee).Take(1).Single());


            TimekeepingList = (from timekeeping in db.TIMEKEEPINGs
                               where timekeeping.EMPLOYEE_ID == employee_ID
                               orderby timekeeping.MONTH descending
                               select timekeeping).ToArray();

            SalaryList = (from salary in db.SALARies
                          where salary.EMPLOYEE_ID == employee_ID
                          orderby salary.DATE_START descending
                          select salary).ToArray();

            SalaryMonthList = ((from salary in db.SALARies
                                where salary.EMPLOYEE_ID == employee_ID
                                orderby salary.MONTH.Value descending
                                select salary.MONTH.Value).Distinct().ToArray());


            // for detail timekeeping
            TimekeepingMonthList = (from t in db.TIMEKEEPINGs
                                    orderby t.MONTH.Value descending
                                    select t.MONTH.Value).Distinct().ToArray();


            // select the top month
            selectedIndex = 0;



            // declare command 
            SearchTextChangedCommand = new RelayCommand<string>(null, p => { SearchBarChange(p); });

            MonthSelectionChangedCommand = new RelayCommand<DateTime>(null, p => { MonthSelectionChange(p); });




            // command for detail timekeeping
            DoubleClickCommand = new RelayCommand<object>(null, p => NavigationViewModel.CONTENT_MAIN = new uConEmployeeTimekeepingDetail(Employee.EMPLOYEE_ID, NavigationViewModel));

            BackToWholeCommand = new RelayCommand<object>(null, p => NavigationViewModel.CONTENT_MAIN = new uConEmployeeTimekeepingWhole(Employee.EMPLOYEE_ID, NavigationViewModel));
            MonthSelectionChangedDetailCommand = new RelayCommand<DateTime>(null, p => { getDayList(p,employee_ID); });


        }
    }
}
