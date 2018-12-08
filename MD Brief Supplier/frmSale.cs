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
    public partial class frmSale : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader dr;

        public frmSale()
        {
            InitializeComponent();
        }

        void loadBillNo()
        {
            string str = "SELECT MAX(saleid) FROM tblSale";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str,conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        int id = Convert.ToInt32(dr[0].ToString());
                        id += 1;
                        txtBillNo.Text = id.ToString();
                    }
                }
                else
                {
                    txtBillNo.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While loading bill number");
            }
            finally
            {
                conn.Close();
            }
        }
        public void AcceptNumberOnly(KeyPressEventArgs e)
        { 
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        void cal()
        {
            try
            {
                double qty = Convert.ToDouble(txtQuantity.Text);
                double rate = Convert.ToDouble(txtRate.Text);
                double amt = ((double)qty / 1000) * rate;
                txtAmount.Text = amt.ToString();
                double gst = Convert.ToDouble(txtGST.Text) / 100;
                double tot_amt = (amt * gst) + amt;
                txtTotalAmount.Text = tot_amt.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Value");
            }
        }

        void reset()
        {
            txtBillNo.Text = "";
            txtID.Text = "";
            txtName.Clear();
            cmbSize.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtRoasterNo.Text = "";
            txtRate.Text = "";
            txtTotalAmount.Text = "";
            txtRemainsBricks.Clear();
            txtAvailable.Clear();
            txtPaidAmt.Clear();
            txtChange.Clear();
        }
        void check()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Enter customer ID");
                btnGetCustomerID.Focus();
                return;
            }
            if (cmbSize.Text == "-- Please Select Size --")
            {
                MessageBox.Show("Please Select size of bricks ");
                cmbSize.Focus();
                return;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity");
                txtQuantity.Focus();
                return;
            }
            if (txtRoasterNo.Text == "")
            {
                MessageBox.Show("Please select roaster number");
                //btnGetRoasterNo.Focus();
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter rate.");
                txtRate.Focus();
                return;
            }
        }
        void updateStockBricks()
        {
            try 
            {
                conn.Open();
                int roaster_id = Convert.ToInt32(txtRoasterNo.Text);
                int remains = Convert.ToInt32(txtRemainsBricks.Text);
                string str = "update tblTmpStockBricks set Collected_Bricks = '"+remains+"' where Roaster_Id = '"+roaster_id+"'";
                cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error: While Updating Bricks Stock");
            }
            finally
            {
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        { // submit button
            check();
            updateStockBricks();

            int saleid = Convert.ToInt32(txtBillNo.Text);
            int cid = Convert.ToInt32(txtID.Text);
            int roasterid = Convert.ToInt32(txtRoasterNo.Text);
            int qty = Convert.ToInt32(txtQuantity.Text);
            double rate = Convert.ToInt32(txtRate.Text);
            double gst = Convert.ToInt32(txtGST.Text);
            double tot_amt = Convert.ToInt32(txtTotalAmount.Text);
            double paid_amt = Convert.ToInt32(txtPaidAmt.Text);
            double change_amt = Convert.ToInt32(txtChange.Text);

            conn.Open();
            string str = "INSERT INTO tblSale (saleid, cid, roasterid, qty, rate, gst, tot_amt, paid_amt, change_amt, date) VALUES ('"+saleid+"','"+cid+"','"+roasterid+"','"+qty+"','"+rate+"','"+gst+"','"+tot_amt+"','"+paid_amt+"','"+change_amt+"','"+dateTimePicker1.Text+"')";
            cmd = new SqlCommand(str, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res != 0)
            {
                MessageBox.Show("Record Inserted Successfully", "Success", MessageBoxButtons.OK);
                reset();
                loadBillNo();
                btnGetCustomerID.Focus();
            }
        }
        
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            AcceptNumberOnly(e);
            if(txtRate.Text!="")
            cal();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            AcceptNumberOnly(e);
            if(txtQuantity.Text!="")
            cal();
        }

        private void txtGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            AcceptNumberOnly(e);
            if(txtGST.Text!="")
            cal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmNewCustomer().Show();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            AcceptNumberOnly(e);
        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            AcceptNumberOnly(e);
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblBricks' table. You can move, or remove it, as needed.
            try
            {
                this.tblBricksTableAdapter.Fill(this.dataSet1.tblBricks);
                loadBillNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While loading Roaster Menu");
            }
            txtID.Enabled = false;
            txtAmount.Enabled = false;
            txtTotalAmount.Enabled = false;
           
            btnDelete.Enabled = false;
            btnGetCustomerID.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new frmRecordCustomer().Show();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        { 

            if (txtQuantity.Text != "")
            {
                cal();
                double available = Convert.ToDouble(txtAvailable.Text);
                double qty = Convert.ToDouble(txtQuantity.Text);
                if (available < qty)
                {
                    MessageBox.Show("Bricks are not available in this Roaster", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantity.Clear();
                }
                double remains = available - qty;
                txtRemainsBricks.Text = remains.ToString();
            }
            
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if(txtRate.Text!="")
            cal();
        }

        private void txtGST_TextChanged(object sender, EventArgs e)
        {
            if(txtGST.Text!="")
            cal();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadBillNo();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            txtRoasterNo.Text = dr.Cells[1].Value.ToString();
            cmbSize.Text = dr.Cells[2].Value.ToString();
            int roaster_no = Convert.ToInt32(dr.Cells[1].Value.ToString());

            string tot_available = "select Collected_Bricks from tblTmpStockBricks WHERE Roaster_Id = '"+roaster_no+"'";
            try
            {
                conn.Open();
                cmd = new SqlCommand(tot_available, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtAvailable.Text = rdr[0].ToString();
                    txtRemainsBricks.Text = rdr[0].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:");
            }
            finally
            {
                conn.Close();
            }
        }

        private void txtPaidAmt_TextChanged(object sender, EventArgs e)
        {
            if (txtPaidAmt.Text != "")
            {
                double tot_amt = Convert.ToDouble(txtTotalAmount.Text);
                double paid_amt = Convert.ToDouble(txtPaidAmt.Text);
                double change_amt = tot_amt - paid_amt;
                txtChange.Text = change_amt.ToString();
            }
            else
            {
                txtChange.Text = "0";
            }
        }

       
        
    }
}
