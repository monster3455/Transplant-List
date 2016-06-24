using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Patient : IComparable
    {
        protected int _id;
        private string _firstName;
        private string _lastName;
        private Organ _organ;

        public Patient(int i, string f, string l, string o, string b, DateTime d)
        {
            _id = i;
            _firstName = f;
            _lastName = l;
            _organ = new Organ(i, d, o, b);
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

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public Organ Organ
        {
            get
            {
                return _organ;
            }
            set
            {
                _organ = value;
            }
        }

        public int Compare(string p)
        {
            return String.CompareOrdinal(_firstName + " " + _lastName, p);
        }

        public int Compare(Patient p)
        {
            return String.CompareOrdinal(_firstName + " " + _lastName, p._firstName + " " + p._lastName);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Patient p = obj as Patient;
            if (p != null)
                return this.ID.CompareTo(p.ID);
            else
                throw new ArgumentException("Object is not a Patient");
        }

        public string getString()
        {
            return _id + ": " + _firstName + " " + _lastName;
        }
    }
}
