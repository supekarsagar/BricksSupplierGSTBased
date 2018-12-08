using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MD_Brief_Supplier
{
    public partial class frmForgotPassword : Form
    {
        ConnectionString cs = new ConnectionString();
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter your favorite color.");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter New Password.");
                textBox2.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Confirm your Password.");
                textBox3.Focus();
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password must be same.");
                textBox3.Focus();
                textBox3.Text = "";
                return;
            }
            
            try
            {/*
                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                conn.ConnectionString = cs.DBConn;
                cmd.Connection = conn;

                cmd.CommandText = "SELECT count(*) as count FROM tblRoasterOwner WHERE answer = '"+textBox1.Text+"'";
                conn.Open();
               // reader = cmd.ExecuteScalar();

                while (reader.Read())
                {
                    
                }*/
            }
            catch(Exception)
            {

            }
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
