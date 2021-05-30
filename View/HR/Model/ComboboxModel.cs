using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.HR
{
    public class ComboboxModel : BaseViewModel
    {
        //Lưu dữ liệu ISSELECTED trong ComboBox
        private bool _ISSELECTED;
        public bool ISSELECTED { get => _ISSELECTED; set { _ISSELECTED = value; OnPropertyChanged(); } }


        //Lưu dữ liệu NAME trong ComboBox chọn loại để lọc
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }

        //Constructor cho ComboBox chọn loại để lọc
        public ComboboxModel(string name, bool isselected)
        {
            this.ISSELECTED = isselected;
            this.NAME = name;
        }
    }
}
