using System;
using System.Xml.Serialization;
using System.Data.SqlClient;
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
        private int buttonPath;
        private bool modifing;
        private Patient beingModified;

        public Form1()
        {
            InitializeComponent();
            
            buttonPath = 1;
            modifing = false;
            beingModified = null;
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
                        Patient patient = new Patient(1000, FirstNameBox.Text, LastNameBox.Text);
                        Organ org = new Organ(1000, dateTime, OrganBox.Text, BloodTypeBox.Text);

                        patient.AddData();
                        org.AddData();
                        

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
                        DateTime date = new DateTime();
                        Organ toFind = new Organ(-1,date, OrganBox.Text, BloodTypeBox.Text);
                        toFind.FindData();

                        OrganBox.Text = "";
                        BloodTypeBox.Text = "";

                        PrintBox.Text = toFind.getString();
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
                            Patient p = new Patient(-1,FirstNameBox.Text,LastNameBox.Text);
                            p = p.FindData();

                            if (p == null)
                            {
                                PrintBox.Text = "Patient not found";
                                FirstNameBox.Text = "";
                                LastNameBox.Text = "";
                                break;
                            }

                            Organ o = new Organ(p.ID);
                            o = o.GrabData();

                            PrintPatient();

                            FirstNameBox.Text = p.FirstName;
                            LastNameBox.Text = p.LastName;
                            OrganBox.Text = o.OrganName;
                            BloodTypeBox.Text = o.BloodType;
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
                            Patient patient = new Patient(beingModified.ID, FirstNameBox.Text, LastNameBox.Text);
                            Organ organ = new Organ(beingModified.ID, OrganBox.Text, BloodTypeBox.Text);
                            organ.UpdateData();
                            patient.UpdateData();

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
                        Patient p = new Patient(-1, FirstNameBox.Text, LastNameBox.Text);
                        p = p.FindData();

                        if (p == null)
                        {
                            PrintBox.Text = "Patient not found";
                        } else
                        {
                            Organ toFind = new Organ(p.ID, null,null);
                            toFind = toFind.GrabData();

                            PrintBox.Text = p.getString() + " " + toFind.getString();
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
                        Organ toFind = new Organ(-1,OrganBox.Text, BloodTypeBox.Text);
                        toFind = toFind.FindData();

                        if (toFind == null)
                        {
                            PrintBox.Text = "Organ Patient not found";
                        }
                        else
                        {
                            Patient p = new Patient(toFind.ID, null, null);
                            p = p.GrabData();

                            PrintBox.Text = p.getString() + " " + toFind.getString();
                        }

                        OrganBox.Text = "";
                        BloodTypeBox.Text = "";
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

                        Patient p = new Patient(-1,FirstNameBox.Text, LastNameBox.Text);
                        p = p.FindData();

                        if (p == null)
                        {
                            PrintBox.Text = "Patient not found";
                            FirstNameBox.Text = "";
                            LastNameBox.Text = "";
                            break;
                        }

                        Organ o = new Organ(p.ID);
                        o.DeleteData();
                        p.DeleteData();

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
            Organ o = new Organ(-1);
            PrintBox.Text = o.Print();
        }

        //test printing
        private void PrintPatient()
        {
            Patient o = new Patient(-1,null,null);
            PrintBox.Text = o.Print();

            //PrintBox.Text = organList.print();
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
