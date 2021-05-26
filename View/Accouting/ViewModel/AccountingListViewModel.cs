using HRMS.Accouting.uCon;
using Model;
using Model.Database;
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
        //Chuyển content từ ListEmployee sang DeatilSalaryEmployee
        public ICommand showEmployeeCommand { get; set; }
        //Để lưu những thay đổi trong DetailSalaryEmployee
        public ICommand EditCommand { get; set; }
        //Để thực chức năng back trong DetailSalaryEmployee
        public ICommand BackCommand { get; set; }
        #endregion

        private BaseViewModel _AccountingVM;
        public BaseViewModel AccountingVM { get => _AccountingVM; set { _AccountingVM = value; OnPropertyChanged(); } }

        private BaseViewModel _AccountingDetailVM;
        public BaseViewModel AccountingDetailVM { get => _AccountingDetailVM; set { _AccountingDetailVM = value; OnPropertyChanged(); } }

        #region Data Binding Salary List 
        //Binding tới datagrid của Salary List
        private ObservableCollection<SalaryData> _SalaryList;
        public ObservableCollection<SalaryData> SalaryList { get => _SalaryList; set { _SalaryList = value; OnPropertyChanged(); } }

        //Để lưu trữ bản sao để có thể sao chép khi cần thiết
        private ObservableCollection<SalaryData> _SalaryTest;
        public ObservableCollection<SalaryData> SalaryTest { get => _SalaryTest; set { _SalaryTest = value; OnPropertyChanged(); } }

        //Binding tới datagrid selected trong Salary list
        private SalaryData _SelectedItem;
        public SalaryData SelectedItem { 
            get => _SelectedItem; 
            set { 
                _SelectedItem = value; 
                OnPropertyChanged(); 
                //Đưa dữ liệu khi double-left vào 1 row bất kì trong SalaryDetailEmployee
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

        //Binding dữ liệu vào combobox của chọn loại để lọc
        private ObservableCollection<ComboboxModel> _ListType;
        public ObservableCollection<ComboboxModel> ListType { get => _ListType; set { _ListType = value; OnPropertyChanged(); } }

        //Binding dữ liệu với select trong comboox chọn loại lọc
        private ComboboxModel _SELECTEDTYPE;
        public ComboboxModel SELECTEDTYPE { get => _SELECTEDTYPE; set { _SELECTEDTYPE = value; OnPropertyChanged(); } }

        //Binding dữ liệu với Search Text
        private string _SEARCH_TEXT;
        public string SEARCH_TEXT
        {
            get => _SEARCH_TEXT; set
            {
                _SEARCH_TEXT = value;
                OnPropertyChanged();

                //Đưa SalaryTest vào trong SalaryList để dữ liệu được refresh mỗi lần nhập
                SalaryList = SalaryTest;

                //Kiểm tra SearchText có khác null không
                if (!string.IsNullOrEmpty(SEARCH_TEXT))
                {
                    //Kiểm tra ComboBox chọn loại để lọc có khác null không
                    if (SELECTEDTYPE != null)
                    {
                        //Chọn kiểu lọc
                        switch (SELECTEDTYPE.NAME)
                        {
                            //Lọc theo ID
                            case "ID":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.EMPLOYEE_ID.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo tên
                            case "NAME":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo Department
                            case "DEPARTMENT":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.DEPARTMENT.DEPT_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.DEPARTMENT.DEPT_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.DEPARTMENT.DEPT_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo role
                            case "ROLE":
                                SalaryList = new ObservableCollection<SalaryData>(SalaryList.Where(x => x.EMPLOYEE.ROLE.ROLE_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.ROLE.ROLE_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.ROLE.ROLE_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        //Binding tới ComboBox chọn Tháng
        private ObservableCollection<ComboboxModel> _MONTHLIST;
        public ObservableCollection<ComboboxModel> MONTHLIST { get => _MONTHLIST; set { _MONTHLIST = value; OnPropertyChanged(); } }

        //Binding tới selected của ComboxBox chọn tháng
        private ComboboxModel _SELECTMONTHTYPE;
        public ComboboxModel SELECTMONTHTYPE
        {
            get => _SELECTMONTHTYPE; set
            {
                _SELECTMONTHTYPE = value;
                OnPropertyChanged();

                //Nếu selected khác null, nghĩa là tháng đã chọn thì show data theo select dó
                if (SELECTMONTHTYPE != null)
                {
                    LoadSalaryData();
                }
            }
        }
        #endregion

        #region Data Binding SalaryDetailEmployee
        //Toàn bộ dữ liệu binding trong SalaryDetailEmployee

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

        private long _TOTAL_SALARY;
        public long TOTAL_SALARY { get => _TOTAL_SALARY; set { _TOTAL_SALARY = value; OnPropertyChanged(); } }        
        #endregion
        public AccountingListViewModel()
        {
            //Chức năng của showEmployeeCommand
            showEmployeeCommand = new RelayCommand<ContentControl>(p => { 
                if (SelectedItem != null) 
                    { return true; } 
                else 
                    { return false; } 
            },
                p => 
                { p.Content = new uConEmployeeSalary(); });

            #region Load Data khi mỗi khi truy cập tới view
            LoadSalaryData();
            LoadComboboxTypeList();
            LoadMonth();
            #endregion

            //Chức năng của EditCommand
            EditCommand = new RelayCommand<object>((p) =>
            {
                var salaryList = HRMSEntity.Ins.DB.SALARies.Where(x => x.EMPLOYEE_ID == SelectedItem.SALARY.EMPLOYEE_ID && x.DATE_START == SelectedItem.SALARY.DATE_START);
                if (salaryList != null && salaryList.Count() != 0)
                    return true;
                return false;
            }, p => {
                var Salary = HRMSEntity.Ins.DB.SALARies.Where(x => x.EMPLOYEE_ID == SelectedItem.SALARY.EMPLOYEE_ID && x.DATE_START == SelectedItem.SALARY.DATE_START).SingleOrDefault();                
                Salary.HEALTH_INSURANCE = HEALTH_INSURANCE;
                Salary.SOCIAL_INSURANCE = SOCIAL_INSURANCE;
                Salary.WELFARE = WELFARE;
                Salary.BONUS = BONUS;
                Salary.TAX = TAX;
                Salary.TOTAL_SALARY = CalculateSalary(SelectedItem.SALARY, SelectedItem.TIMEKEEPING);
                HRMSEntity.Ins.DB.SaveChanges();
            });

            //Chức năng của BackCommand
            BackCommand = new RelayCommand<ContentControl>(p => { return true; }, p => { p.Content = new uConListEmployeeAccounting(); });

        }

        //Load data từ database vào datagrid trong EmployeeList
        public void LoadSalaryData()
        {
            //Kiểm tra selected comboBox chọn tháng có khác null không 
            if (SELECTMONTHTYPE == null)
            {
                return;
            }

            //Tạo list chứa dữ liệu có lọc theo tháng
            var list = (from emp in HRMSEntity.Ins.DB.EMPLOYEEs
                       join tk in HRMSEntity.Ins.DB.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID into temp1
                       from tk in temp1.DefaultIfEmpty()
                       join sl in HRMSEntity.Ins.DB.SALARies on emp.EMPLOYEE_ID equals sl.EMPLOYEE_ID into temp2
                       from sl in temp2.DefaultIfEmpty()
                       where sl.DATE_START.Value.Month == SELECTMONTHTYPE.MONTH && sl.DATE_START.Value.Year == SELECTMONTHTYPE.YEAR && 
                            tk.DATE_START.Value.Month == SELECTMONTHTYPE.MONTH && tk.DATE_START.Value.Year == SELECTMONTHTYPE.YEAR
                       select new
                       {
                           id = emp.EMPLOYEE_ID,
                           EMPLOYEE = emp,
                           TIMEKEEPING = tk,
                           SALARY = sl
                       }).Distinct();                       

            //lưu dữ liệu từ list vào 2 cái biến vừa khởi tạo
            foreach (var item in list)
            {           
                item.SALARY.TOTAL_SALARY = CalculateSalary(item.SALARY, item.TIMEKEEPING);
            }
            HRMSEntity.Ins.DB.SaveChanges();

            //Khởi tạo 2 biến lưu dữ liệu từ list ở trên (1 cái binding tới datagrid và 1 cái bản sao)
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

        //Load dữ liệu chọn loại vào comboBox chọn loại để lọc (có thể thêm chọn loại mới vào đây)        
        public void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("ID", true));
            ListType.Add(new ComboboxModel("NAME", false));
            ListType.Add(new ComboboxModel("DEPARTMENT", false));
            ListType.Add(new ComboboxModel("ROLE", false));
        }

        //Lấy ngày trong tháng
        private static int GetDaybyMonth(int month, int year)
        {
            switch(month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) ? 29 : 28;
            }    
        }

        //Load dữ liệu tháng vào comboBox Month
        public void LoadMonth()
        {
            //Chọn tháng từ database KHÔNG TRÙNG LẶP (chọn DATE_START và DATE_END để kiểm tra tháng bắt đầu và tháng kết thúc có hợp lệ không (nếu cách nhau không quá 31 ngày hợp lệ)
            var listmonth = (from month in HRMSEntity.Ins.DB.SALARies
                            select new {Date_Start = month.DATE_START, Date_End = month.DATE_END }).Distinct();

            //Khởi tạo biến MONTHLIST để chứa tháng
            MONTHLIST = new ObservableCollection<ComboboxModel>();

            //Đưa dữ liệu từ listmonth vào MONTHLIST
            foreach(var item in listmonth)
            {
                DateTime start = (DateTime)item.Date_Start;
                DateTime end = (DateTime)item.Date_End;

                //Kiểm tra dữ liệu tháng có hợp lệ không
                if(end.Month - start.Month <= 1)
                {
                    int day_end = end.Day;
                    int day_start = start.Day;

                    //Kiểm tra tháng kết thúc có lớn hơn tháng bắt đầu không
                    if(end.Month - start.Month == 1)
                    {
                        day_end = end.Day + GetDaybyMonth((end.Month == 1) ? 12 : end.Month, (end.Month == 1) ? end.Year - 1 : end.Year);
                        day_start = start.Day;                      
                    }

                    //Nếu điều kiện hợp lệ thì lưu dữ liệu vào ComboBox Month thông qua MONTHLIST
                    if (day_end - day_start <= 31)
                    {
                        MONTHLIST.Add(new ComboboxModel(start.Month, start.Year, (start.Month == DateTime.Now.Month && start.Year == DateTime.Now.Year) ? true : false));
                    }

                }
            }
        }

        //Hàm tính lương tổng cộng
        private long CalculateSalary(SALARY salary, TIMEKEEPING timekeeping)
        {
            double total_salary = 0;

            //Lương cơ bản = lương cơ bản * số ngày làm việc / số ngày làm việc mặc định + lương làm thêm * số ngày làm thêm
            double basic_salary = (double)(salary.BASIC_WAGE * salary.COEFFICIENT * timekeeping.NUMBER_OF_WORK_DAY / 24 +
                                            salary.OVERTIME_SALARY * timekeeping.NUMBER_OF_OVERTIME_DAY);

            //Lương thêm = bonus + phụ cấp
            double bonus_salary = (double)(salary.BONUS + salary.WELFARE);

            //Thuế = thuế BHXH + thuế BHYT + thuế cá nhân * Lương cơ bản / 100
            double tax_income = (double)(salary.HEALTH_INSURANCE + salary.SOCIAL_INSURANCE + basic_salary * salary.TAX / 100);

            total_salary = basic_salary + bonus_salary - tax_income;

            return (long)total_salary;
        }
    }
}
