using HRMS.Accouting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Accouting.Model
{
    public class ComboboxModel : BaseViewModel
    {
        //Lưu dữ liệu ISSELECTED trong ComboBox
        private bool _ISSELECTED;
        public bool ISSELECTED { get => _ISSELECTED; set { _ISSELECTED = value; OnPropertyChanged(); } }

        //Lưu dữ liệu NAME trong ComboBox chọn loại để lọc
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }

        //Lưu dữ liệu MONTH trong ComboBox chọn tháng
        private int _MONTH;
        public int MONTH { get => _MONTH; set { _MONTH = value; OnPropertyChanged(); } }

        //Lưu dữ liệu YEAR trong ComboBox chọn tháng
        private int _YEAR;
        public int YEAR { get => _YEAR; set { _YEAR = value; OnPropertyChanged(); } }

        //Lưu dữ liệu DEPT_NAME vào ComboBox chọn phòng ban
        private string _DEPT_NAME;
        public string DEPT_NAME { get => _DEPT_NAME; set { _DEPT_NAME = value; OnPropertyChanged(); } }

        //Lưu dữ liệu DEPT_ID vào ComboBox chọn phòng ban
        private int _DEPT_ID;
        public int DEPT_ID { get => _DEPT_ID; set { _DEPT_ID = value; OnPropertyChanged(); } }

        //Constructor cho ComboBox chọn loại để lọc
        public ComboboxModel(string name, bool isselected)
        {
            this.ISSELECTED = isselected;
            this.NAME = name;
        }

        //Constructor cho ComboBox chọn tháng
        public ComboboxModel(int month, int year, bool isselected)
        {
            this.MONTH = month;
            this.YEAR = year;
            this.ISSELECTED = isselected;
        }
        //Contructor cho ComboBox chọn phòng ban
        public ComboboxModel(string dept_name, int dept_id, bool isselected)
        {
            this.DEPT_NAME = dept_name;
            this.DEPT_ID = dept_id;
            this.ISSELECTED = isselected;
        }
    }
}
