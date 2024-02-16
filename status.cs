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
    public partial class status : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        


        
        public status()
        {
            InitializeComponent();
        }

     

        private void status_Load(object sender, EventArgs e)
        {
            
            idTextBox.Text = menu.y.ToString();
            pnameTextBox.Text = menu.y1.ToString();



        }

        private void statusBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom2 = new SqlCommand("select * from status where (id = @id)", mycon);
            SqlParameter p10 = new SqlParameter("@id",idTextBox.Text);
            mycom2.CommandType = CommandType.Text;
            mycom2.Parameters.Add(p10);
            SqlDataReader myreader = mycom2.ExecuteReader();
            if (myreader.HasRows )
            {
                MessageBox.Show("عذراً هذا المريض حالته مسجلة الرجاء التأكد", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon.Close();
            }
            else if (primary_cTextBox.Text=="" || testTextBox.Text=="" || comboBox1.Text=="" || comboBox2.Text=="")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                SqlConnection mycon1 = new SqlConnection(Class1.x);
                mycon1.Open();
                SqlCommand mycom1 = new SqlCommand("INSERT INTO status ([id], [pname], [primary_c], [disease], [status], [test]) VALUES (@id, @pname, @primary_c, @disease, @status, @test)", mycon1);
                SqlParameter p = new SqlParameter("@id", Convert.ToInt32(idTextBox.Text));
                SqlParameter p1 = new SqlParameter("@pname", pnameTextBox.Text);
                SqlParameter p2 = new SqlParameter("@primary_c", primary_cTextBox.Text);
                SqlParameter p3 = new SqlParameter("@disease", comboBox1.Text);
                SqlParameter p4 = new SqlParameter("@status", comboBox2.Text);
                SqlParameter p5 = new SqlParameter("@test", testTextBox.Text);
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(p);
                mycom1.Parameters.Add(p1);
                mycom1.Parameters.Add(p2);
                mycom1.Parameters.Add(p3);
                mycom1.Parameters.Add(p4);
                mycom1.Parameters.Add(p5);
                SqlDataReader myreader1 = mycom1.ExecuteReader();
                

                
                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom2 = new SqlCommand("select * from status where (id = @id)", mycon);
            SqlParameter p = new SqlParameter("@id",idTextBox.Text);
            mycom2.CommandType = CommandType.Text;
            mycom2.Parameters.Add(p);
            SqlDataReader myreader = mycom2.ExecuteReader();
            if (myreader.HasRows == false)
            {
                MessageBox.Show("عذراً لا يوجد معلومات عن هذا المريض", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon.Close();
            }
            else
            {
                myreader.Close();
                SqlCommand mycom1 = new SqlCommand("select id,pname,primary_c,disease,status,test from status where (pname = @name)", mycon);
                SqlParameter s = new SqlParameter("@name", pnameTextBox.Text);
                mycom1.CommandType = CommandType.Text;
                mycom1.Parameters.Add(s);
                SqlDataReader MyReader = mycom1.ExecuteReader();

                while (MyReader.Read())
                {
                    idTextBox.Text = MyReader[0].ToString();
                    pnameTextBox.Text = MyReader[1].ToString();
                    primary_cTextBox.Text = MyReader[2].ToString();
                    comboBox1.Text = MyReader[3].ToString();
                    comboBox2.Text = MyReader[4].ToString();
                    testTextBox.Text = MyReader[5].ToString();

                }
                mycon.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection mycon1 = new SqlConnection(Class1.x);
            mycon1.Open();
            SqlCommand mycom1 = new SqlCommand("select * from status where (id=@id)", mycon1);
            SqlParameter p1 = new SqlParameter("@id", idTextBox.Text);
            mycom1.CommandType = CommandType.Text;
            mycom1.Parameters.Add(p1);
            SqlDataReader myreader1 = mycom1.ExecuteReader();
            if (myreader1.HasRows == false)
            {
                MessageBox.Show("لا يوجد معلومات لهذا المريض كي يتم حذفها", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon1.Close();
            }
            else
            {
                if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
                {
                    SqlConnection mycon = new SqlConnection(Class1.x);
                    mycon.Open();
                    SqlCommand mycom = new SqlCommand("delete from status where (id = @id) ", mycon);
                    SqlParameter p = new SqlParameter("@id", idTextBox.Text);
                    mycom.CommandType = CommandType.Text;
                    mycom.Parameters.Add(p);
                    SqlDataReader myreader = mycom.ExecuteReader();

                    MessageBox.Show("تم الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    pnameTextBox.Text = "";
                    primary_cTextBox.Text = "";
                    testTextBox.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection mycon1 = new SqlConnection(Class1.x);
            mycon1.Open();
            SqlCommand mycom1 = new SqlCommand("select * from status where (id=@id)", mycon1);
            SqlParameter p10 = new SqlParameter("@id", idTextBox.Text);
            mycom1.CommandType = CommandType.Text;
            mycom1.Parameters.Add(p10);
            SqlDataReader myreader1 = mycom1.ExecuteReader();
            if (myreader1.HasRows == false)
            {
                MessageBox.Show("هذا المريض غير موجود", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                mycon1.Close();
            }
            else if (primary_cTextBox.Text == "" || testTextBox.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else
            {
                if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد التعديل", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
                {
                    SqlConnection mycon = new SqlConnection(Class1.x);
                    mycon.Open();
                    SqlCommand mycom = new SqlCommand("UPDATE status SET [id] = @id, [pname] = @pname, [primary_c] = @primary_c, [disease] = @disease, [status] = @status, [test] = @test WHERE (([id] = @Original_id))", mycon);
                    SqlParameter p = new SqlParameter("@id", Convert.ToInt32(idTextBox.Text));
                    SqlParameter p1 = new SqlParameter("@pname", pnameTextBox.Text);
                    SqlParameter p2 = new SqlParameter("@primary_c", primary_cTextBox.Text);
                    SqlParameter p3 = new SqlParameter("@disease", comboBox1.Text);
                    SqlParameter p4 = new SqlParameter("@status", comboBox2.Text);
                    SqlParameter p5 = new SqlParameter("@test", testTextBox.Text);
                    SqlParameter p6 = new SqlParameter("@Original_id",Convert.ToInt32( idTextBox.Text));
                    mycom.CommandType = CommandType.Text;
                    mycom.Parameters.Add(p);
                    mycom.Parameters.Add(p1);
                    mycom.Parameters.Add(p2);
                    mycom.Parameters.Add(p3);
                    mycom.Parameters.Add(p4);
                    mycom.Parameters.Add(p5);
                    mycom.Parameters.Add(p6);
                    SqlDataReader myreader = mycom.ExecuteReader();
                    MessageBox.Show("تم التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }

            }
        }

       
    }
}
