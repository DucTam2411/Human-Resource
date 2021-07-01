using HRMS.Accouting.Model;
using HRMS.HR.Model.Database;
using HRMS.HR.ViewModel;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Accouting.ViewModel
{
    public class SalaryInformationViewModel : BaseViewModel
    {
        #region Data Binding
        private ObservableCollection<ComboboxModel> _MONTHLIST;
        public ObservableCollection<ComboboxModel> MONTHLIST { get => _MONTHLIST; set { _MONTHLIST = value; OnPropertyChanged(); } }

        private long _SOCIAL_INSURANCE;
        public long SOCIAL_INSURANCE { get => _SOCIAL_INSURANCE; set { _SOCIAL_INSURANCE = value; OnPropertyChanged(); } }

        private long _OVERTIME_SALARY;
        public long OVERTIME_SALARY { get => _OVERTIME_SALARY; set { _OVERTIME_SALARY = value; OnPropertyChanged(); } }

        private long _HEALTH_INSURANCE;
        public long HEALTH_INSURANCE { get => _HEALTH_INSURANCE; set { _HEALTH_INSURANCE = value; OnPropertyChanged(); } }

        private long _BONUS;
        public long BONUS { get => _BONUS; set { _BONUS = value; OnPropertyChanged(); } }

        private long _BASIC_WAGE;
        public long BASIC_WAGE { get => _BASIC_WAGE; set { _BASIC_WAGE = value; OnPropertyChanged(); } }

        private long _WELFARE;
        public long WELFARE { get => _WELFARE; set { _WELFARE = value; OnPropertyChanged(); } }

        private double _COEFFICIENT;
        public double COEFFICIENT { get => _COEFFICIENT; set { _COEFFICIENT = value; OnPropertyChanged(); } }

        private long _TAX;
        public long TAX { get => _TAX; set { _TAX = value; OnPropertyChanged(); } }

        private long _TOTAL_SALARY;
        public long TOTAL_SALARY { get => _TOTAL_SALARY; set { _TOTAL_SALARY = value; OnPropertyChanged(); } }

        private long _TOTAL_TAX;
        public long TOTAL_TAX { get => _TOTAL_TAX; set { _TOTAL_TAX = value; OnPropertyChanged(); } }

        private int _NUMBER_OF_WORK_DAY;
        public int NUMBER_OF_WORK_DAY { get => _NUMBER_OF_WORK_DAY; set { _NUMBER_OF_WORK_DAY = value; OnPropertyChanged(); } }

        private int _NUMBER_OF_OVERTIME_DAY;
        public int NUMBER_OF_OVERTIME_DAY { get => _NUMBER_OF_OVERTIME_DAY; set { _NUMBER_OF_OVERTIME_DAY = value; OnPropertyChanged(); } }

        private int _NUMBER_OF_ABSENT_DAY;
        public int NUMBER_OF_ABSENT_DAY { get => _NUMBER_OF_ABSENT_DAY; set { _NUMBER_OF_ABSENT_DAY = value; OnPropertyChanged(); } }

        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }

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
                    LoadSalaryData(EMPLOYEE_ID);
                }
            }
        }

        private void LoadSalaryData(int id)
        {
            hrmsEntities DB = new hrmsEntities();
            var list = (from emp in DB.EMPLOYEEs
                        join tk in DB.TIMEKEEPINGs on emp.EMPLOYEE_ID equals tk.EMPLOYEE_ID
                        join sl in DB.SALARies on emp.EMPLOYEE_ID equals sl.EMPLOYEE_ID
                        where emp.EMPLOYEE_ID == id
                        && sl.DATE_START.Value.Month == SELECTMONTHTYPE.MONTH
                        && sl.DATE_START.Value.Year == SELECTMONTHTYPE.YEAR
                        && tk.DATE_START.Value.Month == SELECTMONTHTYPE.MONTH
                        && tk.DATE_START.Value.Year == SELECTMONTHTYPE.YEAR
                        select new { EMPLOYEE = emp, TIMEKEEPING = tk, SALARY = sl }).SingleOrDefault();

            TOTAL_SALARY = (long)list.SALARY.TOTAL_SALARY;
            COEFFICIENT = (double)list.SALARY.COEFFICIENT;
            BASIC_WAGE = (long)list.SALARY.BASIC_WAGE;
            WELFARE = (long)list.SALARY.WELFARE;
            BONUS = (long)list.SALARY.BONUS;
            HEALTH_INSURANCE = (long)list.SALARY.HEALTH_INSURANCE;
            SOCIAL_INSURANCE = (long)list.SALARY.SOCIAL_INSURANCE;
            TAX = (long)list.SALARY.TAX;
            NUMBER_OF_ABSENT_DAY = (int)list.TIMEKEEPING.NUMBER_OF_ABSENT_DAY;
            NUMBER_OF_OVERTIME_DAY = (int)list.TIMEKEEPING.NUMBER_OF_OVERTIME_DAY;
            NUMBER_OF_WORK_DAY = (int)list.TIMEKEEPING.NUMBER_OF_WORK_DAY;
            OVERTIME_SALARY = (long)list.SALARY.OVERTIME_SALARY;
            TOTAL_TAX = HEALTH_INSURANCE + SOCIAL_INSURANCE + TAX;
        }
        #endregion
        public SalaryInformationViewModel()
        {
            LoadMonth();
        }

        public SalaryInformationViewModel(int ID)
        {
            EMPLOYEE_ID = ID;
            LoadMonth();
        }

        //Load dữ liệu tháng vào comboBox Month
        private void LoadMonth()
        {
            hrmsEntities db = new hrmsEntities();
            //Chọn tháng từ database KHÔNG TRÙNG LẶP (chọn DATE_START và DATE_END để kiểm tra tháng bắt đầu và tháng kết thúc có hợp lệ không (nếu cách nhau không quá 31 ngày hợp lệ)
            var listmonth = (from month in db.SALARies where month.EMPLOYEE_ID == EMPLOYEE_ID
                             select new { Date_Start = month.DATE_START, Date_End = month.DATE_END }).Distinct();

            //Khởi tạo biến MONTHLIST để chứa tháng
            MONTHLIST = new ObservableCollection<ComboboxModel>();

            //Đưa dữ liệu từ listmonth vào MONTHLIST
            foreach (var item in listmonth)
            {
                DateTime start = (DateTime)item.Date_Start;
                DateTime end = (DateTime)item.Date_End;
                if (!(start.Month == DateTime.Now.Month && start.Year == DateTime.Now.Year))
                {
                    //Kiểm tra dữ liệu tháng có hợp lệ không
                    if (end.Month - start.Month <= 1)
                    {
                        int day_end = end.Day;
                        int day_start = start.Day;

                        //Kiểm tra tháng kết thúc có lớn hơn tháng bắt đầu không
                        if (end.Month - start.Month == 1)
                        {
                            day_end = end.Day + AccountingClass.GetDaybyMonth((end.Month == 1) ? 12 : end.Month, (end.Month == 1) ? end.Year - 1 : end.Year);
                            day_start = start.Day;
                        }

                        //Nếu điều kiện hợp lệ thì lưu dữ liệu vào ComboBox Month thông qua MONTHLIST
                        if (day_end - day_start <= 31)
                        {
                            MONTHLIST.Add(new ComboboxModel(start.Month, start.Year, (AccountingClass.IsMonthBefore(start.Month, start.Year)) ? true : false));
                        }

                    }
                }
            }
            SELECTMONTHTYPE = MONTHLIST.Where(x => x.ISSELECTED == true).FirstOrDefault();
            if (SELECTMONTHTYPE == null)
            {
                SELECTMONTHTYPE = MONTHLIST.FirstOrDefault();
            }
        }


    }
}
