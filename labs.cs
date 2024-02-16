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
    public partial class labs : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        public labs()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("INSERT INTO labs ([labid], [labn], [alls], [paids]) VALUES (@labid, @labn, @alls, @paids)", mycon);
                SqlParameter p = new SqlParameter("@labid", Convert.ToInt32(textBox1.Text));
                SqlParameter p1 = new SqlParameter("@labn", textBox2.Text);
                SqlParameter p2 = new SqlParameter("@alls", Convert.ToInt32(textBox3.Text));
                SqlParameter p3 = new SqlParameter("@paids", Convert.ToInt32(textBox4.Text));
                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                mycom.Parameters.Add(p1);
                mycom.Parameters.Add(p2);
                mycom.Parameters.Add(p3);

                SqlDataReader myreader = mycom.ExecuteReader();



                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                con.ConnectionString = Class1.x;
                con.Open();
                cm.Connection = con;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "select max(labid) from labs ";
                int m = (int)cm.ExecuteScalar() + 1;
                textBox1.Text = m.ToString();
                con.Close();
            }
        }


        private void labs_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Class1.x;
            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(labid) from labs ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       



        private void tabPage2_Enter(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand("select labid,labn,alls ,paids   from labs ", con);
                
                com.CommandType = CommandType.Text;
                

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    labsDataGridView.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
            }
        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        










        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("الرجاء إدخال رقم المخبر", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("select * from labs where (labid=@labid)", mycon1);
                SqlParameter p1 = new SqlParameter("@labid", textBox1.Text);
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p1);
                SqlDataReader myreader1 = mycom1.ExecuteReader();
                if (myreader1.HasRows == false)
                {
                    MessageBox.Show("هذا المخبر غير موجود", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    mycon1.Close();
                }
                else
                {
                    if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
                    {
                        SqlConnection mycon = new SqlConnection(Class1.x);
                        mycon.Open();
                        SqlCommand mycom = new SqlCommand("delete from labs where (labid=@labid)", mycon);
                        SqlParameter p = new SqlParameter("@labid", textBox1.Text);
                        mycom.CommandType = CommandType.Text;
                        mycom.Parameters.Add(p);
                        SqlDataReader myreader = mycom.ExecuteReader();
                        mycon.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        MessageBox.Show("تم الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        con.ConnectionString = Class1.x;
                        con.Open();
                        cm.Connection = con;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select max(labid) from labs ";
                        int m = (int)cm.ExecuteScalar() + 1;
                        textBox1.Text = m.ToString();
                        con.Close();

                    }
                }
            }
        }


        private void button8_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم المخبر الذي تريد البحث عنه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {

                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("select * from labs where (labn=@labn) ", mycon);
                SqlParameter p = new SqlParameter("@labn", textBox5.Text);
                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                SqlDataReader myreader = mycom.ExecuteReader();

                if (myreader.HasRows == false)
                {
                    MessageBox.Show("هذا الاسم غير موجود", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    textBox5.Text = "";

                    mycon.Close();
                }
                else
                {
                    myreader.Close();

                    SqlCommand mycom1 = new SqlCommand("select labid,labn,alls,paids from labs where (labn = @labn)", mycon);
                    SqlParameter s = new SqlParameter("@labn", textBox5.Text);
                    mycom1.CommandType = CommandType.Text;
                    mycom1.Parameters.Add(s);
                    SqlDataReader MyReader = mycom1.ExecuteReader();

                    while (MyReader.Read())
                    {
                        textBox1.Text = MyReader[0].ToString();
                        textBox2.Text = MyReader[1].ToString();

                        textBox3.Text = MyReader[2].ToString();
                        textBox4.Text = MyReader[3].ToString();


                    }
                    mycon.Close();
                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            con.Open();
            cm.Connection = con;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select max(labid) from labs ";
            int m = (int)cm.ExecuteScalar() + 1;
            textBox1.Text = m.ToString();
            con.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            SqlConnection mycon1 = new SqlConnection(Class1.x);
            mycon1.Open();
            SqlCommand mycom1 = new SqlCommand("select * from labs where (labid=@labid)", mycon1);
            SqlParameter p10 = new SqlParameter("@labid", textBox1.Text);
            mycom1.CommandType = CommandType.Text;
            mycom1.Parameters.Add(p10);
            SqlDataReader myreader1 = mycom1.ExecuteReader();
            if (myreader1.HasRows == false)
            {
                MessageBox.Show("هذا المخبر غير موجود", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon1.Close();
            }
            else if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد التعديل", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
                {
                    SqlConnection mycon = new SqlConnection(Class1.x);
                    mycon.Open();
                    SqlCommand mycom = new SqlCommand("UPDATE labs SET [labid] = @labid, [labn] = @labn, [alls] = @alls, [paids] = @paids WHERE (([labid] = @Original_labid))", mycon);
                    SqlParameter p = new SqlParameter("@labid", Convert.ToInt32(textBox1.Text));
                    SqlParameter p1 = new SqlParameter("@labn", textBox2.Text);

                    SqlParameter p2 = new SqlParameter("@paids", Convert.ToInt32(textBox4.Text));
                    SqlParameter p3 = new SqlParameter("@alls", Convert.ToInt32(textBox3.Text));

                    SqlParameter p4 = new SqlParameter("@Original_labid", Convert.ToInt32(textBox1.Text));
                    mycom.CommandType = CommandType.Text;
                    mycom.Parameters.Add(p);
                    mycom.Parameters.Add(p1);
                    mycom.Parameters.Add(p2);
                    mycom.Parameters.Add(p3);
                    mycom.Parameters.Add(p4);

                    SqlDataReader myreader = mycom.ExecuteReader();
                    MessageBox.Show("تم التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }

            }
        }

       

        
        }
    }

