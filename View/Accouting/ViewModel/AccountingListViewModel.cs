using HRMS.Accouting.uCon;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRMS.Accouting.ViewModel
{
    public class AccountingListViewModel : BaseViewModel
    {

        #region Command
        public ICommand showEmployeeCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand BackCommand { get; set; }
        #endregion

        private BaseViewModel _AccountingVM;
        public BaseViewModel AccountingVM { get => _AccountingVM; set { _AccountingVM = value; OnPropertyChanged(); } }

        private BaseViewModel _AccountingDetailVM;
        public BaseViewModel AccountingDetailVM { get => _AccountingDetailVM; set { _AccountingDetailVM = value; OnPropertyChanged(); } }

        private ObservableCollection<SalaryData> _SalaryList;
        public ObservableCollection<SalaryData> SalaryList { get => _SalaryList; set { _SalaryList = value; OnPropertyChanged(); } }

        //Để lưu trữ bản sao
        private ObservableCollection<SalaryData> _SalaryTest;
        public ObservableCollection<SalaryData> SalaryTest { get => _SalaryTest; set { _SalaryTest = value; OnPropertyChanged(); } }

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
                    WELFARE = (long)SelectedItem.SALARY.WELFARE;
                    TAX = (long)SelectedItem.SALARY.TAX;
                    EMPLOYEE_ID = SelectedItem.EMPLOYEE.EMPLOYEE_ID;
                    EMPLOYEE_NAME = SelectedItem.EMPLOYEE.NAME;
                    DEPARTMENT_NAME = SelectedItem.EMPLOYEE.DEPARTMENT.DEPT_NAME;
                    BASIC_WAGE = (long)SelectedItem.SALARY.BASIC_WAGE;
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

        private long _BASIC_WAGE;
        public long BASIC_WAGE { get => _BASIC_WAGE; set { _BASIC_WAGE = value; OnPropertyChanged(); } }

        private long _WELFARE;
        public long WELFARE { get => _WELFARE; set { _WELFARE = value; OnPropertyChanged(); } }

        private double _COEFFICIENT;
        public double COEFFICIENT { get => _COEFFICIENT; set { _COEFFICIENT = value; OnPropertyChanged(); } }

        private long _TAX;
        public long TAX { get => _TAX; set { _TAX = value; OnPropertyChanged(); } }

        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }

        private string _EMPLOYEE_NAME;
        public string EMPLOYEE_NAME { get => _EMPLOYEE_NAME; set { _EMPLOYEE_NAME = value; OnPropertyChanged(); } }

        private string _DEPARTMENT_NAME;
        public string DEPARTMENT_NAME { get => _DEPARTMENT_NAME; set { _DEPARTMENT_NAME = value; OnPropertyChanged(); } }

        private ObservableCollection<ComboboxModel> _ListType;
        public ObservableCollection<ComboboxModel> ListType { get => _ListType; set { _ListType = value; OnPropertyChanged(); } }

        private ComboboxModel _SELECTEDTYPE;
        public ComboboxModel SELECTEDTYPE { get => _SELECTEDTYPE; set { _SELECTEDTYPE = value; OnPropertyChanged(); } }

        private string _SEARCH_TEXT;
        public string SEARCH_TEXT { get => _SEARCH_TEXT; set {
                _SEARCH_TEXT = value;
                OnPropertyChanged();
                SalaryList = SalaryTest;
                //ObservableCollection<SalaryData> salaryFilter = new ObservableCollection<SalaryData>();
                if (!string.IsNullOrEmpty(SEARCH_TEXT))
                {
                    try
                    {
                        switch (SELECTEDTYPE.NAME)
                        {
                            case "ID":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.EMPLOYEE_ID.ToString().Contains(SEARCH_TEXT)));
                                break;
                            case "NAME":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            case "DEPARTMENT":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.DEPARTMENT.DEPT_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.DEPARTMENT.DEPT_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.DEPARTMENT.DEPT_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            case "ROLE":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.ROLE.ROLE_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.ROLE.ROLE_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.ROLE.ROLE_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            default:
                                break;
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e);
                    }
                }
            } 
        }

        private ObservableCollection<ComboboxModel> _MONTHLIST;
        public ObservableCollection<ComboboxModel> MONTHLIST { get => _MONTHLIST; set { _MONTHLIST = value; OnPropertyChanged(); } }

        private ComboboxModel _MONTHTYPE;
        public ComboboxModel MONTHTYPE { get => _MONTHTYPE; set { _MONTHTYPE = value; OnPropertyChanged(); } }

        public AccountingListViewModel()
        {
            //Thất bại
            showEmployeeCommand = new RelayCommand<ContentControl>(p => { 
                if (SelectedItem != null) 
                    { return true; } 
                else 
                    { return false; } 
            },
                p => 
                { p.Content = new uConEmployeeSalary(); });

            LoadSalaryData();
            LoadComboboxTypeList();

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
                Salary.BONUS = BONUS;
                Salary.TAX = TAX;
                HRMSEntity.Ins.DB.SaveChanges();
            });

            BackCommand = new RelayCommand<ContentControl>(p => { return true; }, p => { p.Content = new uConListEmployeeAccounting(); });

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
            SalaryTest = new ObservableCollection<SalaryData>();

            foreach (var item in list)
            {
                SalaryData salaryData = new SalaryData();
                salaryData.ID = item.id;
                salaryData.EMPLOYEE = item.EMPLOYEE;
                salaryData.TIMEKEEPING = item.TIMEKEEPING;
                salaryData.SALARY = item.SALARY;
                SalaryList.Add(salaryData);
                SalaryTest.Add(salaryData);
            }
        }

        public void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("ID", true));
            ListType.Add(new ComboboxModel("NAME", false));
            ListType.Add(new ComboboxModel("DEPARTMENT", false));
            ListType.Add(new ComboboxModel("ROLE", false));
        }
    }
}
