using HRMS.HR.ViewModel;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Accouting.Model
{
    public class SalaryData : BaseViewModel
    {
        //Lưu ID nếu cần thiết
        private int _ID;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }

        //Lưu thông tin nhân viên
        private EMPLOYEE _EMPLOYEE;
        public EMPLOYEE EMPLOYEE { get => _EMPLOYEE; set { _EMPLOYEE = value; OnPropertyChanged(); } }

        //Lưu thông tin chấm công
        private TIMEKEEPING _TIMEKEEPING;
        public TIMEKEEPING TIMEKEEPING { get => _TIMEKEEPING; set { _TIMEKEEPING = value; OnPropertyChanged(); } }

        //Lưu thông tin lương
        private SALARY _SALARY;
        public SALARY SALARY { get => _SALARY; set { _SALARY = value; OnPropertyChanged(); } }

    }
}
