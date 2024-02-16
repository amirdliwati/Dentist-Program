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
    public partial class prescription : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        public prescription()
        {
            InitializeComponent();
        }

        private void prescription_Load(object sender, EventArgs e)
        {

            con.ConnectionString = Class1.x;
            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(mid) from prescription ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();
            textBox2.Text = menu.y.ToString();
            textBox3.Text = menu.y1.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom2 = new SqlCommand("select * from prescription where (mid = @mid)", mycon);
            SqlParameter p15 = new SqlParameter("@mid", textBox1.Text);
            mycom2.CommandType = CommandType.Text;
            mycom2.Parameters.Add(p15);
            SqlDataReader myreader = mycom2.ExecuteReader();
            if (myreader.HasRows)
            {
                MessageBox.Show("عذراً هذا المريض وصفته مسجلة الرجاء التأكد", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon.Close();
            }
            else if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || dateTimePicker1.Text == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("INSERT INTO prescription ([mid], [id] , [pname], [mname], [notes], [m_s], [type] , [pdate]) VALUES (@mid, @id, @pname, @mname, @notes, @m_s, @type , @pdate)", mycon1);
                SqlParameter p = new SqlParameter("@mid", Convert.ToInt32(textBox1.Text));
                SqlParameter p1 = new SqlParameter("@id", Convert.ToInt32(textBox2.Text));
                SqlParameter p2 = new SqlParameter("@pname", textBox3.Text);
                SqlParameter p3 = new SqlParameter("@mname", textBox4.Text);
                SqlParameter p4 = new SqlParameter("@notes", textBox5.Text);
                SqlParameter p5 = new SqlParameter("@m_s", Convert.ToInt32(textBox6.Text));
                SqlParameter p6 = new SqlParameter("@type", textBox7.Text);
                SqlParameter p7 = new SqlParameter("@pdate", Convert.ToDateTime(dateTimePicker1.Text));
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p);
                mycom1.Parameters.Add(p1);
                mycom1.Parameters.Add(p2);
                mycom1.Parameters.Add(p3);
                mycom1.Parameters.Add(p4);
                mycom1.Parameters.Add(p5);
                mycom1.Parameters.Add(p6);
                mycom1.Parameters.Add(p7);
                SqlDataReader myreader1 = mycom1.ExecuteReader();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.Text = "";
                mycon1.Close();

                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                con.ConnectionString = Class1.x;
                con.Open();
                cm.Connection = con;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "select max(mid) from prescription ";
                int m = (int)cm.ExecuteScalar() + 1;
                textBox1.Text = m.ToString();
                con.Close();

                textBox2.Text = menu.y.ToString();
                textBox3.Text = menu.y1.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("يتم التعديل عن طريق تعديل البيانات بشكل مباشر وشكراً", "طريقة التعديل");
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            prescriptionDataGridView.Rows.Clear();
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom = new SqlCommand("select mid,id,pname,mname,notes,m_s,type,pdate from prescription where (id = @id)", mycon);
            SqlParameter p = new SqlParameter("@id", Convert.ToInt32(textBox2.Text));
            mycom.CommandType = CommandType.Text;
            mycom.Parameters.Add(p);
            SqlDataReader myreader = mycom.ExecuteReader();
            if (myreader.HasRows == false)
            {
                MessageBox.Show("لا يوجد وصفة لهذا المريض");

            }
            else
            {
                while (myreader.Read())
                {
                    prescriptionDataGridView.Rows.Add(myreader[0], myreader[1], myreader[2], myreader[3], myreader[4], myreader[5], myreader[6], myreader[7]);
                }
            }
            MessageBox.Show("يتم التعديل عن طريق تعديل البيانات بشكل مباشر وشكراً", "طريقة التعديل");
            MessageBox.Show("ليتم الحذف الرجاء الضغط بزر الفأرة الأيسر ضغطة مزدوجة على الوصفة التي تريد حذفها وشكراً", "طريقة الحذف");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ليتم الحذف الرجاء الضغط بزر الفأرة الأيسر ضغطة مزدوجة على الوصفة التي تريد حذفها وشكراً", "طريقة الحذف");


        }

        private void prescriptionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("delete from prescription where (mid=@mid)", mycon);
                SqlParameter p = new SqlParameter("@mid", Convert.ToInt32(prescriptionDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                SqlDataReader myreader = mycom.ExecuteReader();
                prescriptionDataGridView.Rows.Clear();
                SqlConnection mycon2 = new SqlConnection(Class1.x);
                mycon2.Open();
                SqlCommand mycom2 = new SqlCommand("select mid,id,pname,mname,notes,m_s,type,pdate from prescription where (id = @id)", mycon2);
                SqlParameter p2 = new SqlParameter("@id", Convert.ToInt32(textBox2.Text));
                mycom2.CommandType = CommandType.Text;
                mycom2.Parameters.Add(p2);
                SqlDataReader myreader2 = mycom2.ExecuteReader();
                if (myreader2.HasRows == false)
                {
                    MessageBox.Show("لا يوجد وصفة لهذا المريض");

                }
                else
                {
                    while (myreader2.Read())
                    {
                        prescriptionDataGridView.Rows.Add(myreader2[0], myreader2[1], myreader2[2], myreader2[3], myreader2[4], myreader2[5], myreader2[6], myreader2[7]);
                    }
                }

            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            con.ConnectionString = Class1.x;
            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(mid) from prescription ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();
            textBox2.Text = menu.y.ToString();
            textBox3.Text = menu.y1.ToString();
        }

        private void prescriptionDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString( prescriptionDataGridView.Rows[e.RowIndex].Cells[3].Value) == "" || Convert.ToString(  prescriptionDataGridView.Rows[e.RowIndex].Cells[4].Value) == "" || Convert.ToString( prescriptionDataGridView.Rows[e.RowIndex].Cells[5].Value) == "" || Convert.ToString( prescriptionDataGridView.Rows[e.RowIndex].Cells[6].Value) == "" || Convert.ToString( prescriptionDataGridView.Rows[e.RowIndex].Cells[7].Value) == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("UPDATE [dbo].[prescription] SET [mid] = @mid, [id] = @id, [pname] = @pname, [mname] = @mname, [notes] = @notes, [m_s] = @m_s, [type] = @type, [pdate] = @pdate WHERE (([mid] = @Original_mid))", mycon1);
                SqlParameter p = new SqlParameter("@mid", Convert.ToInt32(prescriptionDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                SqlParameter p1 = new SqlParameter("@id", Convert.ToInt32(prescriptionDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()));
                SqlParameter p2 = new SqlParameter("@pname", prescriptionDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                SqlParameter p3 = new SqlParameter("@mname", prescriptionDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
                SqlParameter p4 = new SqlParameter("@notes", prescriptionDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
                SqlParameter p5 = new SqlParameter("@m_s", Convert.ToInt32(prescriptionDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString()));
                SqlParameter p6 = new SqlParameter("@type", prescriptionDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString());
                SqlParameter p7 = new SqlParameter("@pdate", Convert.ToDateTime(prescriptionDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString()));

                SqlParameter p11 = new SqlParameter("@Original_mid", Convert.ToInt32(prescriptionDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p);
                mycom1.Parameters.Add(p1);
                mycom1.Parameters.Add(p2);
                mycom1.Parameters.Add(p3);
                mycom1.Parameters.Add(p4);
                mycom1.Parameters.Add(p5);
                mycom1.Parameters.Add(p6);
                mycom1.Parameters.Add(p7);

                mycom1.Parameters.Add(p11);
                SqlDataReader myreader1 = mycom1.ExecuteReader();
            }






        }
    }
}
