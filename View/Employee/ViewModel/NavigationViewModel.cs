using HRMS.Employee.uCon;
using HRMS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRMS.Employee.ViewModel
{
    public class NavigationViewModel : BaseViewModel
    {

        int employee_id;
        public NavigationViewModel(int employee_id)
        {
            InformationCommand = new RelayCommand<object>(null, p =>
            {
                CONTENT_MAIN = new uConEmployeeInformation(employee_id, this);
            });

            TimekeepingCommand = new RelayCommand<object>(null, p =>
            {
                CONTENT_MAIN = new uConEmployeeTimekeepingWhole(employee_id, this);
            });

            SalaryCommand = new RelayCommand<object>(null, p =>
            {
                CONTENT_MAIN = new uConEmployeeSalary(employee_id, this);
            });

            CONTENT_MAIN = new uConEmployeeInformation(employee_id, this);
        }


        private object _CONTENT_MAIN;
        public object CONTENT_MAIN
        {
            get
            {

                return _CONTENT_MAIN;
            }
            set
            {
                _CONTENT_MAIN = value;

                OnPropertyChanged();
            }
        }


        public bool _VISIBLE = true;
        public bool VISIBLE
        {
            get
            {
                return _VISIBLE;
            }
            set
            {
                _VISIBLE = value;
                OnPropertyChanged();
            }
        }


        public ICommand checkAttendanceCommand { get; set; }

        public ICommand InformationCommand { get; set; }
        public ICommand TimekeepingCommand { get; set; }
        public ICommand SalaryCommand { get; set; }


    }

}
