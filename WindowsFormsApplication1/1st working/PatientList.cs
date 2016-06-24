using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PatientList
    {
        private Patient[] _patients;
        private int _size;

        public PatientList()
        {
            _patients = new Patient[1000000];
            _size = 0;
        }

        public PatientList(Patient p)
        {
            _patients = new Patient[1000000];
            _patients[0] = p;
            _size = 1;
        }

        public void addToList(Patient p)
        {

            int i = _size;
            _patients[i] = p;
            _size++;

            while (i > 0)
            {
                if (_patients[i] != null)
                {
                    if (_patients[i].ID < _patients[i - 1].ID)
                    {
                        Swap(i - 1, i);
                    }
                }
                i--;
            }
        }

        /*public void Sort(int lo, int hi){
            int i = hi - 1;
            while(lo < hi){
                _patients[i];
            }
        }*/

        private void Swap(int i, int j)
        {
            Patient n = _patients[i];
            _patients[i] = _patients[j];
            _patients[j] = n;
        }

        public void updatePatient(Patient p)
        {
            int i = findInList(p.ID);
            _patients[i].FirstName = p.FirstName;
            _patients[i].LastName = p.LastName;
            _patients[i].Organ = p.Organ;
        }

        public int findInList(int id)
        {
            return findInList(id, 0, _size);
        }

        public int findInList(int id,int l, int h)
        {
            if(l > h) { return -1; }

            int m = (l + h) / 2;

            if (_patients[m].ID == id)
            {
                return m;
            }
            else if (id < _patients[m].ID)
            {
                return findInList(id, l, m-1);
            }
            else
            {
                return findInList(id, m+1, h);
            }
        }

        public Patient findInList(string s)
        {
            int i = _size;
            Patient p = null;

            for (i = 0; i < _size; i++)
            {
                if(_patients[i].Compare(s) == 0)
                {
                    p = _patients[i];
                }
            }

            return p;
        }

        public void delete(Patient p)
        {
            int i = findInList(p.ID);

            while(i < _size)
            {
                Swap(i, i + 1);
                i++;
            }

            _patients[i - 1] = null;
            _size--;
        }

        public string print()
        {
            int i;
            string s = "";
            for (i = 0; i < _size; i++)
            {
                s = s + _patients[i].getString() + "\n";
            }

            return s;
        }

    }
}
