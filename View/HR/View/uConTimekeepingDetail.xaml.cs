﻿using HRMS.HR.Model;
using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRMS.HR.View
{
    /// <summary>
    /// Interaction logic for uConTimekeepingDetail.xaml
    /// </summary>
    public partial class uConTimekeepingDetail : UserControl
    {
        public uConTimekeepingDetail(int id, TimekeepingData selected)
        {
            InitializeComponent();
            DataContext = new ReportViewModel(id, selected);
        }
    }
}
