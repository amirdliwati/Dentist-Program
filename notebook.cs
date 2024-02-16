using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dentist_program
{
    public partial class notebook : Form
    {
        public notebook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom = new SqlCommand("Select id,pname,jdate,alls from sessions where (jdate=@jdate) ", mycon);
            
            SqlParameter p = new SqlParameter("@jdate", Convert .ToDateTime( textBox1.Text));
            mycom.CommandType = CommandType.Text;
            
            mycom.Parameters.Add(p);
            SqlDataReader myreader = mycom.ExecuteReader();
           
            if (myreader.HasRows == false)
            {
                MessageBox.Show("التاريخ خاطئ الرجاء التأكد منه");
            }
            else
            {
                while (myreader.Read())
                {
                    dataGridView1.Rows.Add(myreader[0], myreader[1], myreader[2],myreader[3]);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        

       
    }
}
