using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Model
{
    public class HRMSDatabase
    {
        private  static hrmsEntities _ins;
        public static hrmsEntities Ins
        {
            get
            {
                _ins = new hrmsEntities();
                return _ins;
            }
        }

    }
}
