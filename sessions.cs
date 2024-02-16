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
    public partial class sessions : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        public sessions()
        {
            InitializeComponent();
        }

        private void sessions_Load(object sender, EventArgs e)
        {

            con.ConnectionString = Class1.x;
            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(sid) from sessions ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();
            textBox2.Text = menu.y.ToString();
            textBox3.Text = menu.y1.ToString();
            textBox11.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom2 = new SqlCommand("select * from sessions where (sid = @sid)", mycon);
            SqlParameter p15 = new SqlParameter("@sid", textBox1.Text);
            mycom2.CommandType = CommandType.Text;
            mycom2.Parameters.Add(p15);
            SqlDataReader myreader = mycom2.ExecuteReader();
            if (myreader.HasRows)
            {
                MessageBox.Show("عذراً هذه الجلسة مسجلة الرجاء التأكد", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon.Close();
            }
            else if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("INSERT INTO [dbo].[sessions] ([sid], [id], [pname], [donej], [type], [touthn], [jdate], [session_s], [discount], [alls], [notes]) VALUES (@sid, @id, @pname, @donej, @type, @touthn, @jdate, @session_s, @discount, @alls, @notes)", mycon1);
                SqlParameter p = new SqlParameter("@sid", Convert.ToInt32(textBox1.Text));
                SqlParameter p1 = new SqlParameter("@id", Convert.ToInt32(textBox2.Text));
                SqlParameter p2 = new SqlParameter("@pname", textBox3.Text);
                SqlParameter p3 = new SqlParameter("@donej", textBox4.Text);
                SqlParameter p4 = new SqlParameter("@type", textBox5.Text);
                SqlParameter p5 = new SqlParameter("@touthn", Convert.ToInt32(textBox6.Text));
                SqlParameter p6 = new SqlParameter("@jdate", Convert.ToDateTime(textBox11.Text));
                SqlParameter p7 = new SqlParameter("@session_s", Convert.ToInt32(textBox7.Text));
                SqlParameter p8 = new SqlParameter("@discount", Convert.ToInt32(textBox8.Text));
                SqlParameter p9 = new SqlParameter("@alls", Convert.ToInt32(textBox9.Text));
                SqlParameter p10 = new SqlParameter("@notes", textBox10.Text);
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p);
                mycom1.Parameters.Add(p1);
                mycom1.Parameters.Add(p2);
                mycom1.Parameters.Add(p3);
                mycom1.Parameters.Add(p4);
                mycom1.Parameters.Add(p5);
                mycom1.Parameters.Add(p6);
                mycom1.Parameters.Add(p7);
                mycom1.Parameters.Add(p8);
                mycom1.Parameters.Add(p9);
                mycom1.Parameters.Add(p10);
                SqlDataReader myreader1 = mycom1.ExecuteReader();

                textBox10.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";


                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                con.ConnectionString = Class1.x;
                con.Open();
                cm.Connection = con;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "select max(sid) from sessions ";
                int m = (int)cm.ExecuteScalar() + 1;
                textBox1.Text = m.ToString();
                con.Close();
                textBox2.Text = menu.y.ToString();
                textBox3.Text = menu.y1.ToString();
                textBox11.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            }
        }



        private void tabPage2_Enter(object sender, EventArgs e)
        {
            sessionsDataGridView.Rows.Clear();
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom = new SqlCommand("select sid,id,pname,donej,type,touthn,jdate,session_s,discount,alls,notes from sessions where (id = @id)", mycon);
            SqlParameter p = new SqlParameter("@id", Convert.ToInt32(textBox2.Text));
            mycom.CommandType = CommandType.Text;
            mycom.Parameters.Add(p);
            SqlDataReader myreader = mycom.ExecuteReader();
            if (myreader.HasRows == false)
            {
                MessageBox.Show("لا يوجد جلسات لهذا المريض");

            }
            else
            {
                while (myreader.Read())
                {
                    sessionsDataGridView.Rows.Add(myreader[0], myreader[1], myreader[2], myreader[3], myreader[4], myreader[5], myreader[6], myreader[7], myreader[8], myreader[9], myreader[10]);
                }
            }
            MessageBox.Show("يتم التعديل عن طريق تعديل البيانات بشكل مباشر وشكراً", "طريقة التعديل");
            MessageBox.Show("ليتم الحذف الرجاء الضغط بزر الفأرة الأيسر ضغطة مزدوجة على الجلسة التي تريد حذفها وشكراً", "طريقة الحذف");

        }



        private void button3_Click(object sender, EventArgs e)
        {

            MessageBox.Show("يتم التعديل عن طريق تعديل البيانات بشكل مباشر وشكراً", "طريقة التعديل");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            con.ConnectionString = Class1.x;
            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(sid) from sessions ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();
            textBox2.Text = menu.y.ToString();
            textBox3.Text = menu.y1.ToString();
            textBox11.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }





        private void sessionsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("delete from sessions where (sid=@sid)", mycon);
                SqlParameter p = new SqlParameter("@sid", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                SqlDataReader myreader = mycom.ExecuteReader();
                myreader.Close();
                sessionsDataGridView.Rows.Clear();
                SqlConnection mycon2 = new SqlConnection(Class1.x);
                mycon2.Open();
                SqlCommand mycom2 = new SqlCommand("select sid,id,pname,donej,type,touthn,jdate,session_s,discount,alls,notes from sessions where (id = @id)", mycon2);
                SqlParameter p2 = new SqlParameter("@id", Convert.ToInt32(textBox2.Text));
                mycom2.CommandType = CommandType.Text;
                mycom2.Parameters.Add(p2);
                SqlDataReader myreader2 = mycom2.ExecuteReader();
                if (myreader2.HasRows == false)
                {
                    MessageBox.Show("لا يوجد جلسات لهذا المريض");

                }
                else
                {
                    while (myreader2.Read())
                    {
                        sessionsDataGridView.Rows.Add(myreader2[0], myreader2[1], myreader2[2], myreader2[3], myreader2[4], myreader2[5], myreader2[6], myreader2[7], myreader2[8], myreader2[9], myreader2[10]);
                    }
                }



            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("ليتم الحذف الرجاء الضغط بزر الفأرة الأيسر ضغطة مزدوجة على الجلسة التي تريد حذفها وشكراً", "طريقة الحذف");
        }

        private void sessionsDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToString( sessionsDataGridView.Rows[e.RowIndex].Cells[3].Value) == "" || Convert.ToString( sessionsDataGridView.Rows[e.RowIndex].Cells[4].Value) == "" || Convert.ToString( sessionsDataGridView.Rows[e.RowIndex].Cells[5].Value) == "" || Convert.ToString( sessionsDataGridView.Rows[e.RowIndex].Cells[7].Value) == "" || Convert.ToString( sessionsDataGridView.Rows[e.RowIndex].Cells[8].Value) == "" ||Convert.ToString( sessionsDataGridView.Rows[e.RowIndex].Cells[9].Value) == "" || Convert.ToString( sessionsDataGridView.Rows[e.RowIndex].Cells[10].Value) == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("UPDATE [dbo].[sessions] SET [sid] = @sid, [id] = @id, [pname] = @pname, [donej] = @donej, [type] = @type, [touthn] = @touthn, [jdate] = @jdate, [session_s] = @session_s, [discount] = @discount, [alls] = @alls, [notes] = @notes WHERE (([sid] = @Original_sid))", mycon1);
                SqlParameter p = new SqlParameter("@sid", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                SqlParameter p1 = new SqlParameter("@id", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()));
                SqlParameter p2 = new SqlParameter("@pname", sessionsDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                SqlParameter p3 = new SqlParameter("@donej", sessionsDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
                SqlParameter p4 = new SqlParameter("@type", sessionsDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
                SqlParameter p5 = new SqlParameter("@touthn", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString()));
                SqlParameter p6 = new SqlParameter("@jdate", Convert.ToDateTime(sessionsDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString()));
                SqlParameter p7 = new SqlParameter("@session_s", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString()));
                SqlParameter p8 = new SqlParameter("@discount", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString()));
                SqlParameter p9 = new SqlParameter("@alls", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString()));
                SqlParameter p10 = new SqlParameter("@notes", sessionsDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString());
                SqlParameter p11 = new SqlParameter("@Original_sid", Convert.ToInt32(sessionsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p);
                mycom1.Parameters.Add(p1);
                mycom1.Parameters.Add(p2);
                mycom1.Parameters.Add(p3);
                mycom1.Parameters.Add(p4);
                mycom1.Parameters.Add(p5);
                mycom1.Parameters.Add(p6);
                mycom1.Parameters.Add(p7);
                mycom1.Parameters.Add(p8);
                mycom1.Parameters.Add(p9);
                mycom1.Parameters.Add(p10);
                mycom1.Parameters.Add(p11);
                SqlDataReader myreader1 = mycom1.ExecuteReader();
            }






















        }
    }
}
