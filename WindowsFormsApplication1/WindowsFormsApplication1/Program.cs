using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        //private static PatientList patientList;
        //private static BinaryTree organList;
        static void Main()
        {
            //patientList = new PatientList();
            //organList = new BinaryTree();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /*public static void addToTree()
        {
            patientList 
        }*/

    }
}
