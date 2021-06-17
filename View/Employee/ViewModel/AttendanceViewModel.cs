using Augustine.VietnameseCalendar.Core.LuniSolarCalendar;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRMS.Employee.ViewModel
{
    public class AttendanceViewModel : BaseViewModel
    {
        public ICommand MorningCommand { get; set; }
        public ICommand AfternoonCommand { get; set; }
        public AttendanceViewModel(int id)
        {
            hrmsEntities db = new hrmsEntities();
            var timekeepingdetail1 = db.TIMEKEEPING_DETAIL.Where(x => x.EMPLOYEE_ID == id && x.CHECK_DATE.Value.Day == DateTime.Now.Day && x.CHECK_DATE.Value.Month == DateTime.Now.Month && x.CHECK_DATE.Value.Year == DateTime.Now.Year && x.SESSION == 1).SingleOrDefault();
            var timekeepingdetail2 = db.TIMEKEEPING_DETAIL.Where(x => x.EMPLOYEE_ID == id && x.CHECK_DATE.Value.Day == DateTime.Now.Day && x.CHECK_DATE.Value.Month == DateTime.Now.Month && x.CHECK_DATE.Value.Year == DateTime.Now.Year && x.SESSION == 2).SingleOrDefault();
            var timekeeping = db.TIMEKEEPINGs.Where(x => x.EMPLOYEE_ID == id && x.MONTH.Value.Month == DateTime.Now.Month && x.MONTH.Value.Year == DateTime.Now.Year).SingleOrDefault();
            MorningCommand = new RelayCommand<object>(p =>
            {
                if (DateTime.Now.Hour > 7 && DateTime.Now.Hour < 11)
                {
                    if (timekeepingdetail1 == null || timekeepingdetail1.TIMEKEEPING_DETAIL_TYPE == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                { return false; }
            },
            p =>
            {
                if (IsHoliday(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
                {
                    var timekeepingdetail = new TIMEKEEPING_DETAIL();
                    timekeepingdetail.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                    timekeepingdetail.CHECK_DATE = DateTime.Now;
                    timekeepingdetail.SESSION = 1;
                    timekeepingdetail.EMPLOYEE_ID = id;
                    timekeepingdetail.TIMEKEEPING_DETAIL_TYPE = 3;
                    timekeepingdetail1 = timekeepingdetail;
                    db.TIMEKEEPING_DETAIL.Add(timekeepingdetail);
                }
                else
                {
                    timekeepingdetail1.TIMEKEEPING_DETAIL_TYPE = 1;
                    timekeeping.NUMBER_OF_ABSENT_DAY = (float?)(timekeeping.NUMBER_OF_ABSENT_DAY - 0.5);
                    timekeeping.NUMBER_OF_WORK_DAY = (float)(timekeeping.NUMBER_OF_WORK_DAY + 0.5);
                }
                db.SaveChanges();
            }
            );
            AfternoonCommand = new RelayCommand<object>(p =>
            {
                if (DateTime.Now.Hour > 13 && DateTime.Now.Hour < 23)
                {
                    if (timekeepingdetail2 == null || timekeepingdetail2.TIMEKEEPING_DETAIL_TYPE == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                { return false; }
            },
            p =>
            {
                if (IsHoliday(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year) || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                {
                    var timekeepingdetail = new TIMEKEEPING_DETAIL();
                    timekeepingdetail.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                    timekeepingdetail.CHECK_DATE = DateTime.Now;
                    timekeepingdetail.SESSION = 2;
                    timekeepingdetail.EMPLOYEE_ID = id;
                    timekeepingdetail.TIMEKEEPING_DETAIL_TYPE = 3;
                    timekeepingdetail2 = timekeepingdetail;
                    db.TIMEKEEPING_DETAIL.Add(timekeepingdetail);
                }
                else
                {
                    timekeepingdetail2.TIMEKEEPING_DETAIL_TYPE = 2;
                    timekeeping.NUMBER_OF_ABSENT_DAY = (float?)(timekeeping.NUMBER_OF_ABSENT_DAY - 0.5);
                    timekeeping.NUMBER_OF_WORK_DAY = (float)(timekeeping.NUMBER_OF_WORK_DAY + 0.5);
                }
                db.SaveChanges();
            }
            );
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
    }
}
