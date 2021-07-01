using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Augustine.VietnameseCalendar.Core.LuniSolarCalendar;
using HRMS.Accouting.Model;
using HRMS.HR.ViewModel;
using HRMS.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HRMS.Accouting.ViewModel
{
    class AccountingClass : BaseViewModel
    {

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

        //Hàm tính lương tổng cộng
        private static float _AVERAGE_DAY;
        public static float AVERAGE_DAY { get => _AVERAGE_DAY; set { _AVERAGE_DAY = value; } }

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
        public static long CalculateSalary(SALARY salary, TIMEKEEPING timekeeping)
        {
            long total_salary = 0;

            DateTime date = (DateTime)salary.DATE_START;
            //Lương cơ bản = lương cơ bản * số ngày làm việc / số ngày làm việc mặc định + lương làm thêm * số ngày làm thêm
            AVERAGE_DAY = CalculateAverageDay(date.Month, date.Year);
            long basic_salary = (long)(((salary.COEFFICIENT * salary.BASIC_WAGE) + salary.WELFARE) * timekeeping.NUMBER_OF_WORK_DAY / AVERAGE_DAY +
                                            salary.OVERTIME_SALARY * timekeeping.NUMBER_OF_OVERTIME_DAY + salary.BONUS);

            //Thuế = thuế BHXH + thuế BHYT + thuế cá nhân * Lương cơ bản / 100
            long tax_income = (long)(salary.HEALTH_INSURANCE + salary.SOCIAL_INSURANCE + salary.TAX);

            total_salary = basic_salary - tax_income;
            total_salary = (long)Math.Round((double)(total_salary / 1000)) * 1000;

            return total_salary;
        }

        public static long CalculateSalary(long SOCIAL_INSURANCE, long HEALTH_INSURANCE, long TAX, long BONUS, long WELFARE,
                                            long BASIC_WAGE, long OVERTIME_SALARY, double COEFFICIENT,
                                            int NUMBER_OF_WORK_DAY, int NUMBER_OF_OVERTIME_DAY, int MONTH, int YEAR)
        {
            long total_salary = 0;
            AVERAGE_DAY = CalculateAverageDay(MONTH, YEAR);
            long basic_salary = (long)(((COEFFICIENT * BASIC_WAGE) + WELFARE) * NUMBER_OF_WORK_DAY / AVERAGE_DAY +
                                            OVERTIME_SALARY * NUMBER_OF_OVERTIME_DAY + BONUS);

            //Thuế = thuế BHXH + thuế BHYT + thuế cá nhân * Lương cơ bản / 100
            long tax_income = (long)(HEALTH_INSURANCE + SOCIAL_INSURANCE + TAX);

            total_salary = basic_salary - tax_income;
            total_salary = (long)Math.Round((double)(total_salary / 1000)) * 1000;
            return total_salary;
        }

        //Convert byte[] sang bitmap
        public static BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        //Kiểm tra tháng trước đó
        public static bool IsMonthBefore(int month, int year)
        {
            if (DateTime.Now.Month == 1)
            {
                if (month == 12 && year == DateTime.Now.Year - 1)
                    return true;
                else
                    return false;
            }
            else
            {
                if (month == DateTime.Now.Month - 1 && year == DateTime.Now.Year)
                    return true;
                else
                    return false;
            }
        }

        //Chuyển từ datagrid sang datatable
        public static DataTable ToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (var item in items)
            {
                var values = new object[properties.Length];
                for (var i = 0; i < properties.Length; i++)
                {
                    //inserting property values to data table rows
                    values[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check data table
            return dataTable;
        }

        public static DataTable DataGridtoDataTable(DataGrid dg)
        {
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            string[] Lines = result.Split(new string[] { "\r\n", "\n" },
            StringSplitOptions.None);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToUpper(), typeof(string));
            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0) - 1; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols; f++)
                {
                    Row[f] = Fields[f];
                }
                dt.Rows.Add(Row);
            }
            return dt;

        }

        public static DateTime GetDateBefore()
        {
            if (DateTime.Now.Month == 1)
            {
                return new DateTime(DateTime.Now.Year - 1, 12, 1);
            }
            else
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
        }
    }
}
