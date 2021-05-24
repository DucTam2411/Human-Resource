﻿using System;
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

namespace HRMS.Accouting.uCon
{
    /// <summary>
    /// Interaction logic for uConRequestBoard.xaml
    /// </summary>
    public partial class uConRequestBoard : UserControl
    {
        public uConRequestBoard()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler RoutedUserControlClicked;

        private void btnHandle_Click(object sender, RoutedEventArgs e)
        {
            if (RoutedUserControlClicked != null)
            {
                RoutedUserControlClicked(this, e);
            }
        }
    }
}