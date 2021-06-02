using HRMS.Employee.uCon;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRMS.Employee.ViewModel
{
    class EmployeeViewModel : BaseViewModel
    {


        #region Handle uConSalary

        public ICommand MonthSelectionChangedCommand { get; set; }
        // get data in combobox


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


        public void MonthSelectionChange(DateTime a)
        {
            int day = a.Day, month = a.Month;
            TimekeepingSelected = ((from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
                                    where timekeeping.MONTH.Value.Month == month && timekeeping.MONTH.Value.Day == day
                                    select timekeeping).Take(1).Single());
            SalarySelected = ((from s in HRMSDatabase.Ins.SALARies
                               where s.MONTH.Value.Month == month && s.MONTH.Value.Day == day
                               select s).Take(1).Single());

        }

        #endregion




        #region Handle uConDetailTimekeeping


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

        private DateTime[] _workdayList { get; set; }
        public DateTime[] workdayList
        {

            get { return _workdayList; }
            set
            {
                _workdayList = value;
                OnPropertyChanged();
            }

        }

        public DateTime[] _absentdayList { get; set; }
        public DateTime[] absentdayList
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

        public DateTime[] _overtimeList { get; set; }
        public DateTime[] overtimeList
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
        ///  COMMAND
        /// </summary>
        public ICommand MonthSelectionChangedDetailCommand { get; set; }



        /// <summary>
        ///  FUNCTION
        /// </summary>
        public void getDayList(DateTime timekeeping_date)
        {
            workdayList = ((from t in HRMSDatabase.Ins.TIMEKEEPING_DETAIL
                            where t.TIMEKEEPING.MONTH.Value.Month == timekeeping_date.Month &&
                            t.TIMEKEEPING.MONTH.Value.Year == timekeeping_date.Year &&
                            t.TIMEKEEPING_DETAIL_TYPE == 1
                            select t.CHECK_DATE.Value).ToArray());

            absentdayList = ((from t in HRMSDatabase.Ins.TIMEKEEPING_DETAIL
                              where t.TIMEKEEPING.MONTH == timekeeping_date && t.TIMEKEEPING_DETAIL_TYPE == 2
                              select t.CHECK_DATE.Value).ToArray());

            overtimeList = ((from t in HRMSDatabase.Ins.TIMEKEEPING_DETAIL
                             where t.TIMEKEEPING.MONTH == timekeeping_date && t.TIMEKEEPING_DETAIL_TYPE == 3
                             select t.CHECK_DATE.Value).ToArray());

        }


        #endregion


        #region Handle uConTimekeeping + uConInformation
        public ICommand SearchTextCommand { get; set; }
        public ICommand SearchTextChangedCommand { get; set; }



        // for binding for information
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



        // 

        // for first_select
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

        public void SearchBarChange(string text)
        {

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
                                TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
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
                                TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
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
                                MessageBox.Show("SS");
                                TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
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
                            TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_WORK_DAY.Value == workday
                                               select timekeeping).ToArray();
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Total Overtime Day":
                        int overtimeday = 0;
                        if (Int32.TryParse(text, out overtimeday))
                        {
                            overtimeday = Int32.Parse(text);
                            TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_OVERTIME_DAY.Value == overtimeday
                                               select timekeeping).ToArray();
                        }
                        break;



                    case "System.Windows.Controls.ComboBoxItem: Total Absent Day":
                        int absentday = 0;
                        if (Int32.TryParse(text, out absentday))
                        {
                            overtimeday = Int32.Parse(text);
                            TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_ABSENT_DAY.Value.ToString().StartsWith(absentday.ToString())
                                               select timekeeping).ToArray();
                        }
                        break;
                }

            }
            else
            {
                TimekeepingList = (from t in HRMSDatabase.Ins.TIMEKEEPINGs
                                   orderby t.MONTH descending
                                   select t).ToArray();
            }

        }

        #endregion


        #region Handle navigation 
        public ICommand DoubleClickCommmand { get; set; }

        #endregion


        // constructor 
        public EmployeeViewModel()
        {

            Employee = ((from employee in HRMSDatabase.Ins.EMPLOYEEs
                         select employee).Take(1).Single());


            TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
                               orderby timekeeping.MONTH descending
                               select timekeeping).ToArray();

            SalaryList = (from salary in HRMSDatabase.Ins.SALARies
                          where salary.EMPLOYEE_ID == 4
                          orderby salary.DATE_START descending
                          select salary).ToArray();

            SalaryMonthList = ((from salary in HRMSDatabase.Ins.SALARies
                                where salary.EMPLOYEE_ID == 4
                                orderby salary.MONTH.Value descending
                                select salary.MONTH.Value).Distinct().ToArray());

            // select the top month
            selectedIndex = 0;

            // declare command 
            SearchTextChangedCommand = new RelayCommand<string>(null, p => { SearchBarChange(p); });
            MonthSelectionChangedCommand = new RelayCommand<DateTime>(null, p => { MonthSelectionChange(p); });
            DoubleClickCommmand = new RelayCommand<TIMEKEEPING>(null, p =>
                      {
                          MessageBox.Show(p.NUMBER_OF_WORK_DAY.Value.ToString());
                      });

            MonthSelectionChangedDetailCommand = new RelayCommand<DateTime>(null, p => { getDayList(p); });


            // for detail salary 
            TimekeepingMonthList = (from t in HRMSDatabase.Ins.TIMEKEEPINGs
                                    orderby t.MONTH.Value descending
                                    select t.MONTH.Value).Distinct().ToArray();




        }

        public EmployeeViewModel(int employee_ID)
        {
            EMPLOYEE tem = ((from employee in HRMSDatabase.Ins.EMPLOYEEs
                             where employee.EMPLOYEE_ID == employee_ID
                             select employee).Take(1).Single());


            Employee = tem;
            TimekeepingList = (from timekeeping in HRMSDatabase.Ins.TIMEKEEPINGs
                               where timekeeping.EMPLOYEE_ID == employee_ID
                               orderby timekeeping.MONTH descending
                               select timekeeping).ToArray();

            SalaryList = (from salary in HRMSDatabase.Ins.SALARies
                          where salary.EMPLOYEE_ID == employee_ID
                          orderby salary.DATE_START descending
                          select salary).ToArray();


            SearchTextCommand = new RelayCommand<string>(null, p => { MessageBox.Show("DDD"); });
            SearchTextChangedCommand = new RelayCommand<string>(null, p => { SearchBarChange(p); });
        }





        public void CheckAttendance()
        {

            // insert absent day
            DateTime today = new DateTime();
            DateTime dateBefore = (from t in HRMSDatabase.Ins.TIMEKEEPINGs
                                   orderby t.MONTH descending
                                   where t.MONTH.HasValue == true
                                   select t.MONTH.Value).Take(1).Single();

            int idTimekeeping = (from t in HRMSDatabase.Ins.TIMEKEEPINGs
                                   orderby t.MONTH descending
                                   where t.MONTH.HasValue == true
                                   select t.TIMEKEEPING_ID ).Take(1).Single();
            for (DateTime tem = dateBefore.AddDays(1); DateTime.Compare(tem, today) > 0; tem.AddDays(1))
            {
                TIMEKEEPING_DETAIL tem_detail = new TIMEKEEPING_DETAIL();
                tem_detail.EMPLOYEE_ID = Employee.EMPLOYEE_ID;
                tem_detail.CHECK_DATE = tem;
                tem_detail.TIMEKEEPING_ID = idTimekeeping;
                tem_detail.TIMEKEEPING_DETAIL_TYPE = 3;
            }


            // first day of the month 
            if(today.Day == 1)
            {

            }


        }








    }
}
