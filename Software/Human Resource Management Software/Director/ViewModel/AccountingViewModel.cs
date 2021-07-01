using HRMS.Accouting.Model;
using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Director.ViewModel
{
    public class AccountingViewModel : BaseViewModel
    {
        #region Binding user
        private int _USER_ID;
        public int USER_ID { get => _USER_ID; set { _USER_ID = value; OnPropertyChanged(); } }

        private string _USER_NAME;
        public string USER_NAME { get => _USER_NAME; set { _USER_NAME = value; OnPropertyChanged(); } }

        private int _USER_DEPT;
        public int USER_DEPT { get => _USER_DEPT; set { _USER_DEPT = value; OnPropertyChanged(); } }

        private int _USER_ROLE;
        public int USER_ROLE { get => _USER_ROLE; set { _USER_ROLE = value; OnPropertyChanged(); } }
        #endregion

        //Binding tới datagrid của Emloyee List
        private ObservableCollection<SalaryInformationData> _EmployeeList;
        public ObservableCollection<SalaryInformationData> EmployeeList { get => _EmployeeList; set { _EmployeeList = value; OnPropertyChanged(); } }

        //Để lưu trữ bản sao để có thể sao chép khi cần thiết
        private ObservableCollection<SalaryInformationData> _EmployeeTest;
        public ObservableCollection<SalaryInformationData> EmployeeTest { get => _EmployeeTest; set { _EmployeeTest = value; OnPropertyChanged(); } }

        //Binding dữ liệu vào combobox của chọn loại để lọc
        private ObservableCollection<ComboboxModel> _ListType;
        public ObservableCollection<ComboboxModel> ListType { get => _ListType; set { _ListType = value; OnPropertyChanged(); } }

        //Binding dữ liệu với select trong comboox chọn loại lọc
        private ComboboxModel _SELECTEDTYPE;
        public ComboboxModel SELECTEDTYPE { get => _SELECTEDTYPE; set { _SELECTEDTYPE = value; OnPropertyChanged(); } }

        //Binding dữ liệu vào combobox department của chọn loại để lọc
        private ObservableCollection<ComboboxModel> _ListDeptType;
        public ObservableCollection<ComboboxModel> ListDeptType { get => _ListDeptType; set { _ListDeptType = value; OnPropertyChanged(); } }

        //Binding dữ liệu với select trong comboox chọn loại lọc
        private ComboboxModel _SELECTEDDEPTTYPE;
        public ComboboxModel SELECTEDDEPTTYPE
        {
            get => _SELECTEDDEPTTYPE;
            set
            {
                _SELECTEDDEPTTYPE = value;
                OnPropertyChanged();
                if (SELECTEDDEPTTYPE != null)
                    LoadEmployeeData();
            }
        }

        //Binding dữ liệu với Search Text
        private string _SEARCH_TEXT;
        public string SEARCH_TEXT
        {
            get => _SEARCH_TEXT; set
            {
                _SEARCH_TEXT = value;
                OnPropertyChanged();

                //Đưa EMployeeTest vào trong EmployeeList để dữ liệu được refresh mỗi lần nhập
                EmployeeList = EmployeeTest;

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
                                EmployeeList = new ObservableCollection<SalaryInformationData>(EmployeeList.Where(x => x.EMPLOYEE_ID.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo tên
                            case "NAME":
                                EmployeeList = new ObservableCollection<SalaryInformationData>(EmployeeList.Where(x => x.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo role
                            case "ROLE":
                                EmployeeList = new ObservableCollection<SalaryInformationData>(EmployeeList.Where(x => x.ROLE.Contains(SEARCH_TEXT) ||
                                                                                                        x.ROLE.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.ROLE.ToUpper().Contains(SEARCH_TEXT)));
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
                    LoadEmployeeData();
                }
            }
        }



        private void LoadEmployeeData()
        {
            //Kiểm tra selected comboBox chọn tháng có khác null không 
            if (SELECTMONTHTYPE == null)
            {
                return;
            }
            //Kiểm tra selected của comboBox chọn phòng ban có khác null không
            if (SELECTEDDEPTTYPE == null)
            {
                return;
            }

            //Tạo list chứa dữ liệu có lọc theo tháng
            hrmsEntities DB = new hrmsEntities();

            //Tạo ra list lưu dữ liệu các nhân viên được lọc theo phòng ban (hiện thị tất cả thì trả về true)
            var list_filter_dept = from emp in DB.EMPLOYEEs where SELECTEDDEPTTYPE.DEPT_ID > 0 ? emp.DEPT_ID == SELECTEDDEPTTYPE.DEPT_ID : true select emp;

            //Tạo ra list temp lưu dữ liệu các nhân viên nào chưa bị xóa nằm trong phòng ban đã lọc (nếu tháng được chọn, lúc đó nhân viên chưa bị xóa thì vẫn hiện)
            var list_temp = (from emp in list_filter_dept
                             join del in DB.DELETEs on emp.EMPLOYEE_ID equals del.EMPLOYEE_ID
                             where (del.ISDELETED == false) || (del.ISDELETED == true &&
                             (del.MONTH.Value.Year > SELECTMONTHTYPE.YEAR || (del.MONTH.Value.Month > SELECTMONTHTYPE.MONTH && del.MONTH.Value.Year == SELECTMONTHTYPE.YEAR)))
                             select emp).Distinct();

            //Tạo ra list lưu dữ liệu lương dựa vào nhân viên đã được lọc theo các điều kiện trên (lọc thoe phòng ban và hiển thị thông tin của nhân viên chưa bị xóa)
            var list = (from emp in list_temp
                        join tk in DB.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID into temp1
                        from tk in temp1.DefaultIfEmpty()
                        join sl in DB.SALARies on emp.EMPLOYEE_ID equals sl.EMPLOYEE_ID into temp2
                        from sl in temp2.DefaultIfEmpty()
                        where sl.MONTH.Value.Month == SELECTMONTHTYPE.MONTH && sl.MONTH.Value.Year == SELECTMONTHTYPE.YEAR &&
                            tk.MONTH.Value.Month == SELECTMONTHTYPE.MONTH && tk.MONTH.Value.Year == SELECTMONTHTYPE.YEAR
                        select new
                        {
                            id = emp.EMPLOYEE_ID,
                            month_start = sl.DATE_START.Value.Month,
                            year_start = sl.DATE_START.Value.Year,
                            EMPLOYEE = emp,
                            TIMEKEEPING = tk,
                            SALARY = sl
                        }).Distinct();
            EmployeeList = new ObservableCollection<SalaryInformationData>();
            EmployeeTest = new ObservableCollection<SalaryInformationData>();
            foreach (var item in list)
            {
                SalaryInformationData employeeData = new SalaryInformationData();

                employeeData.EMPLOYEE_ID = item.id;
                employeeData.NAME = item.EMPLOYEE.NAME;
                employeeData.DEPARTMENT = item.EMPLOYEE.DEPARTMENT.DEPT_NAME;
                employeeData.ROLE = item.EMPLOYEE.ROLE.ROLE_NAME;
                employeeData.BASICWAGE = (long)item.SALARY.BASIC_WAGE;
                employeeData.WORKDAY = (int)item.TIMEKEEPING.NUMBER_OF_WORK_DAY;
                employeeData.OVERTIMEDAY = (int)item.TIMEKEEPING.NUMBER_OF_OVERTIME_DAY;
                employeeData.OVERTIMESALARY = (long)item.SALARY.OVERTIME_SALARY;
                employeeData.TOTALSALARY = (long)item.SALARY.TOTAL_SALARY;
                employeeData.SOCIALINSURANCE = (long)item.SALARY.SOCIAL_INSURANCE;
                employeeData.HEALTHINSURANCE = (long)item.SALARY.HEALTH_INSURANCE;
                employeeData.TAX = (long)item.SALARY.TAX;
                employeeData.WELFARE = (long)item.SALARY.WELFARE;
                employeeData.BONUS = (long)item.SALARY.BONUS;
                employeeData.COEFFICIENT = (double)item.SALARY.COEFFICIENT;
                employeeData.DATESTART = (DateTime)item.SALARY.DATE_START;
                employeeData.MONTH = (DateTime)item.SALARY.MONTH;
                employeeData.DATEEND = (DateTime)item.SALARY.DATE_END;
                employeeData.NOTE = item.SALARY.NOTE;



                EmployeeList.Add(employeeData);
                EmployeeTest.Add(employeeData);

            }
        }



        //Load dữ liệu chọn loại vào comboBox chọn dept để lọc (có thể thêm chọn loại mới vào đây)        
        private void LoadComboboxTypeDeptList()
        {
            hrmsEntities DB = new hrmsEntities();
            var list = from dept in DB.DEPARTMENTs select dept;
            ListDeptType = new ObservableCollection<ComboboxModel>();

            //ALL để chọn lọc theo tất cả phòng ban
            ListDeptType.Add(new ComboboxModel("ALL", 0, true));

            foreach (var item in list)
            {
                ListDeptType.Add(new ComboboxModel(item.DEPT_NAME, item.DEPT_ID, false));
            }
            SELECTEDDEPTTYPE = ListDeptType.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }

        private void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("ID", true));
            ListType.Add(new ComboboxModel("NAME", false));
            ListType.Add(new ComboboxModel("ROLE", false));
            SELECTEDTYPE = ListType.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }



        //Load dữ liệu tháng vào comboBox Month
        private void LoadMonth()
        {
            hrmsEntities db = new hrmsEntities();
            //Chọn tháng từ database KHÔNG TRÙNG LẶP (chọn DATE_START và DATE_END để kiểm tra tháng bắt đầu và tháng kết thúc có hợp lệ không (nếu cách nhau không quá 31 ngày hợp lệ)
            var listmonth = (from month in db.SALARies
                             orderby month.MONTH descending
                             select new { Month = month.MONTH }).Distinct();

            //Khởi tạo biến MONTHLIST để chứa tháng
            MONTHLIST = new ObservableCollection<ComboboxModel>();

            bool isMonthNow = false;
            //Đưa dữ liệu từ listmonth vào MONTHLIST
            foreach (var item in listmonth)
            {
                DateTime date = (DateTime)item.Month;
                if (date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year)
                    isMonthNow = true;
                if (isMonthNow == false)
                {
                    MONTHLIST.Add(new ComboboxModel(date.Month, date.Year, false));
                }
                //Nếu điều kiện hợp lệ thì lưu dữ liệu vào ComboBox Month thông qua MONTHLIST
            }
            if (SELECTMONTHTYPE == null)
            {
                SELECTMONTHTYPE = MONTHLIST.LastOrDefault();
            }
        }
        public AccountingViewModel()
        {
            LoadComboboxTypeDeptList();
            LoadEmployeeData();
            LoadMonth();
            LoadComboboxTypeList();

        }


    }
}
