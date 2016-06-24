using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private PatientList patientList;
        private BinaryTree organList;
        private int buttonPath;
        private bool modifing;
        private Patient beingModified;

        public Form1()
        {
            patientList = new PatientList();
            organList = new BinaryTree();
            InitializeComponent();
            buttonPath = 1;
            modifing = false;
            beingModified = null;

            //temp till database in
            int i = 1;
            DateTime dateTime;
            Patient patient;
            Node node;
            string path = @"C:\Users\Brian F Cook\Documents\visual studio 2015\Projects\WindowsFormsApplication1\WindowsFormsApplication1\input.txt";
            string[] readIn;
            StreamReader sr;

            using (sr = File.OpenText(path))
            {
                string s = "";
                if ((s = sr.ReadLine()) == null)
                {
                    Console.Write("Input is empty\n");
                    return;
                }

                dateTime = DateTime.Parse(s);
                s = sr.ReadLine();
                readIn = s.Split(' ');
                patient = new Patient(i, readIn[0], readIn[1], readIn[2], readIn[3], dateTime);
                node = new Node(patient.Organ);

                organList = new BinaryTree(node);
                patientList = new PatientList(patient);
                i++;

                while ((s = sr.ReadLine()) != null)
                {
                    //Console.Write(i + " ");

                    dateTime = DateTime.Parse(s);
                    //Console.Write(i + " ");
                    s = sr.ReadLine();
                    //Console.Write(i + " ");
                    readIn = s.Split(' ');
                    //Console.Write(i + "a");
                    //Console.WriteLine(readIn[0] + " " + readIn[1] + " " + readIn[2] + " " + readIn[3]);
                    //Console.Write(i + "b");
                    patient = new Patient(i, readIn[0], readIn[1],readIn[2], readIn[3], dateTime);
                    //Console.Write(i + " ");
                    node = new Node(patient.Organ);
                    //Console.Write(i + " ");
                    organList.addNode(node);
                    //Console.Write(i + " ");
                    patientList.addToList(patient);
                    i++;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            switch (buttonPath)
            {
                case 1://Add
                    try
                    {
                        DateTime dateTime = DateTime.Parse(MonthBox.Text + "/" + DayBox.Text + "/" + YearBox.Text + " " + HourBox.Text + ":" + MinuteBox.Text + ":00" + AMPMBox.SelectedText);
                        Patient patient = new Patient(1000, FirstNameBox.Text, LastNameBox.Text, OrganBox.Text, BloodTypeBox.Text, dateTime);
                        Node node = new Node(patient.Organ);

                        organList.addNode(node);
                        patientList.addToList(patient);

                        MonthBox.Text = "MM";
                        DayBox.Text = "DD";
                        YearBox.Text = "YYYY";
                        HourBox.Text = "HH";
                        MinuteBox.Text = "MM";
                        FirstNameBox.Text = "";
                        LastNameBox.Text = "";
                        OrganBox.Text = "";
                        BloodTypeBox.Text = "";

                        PrintBox.Text = dateTime.ToString();
                    }
                    catch (FormatException exc)
                    {
                        PrintBox.Text = "Invalid Input";
                    }
                    break;
                case 2://Retrieve
                    try
                    {
                        Node found;
                        Organ toFind = new Organ(OrganBox.Text, BloodTypeBox.Text);

                        found = organList.searchFor(toFind, 1);

                        OrganBox.Text = "";
                        BloodTypeBox.Text = "";

                        PrintBox.Text = found.getString();
                    }
                    catch (FormatException exc)
                    {
                        PrintBox.Text = "Invalid Input";
                    }
                    break;
                case 3://Modify
                    try
                    {
                        if (!modifing)
                        {
                            Patient p = patientList.findInList(FirstNameBox.Text + " " + LastNameBox.Text);

                            if (p == null)
                            {
                                PrintBox.Text = "Patient not found";
                                FirstNameBox.Text = "";
                                LastNameBox.Text = "";
                                break;
                            }

                            PrintBox.Text = patientList.print() + "\n";

                            FirstNameBox.Text = p.FirstName;
                            LastNameBox.Text = p.LastName;
                            OrganBox.Text = p.Organ.OrganName;
                            BloodTypeBox.Text = p.Organ.BloodType;
                            beingModified = p;

                            ModifyButton.Text = "Cancel?";

                            OrganBox.Enabled = true;
                            BloodTypeBox.Enabled = true;
                            AddButton.Enabled = false;
                            DeleteButton.Enabled = false;
                            SearchNameButton.Enabled = false;
                            SearchOrganButton.Enabled = false;
                            RecieveButton.Enabled = false;
                            modifing = true;
                        }
                        else
                        {

                            Node temp = organList.searchFor(beingModified.Organ, 1);

                            Patient patient = new Patient(beingModified.ID, FirstNameBox.Text, LastNameBox.Text, OrganBox.Text, BloodTypeBox.Text, temp.Organ.Date);

                            temp = new Node(patient.Organ);

                            patientList.updatePatient(patient);
                            organList.addNode(temp);

                            beingModified = null;

                            ModifyButton.Text = "Modify";

                            OrganBox.Enabled = false;
                            BloodTypeBox.Enabled = false;
                            AddButton.Enabled = true;
                            DeleteButton.Enabled = true;
                            SearchNameButton.Enabled = true;
                            SearchOrganButton.Enabled = true;
                            RecieveButton.Enabled = true;
                            modifing = false;

                            FirstNameBox.Text = "";
                            LastNameBox.Text = "";
                            OrganBox.Text = "";
                            BloodTypeBox.Text = "";
                        }
                    }
                    catch (FormatException exc)
                    {
                        PrintBox.Text = "Invalid Input";
                    }
                    break;
                case 4://Search Name
                    try
                    {
                        Patient p = patientList.findInList(FirstNameBox.Text + " " + LastNameBox.Text);

                        if(p == null)
                        {
                            PrintBox.Text = "Patient not found";
                        } else
                        {
                            PrintBox.Text = p.getString();
                        }

                        FirstNameBox.Text = "";
                        LastNameBox.Text = "";
                    }
                    catch (FormatException exc)
                    {
                        PrintBox.Text = "Invalid Input";
                    }
                    break;
                case 5://Search Organ
                    try
                    {
                        Node found;
                        Organ toFind = new Organ(OrganBox.Text, BloodTypeBox.Text);

                        found = organList.searchFor(toFind, 0);

                        OrganBox.Text = "";
                        BloodTypeBox.Text = "";

                        PrintBox.Text = found.getString();
                    }
                    catch (FormatException exc)
                    {
                        PrintBox.Text = "Invalid Input";
                    }
                    break;
                case 6://Delete
                    try
                    {
                        //not perfect, currently deletes first person of certain name

                        Patient p = patientList.findInList(FirstNameBox.Text + " " + LastNameBox.Text);

                        if (p == null)
                        {
                            PrintBox.Text = "Patient not found";
                            FirstNameBox.Text = "";
                            LastNameBox.Text = "";
                            break;
                        }

                        Node node = new Node(p.Organ);
                        organList.searchFor(node, 1);
                        patientList.delete(p);

                        FirstNameBox.Text = "";
                        LastNameBox.Text = "";

                        PrintBox.Text = "Deleted";
                    }
                    catch (FormatException exc)
                    {
                        PrintBox.Text = "Invalid Input";
                    }
                    break;
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            buttonPath = 1;

            MonthBox.Enabled = true;
            DayBox.Enabled = true;
            YearBox.Enabled = true;
            HourBox.Enabled = true;
            MinuteBox.Enabled = true;
            AMPMBox.Enabled = true;
            FirstNameBox.Enabled = true;
            LastNameBox.Enabled = true;
            OrganBox.Enabled = true;
            BloodTypeBox.Enabled = true;
        }

        private void RecieveButton_Click(object sender, EventArgs e)
        {
            buttonPath = 2;

            MonthBox.Enabled = false;
            DayBox.Enabled = false;
            YearBox.Enabled = false;
            HourBox.Enabled = false;
            MinuteBox.Enabled = false;
            AMPMBox.Enabled = false;
            FirstNameBox.Enabled = false;
            LastNameBox.Enabled = false;
            OrganBox.Enabled = true;
            BloodTypeBox.Enabled = true;
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            buttonPath = 3;

            if (!modifing)
            {
                MonthBox.Enabled = false;
                DayBox.Enabled = false;
                YearBox.Enabled = false;
                HourBox.Enabled = false;
                MinuteBox.Enabled = false;
                AMPMBox.Enabled = false;
                FirstNameBox.Enabled = true;
                LastNameBox.Enabled = true;
                OrganBox.Enabled = false;
                BloodTypeBox.Enabled = false;
            }
            else
            {
                beingModified = null;

                ModifyButton.Text = "Modify";

                OrganBox.Enabled = false;
                BloodTypeBox.Enabled = false;
                AddButton.Enabled = true;
                DeleteButton.Enabled = true;
                SearchNameButton.Enabled = true;
                SearchOrganButton.Enabled = true;
                RecieveButton.Enabled = true;
                modifing = false;
            }
        }

        private void SearchNameButton_Click(object sender, EventArgs e)
        {
            buttonPath = 4;

            MonthBox.Enabled = false;
            DayBox.Enabled = false;
            YearBox.Enabled = false;
            HourBox.Enabled = false;
            MinuteBox.Enabled = false;
            AMPMBox.Enabled = false;
            FirstNameBox.Enabled = true;
            LastNameBox.Enabled = true;
            OrganBox.Enabled = false;
            BloodTypeBox.Enabled = false;
        }

        private void SearchOrganButton_Click(object sender, EventArgs e)
        {
            buttonPath = 5;

            MonthBox.Enabled = false;
            DayBox.Enabled = false;
            YearBox.Enabled = false;
            HourBox.Enabled = false;
            MinuteBox.Enabled = false;
            AMPMBox.Enabled = false;
            FirstNameBox.Enabled = false;
            LastNameBox.Enabled = false;
            OrganBox.Enabled = true;
            BloodTypeBox.Enabled = true;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintBox.Text = organList.print();
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            buttonPath = 6;

            MonthBox.Enabled = false;
            DayBox.Enabled = false;
            YearBox.Enabled = false;
            HourBox.Enabled = false;
            MinuteBox.Enabled = false;
            AMPMBox.Enabled = false;
            FirstNameBox.Enabled = true;
            LastNameBox.Enabled = true;
            OrganBox.Enabled = false;
            BloodTypeBox.Enabled = false;
        }

        private void MonthBox_Click(object sender, EventArgs e)
        {
            MonthBox.Text = "";
        }

        private void DayBox_Click(object sender, EventArgs e)
        {
            DayBox.Text = "";
        }

        private void YearBox_Click(object sender, EventArgs e)
        {
            YearBox.Text = "";
        }

        private void HourBox_Click(object sender, EventArgs e)
        {
            HourBox.Text = "";
        }

        private void MinuteBox_Click(object sender, EventArgs e)
        {
            MinuteBox.Text = "";
        }
    }
}
