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
        private string _ROLE;
        public string ROLE { get => _ROLE; set { _ROLE = value; OnPropertyChanged(); } }
        private string _DEPT;
        public string DEPT { get => _DEPT; set { _DEPT = value; OnPropertyChanged(); } }
        private double _WORK;
        public double WORK { get => _WORK; set { _WORK = value; OnPropertyChanged(); } }
        private double _ABSENT;
        public double ABSENT { get => _ABSENT; set { _ABSENT = value; OnPropertyChanged(); } }
        private double _OVERTIME;
        public double OVERTIME { get => _OVERTIME; set { _OVERTIME= value; OnPropertyChanged(); } }
        private double _STANDARD;
        public double STANDARD { get => _STANDARD; set { _STANDARD = value; OnPropertyChanged(); } }
    }
}
