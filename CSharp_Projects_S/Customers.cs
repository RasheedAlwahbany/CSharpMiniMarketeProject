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
    class Customers:Parents
    {
        SqlConnection get = new SqlConnection(@"Data Source=DESKTOP-UNG7K77;Initial Catalog=CSharp_Projects;Integrated Security=true;");
        SqlCommand cmd;
        int quantity;
        decimal  total,pay,rest;
        string emp_id;
        public int Quantity
        {
            get { return quantity;}
            set
            {
                if (value >0)
                    quantity = value;
            }
        }
        
        public decimal Total
        {
            get { return total; }
            set
            {
                if (value > 0)
                    total = value;
            }
        }
        public decimal Pay
        {
            get { return pay; }
            set
            {
                if (value > 0)
                    pay = value;
            }
        }
        public decimal Rest
        {
            get { return rest; }
            set
            {
                if (value > 0)
                    rest = value;
            }
        }
        public string Emp_id
        {
            get { return emp_id; }
            set
            {
                if (value != "")
                    emp_id = value;
            }
        }
        public Customers(string id,string fn,string ln,string des,int ph,int quant,decimal tot,string emp,decimal pay1,decimal rest1):base(id,fn,ln,des,ph)
        {
            Quantity = quant;
            Total = tot;
            Emp_id = emp;
            Pay = pay1;
            Rest = rest1;
        }
        public Customers(string id1):base(id1)
        {

        }
        public Customers() { }
        public void addcust()
        {
            try
            {
                cmd = new SqlCommand("exec addcustm '"+base.Id+"','"+base.Fname+"','"+base.Lname+"',"+base.Phone+",'"+base.Des+"','"+Emp_id+"',"+quantity+","+Total+","+Pay+","+rest, get);
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
        public void updatecust()
        {
            try
            {
                cmd = new SqlCommand("exec updatecustm '" + base.Id + "','" + base.Fname + "','" + base.Lname + "'," + base.Phone + ",'" + base.Des + "','" + Emp_id + "'," + quantity + "," + Total + "," + Pay + "," + rest, get);
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
        public void deltecust()
        {
            try
            {
                cmd = new SqlCommand("delete from customer where  c_id='" + base.Id + "'" , get);
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
