using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Model
{
    public class HRMSDatabase
    {
        private  static hrmsEntities1 _ins;
        public static hrmsEntities1 Ins
        {
            get
            {
                _ins = new hrmsEntities1();
                return _ins;
            }
        }

    }
}
