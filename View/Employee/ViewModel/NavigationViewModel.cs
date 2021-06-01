using HRMS.Employee.uCon;
using HRMS.Model;
using System;
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

        public NavigationViewModel()
        {
            InformationCommand = new RelayCommand<object>(null, p =>
            {
                CONTENT_MAIN = new uConEmployeeInformation();
            });

            TimekeepingCommand = new RelayCommand<object>(null, p =>
            {
                CONTENT_MAIN = new uConEmployeeTimekeepingDetail();
            });

            SalaryCommand = new RelayCommand<object>(null, p =>
            {
                CONTENT_MAIN = new uConEmployeeSalary();
            });

        }


        private object _CONTENT_MAIN = new uConEmployeeInformation();
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

        public ICommand InformationCommand { get; set; }
        public ICommand TimekeepingCommand { get; set; }
        public ICommand SalaryCommand { get; set; }
    }
}
