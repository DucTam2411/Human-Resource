using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.HR.Model
{
    public class TimekeepingClass : BaseViewModel
    {
        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value; OnPropertyChanged(); } }
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }
        private string _ROLE;
        public string ROLE { get => _ROLE; set { _ROLE = value; OnPropertyChanged(); } }
        private string _DEPT;
        public string DEPT { get => _DEPT; set { _DEPT = value; OnPropertyChanged(); } }
        private string _MONTH;
        public string MONTH { get => _MONTH; set { _MONTH = value; OnPropertyChanged(); } }

        private string _DATE;
        public string DATE { get => _DATE; set { _DATE = value;OnPropertyChanged(); } }
        private string _SESSION;
        public string SESSION { get => _SESSION; set { _SESSION = value;OnPropertyChanged(); } }
        private string _ATTENDANCE;
        public string ATTENDANCE { get => _ATTENDANCE; set { _ATTENDANCE = value;OnPropertyChanged(); } }
       
    }
}
