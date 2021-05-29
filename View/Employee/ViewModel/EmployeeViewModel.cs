using HRMS.Accouting.Model;
using HRMS.Accouting.ViewModel;
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
        private TIMEKEEPING[] _TimekeepingList ;
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


        private SALARY _SalarySelected ;
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
            TimekeepingSelected = ((from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
                                    where timekeeping.MONTH.Value.Month == month && timekeeping.MONTH.Value.Day == day
                                    select timekeeping).Take(1).Single());
            SalarySelected = ((from s in HRMSEntities.Ins.DB.SALARies
                               where s.SALARY_MONTH.Value.Month == month && s.SALARY_MONTH.Value.Day == day
                               select s).Take(1).Single());
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
                                TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
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
                                TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
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
                                TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
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
                            TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_WORK_DAY.Value == workday
                                               select timekeeping).ToArray();
                        }
                        break;

                    case "System.Windows.Controls.ComboBoxItem: Total Overtime Day":
                        int overtimeday = 0;
                        if (Int32.TryParse(text, out overtimeday))
                        {
                            overtimeday = Int32.Parse(text);
                            TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_OVERTIME_DAY.Value == overtimeday
                                               select timekeeping).ToArray();
                        }
                        break;



                    case "System.Windows.Controls.ComboBoxItem: Total Absent Day":
                        int absentday = 0;
                        if (Int32.TryParse(text, out absentday))
                        {
                            overtimeday = Int32.Parse(text);
                            TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
                                               where timekeeping.NUMBER_OF_ABSENT_DAY.Value.ToString().StartsWith(absentday.ToString())
                                               select timekeeping).ToArray();
                        }
                        break;
                }

            }
            else
            {
                TimekeepingList = (from t in HRMSEntities.Ins.DB.TIMEKEEPINGs
                                   orderby t.MONTH descending
                                   select t).ToArray();
            }

        }

        #endregion

      

        
        public EmployeeViewModel()
        {

            Employee = ((from employee in HRMSEntities.Ins.DB.EMPLOYEEs
                         select employee).Take(1).Single());


            TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
                               where timekeeping.EMPLOYEE_ID  == 3 
                               orderby timekeeping.MONTH descending
                               select timekeeping).ToArray();

            SalaryList = (from salary in HRMSEntities.Ins.DB.SALARies
                          where salary.EMPLOYEE_ID == 3
                          orderby salary.DATE_START descending
                          select salary).ToArray();

            SalaryMonthList = ((from salary in HRMSEntities.Ins.DB.SALARies
                                where salary.EMPLOYEE_ID == 3
                                orderby salary.SALARY_MONTH.Value descending
                                select salary.SALARY_MONTH.Value).Distinct().ToArray());


            // declare command 
            SearchTextChangedCommand = new RelayCommand<string>(null, p => { SearchBarChange(p); });
            MonthSelectionChangedCommand = new RelayCommand<DateTime>(null, p => { MonthSelectionChange(p); });


        }

        public EmployeeViewModel(int employee_ID)
        {
            EMPLOYEE tem = ((from employee in HRMSEntities.Ins.DB.EMPLOYEEs
                             where employee.EMPLOYEE_ID == employee_ID
                             select employee).Take(1).Single());


            Employee = tem;
            TimekeepingList = (from timekeeping in HRMSEntities.Ins.DB.TIMEKEEPINGs
                               where timekeeping.EMPLOYEE_ID == employee_ID
                               orderby timekeeping.MONTH descending
                               select timekeeping).ToArray();

            SalaryList = (from salary in HRMSEntities.Ins.DB.SALARies
                          where salary.EMPLOYEE_ID == employee_ID
                          orderby salary.DATE_START descending
                          select salary).ToArray();


            SearchTextCommand = new RelayCommand<string>(null, p => { MessageBox.Show("DDD"); });
            SearchTextChangedCommand = new RelayCommand<string>(null, p => { SearchBarChange(p); });
        }

    }
}
