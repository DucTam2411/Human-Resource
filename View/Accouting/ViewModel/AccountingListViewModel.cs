using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRMS.Accouting.ViewModel
{
    public class AccountingListViewModel : BaseViewModel
    {

        #region Command
        public ICommand showEmployeeCommand { get; set; }
        public ICommand EditCommand { get; set; }
        #endregion

        private ObservableCollection<SalaryData> _SalaryList;
        public ObservableCollection<SalaryData> SalaryList { get => _SalaryList; set { _SalaryList = value; OnPropertyChanged(); } }

        private SalaryData _SelectedItem;
        public SalaryData SelectedItem { 
            get => _SelectedItem; 
            set { 
                _SelectedItem = value; 
                OnPropertyChanged(); 
                if(SelectedItem != null)
                {
                    SOCIAL_INSURANCE = (long)SelectedItem.SALARY.SOCIAL_INSURANCE;
                    HEALTH_INSURANCE = (int)SelectedItem.SALARY.HEALTH_INSURANCE;
                    OVERTIME_SALARY = (long)SelectedItem.SALARY.OVERTIME_SALARY;
                    BONUS = (long)SelectedItem.SALARY.BONUS;
                    WAGE = (long)SelectedItem.SALARY.WAGE;
                    WELFARE = (long)SelectedItem.SALARY.WELFARE;
                    TAX = (long)SelectedItem.SALARY.TAX;
                    COEFFICIENT = (double)SelectedItem.SALARY.COEFFICIENT;
                }
            } 
        }

        private long _SOCIAL_INSURANCE;
        public long SOCIAL_INSURANCE { get => _SOCIAL_INSURANCE; set { _SOCIAL_INSURANCE = value; OnPropertyChanged(); } }

        private long _OVERTIME_SALARY;
        public long OVERTIME_SALARY { get => _OVERTIME_SALARY; set { _OVERTIME_SALARY = value; OnPropertyChanged(); } }

        private int _HEALTH_INSURANCE;
        public int HEALTH_INSURANCE { get => _HEALTH_INSURANCE; set { _HEALTH_INSURANCE = value; OnPropertyChanged(); } }

        private long _BONUS;
        public long BONUS { get => _BONUS; set { _BONUS = value; OnPropertyChanged(); } }

        private long _WAGE;
        public long WAGE { get => _WAGE; set { _WAGE = value; OnPropertyChanged(); } }

        private long _WELFARE;
        public long WELFARE { get => _WELFARE; set { _WELFARE = value; OnPropertyChanged(); } }

        private double _COEFFICIENT;
        public double COEFFICIENT { get => _COEFFICIENT; set { _COEFFICIENT = value; OnPropertyChanged(); } }

        private long _TAX;
        public long TAX { get => _TAX; set { _TAX = value; OnPropertyChanged(); } }

        public AccountingListViewModel()
        {
            //Thất bại
            //showEmployeeCommand = new RelayCommand<ContentControl>(p => { if (SelectedItem != null)  { return true;  } else {return false;} }, 
            //    p => { p.Content = new uConEmployeeSalary(SelectedItem); p.Margin = new Thickness(0, -20, 0, 0); });

            LoadSalaryData();

            EditCommand = new RelayCommand<object>((p) =>
            {
                var salaryList = HRMSEntity.Ins.DB.SALARies.Where(x => x.EMPLOYEE_ID == SelectedItem.SALARY.EMPLOYEE_ID);
                if (salaryList != null && salaryList.Count() != 0)
                    return true;
                return false;
            }, p => {
                var Salary = HRMSEntity.Ins.DB.SALARies.Where(x => x.EMPLOYEE_ID == SelectedItem.SALARY.EMPLOYEE_ID).SingleOrDefault();
                Salary.HEALTH_INSURANCE = HEALTH_INSURANCE;
                Salary.SOCIAL_INSURANCE = SOCIAL_INSURANCE;
                Salary.WELFARE = WELFARE;
                Salary.COEFFICIENT = COEFFICIENT;
                Salary.OVERTIME_SALARY = OVERTIME_SALARY;
                Salary.BONUS = BONUS;
                Salary.TAX = TAX;
                HRMSEntity.Ins.DB.SaveChanges();
            });

        }

        public void LoadSalaryData()
        {
            var list = from emp in HRMSEntity.Ins.DB.EMPLOYEEs
                       join tk in HRMSEntity.Ins.DB.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID into temp1
                       from tk in temp1.DefaultIfEmpty()
                       join sl in HRMSEntity.Ins.DB.SALARies on emp.EMPLOYEE_ID equals sl.EMPLOYEE_ID into temp2
                       from sl in temp2.DefaultIfEmpty()
                       select new
                       {
                           id = emp.EMPLOYEE_ID,
                           EMPLOYEE = emp,
                           TIMEKEEPING = tk,
                           SALARY = sl
                       };

            SalaryList = new ObservableCollection<SalaryData>();

            foreach (var item in list)
            {
                SalaryData salaryData = new SalaryData();
                salaryData.ID = item.id;
                salaryData.EMPLOYEE = item.EMPLOYEE;
                salaryData.TIMEKEEPING = item.TIMEKEEPING;
                salaryData.SALARY = item.SALARY;
                //salaryData.Name = item.EMPLOYEE.NAME;
                //salaryData.Dept_Name = item.EMPLOYEE.DEPARTMENT.DEPT_NAME;
                //salaryData.Role_Name = item.EMPLOYEE.ROLE.ROLE_NAME;
                //salaryData.Date_Start = (DateTime)item.SALARY.DATE_START;
                //salaryData.Date_End = (DateTime)item.SALARY.DATE_END;
                //salaryData.NumOfWork = (int)item.TIMEKEEPING.NUMBER_OF_WORK_DAY;
                //salaryData.Salary = (double)item.SALARY.TOTAL_SALARY;
                SalaryList.Add(salaryData);
            }
        }
    }
}
