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
    public partial class personal_account : Form
    {
        public personal_account()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("اسم المستخدم أو كلمة المرور خطأ الرجاء التأكد منها وشكراً ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {


                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("SELECT * FROM manager WHERE  ((u= @user_name)and(p=@password))", mycon);
                SqlParameter p = new SqlParameter("@user_name", textBox1.Text);
                SqlParameter p1 = new SqlParameter("@password", textBox2.Text);

                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                mycom.Parameters.Add(p1);
                SqlDataReader myreader = mycom.ExecuteReader();
                if (myreader.HasRows == false)
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور  خطأ الرجاء التأكد منه وشكراً ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    mycon.Close();
                }

                else
                {
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    button1.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text=="" ||textBox5.Text==""||textBox3.Text=="")
                 MessageBox.Show("اسم المستخدم أو كلمة المرور خطأ الرجاء التأكد منها وشكراً ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else if (textBox4.Text == textBox5.Text)
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("UPDATE manager SET [u] = @u, [p] = @p", mycon);
                mycom.CommandType = CommandType.Text;
                SqlParameter p = new SqlParameter("@u",textBox3.Text);
                SqlParameter p1 = new SqlParameter("@p",textBox4.Text);
                mycom.Parameters.Add(p);
                mycom.Parameters.Add(p1);
                SqlDataReader myreader = mycom.ExecuteReader();



                MessageBox.Show("تم تعديل اسم المستخدم وكلمة المرور بنجاح ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
                MessageBox.Show("اسم المستخدم أو كلمة المرور خطأ الرجاء التأكد منها وشكراً ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

        }


        

        private void patient_account_Load(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
