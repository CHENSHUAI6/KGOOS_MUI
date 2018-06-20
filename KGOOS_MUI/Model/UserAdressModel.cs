using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGOOS_MUI.Model
{
    public class UserAdressModel
    {
        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Adress;
        public string Adress
        {
            get { return _Adress; }
            set { _Adress = value; }
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

    }
}
