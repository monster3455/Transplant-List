using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Organ
    {
        private int _id;
        private DateTime _date;
        private string _organName;
        private string _bloodType;

        public Organ(string o, string b)
        {
            _id = -1;
            _organName = o;
            _bloodType = b;
        }

        public Organ(int i, DateTime d, string o, string b)
        {
            _id = i;
            _date = d;
            _organName = o;
            _bloodType = b;
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string OrganName
        {
            get
            {
                return _organName;
            }
            set
            {
                _organName = value;
            }
        }

        public string BloodType
        {
            get
            {
                return _bloodType;
            }
            set
            {
                _bloodType = value;
            }
        }

        //both compare methods use CompareOrdinal 
        public int Compare(Organ p)
        {
            return String.CompareOrdinal(_organName + " " + _bloodType, p._organName + " " + p._bloodType);
        }

        public string getString()
        {
            return _organName + " " + _bloodType;
        }
    }
}
