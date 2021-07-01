using HRMS.HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.HR.Model
{
    public class SideBarDatabase : BaseViewModel
    {
        private string _ICONKIND;
        public string ICONKIND { get => _ICONKIND; set { _ICONKIND = value; OnPropertyChanged(); } }

        private string _TEXTBLOCKNAME;
        public string TEXTBLOCKNAME { get => _TEXTBLOCKNAME; set { _TEXTBLOCKNAME = value; OnPropertyChanged(); } }

        public SideBarDatabase(string iconKind, string name)
        {
            this.ICONKIND = iconKind;
            this.TEXTBLOCKNAME = name;
        }
    }
}
