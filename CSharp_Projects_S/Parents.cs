using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Eng.Rasheed Adnan Al-Wahbany ^_^
namespace CSharp_Projects_S
{
    class Parents
    {
        string id, fname, lname, des;
        long phone;
        public string Id
        {
            get { return id; }
            set
            {
                if (value != "")
                    id = value;
            }
        }
        public string Fname
        {
            get { return fname; }
            set
            {
                if (value != "")
                    fname = value;
            }
        }
        public string Lname
        {
            get { return lname; }
            set
            {
                if (value != "")
                    lname = value;
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
        public long Phone
        {
            get { return phone; }
            set
            {
                if (value >0)
                    phone = value;
            }
        }
        public Parents(string id1,string fn,string ln,string de,int phon)
        {
            Id = id1;
            Fname = fn;
            Lname = ln;
            Des = de;
            Phone = phon;
        }
        public Parents(string emid)
        {
            Id = emid;
        }
        public Parents()
        {

        }
      
    }
}
