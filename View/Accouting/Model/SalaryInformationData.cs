using HRMS.Accouting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Accouting.Model
{
    public class SalaryInformationData : BaseViewModel
    {
        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }

        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }

        private string _DEPARTMENT;
        public string DEPARTMENT { get => _DEPARTMENT; set { _DEPARTMENT = value; OnPropertyChanged(); } }

        private string _ROLE;
        public string ROLE { get => _ROLE; set { _ROLE = value; OnPropertyChanged(); } }

        private double _COEFFICIENT;
        public double COEFFICIENT { get => _COEFFICIENT; set { _COEFFICIENT = value; OnPropertyChanged(); } }

        private DateTime _START;
        public DateTime DATESTART { get => _START; set { _START = value; OnPropertyChanged(); } }

        private DateTime _END;
        public DateTime DATEEND { get => _END; set { _END = value; OnPropertyChanged(); } }

        private DateTime _MONTH;
        public DateTime MONTH { get => _MONTH; set { _MONTH = value; OnPropertyChanged(); } }

        private int _WORK;
        public int WORKDAY { get => _WORK; set { _WORK = value; OnPropertyChanged(); } }

        private int _OVERTIME;
        public int OVERTIMEDAY { get => _OVERTIME; set { _OVERTIME = value; OnPropertyChanged(); } }

        private long _BASIC_WAGE;
        public long BASICWAGE { get => _BASIC_WAGE; set { _BASIC_WAGE = value; OnPropertyChanged(); } }

        private long _OVERTIME_SALARY;
        public long OVERTIMESALARY { get => _OVERTIME_SALARY; set { _OVERTIME_SALARY = value; OnPropertyChanged(); } }

        private long _SOCIAL_INSURANCE;
        public long SOCIALINSURANCE { get => _SOCIAL_INSURANCE; set { _SOCIAL_INSURANCE = value; OnPropertyChanged(); } }

        private long _HEALTH_INSURANCE;
        public long HEALTHINSURANCE { get => _HEALTH_INSURANCE; set { _HEALTH_INSURANCE = value; OnPropertyChanged(); } }

        private long _BONUS;
        public long BONUS { get => _BONUS; set { _BONUS = value; OnPropertyChanged(); } }

        private long _WELFARE;
        public long WELFARE { get => _WELFARE; set { _WELFARE = value; OnPropertyChanged(); } }

        private long _TAX;
        public long TAX { get => _TAX; set { _TAX = value; OnPropertyChanged(); } }

        private long _TOTAL_SALARY;
        public long TOTALSALARY { get => _TOTAL_SALARY; set { _TOTAL_SALARY = value; OnPropertyChanged(); } }

        private string _NOTE;
        public string NOTE { get => _NOTE; set { _NOTE = value; OnPropertyChanged(); } }
    }
}
