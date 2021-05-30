using HRMS.HR.Model.Database;
using HRMS.HR.uCon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRMS.HR.ViewModel
{
    public class ListEmployeeViewModel : BaseViewModel
    {
        private ObservableCollection<EMPLOYEE> _employees;
        public ICommand GridLoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ObservableCollection<EMPLOYEE> employees { get => _employees; set { _employees = value;OnPropertyChanged(); } }

        private EMPLOYEE _SELECTED_ITEM;
        public EMPLOYEE SELECTED_ITEM {
            get => _SELECTED_ITEM;
            set {
                _SELECTED_ITEM = value;
                OnPropertyChanged();
                if (SELECTED_ITEM != null)
                {
                    NAME = SELECTED_ITEM.NAME;
                    ID_CARD = (int)SELECTED_ITEM.ID_CARD;
                    BIRTH_DATE = (DateTime)SELECTED_ITEM.BIRTH_DATE;
                    BIRTH_PLACE = SELECTED_ITEM.BIRTH_PLACE;
                    CITIZENSHIP = SELECTED_ITEM.CITIZENSHIP;
                    GENDER = SELECTED_ITEM.GENDER;
                    PHONE = SELECTED_ITEM.PHONE;
                    ROLE_NAME = SELECTED_ITEM.ROLE.ROLE_NAME;
                    DEPT_NAME = SELECTED_ITEM.DEPARTMENT.DEPT_NAME;
                    ACADEMIC_LEVEL = SELECTED_ITEM.ACADEMIC_LEVEL;
                    EMAIL = SELECTED_ITEM.EMAIL;
                }
            }
        }
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }
        private int _ID_CARD;
        public int ID_CARD { get => _ID_CARD; set { _ID_CARD = value; OnPropertyChanged(); } }
        private DateTime _BIRTH_DATE = DateTime.Now;
        public DateTime BIRTH_DATE { get => _BIRTH_DATE; set { _BIRTH_DATE = value; OnPropertyChanged(); } }
        private string _BIRTH_PLACE;
        public string BIRTH_PLACE { get => _BIRTH_PLACE; set { _BIRTH_PLACE = value; OnPropertyChanged(); } }
        private string _CITIZENSHIP;
        public string CITIZENSHIP { get => _CITIZENSHIP; set { _CITIZENSHIP = value; OnPropertyChanged(); } }
        private string _GENDER;
        public string GENDER { get => _GENDER; set { _GENDER = value; OnPropertyChanged(); } }
        private string _PHONE;
        public string PHONE { get => _PHONE; set { _PHONE = value; OnPropertyChanged(); } }
        private string _ROLE_NAME;
        public string ROLE_NAME { get => _ROLE_NAME; set { _ROLE_NAME = value; OnPropertyChanged(); } }
        private int _ROLE_ID;
        public int ROLE_ID { get => _ROLE_ID; set { _ROLE_ID = value;OnPropertyChanged(); } }
        private string _DEPT_NAME;
        public string DEPT_NAME { get => _DEPT_NAME; set { _DEPT_NAME = value; OnPropertyChanged(); } }
        private string _ACADEMIC_LEVEL;
        private int _DEPT_ID;
        public int DEPT_ID { get => _DEPT_ID; set { _DEPT_ID = value; OnPropertyChanged(); } }
        public string ACADEMIC_LEVEL { get => _ACADEMIC_LEVEL; set { _ACADEMIC_LEVEL = value; OnPropertyChanged(); } }
        private string _EMAIL;
        public string EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }

        public ListEmployeeViewModel()
        {
            LoadData();
            AddCommand = new RelayCommand<ContentControl>(p => { return true;
            }, p =>
            {
                p.Content = new uConAddEmployee();
            });
            DoubleClickCommand = new RelayCommand<ContentControl>(p => { if (SELECTED_ITEM != null) { return true; } else { return false; } },
            p => {
                p.Content = new uConModifyEmployee(SELECTED_ITEM);
            });
            ConfirmCommand = new RelayCommand<object>(p => {
                if (string.IsNullOrEmpty(ID_CARD.ToString()) || string.IsNullOrEmpty(NAME) || string.IsNullOrEmpty(DEPT_NAME) || string.IsNullOrEmpty(ROLE_NAME))
                    return false;
                var displayList = HRMSEntities.Ins.DB.EMPLOYEEs.Where(x => x.ID_CARD == ID_CARD);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;
            }, p => {
                setID();
                hrmsEntities db = new hrmsEntities();
                var employee = new EMPLOYEE()
                {
                    ID_CARD = ID_CARD,
                    NAME = NAME,
                    AGE = DateTime.Now.Year - BIRTH_DATE.Year,
                    GENDER = GENDER,
                    ACADEMIC_LEVEL = ACADEMIC_LEVEL,
                    BIRTH_DATE = BIRTH_DATE,
                    BIRTH_PLACE = BIRTH_PLACE,
                    EMAIL = EMAIL,
                    PHONE = PHONE,
                    CITIZENSHIP = CITIZENSHIP,
                    DEPT_ID = DEPT_ID,
                    ROLE_ID = ROLE_ID,
                    IMAGE = null,
                    BLOODTYPE = null
                };
                db.EMPLOYEEs.Add(employee);
                db.SaveChanges();
                MessageBox.Show("Added successfully!");
            });
            BackCommand = new RelayCommand<ContentControl>(p => { return true; }, p => { p.Content = new uConListEmployee(); });
        }
        public ListEmployeeViewModel(EMPLOYEE selected)
        {
            SELECTED_ITEM = selected;
            SaveCommand = new RelayCommand<object>(p => { return true; }, p =>
            {
                EditData(selected);
                MessageBox.Show("Saved successfully");
            });
            BackCommand = new RelayCommand<ContentControl>(p => { return true; }, p => { p.Content = new uConListEmployee(); });
            RemoveCommand = new RelayCommand<object>(p => { return true; }, p =>
            {
                DeleteData(selected);
                MessageBox.Show("Deleted successfully");
            });
        }

        private void EditData(EMPLOYEE e)
        {
            hrmsEntities db = new hrmsEntities();
            var Employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == e.EMPLOYEE_ID).SingleOrDefault();
            Employee.NAME = NAME;
            Employee.AGE = DateTime.Now.Year - BIRTH_DATE.Year;
            Employee.ACADEMIC_LEVEL = ACADEMIC_LEVEL;
            Employee.GENDER = GENDER;
            Employee.BIRTH_DATE = BIRTH_DATE;
            Employee.EMAIL = EMAIL;
            Employee.PHONE = PHONE;
            Employee.BIRTH_PLACE = BIRTH_PLACE;
            Employee.CITIZENSHIP = CITIZENSHIP;
            setID();
            Employee.ROLE_ID = ROLE_ID;
            Employee.DEPT_ID = DEPT_ID;
            db.SaveChanges();
        }
        private void DeleteData(EMPLOYEE e)
        {
            hrmsEntities db = new hrmsEntities();
            var Employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == e.EMPLOYEE_ID).SingleOrDefault();
            db.EMPLOYEEs.Remove(Employee);
            db.SaveChanges();
        }
        private void setID()
        {
            switch (ROLE_NAME)
            {
                case "MANAGER HR DEPT":
                    ROLE_ID = 1;
                    break;
                case "VICE MANAGER HR DEPT":
                    ROLE_ID = 2;
                    break;
                case "EMPLOYEE HR DEPT":
                    ROLE_ID = 3;
                    break;
                case "MANAGER ACCOUNTING":
                    ROLE_ID = 4;
                    break;
                case "VICE MANAGER ACCOUNTING":
                    ROLE_ID = 5;
                    break;
                case "EMPLOYEE ACOUNTING":
                    ROLE_ID = 6;
                    break;
                case "DIRECTOR":
                    ROLE_ID = 7;
                    break;
                case "VICE DIRECTOR":
                    ROLE_ID = 8;
                    break;
                case "EMPLOYEE SOFTWARE DEPT":
                    ROLE_ID = 9;
                    break;
            }
            switch (DEPT_NAME)
            {
                case "HUMAN RESOURCE DEPT":
                    DEPT_ID = 1;
                    break;
                case "ACOUNTING DEPT":
                    DEPT_ID = 2;
                    break;
                case "DIRECTOR DEPT":
                    DEPT_ID = 3;
                    break;
                case "SOFTWARE DEPT":
                    DEPT_ID = 4;
                    break;
                case "QUALITY MANAGEMENT DEPT":
                    DEPT_ID = 5;
                    break;
                case "BUSSINESS DEPT":
                    DEPT_ID = 6;
                    break;
                case "SUPPORT DEPT":
                    DEPT_ID = 7;
                    break;
            }
        }
        private void LoadData()
        {
            var list = (from emp in HRMSEntities.Ins.DB.EMPLOYEEs select emp);
            employees = new ObservableCollection<EMPLOYEE>();
            foreach (var item in list)
            {
                employees.Add(item);
            }
        }


        //private void Grid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var customers = (from customer in HRMSEntities.Ins.DB.EMPLOYEEs
        //                     select customer);
        //    dtgvEmployees.ItemsSource = customers.ToArray();
        //}

        //private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{

        //    EMPLOYEE employee = (dtgvEmployees.SelectedItem as EMPLOYEE);
        //    contentControlMain.Content = new uConModifyEmployee(employee);
        //}

        //private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        //{
        //    contentControlMain.Content = new uConAddEmployee();
        //}

    }
}
