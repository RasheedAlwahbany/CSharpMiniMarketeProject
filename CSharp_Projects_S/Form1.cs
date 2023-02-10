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
    public partial class Form1 : Form
    {
        SqlConnection get = new SqlConnection(@"Data Source=DESKTOP-UNG7K77;Initial Catalog=CSharp_Projects;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataReader read;
        char is_m = ' ';
        public string retry = "",uname,man;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string un,char ism,string empid)
        {
            InitializeComponent();
            is_m = ism;
            uname = un;
            man = empid;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("select emp_id,passwd,ismanager,uname from employee where uname='"+user_name.Text+"' and passwd='"+passwd.Text+"'",get);
                get.Open();
                read = cmd.ExecuteReader();

                if (read.Read())
                {

                    if (ismanager.Checked)
                    {

                        this.Hide();
                        Main_Form h = new Main_Form(user_name.Text, '1', read[0].ToString());
                        if (h.Focused == false)
                        {
                            MessageBox.Show("Welcome dear: "+user_name.Text,"Welcome",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            h.ShowDialog();
                            this.Close();
                        }

                    }
                    else
                    {

                        this.Hide();
                        Main_Form h = new Main_Form(user_name.Text, read[0].ToString());
                        if (h.Focused == false)
                        {
                            MessageBox.Show("Welcome dear: " + user_name.Text, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            h.ShowDialog();

                            this.Close();
                        }
                    }
                    read.Close();
                }
                else
                {
                    user_name.Focus();
                    MessageBox.Show("Error user name or password.\nPlase try again.", "Error");
                }
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

        private void textBox1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            try
            {

                cmd = new SqlCommand("select ismanager from employee where uname='" + user_name.Text + "'", get);
                get.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    if (read[0].ToString() == "1")
                    {
                        ismanager.Checked = true;
                    }
                    else
                    {
                        ismanager.Checked = false;
                    }
                }
            }
            catch 
            {

            }
            finally
            {
                get.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (retry != "")
            {
                this.Hide();
                Main_Form h = new Main_Form(uname, is_m, man);
                h.ShowDialog();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (retry != "")
            {
                this.Hide();
                Main_Form h = new Main_Form(uname,is_m,man);
                h.ShowDialog();
            }
            else
            this.Close();
            

            }
    }
}
