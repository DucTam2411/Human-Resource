using HRMS.HR.Model.Database;
using HRMS.HR.Model;
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
using System.Web.Security;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using HRMS.Model;

namespace HRMS.HR.ViewModel
{
    public class ListEmployeeViewModel : BaseViewModel
    {
        private ObservableCollection<EmployeeInformation> _employees;
        private ObservableCollection<EmployeeInformation> _testemployees;
        public ICommand GridLoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddImageCommand { get; set; }
        public ICommand ViewUser { get; set; }

        public ICommand ChangePasswordCommand { get; set; }

        public ICommand Next { get; set; }

        public ObservableCollection<EmployeeInformation> employees { get => _employees; set { _employees = value; OnPropertyChanged(); } }
        public ObservableCollection<EmployeeInformation> testemployees { get => _testemployees; set { _testemployees = value; OnPropertyChanged(); } }

        private EmployeeInformation _SELECTED_ITEM;
        public EmployeeInformation SELECTED_ITEM {
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
                    ROLE_NAME = SELECTED_ITEM.ROLE_NAME;
                    DEPT_NAME = SELECTED_ITEM.DEPT_NAME;
                    ACADEMIC_LEVEL = SELECTED_ITEM.ACADEMIC_LEVEL;
                    EMAIL = SELECTED_ITEM.EMAIL;
                    USER user = HRMSEntities.Ins.DB.USERs.Where(x => x.EMPLOYEE_ID == SELECTED_ITEM.EMPLOYEE_ID).FirstOrDefault();
                    PASSWORD = user.PASSWORD;
                    USERNAME = user.USERNAME;
                    EMPLOYEE emp = HRMSEntities.Ins.DB.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == SELECTED_ITEM.EMPLOYEE_ID).FirstOrDefault();
                    IMAGESOURCE = emp.IMAGE;
                    if (IMAGESOURCE == null)
                    {
                        BUTTONTHICKNESS = 1;
                        IMAGE_SOURCE = null;
                        BRUSH = Brushes.AliceBlue;
                    }
                    else
                    {
                        BUTTONTHICKNESS = 0;
                        IMAGE_SOURCE = ToImage(IMAGESOURCE);
                        BRUSH = Brushes.Transparent;
                    }
                }
            }
        }
        private string _USERNAME;
        public string USERNAME { get => _USERNAME; set { _USERNAME = value; OnPropertyChanged(); } }
        private string _PASSWORD;
        public string PASSWORD { get => _PASSWORD; set { _PASSWORD = value; OnPropertyChanged(); } }
        private int _EMPLOYEE_ID;
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set { _EMPLOYEE_ID = value;OnPropertyChanged(); } }
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
        private double _COEFFICIENT;
        public double COEFFICIENT { get => _COEFFICIENT; set { _COEFFICIENT = value; OnPropertyChanged(); } }
        private long _BASIC_WAGE;
        public long BASIC_WAGE { get => _BASIC_WAGE; set { _BASIC_WAGE = value; OnPropertyChanged(); } }

        private long _OVERTIME_SALARY;
        public long OVERTIME_SALARY { get => _OVERTIME_SALARY; set { _OVERTIME_SALARY = value; OnPropertyChanged(); } }
        private string _NOTE;
        public string NOTE { get => _NOTE; set { _NOTE = value; OnPropertyChanged(); } }

        private string _NOTE_REMOVE;
        public string NOTE_REMOVE { get => _NOTE_REMOVE; set { _NOTE_REMOVE = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ListRole;
        public ObservableCollection<string> ListRole { get => _ListRole; set { _ListRole = value; OnPropertyChanged(); } }

        private ComboboxModel _SELECTEDTYPE;
        public ComboboxModel SELECTEDTYPE { get => _SELECTEDTYPE; set { _SELECTEDTYPE = value; OnPropertyChanged(); } }

        private ObservableCollection<ComboboxModel> _ListType;
        public ObservableCollection<ComboboxModel> ListType { get => _ListType; set { _ListType = value; OnPropertyChanged(); } }

        private byte[] _IMAGESOURCE;
        public byte[] IMAGESOURCE { get => _IMAGESOURCE; set { _IMAGESOURCE = value; OnPropertyChanged(); } }

        private BitmapImage _IMAGE_SOURCE;
        public BitmapImage IMAGE_SOURCE { get => _IMAGE_SOURCE; set { _IMAGE_SOURCE = value; OnPropertyChanged(); } }

        private Brush _BRUSH;
        public Brush BRUSH { get => _BRUSH; set { _BRUSH = value; OnPropertyChanged(); } }

        private int _BUTTONTHICKNESS;
        public int BUTTONTHICKNESS { get => _BUTTONTHICKNESS; set { _BUTTONTHICKNESS = value; OnPropertyChanged(); } }

        private int _USER_ID;
        public int USER_ID { get => _USER_ID; set { _USER_ID = value; OnPropertyChanged(); } }

        private string _USER_NAME;
        public string USER_NAME { get => _USER_NAME; set { _USER_NAME = value; OnPropertyChanged(); } }

        private int _USER_DEPT;
        public int USER_DEPT { get => _USER_DEPT; set { _USER_DEPT = value; OnPropertyChanged(); } }

        private int _USER_ROLE;
        public int USER_ROLE { get => _USER_ROLE; set { _USER_ROLE = value; OnPropertyChanged(); } }

        private string _SEARCH_TEXT;
        public string SEARCH_TEXT
        {
            get => _SEARCH_TEXT; set
            {
                _SEARCH_TEXT = value;
                OnPropertyChanged();

                //Đưa SalaryTest vào trong SalaryList để dữ liệu được refresh mỗi lần nhập
                employees = testemployees;

                //Kiểm tra SearchText có khác null không
                if (!string.IsNullOrEmpty(SEARCH_TEXT))
                {
                    //Kiểm tra ComboBox chọn loại để lọc có khác null không
                    if (SELECTEDTYPE != null)
                    {
                        //Chọn kiểu lọc
                        switch (SELECTEDTYPE.NAME)
                        {
                            //Lọc theo ID
                            case "ID":
                                employees = new ObservableCollection<EmployeeInformation>(employees.Where(x => x.ID_CARD.ToString().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo tên
                            case "NAME":
                                employees = new ObservableCollection<EmployeeInformation>(employees.Where(x => x.NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo Department
                            case "DEPARTMENT":
                                employees = new ObservableCollection<EmployeeInformation>(employees.Where(x => x.DEPT_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPT_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.DEPT_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;

                            //Lọc theo role
                            case "ROLE":
                                employees = new ObservableCollection<EmployeeInformation>(employees.Where(x => x.ROLE_NAME.Contains(SEARCH_TEXT) ||
                                                                                                        x.ROLE_NAME.ToLower().Contains(SEARCH_TEXT) ||
                                                                                                        x.ROLE_NAME.ToUpper().Contains(SEARCH_TEXT)));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }



        public ListEmployeeViewModel(int ID)
        {
            CreateAttendanceDays();
            LoadComboboxTypeList();
            LoadData();
            USER_ID = ID;
            BUTTONTHICKNESS = 1;
            IMAGE_SOURCE = null;
            BRUSH = Brushes.AliceBlue;
            AddCommand = new RelayCommand<ContentControl>(p => { return true;
            }, p =>
            {
                p.Content = new uConAddEmployee(ID);
                RandomGenerator generator = new RandomGenerator();
                USERNAME = generator.RandomNumber(10000, 99999).ToString();
                PASSWORD = generator.RandomPassword();
                BASIC_WAGE = 0;
                OVERTIME_SALARY = 0;
                COEFFICIENT = 0;
            });
            DoubleClickCommand = new RelayCommand<ContentControl>(p => { if (SELECTED_ITEM != null) { return true; } else { return false; } },
            p => {
                p.Content = new uConModifyEmployee(SELECTED_ITEM, ID);
            });
            ConfirmCommand = new RelayCommand<ContentControl>(p => {
                if (string.IsNullOrEmpty(ID_CARD.ToString()) || string.IsNullOrEmpty(NAME) || string.IsNullOrEmpty(DEPT_NAME) || string.IsNullOrEmpty(ROLE_NAME) || BASIC_WAGE == 0 || OVERTIME_SALARY == 0 || COEFFICIENT == 0)
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
                    IMAGE = IMAGESOURCE,
                };

                db.EMPLOYEEs.Add(employee);
                RandomGenerator generator = new RandomGenerator();
                var user = new USER()
                {

                    EMPLOYEE_ID = employee.EMPLOYEE_ID,
                    ID_USER = employee.EMPLOYEE_ID,
                    USERNAME = USERNAME,
                    PASSWORD = CreateMD5(Base64Encode(PASSWORD))
                };
                db.USERs.Add(user);
                var delete = new DELETE()
                {
                    EMPLOYEE_ID = employee.EMPLOYEE_ID,
                    ID_DELETE = employee.EMPLOYEE_ID,
                    ISDELETED = false,
                };
                var salary = new SALARY()
                {
                    EMPLOYEE_ID = employee.EMPLOYEE_ID,
                    BASIC_WAGE = BASIC_WAGE,
                    OVERTIME_SALARY = OVERTIME_SALARY,
                    COEFFICIENT = COEFFICIENT,
                    BONUS = 0,
                    WELFARE = 0,
                    TAX = 0,
                    SOCIAL_INSURANCE = 0,
                    HEALTH_INSURANCE = 0,
                    MONTH = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                    DATE_START = DateTime.Now,
                    DATE_END = new DateTime(DateTime.Now.Year,DateTime.Now.Month + 1,1),
                    NOTE = NOTE
                };
                var Employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == ID).SingleOrDefault();
                var record = new RECORD()
                {
                    EMPLOYEE_ID = ID,
                    DEPT_ID = Employee.DEPT_ID,
                    EMPLOYEE_CHANGE_ID = employee.EMPLOYEE_ID,
                    EMPLOYEE_CHANGE_NAME = employee.NAME,
                    CHANGE = "Added Name = " + NAME,
                    DATE_CHANGE = DateTime.Now,
                    MONTH_CHANGE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                };
                var timekeeping = new TIMEKEEPING()
                {
                    TIMEKEEPING_ID = DateTime.Now.Month + DateTime.Now.Year + ID,
                    DATE_START = DateTime.Now,
                    MONTH = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                    DATE_END = new DateTime(DateTime.Now.Year, DateTime.Now.Month, GetDaybyMonth(DateTime.Now.Month, DateTime.Now.Year)),
                    EMPLOYEE_ID = ID,
                    NUMBER_OF_ABSENT_DAY = ReportViewModel.CalculateAverageDay(DateTime.Now.Month, DateTime.Now.Year),
                    NUMBER_OF_OVERTIME_DAY = 0,
                    NUMBER_OF_WORK_DAY = 0,
                    NUMBER_OF_STANDARD_DAY = ReportViewModel.CalculateAverageDay(DateTime.Now.Month, DateTime.Now.Year)
                };
            db.TIMEKEEPINGs.Add(timekeeping);
            DateTime date = DateTime.Now;
                for (int i = date.Day; i <= GetDaybyMonth(DateTime.Now.Month, DateTime.Now.Year); i++)
                {
                    if (ReportViewModel.IsHoliday(date.Day, date.Month, date.Year) == false)
                    {
                        if (date.DayOfWeek == DayOfWeek.Saturday)
                        {
                            TIMEKEEPING_DETAIL timedetail = new TIMEKEEPING_DETAIL();
                            timedetail.EMPLOYEE_ID = ID;
                            timedetail.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                            timedetail.CHECK_DATE = date;
                            timedetail.SESSION = 1;
                            timedetail.TIMEKEEPING_DETAIL_TYPE = 0;
                            db.TIMEKEEPING_DETAIL.Add(timedetail);
                        }
                        else
                        {
                            TIMEKEEPING_DETAIL timedetail1 = new TIMEKEEPING_DETAIL();
                            timedetail1.EMPLOYEE_ID = ID;
                            timedetail1.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                            timedetail1.CHECK_DATE = date;
                            timedetail1.SESSION = 1;
                            timedetail1.TIMEKEEPING_DETAIL_TYPE = 0;
                            db.TIMEKEEPING_DETAIL.Add(timedetail1);

                            TIMEKEEPING_DETAIL timedetail2 = new TIMEKEEPING_DETAIL();
                            timedetail2.EMPLOYEE_ID = ID;
                            timedetail2.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                            timedetail2.CHECK_DATE = date;
                            timedetail2.SESSION = 2;
                            timedetail2.TIMEKEEPING_DETAIL_TYPE = 0;
                            db.TIMEKEEPING_DETAIL.Add(timedetail2);
                        }
                    }
                    date = date.AddDays(1);
                }

                
                db.RECORDs.Add(record);
                db.SALARies.Add(salary);
                db.DELETEs.Add(delete);
                db.SaveChanges();
                MessageBox.Show("Added successfully!");
                p.Content = new uConListEmployee(ID);
            });
            BackCommand = new RelayCommand<ContentControl>(p => { return true; }, p => { p.Content = new uConListEmployee(ID); });
            AddImageCommand = new RelayCommand<object>(p => IsAddImageData(), p => AddImageData());
            ViewUser = new RelayCommand<object>(p => { return true; }, p => { MessageBox.Show("Username: " + USERNAME + "\nPassword: " + PASSWORD); });
            {
                if (DEPT_NAME == "DIRECTOR")
                {
                    ListRole = new ObservableCollection<string>();
                    ListRole.Add("DIRECTOR");
                    ListRole.Add("VICE DIRECTOR");
                }
                else
                {
                    ListRole = new ObservableCollection<string>();
                    ListRole.Add("MANAGER");
                    ListRole.Add("VICE MANAGER");
                    ListRole.Add("EMPLOYEE");
                }

            } ;
            Next = new RelayCommand<TabControl>(p => { return true; }, p => { p.SelectedItem = 1; });
            
        }
        public ListEmployeeViewModel(EmployeeInformation selected,int ID)
        {
            SELECTED_ITEM = selected;
            hrmsEntities db = new hrmsEntities();
            PASSWORD = selected.PASSWORD;
            string dept = DEPT_NAME;
            SaveCommand = new RelayCommand<ContentControl>(p => { return true; }, p =>
            {
                EditData(selected,ID);
                MessageBox.Show("Saved successfully");
                p.Content = new uConListEmployee(ID);
            });
            BackCommand = new RelayCommand<ContentControl>(p => { return true; }, p => { p.Content = new uConListEmployee(ID); });
            RemoveCommand = new RelayCommand<ContentControl>(p => { if (string.IsNullOrEmpty(NOTE_REMOVE)) { return false; } return true; }, p =>
            {
                DeleteData(selected,ID);
                MessageBox.Show("Removed successfully");
                p.Content = new uConListEmployee(ID);
            });
            AddImageCommand = new RelayCommand<object>(p => IsAddImageData(), p => AddImageData());
            ViewUser = new RelayCommand<object>(p => { return true; }, p => { MessageBox.Show("Username: " + USERNAME + "\nPassword: " + PASSWORD + "\nDEPT_NAME: "+ DEPT_NAME); });
            ChangePasswordCommand = new RelayCommand<ContentControl>(p => { return true; }, p =>
            {
                var User = db.USERs.Where(x => x.EMPLOYEE_ID == selected.EMPLOYEE_ID).SingleOrDefault();
                User.PASSWORD = CreateMD5(Base64Encode(PASSWORD));
                db.SaveChanges();
                p.Content = new uConListEmployee(ID);
            });
        }

        private void EditData(EmployeeInformation e, int ID)
        {
            hrmsEntities db = new hrmsEntities();
            var Employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == e.EMPLOYEE_ID).SingleOrDefault();
            Employee.NAME = NAME;
            Employee.ID_CARD = ID_CARD;
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
            Employee.IMAGE = IMAGESOURCE;

            String change = "";
            int countchange = 0;
            if (NAME != e.NAME)
            {
                change = change + string.Format("NAME ({0} -> {1})   ", e.NAME, NAME);
                countchange++;
            }
            if (ID_CARD != e.ID_CARD)
            {
                change = change + String.Format(" CARD ID ({0} -> {1})   ", e.ID_CARD, ID_CARD);
            }
            if (BIRTH_DATE != e.BIRTH_DATE)
            {
                change = change + string.Format("AGE ({0} -> {1})   ,BIRTHDATE ({2} -> {3})   ", DateTime.Now.Year - e.BIRTH_DATE.Year, DateTime.Now.Year - BIRTH_DATE.Year, e.BIRTH_DATE, BIRTH_DATE);
                countchange++;
            }
            if (ACADEMIC_LEVEL != e.ACADEMIC_LEVEL)
            {
                change = change + string.Format("ACADEMIC LEVEL ({0} -> {1})   ", e.ACADEMIC_LEVEL, ACADEMIC_LEVEL);
                countchange++;
            }
            if (GENDER != e.GENDER)
            {
                change = change + string.Format("GENDER ({0} -> {1})   ", e.GENDER, GENDER);
                countchange++;
            }
            if (EMAIL != e.EMAIL)
            {
                change = change + string.Format("EMAIL ({0} -> {1})   ", e.EMAIL, EMAIL);
                countchange++;
            }
            if (PHONE != e.PHONE)
            {
                change = change + string.Format("PHONE ({0} -> {1})   ", e.PHONE, PHONE);
                countchange++;
            }
            if (BIRTH_PLACE != e.BIRTH_PLACE)
            {
                change = change + string.Format("BIRTH_PLACE ({0} -> {1})   ", e.BIRTH_PLACE, BIRTH_PLACE);
                countchange++;
            }
            if (CITIZENSHIP != e.CITIZENSHIP)
            {
                change = change + string.Format("CITIZENSHIP ({0} -> {1})   ", e.CITIZENSHIP, CITIZENSHIP);
                countchange++;
            }
            if (ROLE_ID != e.ROLE_ID)
            {
                change = change + string.Format("ROLE ({0} -> {1})   ", e.ROLE_NAME, ROLE_NAME);
                countchange++;
            }
            if (DEPT_ID != e.DEPT_ID)
            {
                change = change + string.Format("DEPARTMENT ({0} -> {1})   ", e.DEPT_NAME, DEPT_NAME);
                countchange++;
            }
            if (countchange != 0)
            {
                var employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == ID).SingleOrDefault();
                RECORD record = new RECORD();
                record.EMPLOYEE_ID = employee.EMPLOYEE_ID;
                record.EMPLOYEE_CHANGE_NAME = NAME;
                record.EMPLOYEE_CHANGE_ID = EMPLOYEE_ID;
                record.DATE_CHANGE = DateTime.Now;
                record.DEPT_ID = employee.DEPT_ID;
                record.CHANGE = change;
                record.MONTH_CHANGE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                db.RECORDs.Add(record);
            }
            
            db.SaveChanges();
        }
        private void DeleteData(EmployeeInformation e, int ID)
        {

            hrmsEntities db = new hrmsEntities();
            var employee = db.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == ID).SingleOrDefault();
            var Employee = db.DELETEs.Where(x => x.EMPLOYEE_ID == e.EMPLOYEE_ID).SingleOrDefault();
            Employee.ISDELETED = true;
            Employee.MONTH = DateTime.Now;
            Employee.NOTE = NOTE_REMOVE;
            var record = new RECORD()
            {
                EMPLOYEE_ID = ID,
                DEPT_ID = employee.DEPT_ID,
                EMPLOYEE_CHANGE_ID = Employee.EMPLOYEE_ID,
                EMPLOYEE_CHANGE_NAME = NAME,
                CHANGE = " Removed ID = " + Employee.EMPLOYEE_ID + ", Name = " + NAME + ", Reason: " + NOTE_REMOVE,
                DATE_CHANGE = DateTime.Now,
                MONTH_CHANGE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };
            db.RECORDs.Add(record);
            db.SaveChanges();
        }
        private void setID()
        {
            switch (ROLE_NAME)
            {
                case "MANAGER":
                    ROLE_ID = 1;
                    break;
                case "VICE MANAGER":
                    ROLE_ID = 2;
                    break;
                case "EMPLOYEE":
                    ROLE_ID = 3;
                    break;
                case "DIRECTOR":
                    ROLE_ID = 4;
                    break;
                case "VICE DIRECTOR":
                    ROLE_ID = 5;
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

            hrmsEntities DB = new hrmsEntities();
            var list = (from emp in DB.EMPLOYEEs
                        join sl in DB.SALARies on emp.EMPLOYEE_ID equals sl.EMPLOYEE_ID
                        join del in DB.DELETEs on sl.EMPLOYEE_ID equals del.EMPLOYEE_ID
                        where del.ISDELETED == false
                        && sl.MONTH.Value.Month == DateTime.Now.Month
                        && sl.MONTH.Value.Year == DateTime.Now.Year
                        select new
                        {
                            id = emp.EMPLOYEE_ID,
                            EMPLOYEE = emp,
                            SALARY = sl,
                            DELETE = del
                        }).Distinct();
            employees = new ObservableCollection<EmployeeInformation>();
            testemployees = new ObservableCollection<EmployeeInformation>();
            foreach (var item in list)
            {
                EmployeeInformation employeeInformation = new EmployeeInformation();
                employeeInformation.EMPLOYEE_ID = item.EMPLOYEE.EMPLOYEE_ID;
                employeeInformation.ID_CARD = (int)item.EMPLOYEE.ID_CARD;
                employeeInformation.NAME = item.EMPLOYEE.NAME;
                employeeInformation.DEPT_NAME = item.EMPLOYEE.DEPARTMENT.DEPT_NAME;
                employeeInformation.GENDER = item.EMPLOYEE.GENDER;
                employeeInformation.CITIZENSHIP = item.EMPLOYEE.CITIZENSHIP;
                employeeInformation.ROLE_NAME = item.EMPLOYEE.ROLE.ROLE_NAME;
                employeeInformation.BASIC_WAGE = (long)item.SALARY.BASIC_WAGE;
                employeeInformation.OVERTIME_SALARY = (long)item.SALARY.OVERTIME_SALARY;
                employeeInformation.COEFFICIENT = (double)item.SALARY.COEFFICIENT;
                employeeInformation.BIRTH_DATE = (DateTime)item.EMPLOYEE.BIRTH_DATE;
                employeeInformation.PHONE = item.EMPLOYEE.PHONE;
                employeeInformation.EMAIL = item.EMPLOYEE.EMAIL;
                employeeInformation.ACADEMIC_LEVEL = item.EMPLOYEE.ACADEMIC_LEVEL;
                employeeInformation.BIRTH_PLACE = item.EMPLOYEE.BIRTH_PLACE;
                employees.Add(employeeInformation);
                testemployees.Add(employeeInformation);
            }
        }
        private void LoadComboboxTypeList()
        {
            ListType = new ObservableCollection<ComboboxModel>();
            ListType.Add(new ComboboxModel("ID", true));
            ListType.Add(new ComboboxModel("NAME", false));
            ListType.Add(new ComboboxModel("DEPARTMENT", false));
            ListType.Add(new ComboboxModel("ROLE", false));
            SELECTEDTYPE = ListType.Where(x => x.ISSELECTED == true).FirstOrDefault();
        }


        //Điều kiện add ảnh
        private bool IsAddImageData()
        {
            if (IMAGESOURCE == null)
                return true;
            return false;
        }

        //Command add ảnh
        private void AddImageData()
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png", ValidateNames = true, Multiselect = false };

            if (ofd.ShowDialog() == true)
            {
                string FILENAME = ofd.FileName;
                BitmapImage image = new BitmapImage(new Uri(FILENAME));
                IMAGESOURCE = File.ReadAllBytes(FILENAME);
                IMAGE_SOURCE = image;
                BUTTONTHICKNESS = 0;
                BRUSH = Brushes.Transparent;
            }
        }

        public static BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public static string Base64Encode(string plainText)
        {
            if (plainText != String.Empty)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            return String.Empty;
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        //Lấy ngày trong tháng
        public static int GetDaybyMonth(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) ? 29 : 28;
            }
        }

        // Tạo bảng timekeeping hằng ngày

        public static void CreateAttendanceDays()
        {
            hrmsEntities db = new hrmsEntities();
            var list = (from emp in db.EMPLOYEEs join
                        del in db.DELETEs on emp.EMPLOYEE_ID equals del.EMPLOYEE_ID
                        where del.ISDELETED == false
                        select new { id = emp.EMPLOYEE_ID}).Distinct();
            
            foreach (var item in list)
            {
                TIMEKEEPING temp = db.TIMEKEEPINGs.Where(x => x.EMPLOYEE_ID == item.id && x.MONTH.Value.Month == DateTime.Now.Month && x.MONTH.Value.Year == DateTime.Now.Year).FirstOrDefault();
                if (temp == null)
                {
                    DateTime date = DateTime.Now;

                    var timekeeping = new TIMEKEEPING()
                    {
                        TIMEKEEPING_ID = DateTime.Now.Month + DateTime.Now.Year + item.id,
                        DATE_START = DateTime.Now,
                        MONTH = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                        DATE_END = new DateTime(DateTime.Now.Year, DateTime.Now.Month, GetDaybyMonth(DateTime.Now.Month, DateTime.Now.Year)),
                        EMPLOYEE_ID = item.id,
                        NUMBER_OF_ABSENT_DAY = ReportViewModel.CalculateAverageDay(DateTime.Now.Month, DateTime.Now.Year),
                        NUMBER_OF_OVERTIME_DAY = 0,
                        NUMBER_OF_WORK_DAY = 0,
                        NUMBER_OF_STANDARD_DAY = ReportViewModel.CalculateAverageDay(DateTime.Now.Month, DateTime.Now.Year)
                    };
                    
                    db.TIMEKEEPINGs.Add(timekeeping);
                    for (int i = date.Day; i <= GetDaybyMonth(DateTime.Now.Month, DateTime.Now.Year); i++)
                    {
                        if (ReportViewModel.IsHoliday(date.Day, date.Month, date.Year) == false)
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday)
                            {
                                TIMEKEEPING_DETAIL timedetail = new TIMEKEEPING_DETAIL();
                                timedetail.EMPLOYEE_ID = item.id;
                                timedetail.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                                timedetail.CHECK_DATE = date;
                                timedetail.SESSION = 1;
                                timedetail.TIMEKEEPING_DETAIL_TYPE = 0;
                                db.TIMEKEEPING_DETAIL.Add(timedetail);
                            }
                            else
                            {
                                TIMEKEEPING_DETAIL timedetail1 = new TIMEKEEPING_DETAIL();
                                timedetail1.EMPLOYEE_ID = item.id;
                                timedetail1.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                                timedetail1.CHECK_DATE = date;
                                timedetail1.SESSION = 1;
                                timedetail1.TIMEKEEPING_DETAIL_TYPE = 0;
                                db.TIMEKEEPING_DETAIL.Add(timedetail1);

                                TIMEKEEPING_DETAIL timedetail2 = new TIMEKEEPING_DETAIL();
                                timedetail2.EMPLOYEE_ID = item.id;
                                timedetail2.TIMEKEEPING_ID = timekeeping.TIMEKEEPING_ID;
                                timedetail2.CHECK_DATE = date;
                                timedetail2.SESSION = 2;
                                timedetail2.TIMEKEEPING_DETAIL_TYPE = 0;
                                db.TIMEKEEPING_DETAIL.Add(timedetail2);
                            }
                        }
                        date = date.AddDays(1);
                    }
                    
                }
            }
            db.SaveChanges();

        }

    }
}
