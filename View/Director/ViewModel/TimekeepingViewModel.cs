using HRMS.Director.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRMS.Director.ViewModel
{
    public class TimekeepingViewModel : BaseViewModel
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

        
        public TimekeepingViewModel()
        {
            
            LoadComboboxTypeList();
            LoadTimekeepingData();

           
        }
        private void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("ID", true));
            ListType.Add(new ComboboxModel("MONTH", false));
            ListType.Add(new ComboboxModel("DAY START", false));
            ListType.Add(new ComboboxModel("DAY END", false));
            ListType.Add(new ComboboxModel("TOTAL WORK DAY", false));
            ListType.Add(new ComboboxModel("TOTAL ABSENT DAY", false));
            ListType.Add(new ComboboxModel("TOTAL OVERTIME DAY", false));
            ListType.Add(new ComboboxModel("NOTE", false));
            SELECTEDTYPE = ListType.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }

        private void LoadTimekeepingData()
        {
            hrmsEntities DB = new hrmsEntities();
            var list = from emp in DB.EMPLOYEEs
                       join tk in DB.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID
                       where tk.DATE_START.Value.Month == DateTime.Now.Month && tk.DATE_START.Value.Year == DateTime.Now.Year
                       select new { TIMEKEEPING = tk };

            //Khởi tạo 2 biến lưu dữ liệu từ list ở trên (1 cái binding tới datagrid và 1 cái bản sao)
            TimekeepingList = new ObservableCollection<TimekeepingData>();
            TimekeepingTest = new ObservableCollection<TimekeepingData>();

            foreach (var item in list)
            {
                TimekeepingData tkdata = new TimekeepingData();
                tkdata.ID = item.TIMEKEEPING.TIMEKEEPING_ID;
                tkdata.MONTH = new DateTime(item.TIMEKEEPING.DATE_START.Value.Year, item.TIMEKEEPING.DATE_START.Value.Month, 1);
                tkdata.DAY_START = item.TIMEKEEPING.DATE_START.Value.Day;
                tkdata.DAY_END = item.TIMEKEEPING.DATE_END.Value.Day;
                tkdata.TOTAL_WORK_DAY = (int)item.TIMEKEEPING.NUMBER_OF_WORK_DAY;
                tkdata.TOTAL_OVERTIME_DAY = (int)item.TIMEKEEPING.NUMBER_OF_OVERTIME_DAY;
                tkdata.TOTAL_ABSENT_DAY = (int)item.TIMEKEEPING.NUMBER_OF_ABSENT_DAY;

                TimekeepingList.Add(tkdata);
                TimekeepingTest.Add(tkdata);
            }
        }
    }
}
