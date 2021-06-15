using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HRMS.Employee.ViewModel
{
    public class TimerViewModel : BaseViewModel
    {
        DispatcherTimer dispatcher;

        int employee_id;
        public TimerViewModel(int employee_id)
        {
            this.employee_id = employee_id;
            DispatcherTimerSetup();
        }


        private void DispatcherTimerSetup()
        {
            dispatcher = new DispatcherTimer();
            dispatcher.Interval = TimeSpan.FromHours(1);
            dispatcher.Tick += Dispatcher_TickAsync;
            dispatcher.Start();
        }

        private async void Dispatcher_TickAsync(object sender, EventArgs e)
        {

            // get lastest day in timekeeping table 
            DateTime[] lastDayInTimeKeeping = (from t in HRMSDatabase.Ins.TIMEKEEPINGs
                                               orderby t.TIMEKEEPING_ID descending
                                               select t.MONTH.Value).ToArray();
            
            // the first record ever
            if(lastDayInTimeKeeping.Length == 0)
            {
                await insertNewTimekeepingAsync(employee_id);
            }
            else
            {
                DateTime[] lastDayInTimekeeping_Detail = (from t in HRMSDatabase.Ins.TIMEKEEPING_DETAIL
                                                      orderby t.TIMEKEEPING_DETAIL_ID descending
                                                      select t.CHECK_DATE.Value).ToArray();

                if (lastDayInTimekeeping_Detail.Length <= 0 || !isTheSameDay(lastDayInTimekeeping_Detail[0], DateTime.Now))
                {

                }
            }
        }

        public async Task insertNewTimekeepingAsync(int emplopyee_id)
        {
            TIMEKEEPING record = new TIMEKEEPING();
            record.EMPLOYEE_ID = emplopyee_id;
            record.NUMBER_OF_ABSENT_DAY = 0;
            record.NUMBER_OF_OVERTIME_DAY = 0;
            record.NUMBER_OF_WORK_DAY = 0;
            record.MONTH = DateTime.Now;


            HRMSDatabase.Ins.TIMEKEEPINGs.Add(record);
            await HRMSDatabase.Ins.SaveChangesAsync();
        }

        public async Task insertNewTimekeepingDetailAsync(int employee_id, int timekeeping_id)
        {
            TIMEKEEPING_DETAIL record = new TIMEKEEPING_DETAIL();
            record.EMPLOYEE_ID = employee_id;
            record.TIMEKEEPING_ID = timekeeping_id;
            record.CHECK_DATE = DateTime.Now;

            HRMSDatabase.Ins.TIMEKEEPING_DETAIL.Add(record);
            await HRMSDatabase.Ins.SaveChangesAsync();
        }



        private bool isNormalWorkday(DateTime a)
        {
            switch (a.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    return true;
                case DayOfWeek.Saturday:
                    {
                        int h = a.Hour;
                        if(h <= 11)
                        {
                            return true;
                        }
                        return false;
                    }
                    break;
                case DayOfWeek.Sunday:
                    return false;
            }
            return false;
        }
        private bool isAfternoon(DateTime a)
        {
            // using 24-clock
            int hour = a.Hour;
            if (hour <= 11)
                return false;
            return true;
        }

        private bool isTheSameDay(DateTime a , DateTime b)
        {
            return (a.Day == a.Day && a.Month == b.Month && a.Year == b.Year);
        }
    }
}
