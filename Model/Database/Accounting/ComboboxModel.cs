﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //Lưu dữ liệu vào combox
    public class ComboboxModel:BaseView
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
    }
}
