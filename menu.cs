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
    public partial class menu : Form
    {
        internal static string y,y1;
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
       

        public menu()
        {
            InitializeComponent();
        }

        private void تشخيصالمريضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                MessageBox.Show("الرجاء اختيار المريض الذي تريد إضافة معلومات  عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
                else
            {
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand com = new SqlCommand("select * from patient_account where (id=@id and pname=@pname)",mycon);
            SqlParameter p = new SqlParameter("@id",textBox1.Text);
            SqlParameter p1 = new SqlParameter("@pname",textBox2.Text);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(p);
            com.Parameters.Add(p1);
            SqlDataReader myreader = com.ExecuteReader();
                if (myreader.HasRows==false)
                {
                    MessageBox.Show("الرجاء اختيار المريض الذي تريد إضافة معلومات  عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon.Close();
           }
            else{
                mycon.Close();
            y = textBox1.Text;
            y1 = textBox2.Text;
            status frm = new status();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            }
        }}



        private void الجلساتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("الرجاء اختيار المريض الذي تريد إضافة معلومات  عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand com = new SqlCommand("select * from patient_account where (id=@id and pname=@pname)", mycon);
                SqlParameter p = new SqlParameter("@id", textBox1.Text);
                SqlParameter p1 = new SqlParameter("@pname", textBox2.Text);
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                com.Parameters.Add(p1);
                SqlDataReader myreader = com.ExecuteReader();
                if (myreader.HasRows == false)
                {
                    MessageBox.Show("الرجاء اختيار المريض الذي تريد إضافة معلومات  عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    mycon.Close();
                }
                else
                {
                    mycon.Close();
                    y = textBox1.Text;
                    y1 = textBox2.Text;
                    sessions frm = new sessions();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void الوصفةالطبيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("الرجاء اختيار المريض الذي تريد إضافة معلومات  عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand com = new SqlCommand("select * from patient_account where (id=@id and pname=@pname)", mycon);
                SqlParameter p = new SqlParameter("@id", textBox1.Text);
                SqlParameter p1 = new SqlParameter("@pname", textBox2.Text);
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                com.Parameters.Add(p1);
                SqlDataReader myreader = com.ExecuteReader();
                if (myreader.HasRows == false)
                {
                    MessageBox.Show("الرجاء اختيار المريض الذي تريد إضافة معلومات  عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    mycon.Close();
                }
                else
                {
                    mycon.Close();
                    y = textBox1.Text;
                    y1 = textBox2.Text;
                    prescription frm = new prescription();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void الدفتراليوميToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notebook frm = new notebook();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void التواريخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dates frm = new dates();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void المخابرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                    labs frm = new labs();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom = new SqlCommand("select id from patient_account where id=" + textBox1.Text, mycon);
            SqlDataReader myreader = mycom.ExecuteReader();

            if (myreader.HasRows)
            {
                MessageBox.Show("رقم المريض موجود مسبقا الرجاء ادخال رقم غير موجود ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon.Close();
            }

            else if (textBox2.Text == "" || dateTimePicker1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text=="")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("INSERT INTO patient_account ([id], [pname], [sdate], [paids], [alls], [discount]) VALUES (@id, @pname, @sdate, @paids, @alls, @discount)", mycon1);
                SqlParameter p = new SqlParameter("@id",Convert.ToInt32( textBox1.Text));
                SqlParameter p1 = new SqlParameter("@pname", textBox2.Text);
                SqlParameter p2 = new SqlParameter("@sdate",Convert.ToDateTime( dateTimePicker1.Text));
                SqlParameter p3 = new SqlParameter("@paids",Convert.ToInt32( textBox3.Text));
                SqlParameter p4 = new SqlParameter("@alls",Convert.ToInt32( textBox4.Text));
                SqlParameter p5 = new SqlParameter("@discount",Convert.ToInt32( textBox5.Text));
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p);
                mycom1.Parameters.Add(p1);
                mycom1.Parameters.Add(p2);
                mycom1.Parameters.Add(p3);
                mycom1.Parameters.Add(p4);
                mycom1.Parameters.Add(p5);
                SqlDataReader myreader1 = mycom1.ExecuteReader();
              
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Text = "";
                mycon1.Close();

                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                con.ConnectionString = Class1.x;
                con.Open();
                cm.Connection = con;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "select max(id) from patient_account ";
                int m = (int)cm.ExecuteScalar() + 1;
                textBox1.Text = m.ToString();
                con.Close();
            }
        }

        private void menu_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Class1.x;
            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(id) from patient_account ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();

            toolStripStatusLabel1.Text = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            toolStripStatusLabel2.Text = Convert.ToString(dateTimePicker1.Value.Hour) + ":" + Convert.ToString(dateTimePicker1.Value.Minute) + ":" + Convert.ToString(dateTimePicker1.Value.Second); 
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم المريض الذي تريد البحث عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {

                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("select * from patient_account where (pname=@pname) ", mycon);
                SqlParameter p = new SqlParameter("@pname", textBox6.Text);
                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                SqlDataReader myreader = mycom.ExecuteReader();

                if (myreader.HasRows == false)
                {
                    MessageBox.Show("هذا الاسم غير موجود", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    textBox6.Text = "";

                    mycon.Close();
                }
                else
                {
                    myreader.Close();

                    SqlCommand mycom1 = new SqlCommand("select id,pname,sdate,paids,alls,discount from patient_account where (pname = @name)", mycon);
                    SqlParameter s = new SqlParameter("@name", textBox6.Text);
                    mycom1.CommandType = CommandType.Text;
                    mycom1.Parameters.Add(s);
                    SqlDataReader MyReader = mycom1.ExecuteReader();

                    while (MyReader.Read())
                    {
                        textBox1.Text = MyReader[0].ToString();
                        textBox2.Text = MyReader[1].ToString();
                        dateTimePicker1.Text = MyReader[2].ToString();
                        textBox3.Text = MyReader[3].ToString();
                        textBox4.Text = MyReader[4].ToString();
                        textBox5.Text = MyReader[5].ToString();

                    }
                    mycon.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = "";
            con.ConnectionString = Class1.x;
            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(id) from patient_account ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("select * from prescription where (id = @id)", con);
            SqlParameter a = new SqlParameter("@id", Convert.ToInt32(textBox1.Text));
            com.CommandType = CommandType.Text;
            com.Parameters.Add(a);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows == true)
            {
                MessageBox.Show("الرجاء حذف الارتباطات الفرعية لهذا المريض في جدول الوصفات وشكراً");
                con.Close();
            }
            else
            {
                reader.Close();
                com.CommandText = "select * from sessions where (id = @id)";
                com.Connection = con;
                reader = com.ExecuteReader();
                if (reader.HasRows == true)
                {
                    MessageBox.Show("الرجاء حذف الارتباطات الفرعية لهذا المريض في جدول الجلسات وشكراً");
                    con.Close();
                }


                else
                {
                    con.Close();

                    SqlConnection mycon1 = new SqlConnection(Class1.x);
                    mycon1.Open();
                    SqlCommand mycom1 = new SqlCommand("select * from patient_account where (id=@id)", mycon1);
                    SqlParameter p1 = new SqlParameter("@id", textBox1.Text);
                    mycom1.CommandType = CommandType.Text;
                    mycom1.Parameters.Add(p1);
                    SqlDataReader myreader1 = mycom1.ExecuteReader();
                    if (myreader1.HasRows == false)
                    {
                        MessageBox.Show("هذا المريض غير موجود", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        mycon1.Close();
                    }
                    else
                    {
                        if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
                        {
                            SqlConnection mycon = new SqlConnection(Class1.x);
                            mycon.Open();
                            SqlCommand mycom = new SqlCommand("delete from patient_account where (id = @id) ", mycon);
                            SqlParameter p = new SqlParameter("@id", textBox1.Text);
                            mycom.CommandType = CommandType.Text;
                            mycom.Parameters.Add(p);
                            SqlDataReader myreader = mycom.ExecuteReader();

                            MessageBox.Show("تم الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            dateTimePicker1.Text = "";

                            con.ConnectionString = Class1.x;
                            con.Open();
                            cm.Connection = con;
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select max(id) from patient_account ";
                            int m = (int)cm.ExecuteScalar() + 1;
                            textBox1.Text = m.ToString();
                            con.Close();

                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection mycon1 = new SqlConnection(Class1.x);
            mycon1.Open();
            SqlCommand mycom1 = new SqlCommand("select * from patient_account where (id=@id)", mycon1);
            SqlParameter p10 = new SqlParameter("@id", textBox1.Text);
            mycom1.CommandType = CommandType.Text;
            mycom1.Parameters.Add(p10);
            SqlDataReader myreader1 = mycom1.ExecuteReader();
            if (myreader1.HasRows == false)
            {
                MessageBox.Show("هذا المريض غير موجود", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon1.Close();
            }
            else if (textBox2.Text == "" || dateTimePicker1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد التعديل", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
                {
                    SqlConnection mycon = new SqlConnection(Class1.x);
                    mycon.Open();
                    SqlCommand mycom = new SqlCommand("UPDATE patient_account SET [id] = @id, [pname] = @pname, [sdate] = @sdate, [paids] = @paids, [alls] = @alls, [discount] = @discount WHERE (([id] = @Original_id))", mycon);
                    SqlParameter p = new SqlParameter("@id", Convert.ToInt32(textBox1.Text));
                    SqlParameter p1 = new SqlParameter("@pname", textBox2.Text);
                    SqlParameter p2 = new SqlParameter("@sdate", Convert.ToDateTime(dateTimePicker1.Text));
                    SqlParameter p3 = new SqlParameter("@paids", Convert.ToInt32(textBox3.Text));
                    SqlParameter p4 = new SqlParameter("@alls", Convert.ToInt32(textBox4.Text));
                    SqlParameter p5 = new SqlParameter("@discount", Convert.ToInt32(textBox5.Text));
                    SqlParameter P6 = new SqlParameter("@Original_id",Convert.ToInt32(textBox1.Text));
                    mycom.CommandType = CommandType.Text;
                    mycom.Parameters.Add(p);
                    mycom.Parameters.Add(p1);
                    mycom.Parameters.Add(p2);
                    mycom.Parameters.Add(p3);
                    mycom.Parameters.Add(p4);
                    mycom.Parameters.Add(p5);
                    mycom.Parameters.Add(P6);
                    SqlDataReader myreader = mycom.ExecuteReader();
                    MessageBox.Show("تم التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker2.Value = Convert.ToDateTime(System.DateTime.Now); 
              toolStripStatusLabel1.Text = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;
              toolStripStatusLabel2.Text = Convert.ToString(dateTimePicker2.Value.Hour) + ":" + Convert.ToString(dateTimePicker2.Value.Minute) + ":" + Convert.ToString(dateTimePicker2.Value.Second); 
        
        }

        private void الحسابالشخصيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personal_account frm = new personal_account();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}
