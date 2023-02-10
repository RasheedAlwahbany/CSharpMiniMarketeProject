using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
// Eng.Rasheed Adnan Al-Wahbany ^_^
namespace CSharp_Projects_S
{
    public partial class Main_Form : Form
    {
        SqlConnection get = new SqlConnection(@"Data Source=DESKTOP-UNG7K77;Initial Catalog=CSharp_Projects;Integrated Security=true;");
        SqlDataAdapter data;
        DataTable dt = new DataTable();
        string username="";
        char ismanager=' ';
        string employee_id;
        public Main_Form()
        {
            InitializeComponent();
        }
        public Main_Form( string un,string empid)
        {
            username = un;
            employee_id = empid;
            InitializeComponent();
            if (un != "")
                uname.Text = "User Name:  " + un.ToString() + ".";
        }
        public Main_Form(string un,char ism,string empid)
        {
            username = un;
            ismanager = ism;
            employee_id = empid;
            InitializeComponent();
            if (un != "")
                uname.Text = "User Name:  " + un.ToString() + ".";
        }
        void goemployee()
        {
            if (id.Text != "")
            {
                dt.Clear();
                dt.Columns.Clear();
                try
                {
                    
                    if (id.Text.ToLower() == "employee")
                        data = new SqlDataAdapter("select * from employee", get);
                    else if (id.Text.ToLower() == "customer")
                        data = new SqlDataAdapter("select * from customer", get);
                    else if (id.Text.ToLower() == "invoice")
                        data = new SqlDataAdapter("select * from invoice", get);
                    else if (id.Text.ToLower() == "items")
                        data = new SqlDataAdapter("select * from items", get);
                    else if (id.Text.ToLower() == "stored")
                        data = new SqlDataAdapter("select * from stored", get);
                    else if (id.Text.ToLower() == "saled")
                        data = new SqlDataAdapter("select * from saled", get);

                    data.Fill(dt);
                    dataGridView1.DataSource = dt;
                    row.Text = Convert.ToString(int.Parse(dataGridView1.RowCount.ToString()) - 1)+" Rows Selected";

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
            else
                MessageBox.Show("You must fill th table name at first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void searchemployee()
        {
            if (tabname.Text != "")
            {
                if (dataGridView1.RowCount != 0)
                {
                    dt.Clear();
                    dt.Columns.Clear();
                    try
                    {
                        if (tabname.Text != "")
                        {
                            if (id.Text.ToLower() == "employee")
                                data = new SqlDataAdapter("select * from employee where emp_id+fname+lname+j_type+Address+m_id+des like '%" + tabname.Text + "%'", get);
                            else if (id.Text.ToLower() == "customer")
                                data = new SqlDataAdapter("select * from customer where c_id+fname+lname+emp_id+des like '%" + tabname.Text + "%'", get);
                            else if (id.Text.ToLower() == "invoice")
                                data = new SqlDataAdapter("select * from invoice where in_id+emp_id+c_fn+c_lname+it_id+it_name+it_type+des like '%" + tabname.Text + "%'", get);
                            else if (id.Text.ToLower() == "items")
                                data = new SqlDataAdapter("select * from items where it_id+it_name+it_type+des like '%" + tabname.Text + "%'", get);
                            else if (id.Text.ToLower() == "stored")
                                data = new SqlDataAdapter("select * from stored where st_id+manager_id+it_id+des like '%" + tabname.Text + "%'", get);
                            else if (id.Text.ToLower() == "saled")
                                data = new SqlDataAdapter("select * from saled where s_id+emp_id+it_id+des like '%" + tabname.Text + "%'", get);
                            get.Open();
                            data.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        else
                            goemployee();
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
                else
                    MessageBox.Show("You must fill th table name at first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                goemployee();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void id_Click(object sender, EventArgs e)
        {

            id.Items.Clear();
            if (ismanager == '1')
            {
                string[] gt = { "Employee", "Customer", "Invoice", "Items", "Saled", "Stored" };
                foreach (string i in gt)
                    id.Items.Add(i);
            }
            else
            {
                string[] gt = { "Employee", "Customer", "Invoice", "Items", "Stored" };
                foreach (string i in gt)
                    id.Items.Add(i);
            }


        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            row.Text = "0  Rows Selected.";
            date.Text = "  Date:  " + DateTime.Now.ToLongDateString() + ".";
            dirk.Text = "  Computer name:  " + Environment.MachineName + ".";

        }

        private void gOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goemployee();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void id_SelectedIndexChanged(object sender, EventArgs e)
        {
            goemployee();
        }

        private void helpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        private void dept_num_Click(object sender, EventArgs e)
        {

        }

        private void gOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            goemployee();
        }

        private void tabname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchemployee();
                e.SuppressKeyPress = true;
            }
        }

        private void tabname_TextChanged(object sender, EventArgs e)
        {
            searchemployee();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aDDToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "invoice",employee_id);
            g.ShowDialog();
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {   
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form1 g = new Form1(username, ismanager, employee_id);
            g.retry = "back";
            g.ShowDialog();
        }

        private void updateToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "employee",employee_id);
            g.ShowDialog();
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "customer",employee_id);
            g.ShowDialog();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "items",employee_id);
            g.ShowDialog();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "saled",employee_id);
            g.ShowDialog();
        }

        private void storedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "stored",employee_id);
            g.ShowDialog();
        }

        private void options_Click(object sender, EventArgs e)
        {

        }

        private void logInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 g = new Form1(username, ismanager, employee_id);
            g.retry = "back";
            g.ShowDialog();
        }

        private void gOToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            goemployee();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "invoice", employee_id);
            g.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "items", employee_id);
            g.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "stored", employee_id);
            g.ShowDialog();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "customer", employee_id);
            g.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "employee", employee_id);
            g.ShowDialog();
        }

        private void saledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_System g = new SM_System(username, ismanager, "saled", employee_id);
            g.ShowDialog();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult=MessageBox.Show("You sure you want to close system now?\n","Info",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult == DialogResult.No)
                e.Cancel = true;
            else
            {
                MessageBox.Show("I wish you spend funy times with us.\ngood by.","Good By",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.ExitThread();
            }
            
        }

        private void clearToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabname.Text = "";
            id.Items.Clear();
            dataGridView1.Columns.Clear();
            row.Text = "0 Rows Selected";
            
        }

        private void clearToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            tabname.Text = "";
            id.Items.Clear();
            dataGridView1.Columns.Clear();
            row.Text = "0 Rows Selected";
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
