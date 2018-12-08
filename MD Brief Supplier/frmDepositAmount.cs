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
    public partial class frmDepositAmount : Form
    {
       
        public frmDepositAmount()
        {
            InitializeComponent();
            
        }
        void reset()
        {
            txtID.Text = "";
            txtTotalAmount.Text = "";
            txtBalance.Text = "";
            txtNewBalance.Text = "";
            txtPaidAmount.Text = "";
        }
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            
        
            try
            {
                if (txtPaidAmount.Text == "")
                {
                    txtNewBalance.Text = txtBalance.Text;
                }
                else
                {
                    double tmp = (Convert.ToDouble(txtBalance.Text)) - (Convert.ToDouble(txtPaidAmount.Text));
                    txtNewBalance.Text = tmp.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void frmDepositAmount_Load(object sender, EventArgs e)
        {
            txtPaidAmount.Focus();
            MessageBox.Show("" + dateTimePicker1.Value);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
