using HRMS.Accounting.View;
using HRMS.Accouting.Model;
using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace HRMS.Accouting.ViewModel
{
    public class TimekeepingInformationViewModel : BaseViewModel
    {
        #region Data Binding
        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }

        private int _TIMEKEEPING_ID;
        public int TIMEKEEPING_ID { get => _TIMEKEEPING_ID; set { _TIMEKEEPING_ID = value; OnPropertyChanged(); } }

        private DateTime _MONTH;
        public DateTime MONTH { get => _MONTH; set { _MONTH = value; OnPropertyChanged(); } }

        private int _DATE_START;
        public int DATE_START { get => _DATE_START; set { _DATE_START = value; OnPropertyChanged(); } }

        private int _DATE_END;
        public int DATE_END { get => _DATE_END; set { _DATE_END = value; OnPropertyChanged(); } }

        private int _NUMBER_OF_WORK_DAY;
        public int NUMBER_OF_WORK_DAY { get => _NUMBER_OF_WORK_DAY; set { _NUMBER_OF_WORK_DAY = value; OnPropertyChanged(); } }

        private int _NUMBER_OF_OVERTIME_DAY;
        public int NUMBER_OF_OVERTIME_DAY { get => _NUMBER_OF_OVERTIME_DAY; set { _NUMBER_OF_OVERTIME_DAY = value; OnPropertyChanged(); } }

        private int _NUMBER_OF_ABSENT_DAY;
        public int NUMBER_OF_ABSENT_DAY { get => _NUMBER_OF_ABSENT_DAY; set { _NUMBER_OF_ABSENT_DAY = value; OnPropertyChanged(); } }

        private string _IS_NOTE;
        public string IS_NOTE { get => _IS_NOTE; set { _IS_NOTE = value; OnPropertyChanged(); } }
        #endregion

        //Binding tới datagrid của Timekeeping List
        private ObservableCollection<TimekeepingData> _TimekeepingList;
        public ObservableCollection<TimekeepingData> TimekeepingList { get => _TimekeepingList; set { _TimekeepingList = value; OnPropertyChanged(); } }

        //Để lưu trữ bản sao để có thể sao chép khi cần thiết
        private ObservableCollection<TimekeepingData> _TimekeepingTest;
        public ObservableCollection<TimekeepingData> TimekeepingTest { get => _TimekeepingTest; set { _TimekeepingTest = value; OnPropertyChanged(); } }

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
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.ID.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo MONTH
                            case "MONTH":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.MONTH.ToShortDateString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo DAY START
                            case "DAY START":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.DAY_START.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo NOTE
                            case "NOTE":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.NOTE.Contains(SEARCH_TEXT) ||
                                                                                                                   x.NOTE.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                                   x.NOTE.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo DAY END
                            case "DAY END":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.DAY_END.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo TOTAL WORK DAY 
                            case "TOTAL WORK DAY":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.TOTAL_WORK_DAY.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo TOTAL ABSENT DAY 
                            case "TOTAL ABSENT DAY":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.TOTAL_ABSENT_DAY.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo TOTAL OVERTIME DAY 
                            case "TOTAL OVERTIME DAY":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.TOTAL_OVERTIME_DAY.ToString().Contains(SEARCH_TEXT)));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private TimekeepingData _SELECTEDITEM;
        public TimekeepingData SELECTEDITEM
        {
            get => _SELECTEDITEM; set
            {
                _SELECTEDITEM = value;
                OnPropertyChanged();
            }
        }

        private String _EMPLOYEENAME;
        public String EMPLOYEENAME { get => _EMPLOYEENAME; set { _EMPLOYEENAME = value; OnPropertyChanged(); } }

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
                    LoadDetail(EMPLOYEE_ID, SELECTMONTHTYPE.MONTH, SELECTMONTHTYPE.YEAR);
                }
            }
        }
        public ICommand showDetailCommand { get; set; }

        public ICommand BackCommand { get; set; }
        public TimekeepingInformationViewModel(int ID)
        {
            EMPLOYEE_ID = ID;
            LoadComboboxTypeList();
            LoadTimekeepingData(EMPLOYEE_ID);

            showDetailCommand = new RelayCommand<ContentControl>(p => { return true; }, p => { p.Content = new uConAccountingTimekeepingDetailInformation(EMPLOYEE_ID, SELECTEDITEM); });

        }

        public TimekeepingInformationViewModel(int ID, TimekeepingData item)
        {
            EMPLOYEE_ID = ID;
            hrmsEntities db = new hrmsEntities();
            EMPLOYEE employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == ID).FirstOrDefault();
            EMPLOYEENAME = employee.NAME;
            LoadMonth(item);
            //Chức năng của BackCommand
            BackCommand = new RelayCommand<ContentControl>(p => { return true; },
                p => { p.Content = new uConAccountingTimekeepingInformation(EMPLOYEE_ID); });
        }
        private void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("MONTH", true));
            ListType.Add(new ComboboxModel("DAY START", false));
            ListType.Add(new ComboboxModel("DAY END", false));
            ListType.Add(new ComboboxModel("TOTAL WORK DAY", false));
            ListType.Add(new ComboboxModel("TOTAL ABSENT DAY", false));
            ListType.Add(new ComboboxModel("TOTAL OVERTIME DAY", false));
            SELECTEDTYPE = ListType.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }

        private void LoadTimekeepingData(int id)
        {
            hrmsEntities DB = new hrmsEntities();
            var list = from emp in DB.EMPLOYEEs
                       join tk in DB.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID
                       where emp.EMPLOYEE_ID == id
                       orderby tk.MONTH descending
                       select new { TIMEKEEPING = tk };

            //Khởi tạo 2 biến lưu dữ liệu từ list ở trên (1 cái binding tới datagrid và 1 cái bản sao)
            TimekeepingList = new ObservableCollection<TimekeepingData>();
            TimekeepingTest = new ObservableCollection<TimekeepingData>();

            foreach (var item in list)
            {
                TimekeepingData tkdata = new TimekeepingData();
                tkdata.ID = item.TIMEKEEPING.TIMEKEEPING_ID;
                tkdata.MONTH = new DateTime(item.TIMEKEEPING.DATE_START.Value.Year, item.TIMEKEEPING.DATE_START.Value.Month, 1);
                tkdata.DAY_START = item.TIMEKEEPING.DATE_START.Value;
                tkdata.DAY_END = item.TIMEKEEPING.DATE_END.Value;
                tkdata.TOTAL_WORK_DAY = (int)item.TIMEKEEPING.NUMBER_OF_WORK_DAY;
                tkdata.TOTAL_OVERTIME_DAY = (int)item.TIMEKEEPING.NUMBER_OF_OVERTIME_DAY;
                tkdata.TOTAL_ABSENT_DAY = (int)item.TIMEKEEPING.NUMBER_OF_ABSENT_DAY;

                TimekeepingList.Add(tkdata);
                TimekeepingTest.Add(tkdata);
            }
        }

        private void LoadDetail(int id, int month, int year)
        {
            hrmsEntities db = new hrmsEntities();
            var GetWorkdayList = ((from t in db.TIMEKEEPING_DETAIL
                                   where t.TIMEKEEPING.MONTH.Value.Month == month &&
                                   t.TIMEKEEPING.MONTH.Value.Year == year &&
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
                                     where t.TIMEKEEPING.MONTH.Value.Month == month &&
                                   t.TIMEKEEPING.MONTH.Value.Year == year && t.TIMEKEEPING_DETAIL_TYPE == 0 && t.CHECK_DATE.Value.Day <= DateTime.Now.Day
                                     && t.EMPLOYEE_ID == id
                                     select t).Distinct());
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
                                    where t.TIMEKEEPING.MONTH.Value.Month == month &&
                                   t.TIMEKEEPING.MONTH.Value.Year == year && t.TIMEKEEPING_DETAIL_TYPE == 3
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

        //Load dữ liệu tháng vào comboBox Month
        private void LoadMonth(TimekeepingData data)
        {
            hrmsEntities db = new hrmsEntities();

            //Chọn tháng từ database KHÔNG TRÙNG LẶP (chọn DATE_START và DATE_END để kiểm tra tháng bắt đầu và tháng kết thúc có hợp lệ không (nếu cách nhau không quá 31 ngày hợp lệ)
            var listmonth = (from month in db.TIMEKEEPINGs
                             where month.EMPLOYEE_ID == EMPLOYEE_ID
                             select new { Month = month.MONTH }).Distinct();

            //Khởi tạo biến MONTHLIST để chứa tháng
            MONTHLIST = new ObservableCollection<ComboboxModel>();

            //Đưa dữ liệu từ listmonth vào MONTHLIST
            foreach (var item in listmonth)
            {
                MONTHLIST.Add(new ComboboxModel(item.Month.Value.Month, item.Month.Value.Year, false));
            }
            SELECTMONTHTYPE = MONTHLIST.Where(x => x.MONTH == data.MONTH.Month && x.YEAR == data.MONTH.Year).First();
        }
    }
}
