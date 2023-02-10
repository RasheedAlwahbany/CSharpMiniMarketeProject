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
    class Items
    {
        SqlConnection get = new SqlConnection(@"Data Source=DESKTOP-UNG7K77;Initial Catalog=CSharp_Projects;Integrated Security=true;");
        SqlCommand cmd;
        string id, name, type, des,edate,snum;
        int quantity_per_packets, quantity_per_items;
        decimal cost_per_item,cost_per_packets;
        public string Id
        {
            get { return id; }
            set
            {
                if (value != "")
                    id = value;
            }
        }
        public string Snum
        {
            get { return snum; }
            set
            {
                if (value != "")
                    snum = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value != "")
                    name = value;
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                if (value != "")
                    type = value;
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
        public string Edate
        {
            get { return edate; }
            set
            {
                if (value != "")
                    edate = value;
            }
        }

        public decimal Cost_per_item
        {
            get { return cost_per_item; }
            set
            {
                if (value >0)
                    cost_per_item = value;
            }
        }
        public decimal Cost_per_packets
        {
            get { return cost_per_packets; }
            set
            {
                if (value > 0)
                    cost_per_packets = value;
            }
        }
        public int Quantity_per_packets
        {
            get { return quantity_per_packets; }
            set
            {
                if (value > 0)
                    quantity_per_packets = value;
            }
        }
        public int Quantity_per_items
        {
            get { return quantity_per_items; }
            set
            {
                if (value > 0)
                    quantity_per_items = value;
            }
        }
        public Items(string id1,string n,string typ,string des2,decimal price_pi, decimal price_p_p,int qua,int qua2,string edat,string sn)
        {
            Id = id1;
            Name = n;
            Type = typ;
            Des = des2;
            Cost_per_item = price_pi;
            Cost_per_packets = price_p_p;
            Quantity_per_packets = qua;
            Quantity_per_items = qua2;
            Snum = sn;
        }
        public Items(string id1)
        {
            Id = id1;
        }
        public Items() { }
        public void additems()
        {
            try
            {
                cmd = new SqlCommand("exec additems '"+Id+"','"+Name+"','"+Type+"',"+Quantity_per_packets+","+Quantity_per_items+","+Cost_per_item+","+Cost_per_packets+",'"+Des+"','"+Edate+"','"+Snum+"'", get);
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
        public void updateitems()
        {
            try
            {
                cmd = new SqlCommand("exec updateitems '" + Id + "','" + Name + "','" + Type + "'," + Quantity_per_packets + "," + Quantity_per_items + "," + Cost_per_item + "," + Cost_per_packets + ",'" + Des + "','" + Edate + "','" + Snum + "'", get);
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
        public void deleteitems()
        {
            try
            {
                cmd = new SqlCommand("delete from items where it_id='"+Id+"'",get);
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
