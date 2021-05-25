using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ComboboxModel:BaseView
    {
        private bool _ISSELECTED;
        public bool ISSELECTED { get => _ISSELECTED; set { _ISSELECTED = value; OnPropertyChanged(); } }

        private string _NAME;
        public string NAME { get => _NAME; set { _NAME = value; OnPropertyChanged(); } }

        public ComboboxModel(string name, bool isselected)
        {
            this.ISSELECTED = isselected;
            this.NAME = name;
        }
    }
}
