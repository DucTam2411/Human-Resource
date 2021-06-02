using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.HR.Model
{
    public class TimekeepingData : BaseViewModel
    {
        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }
        private string _ROLE_NAME;
        public string ROLE_NAME { get => _ROLE_NAME; set { _ROLE_NAME = value; OnPropertyChanged(); } }
        private string _DEPT_NAME;
        public string DEPT_NAME { get => _DEPT_NAME; set { _DEPT_NAME = value; OnPropertyChanged(); } }
        private double _WORK_DAY;
        public double WORK_DAY { get => _WORK_DAY; set { _WORK_DAY = value; OnPropertyChanged(); } }
        private double _ABSENT_DAY;
        public double ABSENT_DAY { get => _ABSENT_DAY; set { _ABSENT_DAY = value; OnPropertyChanged(); } }
        private double _OVERTIME_DAY;
        public double OVERTIME_DAY { get => _OVERTIME_DAY; set { _OVERTIME_DAY = value; OnPropertyChanged(); } }
        private double _STANDARD_DAY;
        public double STANDARD_DAY { get => _STANDARD_DAY; set { _STANDARD_DAY = value; OnPropertyChanged(); } }
    }
}
