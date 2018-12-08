using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MD_Brief_Supplier
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            progressBar1.Visible = true;

            this.progressBar1.Value = this.progressBar1.Value + 1;
            if (this.progressBar1.Value == 10)
            {
                label3.Text = "Reading modules..";
                //MessageBox.Show("Reading Modules...");
            }
            else if (this.progressBar1.Value == 20)
            {
                label3.Text = "Loading.";
            }
            else if (this.progressBar1.Value == 40)
            {
                label3.Text = "Loading..";
            }
            else if (this.progressBar1.Value == 60)
            {
                label3.Text = "Loading...";
            }
            else if (this.progressBar1.Value == 80)
            {
                label3.Text = "Loading......";
            }
            else if (this.progressBar1.Value == 100)
            {
               
                timer1.Enabled = false;
                /*frmLogin frm = new frmLogin();
                frm.Show();
                */
                label3.Text = "Done.";
                 new frmLogin().Show();
                //MessageBox.Show("MDI Load");
                this.Hide();
            }
        }
    }
}
