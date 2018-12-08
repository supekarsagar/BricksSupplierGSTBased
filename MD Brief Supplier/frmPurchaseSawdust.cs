using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace MD_Brief_Supplier
{
    public partial class frmPurchaseSawdust : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        int res = 0;
        public frmPurchaseSawdust()
        {
            InitializeComponent();
        }

        void loadID()
        {
            string str = "SELECT MAX(SawDustId) FROM tblPurchaseSawDust";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr[0].ToString());
                        id += 1;
                        txtSawDustId.Text = id.ToString();
                    }
                }
                else
                {
                    txtSawDustId.Text = "1";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Exception is unhandled");
            }
            finally
            {
                conn.Close();
            }
        }
        void reset()
        {
            txtSupplierId.Text = "";
            txtSupplierId.Text = "";
            lblSupplierName.Text = "Supplier Name";
            txtQuantity.Text = "";
            txtRate.Text = "";
            txtAmount.Text = "";
            txtGST.Text = "5";
            txtTransportation.Text = "";
            txtTotalTransportation.Text = "";
            txtTotalAmount.Text = "";
            dtpNowDate.Text = DateTime.Now.Date.ToShortDateString();
        }
       
        void cal()
        {
            double amt = 0, rate = 0, qty = 0, gst = 0, tmp_tot_amt = 0, trans = 0, tot_trans = 0, tot_amt = 0;
            if (txtQuantity.Text != "" && txtRate.Text!="")
            {
                qty = Convert.ToDouble(txtQuantity.Text);
                rate = Convert.ToDouble(txtRate.Text);
                amt = qty * rate;
                txtAmount.Text = amt.ToString();
            }
            if (txtQuantity.Text == "" || txtRate.Text == "")
            {
                txtAmount.Text = "0";
            }
            if (txtGST.Text != "" && txtTransportation.Text != "")
            {
                gst = Convert.ToDouble(txtGST.Text);
                tmp_tot_amt = ((amt * gst) / 100) + amt;
                trans = Convert.ToDouble(txtTransportation.Text);
                tot_trans = qty * trans;
                txtTotalTransportation.Text = tot_trans.ToString();
                tot_amt = tmp_tot_amt + tot_trans;
                txtTotalAmount.Text = tot_amt.ToString();
            }
            if (txtGST.Text == "" || txtTransportation.Text == "")
            {
                txtTotalTransportation.Text = "0";
                txtTotalAmount.Text = "0";
            }
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

        private void txtTransportation_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtTransportation_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSupplierId.Text == "")
            {
                MessageBox.Show("Please retrieve supplier ID");
                txtSupplierId.Focus();
                return;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter quantity");
                txtQuantity.Focus();
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter rate");
                txtRate.Focus();
                return;
            }
            if (txtGST.Text == "")
            {
                MessageBox.Show("Please Enter GST");
                txtGST.Focus();
                return;
            }
            if (txtTransportation.Text == "")
            {
                MessageBox.Show("Please Enter transportation");
                txtTransportation.Focus();
                return;
            }
            int id = Convert.ToInt32(txtSawDustId.Text);
            int sid = Convert.ToInt32(txtSupplierId.Text);
            double qty = Convert.ToInt32(txtQuantity.Text);
            double rate = Convert.ToInt32(txtRate.Text);
            double amt = Convert.ToInt32(txtAmount.Text);
            double gst = Convert.ToInt32(txtGST.Text);
            double transportation = Convert.ToInt32(txtTransportation.Text);
            double tot_transportation = Convert.ToInt32(txtTotalTransportation.Text);
            double tot_amt = Convert.ToInt32(txtTotalAmount.Text);
            
            try
            {
                conn.Open();
                string ins = "insert into tblPurchaseSawDust(SawDustId, sid, qty, rate, amount, gst, transportation, tot_transportation, tot_amount, date) values ('" + id + "','" + sid + "','" + qty + "','" + rate + "','" + amt + "','" + gst + "','" + transportation + "','" + tot_transportation + "','" + tot_amt + "','"+dtpNowDate.Text+"')";
                cmd = new SqlCommand(ins, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record added successfully", "Success");
                    reset();
                    loadID();
                    LoadSawDustRecord();// update gridview

                }
                else
                {
                    MessageBox.Show("Fail to add record.", "Error");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error : while savig data");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (txtSawDustId.Text == "")
            {
                MessageBox.Show("Please Get supplier Sawdust ID");
                txtSawDustId.Focus();
                return;
            }
            if (txtSupplierId.Text == "")
            {
                MessageBox.Show("Please retrieve supplier ID");
                txtSupplierId.Focus();
                return;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter quantity");
                txtQuantity.Focus();
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter rate");
                txtRate.Focus();
                return;
            }
            if (txtGST.Text == "")
            {
                MessageBox.Show("Please Enter GST");
                txtGST.Focus();
                return;
            }
            if (txtTransportation.Text == "")
            {
                MessageBox.Show("Please Enter transportation");
                txtTransportation.Focus();
                return;
            }
            int id = Convert.ToInt32(txtSawDustId.Text);
            int sid = Convert.ToInt32(txtSupplierId.Text);
            double qty = Convert.ToInt32(txtQuantity.Text);
            double rate = Convert.ToInt32(txtRate.Text);
            double amt = Convert.ToInt32(txtAmount.Text);
            double gst = Convert.ToInt32(txtGST.Text);
            double transportation = Convert.ToInt32(txtTransportation.Text);
            double tot_transportation = Convert.ToInt32(txtTotalTransportation.Text);
            double tot_amt = Convert.ToInt32(txtTotalAmount.Text);

            try
            {
                conn.Open();
                string ins = "UPDATE tblPurchaseSawDust SET sid='"+sid+"', qty='"+qty+"', rate='"+rate+"',amount='"+amt+"',gst='"+gst+"',transportation='"+transportation+"',tot_transportation='"+tot_transportation+"',tot_amount='"+tot_amt+"', date='"+dtpNowDate.Text+"' WHERE SawDustId='"+id+"'";
                cmd = new SqlCommand(ins, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record updated successfully", "Success");
                    reset();
                    loadID();
                    LoadSawDustRecord();// update gridview
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSubmit.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Fail to update record.", "Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error : while updating data");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSupplierId.Text == "")
            {
                MessageBox.Show("Please Select ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSupplierId.Focus();
                return;
            }
            int id = Convert.ToInt32(txtSupplierId.Text);
            string str = "DELETE FROM tblPurchaseSawDust WHERE psdid='"+id+"'";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record Deleted.", "Success", MessageBoxButtons.OK);
                    reset();
                    loadID();
                    LoadSawDustRecord();        // referesh grid view;
                    btnSubmit.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to Delete", "Error: While Deleting record", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Deleting Record", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadID();
            txtQuantity.Focus();
        }
        private void LoadSawDustRecord()
        {

            DataTable SawDust = new DataTable();
            SqlDataAdapter SawDustAdapter;
            try
            {
                conn.Open();
                string strCommandText = "SELECT SawDustId as [ID], tblPurchaseSawDust.sid as [ Supplier Id], sname as [NAME],  qty as [QUANTITY], rate as [RATE], amount as [AMOUNT], gst as [GST], transportation as [TRANSPORTATION], tot_transportation as [TOTAL TRANSPORTATION], tot_amount as [TOTAL AMOUNT],date as [DATE]  FROM dbo.tblPurchaseSawDust, dbo.tblSupplier WHERE dbo.tblPurchaseSawDust.sid = dbo.tblSupplier .sid";

                SawDustAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(SawDustAdapter);

                SawDust.Clear();
                SawDustAdapter.Fill(SawDust);

                if (SawDust.Rows.Count > 0)
                    dataGridView2.DataSource = SawDust;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While loading Records");
            }
            finally
            {
                conn.Close();
            }
        }
        private void frmPurchaseSawdust_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblPurchaseSawDust' table. You can move, or remove it, as needed.
           // this.tblPurchaseSawDustTableAdapter.Fill(this.dataSet1.tblPurchaseSawDust);
            // TODO: This line of code loads data into the 'dataSet1.tblSupplier' table. You can move, or remove it, as needed.
            this.tblSupplierTableAdapter.Fill(this.dataSet1.tblSupplier);
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            loadID();
            LoadSawDustRecord();

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtSupplierId.Text=dr.Cells[0].Value.ToString();
            lblSupplierName.Text=dr.Cells[1].Value.ToString();

            txtQuantity.Focus();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        void ExportToExcel()
        {
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView2.RowCount - 1;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            txtSawDustId.Text = Convert.ToInt32(dr.Cells[0].Value.ToString()).ToString();
            txtSupplierId.Text = Convert.ToInt32(dr.Cells[1].Value.ToString()).ToString();
            lblSupplierName.Text = dr.Cells[2].Value.ToString();
            txtQuantity.Text = Convert.ToInt32(dr.Cells[3].Value.ToString()).ToString();
            txtRate.Text = Convert.ToInt32(dr.Cells[4].Value.ToString()).ToString();
            txtAmount.Text = Convert.ToInt32(dr.Cells[5].Value.ToString()).ToString();
            txtGST.Text = Convert.ToInt32(dr.Cells[6].Value.ToString()).ToString();
            txtTransportation.Text = Convert.ToInt32(dr.Cells[7].Value.ToString()).ToString();
            txtTotalTransportation.Text = Convert.ToInt32(dr.Cells[8].Value.ToString()).ToString();
            txtTotalAmount.Text = Convert.ToInt32(dr.Cells[9].Value.ToString()).ToString();

            btnSubmit.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtQuantity.Focus();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {/*
            DataTable SawDust = new DataTable();
            SqlDataAdapter SawDustAdapter;
            try
            {
                conn.Open();
                string strCommandText = "SELECT SawDustId as [ID], tblPurchaseSawDust.sid as [ Supplier Id], sname as [NAME],  qty as [QUANTITY], rate as [RATE], amount as [AMOUNT], gst as [GST], transportation as [TRANSPORTATION], tot_transportation as [TOTAL TRANSPORTATION], tot_amount as [TOTAL AMOUNT],date as [DATE]  FROM dbo.tblPurchaseSawDust, dbo.tblSupplier WHERE dbo.tblPurchaseSawDust.sid = dbo.tblSupplier .sid and sname like '"+txtSearchBox.Text+"%'";

                SawDustAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(SawDustAdapter);

                SawDust.Clear();
                SawDustAdapter.Fill(SawDust);

                if (SawDust.Rows.Count > 0)
                    dataGridView1.DataSource = SawDust;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Searching Records");
            }
            finally
            {
                conn.Close();
            }*/
        }
    }
}
