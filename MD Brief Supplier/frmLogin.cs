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
    public partial class frmLogin : Form
    {
        ConnectionString cs = new ConnectionString();
        frmMDI mdi = new frmMDI();
        public frmLogin()
        {
            InitializeComponent();
            label4.Text = DateTime.Today.ToShortDateString();
        }

        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please enter Username...","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if(textBox2.Text=="")
            {
                MessageBox.Show("Please enter Password...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            try 
            {
                
                SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
               // myConnection = new SqlConnection(cs.DBConn);

                
                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT username FROM tblRoasterOwner WHERE username = @username AND password = @password ", myConnection);
               
                SqlParameter username = new SqlParameter("@username", SqlDbType.VarChar);

                SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar);

                username.Value = textBox1.Text;
                password.Value = textBox2.Text;

                myCommand.Parameters.Add(username);
                myCommand.Parameters.Add(password);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    int i;
                    ProgressBar1.Visible = true;
                    ProgressBar1.Maximum = 5000;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Value = 4;
                    ProgressBar1.Step = 1;

                    for (i = 0; i <= 5000; i++)
                    {
                        ProgressBar1.PerformStep();
                    }

                    this.Hide();
                    mdi.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                    textBox1.Focus();
                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            /*
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();

            conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Backup\dBMaheshBricksSupplier.mdf;Integrated Security=True;Connect Timeout=30";
            cmd.Connection = conn;
            cmd.CommandText = "SELECT username, password FROM tblRoasterOwner";
            adapter.SelectCommand = cmd;
            
            if (username.Equals("admin") && pwd.Equals("admin"))
            {
                MessageBox.Show("WELCOME !!!", "SUCCESS");
                (this).Hide();
                MD_Bricks_Supplier.frmSplash sp = new MD_Bricks_Supplier.frmSplash();
                sp.Show();
               
                mdi.Show();
            }
            else
            {
                MessageBox.Show("FAILED !!!", "Alert");
                textBox1.Focus();
            }
    */
       
        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmForgotPassword().Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ProgressBar1.Visible = false;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
