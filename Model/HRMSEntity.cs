using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HRMSEntity
    {
        private static HRMSEntity ins;

        public static HRMSEntity Ins
        {
            get
            {
                if(ins == null)
                {
                    ins = new HRMSEntity();
                }

                return ins;
            }
            set
            {
                ins = value;
            }
        }

        public hrmsEntities DB { get; set; }

        private HRMSEntity()
        {
            DB = new hrmsEntities();
        }
    }
}
