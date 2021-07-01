using HRMS.HR.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HRMS.HR.ViewModel
{
    public class InformationViewModel : BaseViewModel
    {
        #region Data Binding
        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }

        private int _ID;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }

        private int _ID_CARD;
        public int ID_CARD { get => _ID_CARD; set { _ID_CARD = value; OnPropertyChanged(); } }

        private DateTime _BIRTHDATE;
        public DateTime BIRTHDATE { get => _BIRTHDATE; set { _BIRTHDATE = value; OnPropertyChanged(); } }

        private string _DEPARTMENT;
        public string DEPARTMENT { get => _DEPARTMENT; set { _DEPARTMENT = value; OnPropertyChanged(); } }

        private string _ROLE;
        public string ROLE { get => _ROLE; set { _ROLE = value; OnPropertyChanged(); } }

        private string _CITIZENSHIP;
        public string CITIZENSHIP { get => _CITIZENSHIP; set { _CITIZENSHIP = value; OnPropertyChanged(); } }

        private string _BIRTHPLACE;
        public string BIRTHPLACE { get => _BIRTHPLACE; set { _BIRTHPLACE = value; OnPropertyChanged(); } }

        private string _GENDER;
        public string GENDER { get => _GENDER; set { _GENDER = value; OnPropertyChanged(); } }

        private string _ACADEMIC_LEVEL;
        public string ACADEMIC_LEVEL { get => _ACADEMIC_LEVEL; set { _ACADEMIC_LEVEL = value; OnPropertyChanged(); } }

        private string _PHONE;
        public string PHONE { get => _PHONE; set { _PHONE = value; OnPropertyChanged(); } }

        private string _EMAIL;
        public string EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }

        private byte[] _IMAGE;
        public byte[] IMAGE { get => _IMAGE; set { _IMAGE = value; OnPropertyChanged(); } }

        private BitmapImage _IMAGE_SOURCE;
        public BitmapImage IMAGE_SOURCE { get => IMAGE_SOURCE1; set { IMAGE_SOURCE1 = value; OnPropertyChanged(); } }

        private Brush _BRUSH;
        public Brush BRUSH { get => _BRUSH; set { _BRUSH = value; OnPropertyChanged(); } }

        private int _BUTTONTHICKNESS;
        public int BUTTONTHICKNESS { get => _BUTTONTHICKNESS; set { _BUTTONTHICKNESS = value; OnPropertyChanged(); } }

        public BitmapImage IMAGE_SOURCE1 { get => _IMAGE_SOURCE; set => _IMAGE_SOURCE = value; }

        #endregion
        public InformationViewModel(int EMPLOYEE_ID)
        {
            ID = EMPLOYEE_ID;
            LoadData(ID);
        }

        //public InformationViewModel()
        //{
        //    LoadData(2);
        //}

        void LoadData(int employee_id)
        {
            var emp = HRMSEntities.Ins.DB.EMPLOYEEs.Where(x => x.EMPLOYEE_ID == employee_id).SingleOrDefault();
            ID = employee_id;
            ID_CARD = (int)emp.ID_CARD;
            NAME = emp.NAME;
            DEPARTMENT = emp.DEPARTMENT.DEPT_NAME;
            ROLE = emp.ROLE.ROLE_NAME;
            CITIZENSHIP = emp.CITIZENSHIP;
            BIRTHDATE = (DateTime)emp.BIRTH_DATE;
            BIRTHPLACE = emp.BIRTH_PLACE;
            GENDER = emp.GENDER;
            ACADEMIC_LEVEL = emp.ACADEMIC_LEVEL;
            PHONE = emp.PHONE;
            EMAIL = emp.EMAIL;

            if (emp.IMAGE == null)
            {
                BUTTONTHICKNESS = 1;
                IMAGE_SOURCE = null;
                BRUSH = Brushes.AliceBlue;
            }
            else
            {
                BUTTONTHICKNESS = 0;
                IMAGE_SOURCE = ListEmployeeViewModel.ToImage(emp.IMAGE);
                BRUSH = Brushes.Transparent;
            }
        }
    }
}
