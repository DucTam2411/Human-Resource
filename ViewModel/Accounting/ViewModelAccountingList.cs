using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel.Accounting
{
    public class ViewModelAccountingList : BaseViewModel
    {

        #region Command
        public ICommand showEmployeeCommand { get; set; }
        #endregion

        private ObservableCollection<SalaryData> _SalaryList;
        public ObservableCollection<SalaryData> SalaryList { get => _SalaryList; set { _SalaryList = value; OnPropertyChanged(); } }

        private SalaryData _SelectedItem;
        public SalaryData SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        public ViewModelAccountingList()
        {
            LoadSalaryData();

        }

        public void LoadSalaryData()
        {
            var list = from emp in HRMSEntity.Ins.DB.EMPLOYEEs
                       join tk in HRMSEntity.Ins.DB.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID into temp1 from tk in temp1.DefaultIfEmpty()
                       join sl in HRMSEntity.Ins.DB.SALARies on emp.EMPLOYEE_ID equals sl.EMPLOYEE_ID into temp2 from sl in temp2.DefaultIfEmpty()
                       select new
                       {
                           id = emp.EMPLOYEE_ID,EMPLOYEE = emp, TIMEKEEPING = tk, SALARY = sl
                       };

            SalaryList = new ObservableCollection<SalaryData>();
            
            foreach(var item in list)
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
