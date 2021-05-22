using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SalaryData : BaseView
    {
        //public int Id { get; set; }
        //public String Name { get; set; }
        //public String Dept_Name { get; set; }
        //public String Role_Name { get; set; }
        //public DateTime Date_Start { get; set; }
        //public DateTime Date_End { get; set; }
        //public Double Salary { get; set; }
        //public int NumOfWork { get; set; }
        public int ID { get; set; }
        public EMPLOYEE EMPLOYEE { get; set; }
        public TIMEKEEPING TIMEKEEPING { get; set; }
        public SALARY SALARY { get; set; }

    }
}
