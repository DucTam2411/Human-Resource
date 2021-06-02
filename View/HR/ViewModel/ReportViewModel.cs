using Augustine.VietnameseCalendar.Core.LuniSolarCalendar;
using HRMS.HR.Model.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.HR.ViewModel
{
    class ReportViewModel : BaseViewModel
    {
        public ReportViewModel(int ID)
        {
            LoadComboboxTypeList();
            LoadMonth();
        }
        //Binding tới datagrid của Salary List
        private ObservableCollection<TIMEKEEPING> _TimekeepingList;
        public ObservableCollection<TIMEKEEPING> TimekeepingList { get => _TimekeepingList; set { _TimekeepingList = value; OnPropertyChanged(); } }

        //Để lưu trữ bản sao để có thể sao chép khi cần thiết
        private ObservableCollection<TIMEKEEPING> _TimekeepingTest;
        public ObservableCollection<TIMEKEEPING> TimekeepingTest { get => _TimekeepingTest; set { _TimekeepingTest = value; OnPropertyChanged(); } }

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
                                TimekeepingList = new ObservableCollection<TIMEKEEPING>(TimekeepingList.Where(x => x.EMPLOYEE_ID.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo MONTH
                            case "NAME":
                                TimekeepingList = new ObservableCollection<TIMEKEEPING>(TimekeepingList.Where(x => x.EMPLOYEE.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            //Lọc theo Department
                            case "DEPARTMENT":
                                TimekeepingList = new ObservableCollection<TIMEKEEPING>(TimekeepingList.Where(x => x.EMPLOYEE.DEPARTMENT.DEPT_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.DEPARTMENT.DEPT_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.EMPLOYEE.DEPARTMENT.DEPT_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo role
                            case "ROLE":
                                TimekeepingList = new ObservableCollection<TIMEKEEPING>(TimekeepingList.Where(x => x.EMPLOYEE.ROLE.ROLE_NAME.Contains(SEARCH_TEXT) ||
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
        private static bool IsHoliday(int day, int month, int year)
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
        private static float CalculateAverageDay(int month, int year)
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
            hrmsEntities db = new hrmsEntities();
            var list = (from tk in db.TIMEKEEPINGs
                       where tk.MONTH.Value.Month == SELECTMONTHTYPE.MONTH && tk.MONTH.Value.Year == SELECTMONTHTYPE.YEAR
                       select tk).Distinct();

            TimekeepingList = new ObservableCollection<TIMEKEEPING>();
            TimekeepingTest = new ObservableCollection<TIMEKEEPING>();
            foreach (var item in list)
            {
                item.NUMBER_OF_STANDARD_DAY = CalculateAverageDay(item.MONTH.Value.Month, item.MONTH.Value.Year);
                item.NUMBER_OF_ABSENT_DAY = item.NUMBER_OF_STANDARD_DAY - item.NUMBER_OF_WORK_DAY;
                TimekeepingList.Add(item);
                TimekeepingTest.Add(item);
            }

        }
    }
}
