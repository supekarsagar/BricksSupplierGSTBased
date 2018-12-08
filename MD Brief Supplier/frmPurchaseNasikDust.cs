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
    public partial class frmPurchaseNasikDust : Form
    {

        public frmPurchaseNasikDust()
        {
            InitializeComponent();
        }

        void loadID()
        {

        }
        void reset()
        {
            txtID.Text = "";
            cmbVehicleType.SelectedIndex = 0;
            cmbBhattiType.SelectedIndex = 0;
            txtRate.Text = "";
            txtNumberOfTrips.Text = "";
            txtAmount.Text = "";
        }
        void check()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Get supplier ID");
                btnGetSupplierData.Focus();
                return;
            }
            if (cmbVehicleType.SelectedItem == null)
            {
                MessageBox.Show("Please select vehicle type");
                cmbVehicleType.Focus();
                return;
            }

            if (cmbBhattiType.SelectedItem == null)
            {
                MessageBox.Show("Please select Roaster type");
                cmbVehicleType.Focus();
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter Rate");
                txtRate.Focus();
                return;
            }
            if (txtNumberOfTrips.Text == "")
            {
                MessageBox.Show("Please Enter number of Trips");
                txtNumberOfTrips.Focus();
                return;
            }
        }
        private void btnGetSupplierData_Click(object sender, EventArgs e)
        {
            //new frmRecordSuppiler().Show();
        }

        void cal()
        {
            
           if(txtRate.Text != "" && txtNumberOfTrips.Text!= "")
           {
                double rate = Convert.ToDouble(txtRate.Text);
                double trips = Convert.ToDouble(txtNumberOfTrips.Text);
                txtAmount.Text = (rate * trips).ToString();
            }
           if (txtRate.Text == "" || txtNumberOfTrips.Text == "")
           {
               txtAmount.Text = "0";
           }
            
        }
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtNumberOfTrips_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtNumberOfTrips_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            check();
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

        private void frmPurchaseNasikDust_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
