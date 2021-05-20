using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for uConListEmployeeAccounting.xaml
    /// </summary>
    public partial class uConListEmployeeAccounting : UserControl
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public uConListEmployeeAccounting()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            employees.Add(new Employee() { Role = "Quán lý", Citizenship = "Ấn Độ", Department = "Tổ 1", Gender = "Neutral", ID = "11121", Name = "Trần Quân Hoàng" });
            employees.Add(new Employee() { Role = "Nhân viên văn phòng", Citizenship = "Italy", Department = "Tổ 2", Gender = "Nữ", ID = "11121", Name = "Siêu nhân điện quang" });
            employees.Add(new Employee() { Role = "Nhân viên công vụ", Citizenship = "sds", Department = "Tổ 3", Gender = "Nam", ID = "11121", Name = "Siêu nhân cuồng phong" });
            employees.Add(new Employee() { Role = "Nhân viên công vụ", Citizenship = "sds", Department = "Tổ 3", Gender = "Nam", ID = "11121", Name = "Siêu nhân cuồng phong" });
            employees.Add(new Employee() { Role = "Nhân viên công vụ", Citizenship = "sds", Department = "Tổ 3", Gender = "Nam", ID = "11121", Name = "Siêu nhân cuồng phong" });
            employees.Add(new Employee() { Role = "Giám đốc kỹ thuật", Citizenship = "sds", Department = "dsd", Gender = "Tổ 1", ID = "Nữ", Name = "Gao ồ GAO Ồ" });
            employees.Add(new Employee() { Role = "Giám đốc kỹ thuật", Citizenship = "sds", Department = "dsd", Gender = "Tổ 1", ID = "Nữ", Name = "Gao ồ GAO Ồ" });
            employees.Add(new Employee() { Role = "Giám đốc kỹ thuật", Citizenship = "sds", Department = "dsd", Gender = "Tổ 1", ID = "Nữ", Name = "Gao ồ GAO Ồ" });
            employees.Add(new Employee() { Role = "Giám đốc kỹ thuật", Citizenship = "sds", Department = "dsd", Gender = "Tổ 1", ID = "Nữ", Name = "Gao ồ GAO Ồ" });
            employees.Add(new Employee() { Role = "Giám đốc kỹ thuật", Citizenship = "sds", Department = "dsd", Gender = "Tổ 1", ID = "Nữ", Name = "Gao ồ GAO Ồ" });

            dtgvA.ItemsSource = employees;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            contentControlMain.Content = new uConEmployeeSalary();
            contentControlMain.Margin = new Thickness(0, -20, 0, 0);
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
