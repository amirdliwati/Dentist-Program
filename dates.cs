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
    public partial class dates : Form
    {
        public dates()
        {
            InitializeComponent();
        }



        private void dates_Load(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || dateTimePicker1.Text == "" || textBox4.Text == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                datesDataGridView.Rows.Clear();
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("INSERT INTO dates ([pname], [visitd], [notes], [visit_t]) VALUES (@pname, @visitd, @notes, @visit_t)", mycon1);
                SqlParameter p = new SqlParameter("@pname", textBox1.Text);
                SqlParameter p1 = new SqlParameter("@visitd",Convert.ToDateTime( dateTimePicker1.Text));
                SqlParameter p2 = new SqlParameter("@notes", textBox2.Text);
                SqlParameter p3 = new SqlParameter("@visit_t",textBox4.Text);
                
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p);
                mycom1.Parameters.Add(p1);
                mycom1.Parameters.Add(p2);
                mycom1.Parameters.Add(p3);
                
                SqlDataReader myreader1 = mycom1.ExecuteReader();
               
                textBox1.Text = "";
                textBox2.Text = "";
                
                textBox4.Text = "";

                 dateTimePicker1.Text = "";

                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            datesDataGridView.Rows.Clear();
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom = new SqlCommand("Select pname,visitd,visit_t,notes from dates where (visitd=@visitd) ", mycon);

            SqlParameter p = new SqlParameter("@visitd", Convert.ToDateTime(textBox5.Text));
            mycom.CommandType = CommandType.Text;

            mycom.Parameters.Add(p);
            SqlDataReader myreader = mycom.ExecuteReader();

            if (myreader.HasRows == false)
            {
                MessageBox.Show("لا يوجد مواعيد في هذا التاريخ");
            }
            else
            {
                while (myreader.Read())
                {
                    datesDataGridView.Rows.Add(myreader[0],myreader[1],myreader[2],myreader[3]);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
