using HRMS.HR.Model;
using HRMS.HR.Model.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRMS.HR.ViewModel
{
    public class TimekeepingViewModel : BaseViewModel
    {

        public ICommand DoubleClickCommand { get; set; }
        //Binding tới datagrid 
        private ObservableCollection<TimekeepingClass> _TimekeepingList;
        public ObservableCollection<TimekeepingClass> TimekeepingList { get => _TimekeepingList; set { _TimekeepingList = value; OnPropertyChanged(); } }

        //Để lưu trữ bản sao để có thể sao chép khi cần thiết
        private ObservableCollection<TimekeepingClass> _TimekeepingTest;
        public ObservableCollection<TimekeepingClass> TimekeepingTest { get => _TimekeepingTest; set { _TimekeepingTest = value; OnPropertyChanged(); } }
        //Binding dữ liệu vào combobox của chọn loại để lọc
        private ObservableCollection<ComboboxModel> _ListType;
        public ObservableCollection<ComboboxModel> ListType { get => _ListType; set { _ListType = value; OnPropertyChanged(); } }

        private int _TIMEKEEPING_TYPE;
        public int TIMEKEEPING_TYPE { get => _TIMEKEEPING_TYPE; set { _TIMEKEEPING_TYPE = value; OnPropertyChanged(); } }
        private int _SESSION;
        public int SESSION { get => _SESSION;set { _SESSION = value;OnPropertyChanged(); } }
        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value;OnPropertyChanged(); } }

        //Binding dữ liệu với select trong comboox chọn loại lọc
        private ComboboxModel _SELECTEDTYPE;
        public ComboboxModel SELECTEDTYPE { get => _SELECTEDTYPE; set { _SELECTEDTYPE = value; OnPropertyChanged(); } }
        public TimekeepingViewModel(int id)
        {
            LoadDeptList();
            LoadComboboxTypeList();
            DoubleClickCommand = new RelayCommand<object> 
                (p => { return true; },
                p =>
                {
                    hrmsEntities db = new hrmsEntities();
                    TIMEKEEPING_DETAIL timekeeping = db.TIMEKEEPING_DETAIL.Where(x => x.EMPLOYEE_ID == EMPLOYEE_ID 
                    && x.CHECK_DATE.Value.Day == SELECTED_DATE.Day
                    && x.CHECK_DATE.Value.Month == SELECTED_DATE.Month
                    && x.CHECK_DATE.Value.Year == SELECTED_DATE.Year
                    && x.SESSION == SESSION).SingleOrDefault();
                    EMPLOYEE employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == id).SingleOrDefault();
                    RECORD record = new RECORD();
                    record.EMPLOYEE_ID = employee.EMPLOYEE_ID;
                    record.DEPT_ID = employee.DEPT_ID;
                    record.EMPLOYEE_CHANGE_ID = EMPLOYEE_ID;
                    record.EMPLOYEE_CHANGE_NAME = timekeeping.EMPLOYEE.NAME;
                    record.DATE_CHANGE = DateTime.Now;
                    record.MONTH_CHANGE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    
                    if (TIMEKEEPING_TYPE == 1 || TIMEKEEPING_TYPE == 2)
                    {
                        timekeeping.TIMEKEEPING_DETAIL_TYPE = 0;
                        timekeeping.TIMEKEEPING.NUMBER_OF_WORK_DAY = (float?)(timekeeping.TIMEKEEPING.NUMBER_OF_WORK_DAY - 0.5);
                        timekeeping.TIMEKEEPING.NUMBER_OF_ABSENT_DAY = (float?)(timekeeping.TIMEKEEPING.NUMBER_OF_ABSENT_DAY + 0.5);
                        record.CHANGE = timekeeping.EMPLOYEE.NAME + "(id: " + timekeeping.EMPLOYEE_ID + ") timekeeping in date: " + timekeeping.CHECK_DATE.Value.Day.ToString() + "/" + timekeeping.CHECK_DATE.Value.Month.ToString() + "/" + timekeeping.CHECK_DATE.Value.Year.ToString() + " changed from work to absent";
                    }
                    else
                    {
                        if (SESSION == 1)
                        {
                            timekeeping.TIMEKEEPING_DETAIL_TYPE = 1;
                        }
                        else if (SESSION == 2)
                        {
                            timekeeping.TIMEKEEPING_DETAIL_TYPE = 2;
                        }
                        timekeeping.TIMEKEEPING.NUMBER_OF_WORK_DAY = (float?)(timekeeping.TIMEKEEPING.NUMBER_OF_WORK_DAY + 0.5);
                        timekeeping.TIMEKEEPING.NUMBER_OF_ABSENT_DAY = (float?)(timekeeping.TIMEKEEPING.NUMBER_OF_ABSENT_DAY - 0.5);
                        record.CHANGE = timekeeping.EMPLOYEE.NAME + "(id: " + timekeeping.EMPLOYEE_ID + ") timekeeping in date: " + timekeeping.CHECK_DATE.Value.Day.ToString() + "/" + timekeeping.CHECK_DATE.Value.Month.ToString() + "/" + timekeeping.CHECK_DATE.Value.Year.ToString() + " changed from absent to work";
                    }
                    db.RECORDs.Add(record);
                    db.SaveChanges();
                    LoadTimeKeepingDetail();
                    MessageBox.Show("Changed successfully");
                });
        }
        private TimekeepingClass _SELECTED_ITEM;
        public TimekeepingClass SELECTED_ITEM
        {
            get => _SELECTED_ITEM;
            set
            {
                _SELECTED_ITEM = value;
                OnPropertyChanged();
                if (SELECTED_ITEM != null)
                {
                    EMPLOYEE_ID = SELECTED_ITEM.EMPLOYEE_ID;
                    
                    if (SELECTED_ITEM.SESSION == "Morning")
                    {
                        SESSION = 1;
                    }
                    else if (SELECTED_ITEM.SESSION == "Afternoon")
                    {
                        SESSION = 2;
                    }
                    if (SELECTED_ITEM.ATTENDANCE == "Work")
                    {
                        if (SESSION == 1)
                        {
                            TIMEKEEPING_TYPE = 1;
                        }
                        else if (SESSION == 2)
                        {
                            TIMEKEEPING_TYPE = 2;
                        }
                    }
                    else if (SELECTED_ITEM.ATTENDANCE == "Absent")
                    {
                        TIMEKEEPING_TYPE = 0;
                    }
                }
            }
        }

        private string _SEARCH_TEXT;
        public string SEARCH_TEXT
        {
            get => _SEARCH_TEXT; set
            {
                _SEARCH_TEXT = value;
                OnPropertyChanged();

                TimekeepingList = TimekeepingTest;

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
                                TimekeepingList = new ObservableCollection<TimekeepingClass>(TimekeepingList.Where(x => x.EMPLOYEE_ID.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo MONTH
                            case "NAME":
                                TimekeepingList = new ObservableCollection<TimekeepingClass>(TimekeepingList.Where(x => x.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            //Lọc theo Department
                            case "DEPARTMENT":
                                TimekeepingList = new ObservableCollection<TimekeepingClass>(TimekeepingList.Where(x => x.DEPT.Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPT.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPT.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo role
                            case "ROLE":
                                TimekeepingList = new ObservableCollection<TimekeepingClass>(TimekeepingList.Where(x => x.ROLE.Contains(SEARCH_TEXT) ||
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
        private ObservableCollection<ComboboxModel> _DEPTLIST;
        public ObservableCollection<ComboboxModel> DEPTLIST { get => _DEPTLIST; set { _DEPTLIST = value; OnPropertyChanged(); } }

        //Binding tới selected của ComboxBox chọn tháng
        private ComboboxModel _SELECTDEPTTYPE;
        public ComboboxModel SELECTDEPTTYPE
        {
            get => _SELECTDEPTTYPE; set
            {
                _SELECTDEPTTYPE = value;
                OnPropertyChanged();

                //Nếu selected khác null, nghĩa là tháng đã chọn thì show data theo select dó
                if (SELECTDEPTTYPE != null)
                {
                    LoadTimeKeepingDetail();
                }
            }
        }
        private DateTime _SELECTED_DATE = DateTime.Now;
        public DateTime SELECTED_DATE
        {
            get => _SELECTED_DATE; set
            {
                _SELECTED_DATE = value;
                OnPropertyChanged();
                if (_SELECTED_DATE != null)
                {
                    LoadTimeKeepingDetail();
                }
            }  
        }

        private void LoadDeptList()
        {
            DEPTLIST = new ObservableCollection<ComboboxModel>();
            DEPTLIST.Add(new ComboboxModel("ALL", 0, true));
            DEPTLIST.Add(new ComboboxModel("HUMAN RESOURCE DEPT", 1, false));
            DEPTLIST.Add(new ComboboxModel("ACOUNTING DEPT", 2, false));
            DEPTLIST.Add(new ComboboxModel("DIRECTOR DEPT", 3, false));
            DEPTLIST.Add(new ComboboxModel("SOFTWARE DEPT", 4, false));
            DEPTLIST.Add(new ComboboxModel("QUALITY MANAGEMENT DEPT", 5, false));
            DEPTLIST.Add(new ComboboxModel("BUSSINESS DEPT", 6, false));
            DEPTLIST.Add(new ComboboxModel("SUPPORT DEPT", 7, false));
            SELECTDEPTTYPE = DEPTLIST.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }

        private void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("ID", true));
            ListType.Add(new ComboboxModel("NAME", false));
            ListType.Add(new ComboboxModel("DEPARTMENT", false));
            ListType.Add(new ComboboxModel("ROLE", false));
            SELECTEDTYPE = ListType.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }
        private void LoadTimeKeepingDetail()
        {
            if (SELECTDEPTTYPE == null || SELECTED_DATE == null)
            {
                return;
            }
            hrmsEntities db = new hrmsEntities();
            var list_filter_dept = from emp in db.EMPLOYEEs where SELECTDEPTTYPE.DEPT_ID > 0 ? emp.DEPT_ID == SELECTDEPTTYPE.DEPT_ID : true select emp;
            var list = (from emp in list_filter_dept
                        join tk in db.TIMEKEEPING_DETAIL on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID
                        where tk.CHECK_DATE.Value.Day == SELECTED_DATE.Day && tk.CHECK_DATE.Value.Year == SELECTED_DATE.Year && tk.CHECK_DATE.Value.Month == SELECTED_DATE.Month
                        select tk).Distinct(); ;
            TimekeepingList = new ObservableCollection<TimekeepingClass>();
            TimekeepingTest = new ObservableCollection<TimekeepingClass>();
            foreach (var item in list)
            {
                TimekeepingClass keeping = new TimekeepingClass();
                keeping.EMPLOYEE_ID = (int)item.EMPLOYEE_ID;
                keeping.DEPT = item.EMPLOYEE.DEPARTMENT.DEPT_NAME;
                keeping.ROLE = item.EMPLOYEE.ROLE.ROLE_NAME;
                keeping.NAME = item.EMPLOYEE.NAME;
                keeping.DATE = item.CHECK_DATE.Value.Day.ToString() + "/" + item.CHECK_DATE.Value.Month.ToString() + "/" + item.CHECK_DATE.Value.Year.ToString();
                switch (item.SESSION)
                {
                    case 1:
                        keeping.SESSION = "Morning";
                        break;
                    case 2:
                        keeping.SESSION = "Afternoon";
                        break;
                    default:
                        break;

                }
                switch (item.TIMEKEEPING_DETAIL_TYPE)
                {
                    case 0:
                        keeping.ATTENDANCE = "Absent";
                        break;
                    case 1:
                    case 2:
                        keeping.ATTENDANCE = "Work";
                        break;
                    case 3:
                        keeping.ATTENDANCE = "Overtime";
                        break;

                }
                keeping.MONTH = item.TIMEKEEPING.MONTH.Value.Month.ToString() + "/" + item.TIMEKEEPING.MONTH.Value.Year.ToString();
                TimekeepingList.Add(keeping);
                TimekeepingTest.Add(keeping);
            }
                
        }


    }
}
