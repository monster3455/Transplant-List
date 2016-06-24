using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Node
    {
        private Organ _organ;
        private int _leftHeight;
        private int _rightHeight;
        public Node _leftLeaf;
        public Node _rightLeaf;

        public Node(Organ p)
        {
            _organ = p;
            _leftHeight = 0;
            _rightHeight = 0;
            _leftLeaf = null;
            _rightLeaf = null;
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

        public int LeftHeight
        {
            get
            {
                return _leftHeight;
            }
            set
            {
                _leftHeight = value;
            }
        }

        public int RightHeight
        {
            get
            {
                return _rightHeight;
            }
            set
            {
                _rightHeight = value;
            }
        }

        public Node LeftLeaf
        {
            get
            {
                return _leftLeaf;
            }
            set
            {
                _leftLeaf = value;
            }
        }

        public Node RightLeaf
        {
            get
            {
                return _rightLeaf;
            }
            set
            {
                _rightLeaf = value;
            }
        }

        public bool isLeaf()
        {
            return (_leftLeaf == null && _rightLeaf == null);
        }

        public bool isLeaf(Node n)
        {
            return (n._leftLeaf == null && n._rightLeaf == null);
        }

        public int Compare(Node n)
        {
            int i;
            if ((i = _organ.Compare(n._organ)) != 0)
            {
                return i;
            }
            else if ((i = _organ.Date.CompareTo(n._organ.Date)) != 0)
            {
                return i;
            }
            return 0;
        }

        public string getString()
        {                                                       //testing for tree trimming
            return _organ.Date.ToString() + "\n" + _organ.getString()/* + " " + _leftHeight + " " + _rightHeight*/;
        }
    }
}
