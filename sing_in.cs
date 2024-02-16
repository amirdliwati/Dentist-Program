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
    public partial class sing_in : Form
    {
        public sing_in()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    
                    MessageBox.Show("أهلاً بك مرة أخرى", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    menu frm = new menu();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(MessageBox.Show("هل تريد الخروج؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                Close();
            }
        }
    }
}
