using HRMS.Model;

namespace HRMS.Employee.ViewModel
{
    public class HRMSDatabase
    {
        public static hrmsEntities _Ins;
        public static hrmsEntities Ins
        {
            get
            {
                _Ins = new hrmsEntities();
                return _Ins;
            }
            set
            {
                _Ins = value;
            }
        }
    }
}