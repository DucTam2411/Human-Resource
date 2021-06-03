using HRMS.Accouting.Model;
using HRMS.Accouting.View;
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
    public class DashBoardViewModel : BaseViewModel
    {
        #region Data Binding
        //Binding tới tài khoản hiện tại gồm USER_ID và USER_NAME
        private int _USER_ID;
        public int USER_ID { get => _USER_ID; set { _USER_ID = value; OnPropertyChanged(); } }

        private string _USER_NAME;
        public string USER_NAME { get => _USER_NAME; set { _USER_NAME = value; OnPropertyChanged(); } }

        //Binding tới datagrid của Salary List
        private ObservableCollection<RECORD> _RecordList;
        public ObservableCollection<RECORD> RecordList { get => _RecordList; set { _RecordList = value; OnPropertyChanged(); } }

        //Để lưu trữ bản sao để có thể sao chép khi cần thiết
        private ObservableCollection<RECORD> _RecordTest;
        public ObservableCollection<RECORD> RecordTest { get => _RecordTest; set { _RecordTest = value; OnPropertyChanged(); } }

        //Binding tới datagrid selected trong Salary list
        private RECORD _SelectedItem;
        public RECORD SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                //Đưa dữ liệu khi double-left vào 1 row bất kì trong SalaryDetailEmployee
                if (SelectedItem != null)
                {
                    //Do something
                }
            }
        }
        //Binding dữ liệu vào combobox của chọn loại để lọc
        private ObservableCollection<ComboboxModel> _ListType;
        public ObservableCollection<ComboboxModel> ListType { get => _ListType; set { _ListType = value; OnPropertyChanged(); } }

        //Binding dữ liệu với select trong comboox chọn loại lọc
        private ComboboxModel _SELECTEDTYPE;
        public ComboboxModel SELECTEDTYPE { get => _SELECTEDTYPE; set { _SELECTEDTYPE = value; OnPropertyChanged(); SEARCH_TEXT = ""; } }

        //Binding dữ liệu với Search Text
        private string _SEARCH_TEXT;
        public string SEARCH_TEXT
        {
            get => _SEARCH_TEXT; set
            {
                _SEARCH_TEXT = value;
                OnPropertyChanged();

                //Đưa SalaryTest vào trong SalaryList để dữ liệu được refresh mỗi lần nhập
                RecordList = RecordTest;

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
                                RecordList = new ObservableCollection<RECORD>(RecordList.Where(x => x.EMPLOYEE_ID.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo tên
                            case "Name":
                                RecordList = new ObservableCollection<RECORD>(RecordList.Where(x => x.EMPLOYEE.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo Department
                            case "Department":
                                RecordList = new ObservableCollection<RECORD>(RecordList.Where(x => x.DEPARTMENT.DEPT_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPARTMENT.DEPT_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPARTMENT.DEPT_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo tên nhân viên sửa
                            case "Employee Changed":
                                RecordList = new ObservableCollection<RECORD>(RecordList.Where(x => x.EMPLOYEE_CHANGE_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE_CHANGE_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE_CHANGE_NAME.ToUpper().Contains(SEARCH_TEXT)));
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
                    LoadRecordData();
                }
            }
        }
    #endregion
        //Command để chọn record để hiển thị chi tiết lương
        public ICommand SelectedCommand { get; set; } 

        //Contructor có ID để cung cấp thông tin cho người dùng
        public DashBoardViewModel(int ID)
        {
            USER_ID = ID;
            LoadDataCommand();
        }
        //Constructor mặc định của DashBoardViewModel
        public DashBoardViewModel()
        {
            LoadDataCommand();
        }

        //Load những command và dữ liệu khi khởi tạo constructor
        private void LoadDataCommand()
        {
            LoadComboboxTypeList();
            LoadMonth();
            SelectedCommand = new RelayCommand<ContentControl>(p => IsSelect(), p => SelectClick(p));
        }

        //Load dữ liệu chọn loại vào comboBox chọn loại để lọc (có thể thêm chọn loại mới vào đây)        
        private void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("ID", true));
            ListType.Add(new ComboboxModel("Name", false));
            ListType.Add(new ComboboxModel("Department", false));
            ListType.Add(new ComboboxModel("Employee Changed", false));
            SELECTEDTYPE = ListType.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }

        //Load dữ liệu tháng vào comboBox Month
        private void LoadMonth()
        {
            //Chọn tháng từ database KHÔNG TRÙNG LẶP (chọn DATE_START và DATE_END để kiểm tra tháng bắt đầu và tháng kết thúc có hợp lệ không (nếu cách nhau không quá 31 ngày hợp lệ)
            var listmonth = (from month in HRMSEntities.Ins.DB.SALARies
                             orderby month.MONTH descending
                             select new { Month = month.MONTH }).Distinct();

            //Khởi tạo biến MONTHLIST để chứa tháng
            MONTHLIST = new ObservableCollection<ComboboxModel>();

            //Đưa dữ liệu từ listmonth vào MONTHLIST
            foreach (var item in listmonth)
            {
                DateTime date = (DateTime)item.Month;
                //Nếu điều kiện hợp lệ thì lưu dữ liệu vào ComboBox Month thông qua MONTHLIST
                MONTHLIST.Add(new ComboboxModel(date.Month, date.Year, (date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year) ? true : false));
            }
            SELECTMONTHTYPE = MONTHLIST.Where(x => x.ISSELECTED == true).FirstOrDefault();
            if (SELECTMONTHTYPE == null)
            {
                SELECTMONTHTYPE = MONTHLIST.FirstOrDefault();
            }
        }

        //Load data vào grid
        private void LoadRecordData()
        {
            hrmsEntities db = new hrmsEntities();
            var list = from rc in db.RECORDs
                       where rc.MONTH_CHANGE.Value.Month == SELECTMONTHTYPE.MONTH && rc.MONTH_CHANGE.Value.Year == SELECTMONTHTYPE.YEAR 
                       orderby rc.DATE_CHANGE descending //hiển thị theo thứ tự giảm dần của ngày thay đổi
                       select rc;

            RecordList = new ObservableCollection<RECORD>();
            RecordTest = new ObservableCollection<RECORD>();
            foreach(var item in list)
            {
                RecordList.Add(item);
                RecordTest.Add(item);
            }
        }
        //Điều kiện để list vào datagrid
        private bool IsSelect()
        {
            if (SelectedItem != null)
                return true;
            return false;
        }
        //Hàm thực hiện khi click vào datagrid
        private void SelectClick(ContentControl main)
        {
            main.Content = new uConEmployeeSalary((int)SelectedItem.EMPLOYEE_CHANGE_ID, USER_ID, SELECTMONTHTYPE.MONTH, SELECTMONTHTYPE.YEAR);
        }

    }
}
