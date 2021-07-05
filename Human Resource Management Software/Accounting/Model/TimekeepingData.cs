using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Accouting.Model
{
    public class TimekeepingData : BaseViewModel
    {
        private int _ID;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value;OnPropertyChanged(); } }

        private DateTime _MONTH;
        public DateTime MONTH { get => _MONTH; set { _MONTH = value; OnPropertyChanged(); } }

        private DateTime _DAY_START;
        public DateTime DAY_START { get => _DAY_START; set { _DAY_START = value; OnPropertyChanged(); } }

        private DateTime _DAY_END;
        public DateTime DAY_END { get => _DAY_END; set { _DAY_END = value; OnPropertyChanged(); } }

        private double _TOTAL_WORK_DAY;
        public double TOTAL_WORK_DAY { get => _TOTAL_WORK_DAY; set { _TOTAL_WORK_DAY = value; OnPropertyChanged(); } }

        private double _TOTAL_OVERTIME_DAY;
        public double TOTAL_OVERTIME_DAY { get => _TOTAL_OVERTIME_DAY; set { _TOTAL_OVERTIME_DAY = value; OnPropertyChanged(); } }

        private double _TOTAL_ABSENT_DAY;
        public double TOTAL_ABSENT_DAY { get => _TOTAL_ABSENT_DAY; set { _TOTAL_ABSENT_DAY = value; OnPropertyChanged(); } }

        private string _NOTE;
        public string NOTE { get => _NOTE; set { _NOTE = value; OnPropertyChanged(); } }
    }
}