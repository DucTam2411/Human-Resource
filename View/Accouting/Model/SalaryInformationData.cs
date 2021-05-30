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

        private DateTime _DATE_START;
        public DateTime DATE_START { get => _DATE_START; set { _DATE_START = value; OnPropertyChanged(); } }

        private DateTime _DATE_END;
        public DateTime DATE_END { get => _DATE_END; set { _DATE_END = value; OnPropertyChanged(); } }

        private int _WORK_DAY;
        public int WORK_DAY { get => _WORK_DAY; set { _WORK_DAY = value; OnPropertyChanged(); } }

        private int _OVERTIME_DAY;
        public int OVERTIME_DAY { get => _OVERTIME_DAY; set { _OVERTIME_DAY = value; OnPropertyChanged(); } }

        private long _BASIC_WAGE;
        public long BASIC_WAGE { get => _BASIC_WAGE; set { _BASIC_WAGE = value; OnPropertyChanged(); } }

        private long _OVERTIME_SALARY;
        public long OVERTIME_SALARY { get => _OVERTIME_SALARY; set { _OVERTIME_SALARY = value; OnPropertyChanged(); } }

        private long _SOCIAL_INSURANCE;
        public long SOCIAL_INSURANCE { get => _SOCIAL_INSURANCE; set { _SOCIAL_INSURANCE = value; OnPropertyChanged(); } }

        private long _HEALTH_INSURANCE;
        public long HEALTH_INSURANCE { get => _HEALTH_INSURANCE; set { _HEALTH_INSURANCE = value; OnPropertyChanged(); } }

        private long _BONUS;
        public long BONUS { get => _BONUS; set { _BONUS = value; OnPropertyChanged(); } }

        private long _WELFARE;
        public long WELFARE { get => _WELFARE; set { _WELFARE = value; OnPropertyChanged(); } }

        private long _TAX;
        public long TAX { get => _TAX; set { _TAX = value; OnPropertyChanged(); } }

        private long _TOTAL_SALARY;
        public long TOTAL_SALARY { get => _TOTAL_SALARY; set { _TOTAL_SALARY = value; OnPropertyChanged(); } }

        private string _NOTE;
        public string NOTE { get => _NOTE; set { _NOTE = value; OnPropertyChanged(); } }
    }
}
