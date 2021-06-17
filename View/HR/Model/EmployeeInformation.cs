using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.HR.Model
{
    public class EmployeeInformation : BaseViewModel
    {
        private string _USERNAME;
        public string USERNAME { get => _USERNAME; set { _USERNAME = value; OnPropertyChanged(); } }
        private string _PASSWORD;
        public string PASSWORD { get => _PASSWORD; set { _PASSWORD = value; OnPropertyChanged(); } }
        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }
        private int _ID_CARD;
        public int ID_CARD { get => _ID_CARD; set { _ID_CARD = value; OnPropertyChanged(); } }
        private DateTime _BIRTH_DATE = DateTime.Now;
        public DateTime BIRTH_DATE { get => _BIRTH_DATE; set { _BIRTH_DATE = value; OnPropertyChanged(); } }
        private string _BIRTH_PLACE;
        public string BIRTH_PLACE { get => _BIRTH_PLACE; set { _BIRTH_PLACE = value; OnPropertyChanged(); } }
        private string _CITIZENSHIP;
        public string CITIZENSHIP { get => _CITIZENSHIP; set { _CITIZENSHIP = value; OnPropertyChanged(); } }
        private string _GENDER;
        public string GENDER { get => _GENDER; set { _GENDER = value; OnPropertyChanged(); } }
        private string _PHONE;
        public string PHONE { get => _PHONE; set { _PHONE = value; OnPropertyChanged(); } }
        private string _ROLE_NAME;
        public string ROLE_NAME { get => _ROLE_NAME; set { _ROLE_NAME = value; OnPropertyChanged(); } }
        private int _ROLE_ID;
        public int ROLE_ID { get => _ROLE_ID; set { _ROLE_ID = value; OnPropertyChanged(); } }
        private string _DEPT_NAME;
        public string DEPT_NAME { get => _DEPT_NAME; set { _DEPT_NAME = value; OnPropertyChanged(); } }
        private string _ACADEMIC_LEVEL;
        private int _DEPT_ID;
        public int DEPT_ID { get => _DEPT_ID; set { _DEPT_ID = value; OnPropertyChanged(); } }
        public string ACADEMIC_LEVEL { get => _ACADEMIC_LEVEL; set { _ACADEMIC_LEVEL = value; OnPropertyChanged(); } }
        private string _EMAIL;
        public string EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }
        private double _COEFFICIENT;
        public double COEFFICIENT { get => _COEFFICIENT; set { _COEFFICIENT = value; OnPropertyChanged(); } }
        private long _BASIC_WAGE;
        public long BASIC_WAGE { get => _BASIC_WAGE; set { _BASIC_WAGE = value; OnPropertyChanged(); } }

        private long _OVERTIME_SALARY;
        public long OVERTIME_SALARY { get => _OVERTIME_SALARY; set { _OVERTIME_SALARY = value; OnPropertyChanged(); } }
        

    }
}
