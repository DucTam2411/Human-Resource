using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HRMS.Accouting.ViewModel
{
    public class DetailedSalaryViewModel: BaseViewModel
    {
        public static SalaryData data;
        private SalaryData _SelectedItem;
        public SalaryData SelectedItem
        {
            get {
                if (data != null)
                    return _SelectedItem;
                else
                { 
                    return null;
                }
            }
            set
            {
                if(data != null)
                {
                    _SelectedItem = value;
                }
                OnPropertyChanged();
            }
        }

        public DetailedSalaryViewModel()
        {

        }
    }
}
