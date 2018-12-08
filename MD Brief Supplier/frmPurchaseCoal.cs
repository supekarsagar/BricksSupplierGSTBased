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
    public partial class frmPurchaseCoal : Form
    {
        public frmPurchaseCoal()
        {
            InitializeComponent();
        }

        void reset()
        {
            txtID.Text = "";
            txtBillNo.Text = "";
            txtQuantity.Text = "";
            txtRate.Text = "";
            txtAmount.Text = "";
            txtGST.Text = "5";
            txtTransportation.Text = "";
            txtTotalTransportation.Text = "";
            txtTotalAmount.Text = "";

        }
        void check()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Enter Supplier ID", "Error");
                btnGetSupplierData.Focus();
                return;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Error");
                txtQuantity.Focus();
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter Rate", "Error");
                txtRate.Focus();
                return;
            }
            if (txtGST.Text == "")
            {
                MessageBox.Show("Please Enter GST", "Error");
                txtGST.Focus();
                return;
            }
            if (txtTransportation.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Error");
                txtTransportation.Focus();
                return;
            }

        }
        private void btnGetSupplierData_Click(object sender, EventArgs e)
        {
            // new frmRecordSuppiler().Show();
        }

        void cal()
        {
            try
            {
                double qty = Convert.ToDouble(txtQuantity.Text);
                double rate = Convert.ToDouble(txtRate.Text);
                double amt = qty * rate;
                txtAmount.Text = amt.ToString();
                double gst = Convert.ToDouble(txtGST.Text);
                double tmp_tot_amt = ((amt * gst) / 100) + amt;
                double trans = Convert.ToDouble(txtTransportation.Text);
                double tot_trans = qty * trans;
                txtTotalTransportation.Text = tot_trans.ToString();
                double tot_amt = tmp_tot_amt + tot_trans;
                txtTotalAmount.Text = tot_amt.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check();

            int id = Convert.ToInt32(txtID.Text);
            int billno = Convert.ToInt32(txtBillNo.Text);

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtGST_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtTransportation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cal();
                double qty = Convert.ToDouble(txtQuantity.Text);
                double trans = Convert.ToDouble(txtTransportation.Text);
                txtTotalTransportation.Text = (qty * trans).ToString();
            }
            catch (Exception)
            {
            }
        }

        private void frmPurchaseCoal_Load(object sender, EventArgs e)
        {
            txtQuantity.Focus();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtTransportation_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            check();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Select ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGetSupplierData.Focus();
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
