using HRMS.Accouting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Accouting.Model
{
    public class HRMSEntities : BaseViewModel
    {
        private static HRMSEntities ins;

        public static HRMSEntities Ins { get { ins = new HRMSEntities(); return ins; }  set { ins = value;} }

        public hrmsEntities DB { get; set; }

        private HRMSEntities()
        {
            DB = new hrmsEntities();
        }
    }
}
