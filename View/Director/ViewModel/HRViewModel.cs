using Augustine.VietnameseCalendar.Core.LuniSolarCalendar;
using HRMS.HR;
using HRMS.HR.Model;
using HRMS.HR.Model.Database;
using HRMS.HR.ViewModel;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Director.ViewModel
{
    class HRViewModel : BaseViewModel
    {
        public HRViewModel()
        {
            LoadComboboxTypeList();
            LoadMonth();
            LoadDeptList();
            
        }
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
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.EMPLOYEE_ID.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo MONTH
                            case "NAME":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            //Lọc theo Department
                            case "DEPARTMENT":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.DEPT.Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPT.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPT.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo role
                            case "ROLE":
                                TimekeepingList = new ObservableCollection<TimekeepingData>(TimekeepingList.Where(x => x.ROLE.Contains(SEARCH_TEXT) ||
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
        //Lấy ngày trong tháng
        public static int GetDaybyMonth(int month, int year)
        {
            switch (month)
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
        //Kiểm tra ngày nghỉ
        public static bool IsHoliday(int day, int month, int year)
        {
            //Kiểm tra ngày hôm đó có phải ngày nghỉ không nếu ngày nghỉ rơi vào thứ 7 hoặc chủ nhật thì được nghỉ bù vào thứ 2

            //Kiểm tra ngày 1/1
            if (day == 1 && month == 1)
                return true;
            DateTime date = new DateTime(year, 1, 1);
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                if (day == 3 && month == 1)
                    return true;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                if (day == 2 && month == 1)
                    return true;
            }

            //Kiểm tra ngày 30/4
            if (day == 30 && month == 4)
                return true;
            date = new DateTime(year, 4, 30);
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                if (day == 2 && month == 5)
                    return true;
                if (day == 3 && month == 5)
                    return true;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                if (day == 2 && month == 5)
                    return true;
            }

            //Kiểm tra ngày 1/5
            if (day == 1 && month == 5)
                return true;
            date = new DateTime(year, 5, 1);
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                if (day == 3 && month == 5)
                    return true;
            }

            //Kiểm tra ngày 2/9 (Quốc Khánh được nghỉ 2 ngày)
            if (day == 2 && month == 9)
                return true;
            date = new DateTime(year, 9, 2);
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                if (day == 4 && month == 9)
                    return true;
                if (day == 5 && month == 9)
                    return true;

            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                if (day == 4 && month == 9)
                    return true;
            }

            //Kiểm tra ngày 3/9
            if (day == 3 && month == 9)
                return true;
            date = new DateTime(year, 9, 3);
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                if (day == 5 && month == 9)
                    return true;
            }

            //Kiểm tra ngày âm (tết âm lịch đc nghỉ 5 ngày 29 1 2 3 4 và ngày 10/3) 
            //Kiểm tra ngày 1/1 có phải thứ 3 ko nếu phải thì ko đc nghỉ bù còn thứ 2 thì đc nghỉ bù 1 ngày, còn lai thì nghỉ bù 2 ngày
            LuniSolarDate<VietnameseLocalInfoProvider> lunnardate = LuniSolarCalendar<VietnameseLocalInfoProvider>.LuniSolarDateFromSolarDate(new DateTime(year, month, day));
            int lunnarday = lunnardate.Day;
            int lunarmonth = lunnardate.Month;
            LuniSolarDate<VietnameseLocalInfoProvider> datelunar = LuniSolarCalendar<VietnameseLocalInfoProvider>.LuniSolarDateFromLunarInfo(year, 1, false, 1);
            int tempday = datelunar.Day;
            int tempmonth = datelunar.Month;
            if (new DateTime(year, tempmonth, tempday).DayOfWeek != DayOfWeek.Tuesday)
            {
                if (lunnarday == 5 && lunarmonth == 1)
                    return true;
                if (lunnarday == 6 && lunarmonth == 1)
                    return true;
            }
            else if (new DateTime(year, tempmonth, tempday).DayOfWeek == DayOfWeek.Monday)
            {
                if (lunnarday == 5 && lunarmonth == 1)
                    return true;
            }

            DateTime temp = datelunar.SolarDate.AddDays(-1);
            if (temp.Day == day && temp.Month == month)
                return true;
            if (lunnarday == 1 && lunarmonth == 1)
                return true;
            if (lunnarday == 2 && lunarmonth == 1)
                return true;
            if (lunnarday == 3 && lunarmonth == 1)
                return true;
            if (lunnarday == 4 && lunarmonth == 1)
                return true;
            if (lunnarday == 10 && lunarmonth == 3)
                return true;

            datelunar = LuniSolarCalendar<VietnameseLocalInfoProvider>.LuniSolarDateFromLunarInfo(year, 3, false, 10);
            tempday = datelunar.Day;
            tempmonth = datelunar.Month;
            if (new DateTime(year, tempmonth, tempday).DayOfWeek == DayOfWeek.Saturday)
            {
                if (lunnarday == 12 && lunarmonth == 3)
                    return true;
            }
            else if (new DateTime(year, tempmonth, tempday).DayOfWeek == DayOfWeek.Sunday)
            {
                if (lunnarday == 11 && lunarmonth == 3)
                    return true;
            }

            //Kiểm tra ngày đó có phải chủ nhật ko
            if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Sunday)
                return true;

            return false;
        }

        //Tìm số ngày công chuẩn 5.5 ngày/ tuần
        public static float CalculateAverageDay(int month, int year)
        {
            float countAverage = 0;
            int Day = GetDaybyMonth(month, year);
            for (int i = 1; i <= Day; i++)
            {
                if (!IsHoliday(i, month, year))
                {
                    DateTime date = new DateTime(year, month, i);
                    if (date.DayOfWeek == DayOfWeek.Saturday)
                        countAverage++;
                    else
                        countAverage += 2;
                }
            }
            return countAverage / 2;
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
                    LoadTimekeepingData();
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
                if (SELECTMONTHTYPE != null && SELECTDEPTTYPE != null)
                {
                    LoadTimekeepingData();
                }
            }
        }
        private void LoadMonth()
        {

            //Chọn tháng từ database KHÔNG TRÙNG LẶP (chọn DATE_START và DATE_END để kiểm tra tháng bắt đầu và tháng kết thúc có hợp lệ không (nếu cách nhau không quá 31 ngày hợp lệ)
            var listmonth = (from month in HRMSEntities.Ins.DB.TIMEKEEPINGs
                             orderby month.MONTH descending
                             select new { Month = month.MONTH }).Distinct();

            //Khởi tạo biến MONTHLIST để chứa tháng
            MONTHLIST = new ObservableCollection<ComboboxModel>();
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //Đưa dữ liệu từ listmonth vào MONTHLIST
            foreach (var item in listmonth)
            {
                if ((DateTime)item.Month != date)
                {
                    DateTime date1 = (DateTime)item.Month;
                    //Nếu điều kiện hợp lệ thì lưu dữ liệu vào ComboBox Month thông qua MONTHLIST
                    MONTHLIST.Add(new ComboboxModel(date1.Month, date1.Year, (date1.Month == DateTime.Now.Month && date1.Year == DateTime.Now.Year) ? true : false));
                }
            }
            SELECTMONTHTYPE = MONTHLIST.Where(x => x.ISSELECTED == true).FirstOrDefault();
            if (SELECTMONTHTYPE == null)
            {
                SELECTMONTHTYPE = MONTHLIST.FirstOrDefault();
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

        //Load data vaof grid
        private void LoadTimekeepingData()
        {
            if (SELECTDEPTTYPE == null || SELECTMONTHTYPE == null)
            {
                return;
            }
            hrmsEntities db = new hrmsEntities();
            var list_filter_dept = from emp in db.EMPLOYEEs where SELECTDEPTTYPE.DEPT_ID > 0 ? emp.DEPT_ID == SELECTDEPTTYPE.DEPT_ID : true select emp;
            var list = (from emp in list_filter_dept
                        join tk in db.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID
                        where tk.MONTH.Value.Month == SELECTMONTHTYPE.MONTH && tk.MONTH.Value.Year == SELECTMONTHTYPE.YEAR
                        select tk).Distinct(); ;
            TimekeepingList = new ObservableCollection<TimekeepingData>();
            TimekeepingTest = new ObservableCollection<TimekeepingData>();
            foreach (var item in list)
            {
                item.NUMBER_OF_STANDARD_DAY = CalculateAverageDay(item.MONTH.Value.Month, item.MONTH.Value.Year);
                item.NUMBER_OF_ABSENT_DAY = item.NUMBER_OF_STANDARD_DAY - item.NUMBER_OF_WORK_DAY;
                TimekeepingData data = new TimekeepingData();
                data.EMPLOYEE_ID = (int)item.EMPLOYEE_ID;
                data.NAME = item.EMPLOYEE.NAME;
                data.DEPT = item.EMPLOYEE.DEPARTMENT.DEPT_NAME;
                data.ROLE = item.EMPLOYEE.ROLE.ROLE_NAME;
                data.WORK = (double)item.NUMBER_OF_WORK_DAY;
                data.ABSENT = (double)item.NUMBER_OF_ABSENT_DAY;
                data.STANDARD = (double)item.NUMBER_OF_STANDARD_DAY;
                TimekeepingList.Add(data);
                TimekeepingTest.Add(data);
            }

        }
    }
}
