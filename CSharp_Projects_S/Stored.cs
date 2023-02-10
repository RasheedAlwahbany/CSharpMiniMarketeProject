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
    class Stored
    {
        SqlConnection get = new SqlConnection(@"Data Source=DESKTOP-UNG7K77;Initial Catalog=CSharp_Projects;Integrated Security=true;");
        SqlCommand cmd;
        string st_id, m_id, address,des;
        public string St_id
        {
            get { return st_id; }
            set
            {
                if (value != "")
                    st_id = value;
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
        public string Address
        {
            get { return address; }
            set
            {
                if (value != "")
                    address = value;
            }
        }
       
        public string Des
        {
            get { return des; }
            set
            {
                if (value != "")
                    des = value;
            }
        }
       
 
        public Stored(string stid,string mid,string add,string ds)
        {
            St_id = stid;
            M_id = mid;
            Address = add;
            Des = ds;
        }
        public Stored(string stid) 
        {
            St_id = stid;
        }
        public Stored() { }
        public void addstored()
        {
            try
            {
                cmd = new SqlCommand("exec addstored '"+St_id+"','"+M_id+"','"+Des+"','"+Address+"'", get);
                get.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add successfully.", "Add");
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
        public void updatestored()
        {
            try
            {
                cmd = new SqlCommand("exec updatestored '" + St_id + "','" + M_id + "','" + Des + "','" + Address + "'", get);
                get.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully.", "update");
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
        public void deletestored()
        {
            try
            {
                cmd = new SqlCommand("delete from stored where st_id='"+St_id+"'", get);
                get.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully.", "delete");
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
