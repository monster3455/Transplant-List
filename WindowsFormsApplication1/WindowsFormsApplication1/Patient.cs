using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Patient : IComparable
    {
        protected int _id;
        private string _firstName;
        private string _lastName;
        private static string connect = "Data Source=DESKTOP-0JDVU3E\\SQLEXPRESS;Initial Catalog=PatientList;Integrated Security=True";

        public Patient(int i, string f, string l)
        {
            _id = i;
            _firstName = f;
            _lastName = l;
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

        public void AddData()
        {
            AddData(_firstName,_lastName,_id);
        }

        private static void AddData(string f, string l, int i)
        {

            string queryString =
                "INSERT INTO PatientList(FirstName, LastName, ID) VALUES(@First, @Last, @Id); ";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@First", f);
                command.Parameters.AddWithValue("@Last", l);
                command.Parameters.AddWithValue("@Id", i);
                command.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        public void DeleteData()
        {
            DeleteData(_id);
        }

        private static void DeleteData(int i)
        {

            string queryString =
                "DELETE FROM PatientList WHERE ID = @Id;";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Id", i);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public Patient GrabData()
        {
            return GrabData(_id);
        }

        private static Patient GrabData(int i)
        {
            Patient pat = null;
            string queryString =
                "SELECT FirstName, LastName, ID FROM PatientList WHERE ID = @Id;";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Id", i);
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        pat = new Patient(Int32.Parse(reader[2].ToString()), reader[0].ToString(), reader[1].ToString());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                connection.Close();
            }

            return pat;
        }

        public Patient FindData()
        {
            return FindData(_firstName,_lastName);
        }

        private static Patient FindData(string f, string l)
        {
            Patient pat = null;
            string queryString =
                "SELECT FirstName, LastName, ID FROM PatientList WHERE FirstName = @First AND LastName = @Last;";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@First", f);
                command.Parameters.AddWithValue("@Last", l);
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        pat = new Patient(Int32.Parse(reader[2].ToString()), reader[0].ToString(), reader[1].ToString());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                connection.Close();
            }

            return pat;
        }

        public void UpdateData()
        {
            UpdateData(_id, _firstName,_lastName);
        }

        private static void UpdateData(int i, string f, string l)
        {
            string queryString =
                "UPDATE PatientList SET FirstName = @First, LastName = @Last WHERE ID = @Id;";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@First", f);
                command.Parameters.AddWithValue("@Last", l);
                command.Parameters.AddWithValue("@Id", i);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }



        public string Print()
        {
            return Print(_firstName, _lastName);
        }

        private static string Print(string o, string b)
        {
            string s = "";
            string queryString =
                "SELECT FirstName, LastName, ID FROM PatientList;";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        s = s + reader[0] + " " + reader[1] + " " + reader[2] + "\n";
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                connection.Close();
            }

            return s;
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
