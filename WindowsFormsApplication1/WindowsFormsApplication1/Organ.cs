using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Organ
    {
        private int _id;
        private DateTime _date;
        private string _organName;
        private string _bloodType;
        private static string connect = "Data Source=DESKTOP-0JDVU3E\\SQLEXPRESS;Initial Catalog=Organs;Integrated Security=True";

        public Organ(int i)
        {
            _id = i;
            _date = new DateTime();
            _organName = null;
            _bloodType = null;
        }
        
        public Organ(int i, string o, string b)
        {
            _id = i;
            _date = new DateTime();
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

        //server queries
        public void AddData()
        {
            AddData(_organName, _bloodType, _date, _id);
        }

        private static void AddData(string o, string b, DateTime d, int i)
        {

            string queryString =
                "INSERT INTO OrganList(OrganName,BloodType,EnteredDate,ID) VALUES(@Organ, @Blood, @Date, @Id); ";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Organ",o);
                command.Parameters.AddWithValue("@Blood", b);
                command.Parameters.AddWithValue("@Date", d);
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
                "DELETE FROM OrganList WHERE ID = @Id;";
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

        public Organ GrabData()
        {
            return GrabData(_id);
        }

        private static Organ GrabData(int i)
        {
            Organ org = null;
            string queryString =
                "SELECT OrganName, BloodType, EnteredDate, ID FROM OrganList WHERE ID = @Id;";
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
                        org = new Organ(Int32.Parse(reader[3].ToString()), DateTime.Parse(reader[2].ToString()), reader[0].ToString(), reader[1].ToString());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                connection.Close();
            }

            return org;
        }

        public Organ FindData()
        {
            return FindData(_organName,_bloodType);
        }

        private static Organ FindData(string o,string b)
        {
            Organ org = null;
            string queryString =
                "SELECT OrganName, BloodType, EnteredDate, ID FROM OrganList WHERE OrganName = @Organ AND BloodType = @Blood AND EnteredDate = (SELECT MIN(EnteredDate) FROM OrganList WHERE OrganName = @Organ AND BloodType = @Blood);";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Organ", o);
                command.Parameters.AddWithValue("@Blood", b);
                SqlDataReader reader = command.ExecuteReader();
                try
                {

                    while (reader.Read())
                    {
                        org = new Organ(Int32.Parse(reader[3].ToString()), DateTime.Parse(reader[2].ToString()), reader[0].ToString(), reader[1].ToString());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                connection.Close();
            }

            return org;
        }

        public void UpdateData()
        {
            UpdateData(_id,_organName,_bloodType);
        }

        private static void UpdateData(int i, string o, string b)
        {
            string queryString =
                "UPDATE OrganList SET OrganName = @Organ, BloodType = @Blood WHERE ID = @Id;";
            using (SqlConnection connection = new SqlConnection(
                       connect))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Organ", o);
                command.Parameters.AddWithValue("@Blood", b);
                command.Parameters.AddWithValue("@Id", i);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }




        public string Print()
        {
            return Print(_organName, _bloodType);
        }

        private static string Print(string o, string b)
        {
            string s = "";
            string queryString =
                "SELECT OrganName, BloodType, EnteredDate FROM OrganList;";
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
