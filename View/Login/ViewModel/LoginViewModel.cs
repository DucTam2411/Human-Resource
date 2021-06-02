using HRMS.Employee.uCon;
using HRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public string Pasword
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

        public LoginViewModel()
        {
            CloseCommand = new RelayCommand<Window>(p => p != null, p => p.Close());

            LoginCommand = new RelayCommand<Window>(null,

                p =>
                {
                    MessageBox.Show("S");
                    EmployeeWindow a = new EmployeeWindow();
                    p.Close();
                    a.ShowDialog();
                }
                );
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
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
