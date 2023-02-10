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
    public partial class SM_System : Form
    {

        //static int h;
        // ++h;
        //tabcontrol1.TabPages.Add("new"+h);
        SqlConnection get = new SqlConnection(@"Data Source=DESKTOP-UNG7K77;Initial Catalog=CSharp_Projects;Integrated Security=true;");
        SqlDataReader read;
        SqlCommand cmd;
        SqlDataAdapter data;
        DataTable dt = new DataTable();
        char ism=' ';
        public SM_System()
        {
            InitializeComponent();
        }

        public SM_System( string un,char ism1,string tabname,string empid)
        {
            InitializeComponent();
            username.Text = "User Name: " + un;
            if (ism1 == '1')
            {
                man.Checked = true;
                clear.Enabled = true;
                update.Enabled = true;
                delete.Enabled = true;
                go.Enabled = true;
                ism = ism1;
            }
            else
            {
                ism = ism1;
                man.Checked = false;
                clear.Enabled = false;
                update.Enabled = false;
                delete.Enabled = false;
                go.Enabled = false;
            }
            if (tabname == "invoice")
            {
                emp_id.Text = empid;
                tabcontrol1.SelectedIndex = 0;
            }
            else if (tabname == "items")
                tabcontrol1.SelectedIndex = 1;
            else if (tabname == "stored")
                tabcontrol1.SelectedIndex = 2;
            else if (tabname == "customer")
                tabcontrol1.SelectedIndex = 3;
            else if (tabname == "employee")
                tabcontrol1.SelectedIndex = 4;
            else if (tabname == "saled")
                tabcontrol1.SelectedIndex = 5;
           
        }
        void invoicenum()
        {
            get.Close();
            try
            {
                
                cmd = new SqlCommand("select max(in_id) from invoice", get);
                get.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                    In_num.Text = Convert.ToString(int.Parse(read[0].ToString()) + 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error state: " + ex.Message);
            }
            finally
            {
                read.Close();
                get.Close();

            }
        }
        
         void datagradv()
        {
            try
            {
                dt.Columns.Clear();
                dt.Clear();
                data = new SqlDataAdapter("select * from saled", get);
                get.Open();
                data.Fill(dt);
                datagradeveiw1.DataSource = dt;
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
        
        void cls()
        {
            try
            {
                if (tabcontrol1.SelectedIndex == 0)
                {
                        In_num.Text = Cust_fn.Text = Cust_ln.Text = Cust_pn.Text = It_id.Text = It_name.Text = It_type.Text = It_Costpitem.Text = Total_cost.Text = Pay.Text = Rest.Text = In_Des.Text = "";
                        Item.Checked = true;
                        It_quant.Text = "1";
                        invoicenum();
                }
                else if (tabcontrol1.SelectedIndex == 1)
                {
                    Items_num.Text = Items_name.Text = Items_type.Text = Items_des.Text = Items_p_i.Text = Items_p_p.Text = Items_quant.Text = Items_quant_item.Text = Items_edate.Text = it_snum.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 2)
                {
                    
                    St_num.Text = St_m_num.Text = St_desc.Text = St_address.Text = stordate.Text = "";
                    stinfo.Columns.Clear();
                    
                }
                else if (tabcontrol1.SelectedIndex == 3)
                {
                    cust_id.Text = cust_fname.Text = cust_lname.Text = cust_des.Text = cust_phone.Text = cust_bquant.Text = cust_tot.Text = cust_empid.Text = cpay.Text = crest.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 4)
                {
                    Emp_num.Text = Emp_fn.Text = Emp_ln.Text = emp_passwd.Text = Emp_Des.Text = Jop_type.Text = salary.Text = Bouns.Text = Minus.Text = emp_phone.Text = Address.Text = em_id.Text = usname.Text = cpasswd.Text = "";
                }
                else if(tabcontrol1.SelectedIndex == 5)
                {
                    dt.Columns.Clear();
                    dt.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error state: " + ex.Message);
            }
            finally
            {

                get.Close();
            }
        }
        void showinfo()
        {
            try
            {
                if (tabcontrol1.SelectedIndex == 0)
                {
                    if (In_num.Text != "")
                    {
                        
                        Item.Checked = true;
                        cmd = new SqlCommand("select * from invoice where in_id='" + In_num.Text + "'", get);
                        get.Open();
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            In_num.Text = emp_id.Text = Cust_fn.Text = Cust_ln.Text = Cust_pn.Text = It_id.Text = It_name.Text = It_type.Text = It_quant.Text = It_Costpitem.Text = Total_cost.Text = Pay.Text = Rest.Text = In_Des.Text = In_date.Text = "";
                            In_num.Text = read[0].ToString();
                            emp_id.Text = read[1].ToString();
                            Cust_fn.Text = read[2].ToString();
                            Cust_ln.Text = read[3].ToString();
                            Cust_pn.Text = read[4].ToString();
                            It_id.Text = read[5].ToString();
                            It_name.Text = read[6].ToString();
                            It_type.Text = read[7].ToString();
                            It_quant.Text = read[8].ToString();
                            It_Costpitem.Text = read[9].ToString();
                            Total_cost.Text = read[10].ToString();
                            Pay.Text = read[11].ToString();
                            Rest.Text = read[12].ToString();
                            In_Des.Text = read[13].ToString();
                            In_date.Text = read[14].ToString();
                            if (read[15].ToString() == "1")
                                Packet.Checked = true;
                            else
                                Item.Checked = true;
                        }
                    }
                    else
                        MessageBox.Show("Fill the invoice id at first.");
                }
                else if (tabcontrol1.SelectedIndex == 1)
                {
                    cmd = new SqlCommand("select * from items where it_id ='"+ Items_num .Text+ "'",get);
                    get.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        Items_num.Text = read[0].ToString();
                        Items_name.Text = read[1].ToString();
                        Items_type.Text = read[2].ToString();
                        Items_quant.Text = read[3].ToString();
                        Items_quant_item.Text = read[4].ToString();
                        Items_p_i.Text = read[5].ToString();
                        Items_p_p.Text = read[6].ToString();
                        Items_des.Text = read[7].ToString();
                        Items_edate.Text = read[8].ToString();
                        stdate.Text = read[9].ToString();
                        it_snum.Text = read[10].ToString();
                    }
                }
                else if (tabcontrol1.SelectedIndex == 2)
                {
                    dt.Columns.Clear();
                    dt.Clear();
                    cmd = new SqlCommand("select * from stored where st_id='" + St_num.Text + "'", get);
                    get.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        St_num.Text = St_m_num.Text = St_desc.Text = St_address.Text = stordate.Text = "";
                        St_num.Text = read[0].ToString();
                        St_m_num.Text = read[1].ToString();
                        St_address.Text = read[2].ToString();
                        St_desc.Text = read[3].ToString();
                        stordate.Text = read[4].ToString();
                    }
                    get.Close();
                    data = new SqlDataAdapter("select * from items where st_num='" + St_num.Text + "'", get);
                    data.Fill(dt);
                    stinfo.DataSource = dt;
                }
                else if (tabcontrol1.SelectedIndex == 3)
                {
                    cmd = new SqlCommand("select * from customer where c_id='" + cust_id.Text + "'", get);
                    get.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        cust_id.Text = cust_lname.Text = cust_phone.Text = cust_des.Text = cust_date.Text = cust_empid.Text = cust_bquant.Text = cust_tot.Text = "";
                        cust_id.Text = read[0].ToString();
                        cust_fname.Text = read[1].ToString();
                        cust_lname.Text = read[2].ToString();
                        cust_phone.Text = read[3].ToString();
                        cust_des.Text = read[4].ToString();
                        cust_date.Text = read[5].ToString();
                        cust_empid.Text = read[6].ToString();
                        cust_bquant.Text = read[7].ToString();
                        cust_tot.Text = read[8].ToString();
                        cpay.Text = read[9].ToString();
                        crest.Text = read[10].ToString();
                    }
                }
                else if (tabcontrol1.SelectedIndex == 4)
                {                    
                    cmd = new SqlCommand("select * from employee where emp_id='"+Emp_num.Text+"'",get);
                    get.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        Emp_num.Text = Emp_fn.Text = Emp_ln.Text = emp_passwd.Text = Emp_Des.Text = Jop_type.Text = salary.Text = Bouns.Text = Minus.Text = emp_phone.Text = Address.Text = H_Date.Text = em_id.Text = usname.Text = "";
                        ismanager.Checked = false;
                        Emp_num.Text = read[0].ToString();
                        Emp_fn.Text = read[1].ToString();
                        Emp_ln.Text = read[2].ToString();
                        emp_passwd.Text = read[3].ToString();
                        Emp_Des.Text = read[4].ToString();
                        Jop_type.Text = read[5].ToString();
                        salary.Text = read[6].ToString();
                        if (read[7].ToString() == "")
                            Bouns.Text = "0.00";
                        else
                            Bouns.Text = read[7].ToString();
                        if (read[8].ToString() == "")
                            Minus.Text = "0.00";
                        else
                            Minus.Text = read[8].ToString();
                        emp_phone.Text = read[9].ToString();
                        Address.Text = read[10].ToString();
                        H_Date.Text = read[11].ToString();
                        if (int.Parse(read[12].ToString()) == 1)
                        {
                            ismanager.Checked = true;
                        }
                        else
                            ismanager.Checked = false;
                        if (read[13].ToString() == "")
                            em_id.Text = "";
                        else
                            em_id.Text = read[13].ToString();
                        usname.Text = read[14].ToString();
                    }
                }
                 
                else if (tabcontrol1.SelectedIndex == 5)
                {
                    datagradv();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error state: "+ex.Message);
            }
            finally
            {
               
                get.Close();
            }
       
        }
        void addinvoice()
        {

            get.Close();
            try
            {
                if (tabcontrol1.SelectedIndex == 0)
                {
                    char inp = '0';
                    if (In_num.Text != "")
                    {
                        
                               if (Packet.Checked)
                                {
                                    inp = '1';
                                }
                                cmd = new SqlCommand("exec addinvoice '" + In_num.Text + "','" + emp_id.Text + "','" + Cust_fn.Text + "','" + Cust_ln.Text + "','" + Cust_pn.Text + "','" + It_id.Text + "','" + It_name.Text + "','" + It_type.Text + "'," + It_quant.Text + "," + decimal.Parse(It_Costpitem.Text) + "," + decimal.Parse(Total_cost.Text) + "," + decimal.Parse(Pay.Text) + "," + decimal.Parse(Rest.Text) + ",'" + In_Des.Text + "','" + inp+"'", get);
                                get.Open();
                                cmd.ExecuteNonQuery();
                                In_num.Text = emp_id.Text = Cust_fn.Text = Cust_ln.Text = Cust_pn.Text = It_id.Text = It_name.Text = It_type.Text = It_Costpitem.Text = Total_cost.Text = Pay.Text = Rest.Text = In_Des.Text = "";
                                Item.Checked = true;
                                It_quant.Text = "1";
                                MessageBox.Show("Add successfully.");
                            get.Close();
                            invoicenum();

                    }
                    else
                        MessageBox.Show("Please fill the invoice number at first.");
                }
                else if (tabcontrol1.SelectedIndex == 1)
                {
                    Items f = new Items(Items_num.Text, Items_name.Text, Items_type.Text, Items_des.Text, decimal.Parse(Items_p_i.Text), decimal.Parse(Items_p_p.Text), int.Parse(Items_quant.Text),int.Parse(Items_quant_item.Text), Items_edate.Text, it_snum.Text);
                    f.additems();
                    Items_num.Text= Items_name.Text= Items_type.Text= Items_des.Text=Items_p_i.Text=Items_p_p.Text=Items_quant.Text=Items_quant_item.Text=Items_edate.Text = it_snum.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 2)
                {
                    Stored g = new Stored(St_num.Text, St_m_num.Text,St_address.Text, St_desc.Text );
                    g.addstored();

                    St_num.Text = St_m_num.Text = St_desc.Text = St_address.Text = stordate.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 3)
                {
                    Customers g = new Customers(cust_id.Text, cust_fname.Text, cust_lname.Text, cust_des.Text, int.Parse(cust_phone.Text), int.Parse(cust_bquant.Text), decimal.Parse(cust_tot.Text), cust_empid.Text,decimal.Parse(cpay.Text),decimal.Parse(crest.Text));
                    g.addcust();
                    cust_id.Text= cust_fname.Text= cust_lname.Text= cust_des.Text=cust_phone.Text=cust_bquant.Text=cust_tot.Text= cust_empid.Text=cpay.Text=crest.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 4)
                {
                    if (In_num.Text != "")
                    {
                        decimal b, m;
                        char ism ='0';
                        if (ismanager.Checked)
                            ism = '1';
                        if (calcsalary.Checked)
                        {
                            if (Bouns.Text != "" && Minus.Text != "")
                            {
                                b = decimal.Parse(Bouns.Text);
                                m = decimal.Parse(Minus.Text);
                            }
                            else if (Bouns.Text != "" && Minus.Text == "")
                            {
                                b = decimal.Parse(Bouns.Text);
                                m = 0;
                            }
                            else if (Bouns.Text == "" && Minus.Text != "")
                            {
                                m = decimal.Parse(Minus.Text);
                                b = 0;
                            }
                            else
                                b = m = 0;
                        }
                        else
                            b = m = 0;
                        if (emp_passwd.Text == cpasswd.Text)
                        {
                            Employee g = new Employee(Emp_num.Text, Emp_fn.Text, Emp_ln.Text, emp_passwd.Text, Emp_Des.Text, Jop_type.Text, decimal.Parse(salary.Text), b, m, int.Parse(emp_phone.Text), Address.Text, ism, em_id.Text,usname.Text);
                            g.addemployee();
                            Emp_num.Text= Emp_fn.Text= Emp_ln.Text= emp_passwd.Text= Emp_Des.Text= Jop_type.Text=salary.Text= Bouns.Text= Minus.Text=emp_phone.Text= Address.Text=em_id.Text=usname.Text = cpasswd.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("The passwords not conferms well.","Error");
                        }
                    }
                    else
                        MessageBox.Show("Please fill the invoice number at first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error state: " + ex.Message);
            }
            finally
            {

                get.Close();
            }

        }
        void updateinvoice()
        {
           
            char inp = '0';
            try
            {
                if (tabcontrol1.SelectedIndex == 0)
                {
                    if (In_num.Text != "")
                    {
                       
                        if (Packet.Checked)
                        {
                            inp = '1';
                        }
                        cmd = new SqlCommand("exec updateinvoice '" + In_num.Text + "','" + emp_id.Text + "','" + Cust_fn.Text + "','" + Cust_ln.Text + "','" + Cust_pn.Text + "','" + It_id.Text + "','" + It_name.Text + "','" + It_type.Text + "'," + It_quant.Text + "," + decimal.Parse(It_Costpitem.Text) + "," + decimal.Parse(Total_cost.Text) + "," + decimal.Parse(Pay.Text) + "," + decimal.Parse(Rest.Text) + ",'" + In_Des.Text + "','" + inp + "'", get);
                        get.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully.");
                    }
                    else
                        MessageBox.Show("Please fill the invoice number at first.");

                }
                else if (tabcontrol1.SelectedIndex == 1)
                {
                    Items f = new Items(Items_num.Text, Items_name.Text, Items_type.Text, Items_des.Text, decimal.Parse(Items_p_i.Text), decimal.Parse(Items_p_p.Text), int.Parse(Items_quant.Text),int.Parse(Items_quant_item.Text), Items_edate.Text, it_snum.Text);
                    f.updateitems();
                }
                else if (tabcontrol1.SelectedIndex == 2)
                {

                    Stored g = new Stored(St_num.Text, St_m_num.Text, St_address.Text, St_desc.Text);
                    g.updatestored();
                }
                else if (tabcontrol1.SelectedIndex == 3)
                {
                    Customers g = new Customers(cust_id.Text, cust_fname.Text, cust_lname.Text, cust_des.Text, int.Parse(cust_phone.Text), int.Parse(cust_bquant.Text), decimal.Parse(cust_tot.Text), cust_empid.Text, decimal.Parse(cpay.Text), decimal.Parse(crest.Text));
                    g.updatecust();
                }
                else if (tabcontrol1.SelectedIndex == 4)
                {
                    decimal b, m;
                    char ism = '0';
                    if (ismanager.Checked)
                        ism = '1';
                    if (calcsalary.Checked)
                    {
                        if (Bouns.Text != "" && Minus.Text != "")
                        {
                            b = decimal.Parse(Bouns.Text);
                            m = decimal.Parse(Minus.Text);
                        }
                        else if (Bouns.Text != "" && Minus.Text == "")
                        {
                            b = decimal.Parse(Bouns.Text);
                            m = 0;
                        }
                        else if (Bouns.Text == "" && Minus.Text != "")
                        {
                            m = decimal.Parse(Minus.Text);
                            b = 0;
                        }
                        else
                            b = m = 0;
                    }
                    else
                        b = m = 0;
                    if (emp_passwd.Text == cpasswd.Text)
                    {
                        Employee g = new Employee(Emp_num.Text, Emp_fn.Text, Emp_ln.Text, emp_passwd.Text, Emp_Des.Text, Jop_type.Text, decimal.Parse(salary.Text), b, m, int.Parse(emp_phone.Text), Address.Text, ism, em_id.Text,usname.Text);
                        g.updateemployee();
                    }
                    else
                    {
                        MessageBox.Show("The passwords not conferms well.", "Error");
                    }
                }
                               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error state: " + ex.Message);
            }
            finally
            {

                get.Close();
            }
        
        }
        void deleteinvoice()
        {
            try
            {
                if (tabcontrol1.SelectedIndex==0)
                {
                    cmd = new SqlCommand("delete from invoice where in_id='"+In_num.Text+"'",get);
                    get.Open();
                    cmd.ExecuteNonQuery();
                    In_num.Text = emp_id.Text = Cust_fn.Text = Cust_ln.Text = Cust_pn.Text = It_id.Text = It_name.Text = It_type.Text = It_Costpitem.Text = Total_cost.Text = Pay.Text = Rest.Text = In_Des.Text = "";
                    Item.Checked = true;
                    MessageBox.Show("Deleted successfully.","delete");
                   
                    invoicenum();
                }
                else if (tabcontrol1.SelectedIndex == 1)
                {
                    Items f = new Items(Items_num.Text);
                    f.deleteitems();
                    Items_num.Text = Items_name.Text = Items_type.Text = Items_des.Text = Items_p_i.Text = Items_p_p.Text = Items_quant.Text = Items_quant_item.Text = Items_edate.Text = it_snum.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 2)
                {
                    Stored g = new Stored(St_num.Text);
                    g.deletestored();
                    St_num.Text = St_m_num.Text = St_desc.Text = St_address.Text = stordate.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 3)
                {
                    Customers g = new Customers(cust_id.Text);
                    g.deltecust();
                    cust_id.Text = cust_fname.Text = cust_lname.Text = cust_des.Text = cust_phone.Text = cust_bquant.Text = cust_tot.Text = cust_empid.Text = cpay.Text = crest.Text = "";
                }
                else if (tabcontrol1.SelectedIndex == 4)
                {
                    Employee g = new Employee(Emp_num.Text);
                    g.deleteemployee();
                    Emp_num.Text = Emp_fn.Text = Emp_ln.Text = emp_passwd.Text = Emp_Des.Text = Jop_type.Text = salary.Text = Bouns.Text = Minus.Text = emp_phone.Text = Address.Text = em_id.Text = usname.Text = cpasswd.Text = "";
                }
               else if (tabcontrol1.SelectedIndex==5)
                {

                    cmd = new SqlCommand("delete from saled where s_id='"+ datagradeveiw1.CurrentRow.Cells[0].Value + "'",get);
                    get.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted successfully.","delete");
                    get.Close();
                    datagradv();
                    //MessageBox.Show(""+datagradeveiw1.CurrentRow.Cells[0].Value);

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
        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            get.Close();
            addinvoice();
            
        }

        private void SM_System_Load(object sender, EventArgs e)
        {
            
            if (ism == '1')
                delete.Enabled = update.Enabled = add.Enabled = clear.Enabled = go.Enabled = true;
            else
            {
                delete.Enabled = false;
                 update.Enabled = add.Enabled = clear.Enabled = go.Enabled = true;
            }
            invoicenum();
        }

        private void It_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void calcsalary_CheckedChanged(object sender, EventArgs e)
        {
            if (calcsalary.Checked)
            {
                Bounsl.Enabled = Minusl.Enabled = Bouns.Enabled = Minus.Enabled = true;
            }
            else
            {
                Bounsl.Enabled = Minusl.Enabled = Bouns.Enabled = Minus.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cls();
        }

        private void Packet_CheckedChanged(object sender, EventArgs e)
        {
            if (Packet.Checked)
            {
                get.Close();
                Item.Checked = false;
                try {
                    cmd = new SqlCommand("select price_p_p from items where it_id='" + It_id.Text + "'", get);
                    get.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        It_Costpitem.Text = read[0].ToString();
                    }
                    read.Close();
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
            else
                Item.Checked = true;
        }

        private void Item_CheckedChanged(object sender, EventArgs e)
        {
            if (Item.Checked)
            {
                Packet.Checked = false;
                try
                {
                    cmd = new SqlCommand("select price_p_i from items where it_id='" + It_id.Text + "'", get);
                    get.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        It_Costpitem.Text = read[0].ToString();
                    }
                    read.Close();
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
                Packet.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showinfo();
            
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateinvoice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteinvoice();
           
        }

        private void tabcontrol1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ism == ' ')
            {
                if (tabcontrol1.SelectedIndex == 4)
                    delete.Enabled = update.Enabled = add.Enabled = clear.Enabled = go.Enabled = false;
                else if (tabcontrol1.SelectedIndex == 5)
                {
                    delete.Enabled = update.Enabled = add.Enabled = clear.Enabled = go.Enabled = false;
                }
                else if (tabcontrol1.SelectedIndex == 0 || tabcontrol1.SelectedIndex == 1 || tabcontrol1.SelectedIndex == 2 || tabcontrol1.SelectedIndex == 3)
                {
                    delete.Enabled = false;
                    update.Enabled = add.Enabled = clear.Enabled = go.Enabled = true;
                }

            }
            else if (tabcontrol1.SelectedIndex == 5)
            {
                 update.Enabled = add.Enabled = false;
                delete.Enabled = clear.Enabled = go.Enabled = true;
            }
            else
                delete.Enabled = update.Enabled = add.Enabled = clear.Enabled = go.Enabled = true;
        }

        private void Items_edate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Items_name_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void St_it_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void St_it_number_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void Items_num_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void It_id_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void em_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void emp_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cust_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Emp_num_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Stored_Click(object sender, EventArgs e)
        {

        }

        private void cust_empid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Emp_num_Enter(object sender, EventArgs e)
        {
            try
            {
                Emp_num.Items.Clear();
                cmd = new SqlCommand("select emp_id from employee", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    Emp_num.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void em_id_Enter(object sender, EventArgs e)
        {
            try
            {
                em_id.Items.Clear();
                cmd = new SqlCommand("select emp_id from employee where ismanager='1'", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    em_id.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void St_m_num_Enter(object sender, EventArgs e)
        {
            try
            {
                St_m_num.Items.Clear();
                cmd = new SqlCommand("select emp_id from employee where ismanager='1'", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    St_m_num.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void emp_id_Leave(object sender, EventArgs e)
        {

        }

        private void emp_id_Enter(object sender, EventArgs e)
        {

        }

        private void St_m_num_Leave(object sender, EventArgs e)
        {

        }

        private void cust_empid_Enter(object sender, EventArgs e)
        {
            try
            {
                cust_empid.Items.Clear();
                cmd = new SqlCommand("select emp_id from employee where ismanager='1'", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    cust_empid.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void In_num_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void In_num_Enter(object sender, EventArgs e)
        {
            try
            {
                In_num.Items.Clear();
                cmd = new SqlCommand("select in_id from invoice order by in_id asc", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    In_num.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void It_id_Enter(object sender, EventArgs e)
        {
            try
            {
                It_id.Items.Clear();
                cmd = new SqlCommand("select it_id from items", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    It_id.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void It_name_Enter(object sender, EventArgs e)
        {
            try
            {
                It_name.Items.Clear();
                cmd = new SqlCommand("select it_name from items", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    It_name.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void Items_num_Enter(object sender, EventArgs e)
        {
            try
            {
                Items_num.Items.Clear();
                cmd = new SqlCommand("select it_id from items", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    Items_num.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void St_it_number_Enter(object sender, EventArgs e)
        {
            
        }

        private void St_it_name_Enter(object sender, EventArgs e)
        {
            
        }

        private void Items_name_Enter(object sender, EventArgs e)
        {
            try
            {
                Items_name.Items.Clear();
                cmd = new SqlCommand("select it_name from items", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    Items_name.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void St_num_Enter(object sender, EventArgs e)
        {
            try
            {
                St_num.Items.Clear();
                cmd = new SqlCommand("select st_id from stored", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    St_num.Items.Add(read[0].ToString());
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally { get.Close(); }
        }

        private void cust_id_Enter(object sender, EventArgs e)
        {
            try {
                cust_id.Items.Clear();
                cmd = new SqlCommand("select c_id from customer", get);
                get.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                    cust_id.Items.Add(read[0].ToString());
                read.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message);
            }
            finally { get.Close(); }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void In_num_Leave(object sender, EventArgs e)
        {
            
        }

        private void Items_num_Leave(object sender, EventArgs e)
        {
            
        }

        private void St_num_Leave(object sender, EventArgs e)
        {
            
        }

        private void cust_id_Leave(object sender, EventArgs e)
        {
            
        }

        private void Emp_num_Leave(object sender, EventArgs e)
        {
            
        }

        private void In_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showinfo();
                e.SuppressKeyPress = true;
            }
        }

        private void Items_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showinfo();
                e.SuppressKeyPress = true;
            }
        }

        private void St_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showinfo();
                e.SuppressKeyPress = true;
            }
        }

        private void tabcontrol1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showinfo();
                e.SuppressKeyPress = true;
            }
        }

        private void Emp_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showinfo();
                e.SuppressKeyPress = true;
            }
        }

        private void St_it_number_Leave(object sender, EventArgs e)
        {
            
        }

        private void It_id_Leave(object sender, EventArgs e)
        {
            try
            {
                
                cmd = new SqlCommand("select it_name,it_type,price_p_i,des from items where it_id='"+ It_id.Text+ "'", get);
                get.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    It_name.Text = read[0].ToString();
                    It_type.Text = read[1].ToString();
                    It_Costpitem.Text = read[2].ToString();
                    In_Des.Text = read[3].ToString();
                }
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

        private void It_quant_Leave(object sender, EventArgs e)
        {
            
        }

        private void It_Costpitem_TextChanged(object sender, EventArgs e)
        {
            if (It_quant.Text != "" && It_Costpitem.Text != "" )
            {
                decimal money = decimal.Parse(It_quant.Text) * decimal.Parse(It_Costpitem.Text);
                Total_cost.Text = Convert.ToString(money);
            }
            
        }

        private void It_quant_TextChanged(object sender, EventArgs e)
        {
            if(It_quant.Text!=""&& It_Costpitem.Text != "")
            {
                decimal money = decimal.Parse(It_quant.Text) * decimal.Parse(It_Costpitem.Text);
                Total_cost.Text = Convert.ToString(money);
            }
        }

        private void gOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showinfo();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addinvoice();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateinvoice();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteinvoice();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help g = new Help();
            g.ShowDialog();
        }

        private void Pay_TextChanged(object sender, EventArgs e)
        {
            if (Pay.Text != "" && Total_cost.Text != "")
                Rest.Text = Convert.ToString(decimal.Parse(Total_cost.Text) - decimal.Parse(Pay.Text));
            else
                Rest.Text = Total_cost.Text;
        }

        private void St_sales_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void St_it_number_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void St_Quantity_TextChanged(object sender, EventArgs e)
        {
        }

        private void Total_cost_TextChanged(object sender, EventArgs e)
        {
            if (Total_cost.Text != "" && Pay.Text != "")
                Rest.Text = Convert.ToString(decimal.Parse(Total_cost.Text) - decimal.Parse(Pay.Text));
            else if (Total_cost.Text != "" && Pay.Text == "")
                Rest.Text = Total_cost.Text;
            else
                Rest.Text = "0";
        }

        private void it_snum_Enter(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("select st_id from stored ", get);
                get.Open();
                read = cmd.ExecuteReader();
               while (read.Read())
                {
                    it_snum.Items.Add( read[0].ToString());
                    
                }
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

        private void It_name_Leave(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("select it_id,it_type,price_p_i,des from items where it_name='" + It_name.Text + "'", get);
                get.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    It_id.Text = read[0].ToString();
                    It_type.Text = read[1].ToString();
                    It_Costpitem.Text = read[2].ToString();
                    In_Des.Text = read[3].ToString();
                }
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

        private void cust_tot_TextChanged(object sender, EventArgs e)
        {
            if (cpay.Text != "" && cust_tot.Text != "")
                crest.Text = Convert.ToString(decimal.Parse(cust_tot.Text) - decimal.Parse(cpay.Text));
            else if (cust_tot.Text != "" && cpay.Text == "")
                crest.Text = cust_tot.Text;
            else
                crest.Text = "0";
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help g = new Help();
            g.ShowDialog();
        }

        private void goToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showinfo();
        }

        private void aDDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addinvoice();
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateinvoice();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteinvoice();
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Items_name_Leave(object sender, EventArgs e)
        {
            try {
                cmd = new SqlCommand("select * from items where it_name ='" + Items_name.Text + "'", get);
                get.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    Items_num.Text = read[0].ToString();
                    Items_name.Text = read[1].ToString();
                    Items_type.Text = read[2].ToString();
                    Items_quant.Text = read[3].ToString();
                    Items_quant_item.Text = read[4].ToString();
                    Items_p_i.Text = read[5].ToString();
                    Items_p_p.Text = read[6].ToString();
                    Items_des.Text = read[7].ToString();
                    Items_edate.Text = read[8].ToString();
                    stdate.Text = read[9].ToString();
                    it_snum.Text = read[10].ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message);
            }
            finally
            {
                get.Close();
            }
        }

        private void clearToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cls();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cls();
        }
    }
}
