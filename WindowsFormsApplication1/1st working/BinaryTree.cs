using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class BinaryTree
    {
        private Node _root;

        public BinaryTree()
        {
            _root = null;
        }


        public BinaryTree(Node r)
        {
            _root = r;
        }

        public Node Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
            }
        }

        public int addNode(Node n)
        {
            return addNode(n,_root,null);
        }

        //n is the node that is being added
        public int addNode(Node n, Node temp, Node parent)
        {
            int height = 1;
            if (_root == null)
            {
                _root = n;
                return 0;
            }
            //Console.WriteLine("L");

            if (temp.Compare(n) > 0)
            {
                if (temp.LeftLeaf == null)
                {
                    temp.LeftLeaf = n;
                    temp.LeftHeight = height;
                }
                else {
                    height = addNode(n, temp.LeftLeaf, temp) + 1;
                    //Console.WriteLine(height);
                    if (temp.LeftHeight < height)
                        temp.LeftHeight = height;
                }
            }
            else {
                if (temp.RightLeaf == null)
                {
                    temp.RightLeaf = n;
                    temp.RightHeight = height;
                }
                else {
                    height = addNode(n, temp.RightLeaf, temp) + 1;
                    if (temp.RightHeight < height)
                        temp.RightHeight = height;
                }
            }

            if ((temp.LeftHeight - temp.RightHeight) > 1 || (temp.LeftHeight - temp.RightHeight) < -1)
            {
                //Console.WriteLine("Trim" + temp.LeftHeight + " " + temp.RightHeight);
                if (parent == null)
                {
                    _root = Trimming(temp, temp.LeftHeight - temp.RightHeight);
                }
                else {
                    if (temp.Compare(parent.LeftLeaf) == 0)
                    {
                        parent.LeftLeaf = Trimming(temp, temp.LeftHeight - temp.RightHeight);
                        height -= 1;
                    }
                    else if (temp.Compare(parent.RightLeaf) == 0)
                    {
                        parent.RightLeaf = Trimming(temp, temp.LeftHeight - temp.RightHeight);
                        height -= 1;
                    }
                    else {
                        Console.WriteLine("Error in comparison for Trimming");
                    }
                }
            }

            return height;
        }

        //used to keep tree trimmed (all branches relativly same height)
        private Node Trimming(Node n, int i)
        {
            Node temp;
            int height;

            if (i > 1)
            {
                //Console.WriteLine("Left");
                if (n.LeftLeaf.LeftLeaf != null)
                {
                    temp = n.LeftLeaf;

                    n.LeftLeaf = temp.RightLeaf;
                    height = n.LeftHeight;
                    n.LeftHeight = temp.RightHeight;

                    temp.RightLeaf = n;
                    temp.RightHeight = height - 1;
                }
                else {//Exception case, only occurs at bottom branches
                    temp = n.LeftLeaf.RightLeaf;

                    n.LeftLeaf.RightLeaf = null;
                    n.LeftLeaf.RightHeight = 0;

                    temp.LeftLeaf = n.LeftLeaf;
                    temp.LeftHeight = 1;

                    n.LeftLeaf = null;
                    height = n.LeftHeight;
                    n.LeftHeight = 0;

                    temp.RightLeaf = n;
                    temp.RightHeight = height - 1;
                }

            }
            else if (i < -1)
            {
                //Console.WriteLine("Right");
                if (n.RightLeaf.RightLeaf != null)
                {
                    temp = n.RightLeaf;

                    n.RightLeaf = temp.LeftLeaf;
                    height = n.RightHeight;
                    n.RightHeight = temp.LeftHeight;

                    temp.LeftLeaf = n;
                    temp.LeftHeight = height - 1;
                }
                else {//Exception case, only occurs at bottom branches
                    temp = n.RightLeaf.LeftLeaf;

                    n.RightLeaf.LeftLeaf = null;
                    n.RightLeaf.LeftHeight = 0;

                    temp.RightLeaf = n.RightLeaf;
                    temp.RightHeight = 1;

                    n.RightLeaf = null;
                    height = n.RightHeight;
                    n.RightHeight = 0;

                    temp.LeftLeaf = n;
                    temp.LeftHeight = height - 1;
                }

            }
            else {
                //Console.WriteLine("Same");
                return n;
            }

            return temp;
        }

        public Node searchFor(Node o, int d)
        {
            return searchFor(o,d,_root,null);
        }

        public Node searchFor(Node o, int d, Node n, Node p)
        {

            if (n == null)
                return null;
            /*Console.WriteLine();
            Console.WriteLine(n.getString());*/

            int i = n.Compare(o);
            Node temp = null;
            if (i > 0)
            {
                if (d == 1)
                {
                    temp = searchFor(o, d, n.LeftLeaf, n);
                    if (temp != null)
                        n.LeftHeight -= 1;
                    return temp;
                }

                return searchFor(o, d, n.LeftLeaf, n);
            }
            else if (i < 0)
            {
                if (d == 1)
                {
                    temp = searchFor(o, d, n.RightLeaf, n);
                    if (temp != null)
                        n.RightHeight -= 1;
                    return temp;
                }

                return searchFor(o, d, n.RightLeaf, n);
            }
            else
            {
                temp = n;
                if (d == 1)
                {
                    deleteNode(temp, p);
                }
                if (d == 1)
                {
                    n.LeftHeight -= 1;
                }
            }

            return temp;
        }

        public Node searchFor(Organ o, int d)
        {
            return searchFor(o, d, _root, null);
        }

        //o is what is being searched for
        //d is if it to be deleted
        //n is for recursion
        public Node searchFor(Organ o, int d, Node n, Node p)
        {

            if (n == null)
                return null;
            /*Console.WriteLine();
            Console.WriteLine(n.getString());*/

            int i = n.Organ.Compare(o);
            Node temp = null;
            if (i > 0)
            {
                if (d == 1)
                {
                    temp = searchFor(o, d, n.LeftLeaf, n);
                    if (temp != null)
                        n.LeftHeight -= 1;
                    return temp;
                }

                return searchFor(o, d, n.LeftLeaf, n);
            }
            else if (i < 0)
            {
                if (d == 1)
                {
                    temp = searchFor(o, d, n.RightLeaf, n);
                    if (temp != null)
                        n.RightHeight -= 1;
                    return temp;
                }

                return searchFor(o, d, n.RightLeaf, n);
            }
            else {
                if ((temp = searchFor(o, d, n.LeftLeaf, n)) == null)
                {
                    temp = n;
                    if (d == 1)
                    {
                        deleteNode(temp, p);
                    }
                }
                if (d == 1)
                {
                    n.LeftHeight -= 1;
                }
            }

            return temp;
        }

        private void deleteNode(Node n, Node p)
        {
            Node temp, pTemp = n;

            if (n.isLeaf())
            {
                temp = null;
            }
            else if (n.LeftHeight > n.RightHeight)
            {
                temp = pTemp.LeftLeaf;

                while (temp.RightLeaf != null)
                {
                    pTemp = temp;
                    temp.RightHeight = temp.RightHeight - 1;
                    temp = temp.RightLeaf;
                }

                if (pTemp != n)
                {
                    pTemp.RightLeaf = temp.LeftLeaf;
                    pTemp.RightHeight = temp.LeftHeight;
                }

                if (temp != n.LeftLeaf)
                {
                    temp.LeftLeaf = n.LeftLeaf;
                }
                else {
                    temp.LeftLeaf = null;
                }

                temp.LeftHeight = n.LeftHeight - 1;
                temp.RightLeaf = n.RightLeaf;
                temp.RightHeight = n.RightHeight;
            }
            else {
                temp = pTemp.RightLeaf;

                while (temp.LeftLeaf != null)
                {
                    pTemp = temp;
                    temp.LeftHeight = temp.LeftHeight - 1;
                    temp = temp.LeftLeaf;
                }

                if (pTemp != n)
                {
                    pTemp.LeftLeaf = temp.RightLeaf;
                    pTemp.LeftHeight = temp.RightHeight;
                }

                temp.LeftLeaf = n.LeftLeaf;
                temp.LeftHeight = n.LeftHeight;

                if (temp != n.RightLeaf)
                {
                    temp.RightLeaf = n.RightLeaf;
                }
                else {
                    temp.RightLeaf = null;
                }
                temp.RightHeight = n.RightHeight - 1;
            }

            if (p != null)
            {
                if (p.LeftLeaf == n)
                {
                    p.LeftLeaf = temp;
                }
                else if (p.RightLeaf == n)
                {
                    p.RightLeaf = temp;
                }
            }
            else {
                _root = temp;
            }

        }

        public string print()
        {
            string s;

            if (_root != null)
            {
                s = print(_root);
            }
            else {
                s = "Empty";
            }

            return s;
        }

        public string print(Node n)
        {
            string s = "";
            if (n.LeftLeaf != null)
            {
                s = print(n.LeftLeaf);
            }

            s = s + n.getString() + "\n";

            if (n.RightLeaf != null)
            {
                s = s + print(n.RightLeaf);

            }

            return s;
        }
    }
}
