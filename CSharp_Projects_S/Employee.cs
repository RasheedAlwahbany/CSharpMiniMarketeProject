using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
// Eng.Rasheed Adnan Al-Wahbany ^_^
namespace CSharp_Projects_S
{
    class Employee:Parents
    {
        SqlConnection get = new SqlConnection(@"Data Source=DESKTOP-UNG7K77;Initial Catalog=CSharp_Projects;Integrated Security=true;");
        SqlCommand cmd;
        decimal bouns, salary,minus;
        string j_type, address,m_id,passwd,uname;
        char ism;
        public decimal Bouns
        {
            get { return bouns; }
            set
            {
                if (value > 0)
                    bouns = value;
            }
        }
        public decimal Minus
        {
            get { return minus; }
            set
            {
                if (value > 0)
                    minus = value;
            }
        }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value > 0)
                    salary = value;
            }
        }
        public string J_type
        {
            get { return j_type; }
            set
            {
                if (value !="")
                    j_type = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (value != "")
                    address = value;
            }
        }
        public string M_id
        {
            get { return m_id; }
            set
            {
                if (value != "")
                    m_id = value;
            }
        }
        public string Passwd
        {
            get { return passwd; }
            set
            {
                if (value != "")
                    passwd = value;
            }
        }
        public char Ism
        {
            get { return ism; }
            set
            {
                if (value != ' ')
                    ism = value;
            }

        }
        public string Uname
        {
            get { return uname; }
            set
            {
                if (value != "")
                    uname = value;
            }

        }
        public Employee(string id1, string fn, string ln, string pas, string de, string jt, decimal sal, decimal bo, decimal min, int ph, string add, char im, string m,string un) : base(id1, fn, ln, de, ph)
        {
            Bouns = bo;
            Minus = min;
            Salary = sal;
            J_type = jt;
            Address = add;
            M_id = m;
            Passwd = pas;
            Uname = un;
            Ism = im;
        }
        public Employee(string empid):base(empid)
        {

        }
        public void addemployee()
        {
            try {
                cmd = new SqlCommand("exec addemployee '" + base.Id + "','" + base.Fname + "','" + base.Lname + "','" + Passwd + "','" + base.Des + "','" + J_type + "'," + Salary + "," + Bouns + "," + Minus + "," + base.Phone + ",'" + Address + "','" + ism + "','" + M_id + "','"+Uname+"'", get);
                get.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add successfully.","Add");
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message);

            }
            finally
            {
                get.Close();
            }
        }
        public void updateemployee()
        {
            try
            {
                cmd = new SqlCommand("exec updateemployee '" + base.Id + "','" + base.Fname + "','" + base.Lname + "','" + Passwd + "','" + base.Des + "','" + J_type + "'," + Salary + "," + Bouns + "," + Minus + "," + base.Phone + ",'" + Address + "','" + Ism + "','" + M_id + "','"+Uname+"'", get);
                get.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully.","update");
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message);

            }
            finally
            {
                get.Close();
            }
        }
        public void deleteemployee()
        {
            try
            {
                cmd = new SqlCommand("delete employee where emp_id='" + base.Id + "'", get);
                get.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully.","delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);

            }
            finally
            {
                get.Close();
            }
        }
    }
}
