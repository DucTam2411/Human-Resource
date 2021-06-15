using HRMS.Director.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Director.Model
{
    public class TimekeepingData : BaseViewModel
    {
        private int _ID;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }

        private DateTime _MONTH;
        public DateTime MONTH { get => _MONTH; set { _MONTH = value; OnPropertyChanged(); } }

        private int _DAY_START;
        public int DAY_START { get => _DAY_START; set { _DAY_START = value; OnPropertyChanged(); } }

        private int _DAY_END;
        public int DAY_END { get => _DAY_END; set { _DAY_END = value; OnPropertyChanged(); } }

        private int _TOTAL_WORK_DAY;
        public int TOTAL_WORK_DAY { get => _TOTAL_WORK_DAY; set { _TOTAL_WORK_DAY = value; OnPropertyChanged(); } }

        private int _TOTAL_OVERTIME_DAY;
        public int TOTAL_OVERTIME_DAY { get => _TOTAL_OVERTIME_DAY; set { _TOTAL_OVERTIME_DAY = value; OnPropertyChanged(); } }

        private int _TOTAL_ABSENT_DAY;
        public int TOTAL_ABSENT_DAY { get => _TOTAL_ABSENT_DAY; set { _TOTAL_ABSENT_DAY = value; OnPropertyChanged(); } }

        private string _NOTE;
        public string NOTE { get => _NOTE; set { _NOTE = value; OnPropertyChanged(); } }

    }
}
