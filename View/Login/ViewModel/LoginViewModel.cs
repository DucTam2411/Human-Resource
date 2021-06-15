using HRMS.Employee.uCon;
using HRMS.Employee.ViewModel;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRMS.Login.ViewModel
{
    class LoginViewModel : BaseViewModel
    {

        private string _Username;
        public  string Username
        {
            get => _Username;
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set
            {
                _Password= value;
                OnPropertyChanged();
            }
        }


        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        
        
        public LoginViewModel()
        {
            CloseCommand = new RelayCommand<Window>(p => p != null, p => p.Close());

            LoginCommand = new RelayCommand<Window>(null,

                p => Login(p));
            PasswordChangedCommand = new RelayCommand<PasswordBox>(null, p => { Password = p.Password; });
        }

  
        public void Login(Window w)
        {

            string str = CreateMD5(Base64Encode(Password));
            USER[] user = (from u in HRMSDatabase.Ins.USERs
                           where u.USERNAME == Username && u.PASSWORD == str
                           select u).ToArray();

            if(user.Length > 0)
            {
                switch (user[0].EMPLOYEE.DEPT_ID.Value)
                {
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        int id = user[0].EMPLOYEE_ID.Value;
                        EmployeeWindow e = new EmployeeWindow(id);
                        w.Close();
                        e.ShowDialog();
                        break;

                    case 1:  // HR
                    case 2: // ACCOUTING
                    case 3: // DIRECTOR
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong password or Username !!!");
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
    }
}
