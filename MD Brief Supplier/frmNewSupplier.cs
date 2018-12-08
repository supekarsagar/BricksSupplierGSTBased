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
    public partial class frmNewSupplier : Form
    {
        //SqlConnection conn = null;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();

        public frmNewSupplier()
        {
            InitializeComponent();
            //loadID();
        }

        void loadID()
        {
            try
            {
                //conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
                conn.Open();
                string str = "SELECT MAX(sid) FROM tblSupplier";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr[0].ToString());
                        id += 1;
                        txtID.Text = id.ToString();
                    }
                }
                else
                {
                    txtID.Text = "1";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }
        void reset()
        {
            txtID.Text = "";
            txtSupplierName.Text = "";
            txtMobileNumber.Text = "";
            rtbOfficeAddress.Text = "";
            rtbAddress.Text = "";
            txtGSTNumber.Text = "";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtSupplierName.Text=="")
            {
                MessageBox.Show("Please Enter Supplier Name");
                txtSupplierName.Focus();
                return;
            }
            if (txtMobileNumber.Text == "")
            {
                MessageBox.Show("Please Enter Mobile Number");
                txtMobileNumber.Focus();
                return;
            }
            if (txtGSTNumber.Text == "")
            {
                MessageBox.Show("Please Enter your GST Number");
                txtGSTNumber.Focus();
                return;
            }
            if (rtbAddress.Text == "")
            {
                MessageBox.Show("Please Enter Address");
                rtbAddress.Focus();
                return;
            }
            if (rtbOfficeAddress.Text == "")
            {
                MessageBox.Show("Enter office address");
                rtbOfficeAddress.Focus();
                return;
            }
            try
            {
                //conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
                conn.Open();
                int sid = Convert.ToInt32(txtID.Text);
                double mobno = Convert.ToDouble(txtMobileNumber.Text);
                string cb = "insert into tblSupplier(sid, sname, smobno, sgstno, saddress, soaddress) VALUES ('" + sid + "','" + txtSupplierName.Text + "','" + mobno + "','" + txtGSTNumber.Text + "','" + rtbAddress.Text + "','" + rtbOfficeAddress.Text + "')";

                cmd = new SqlCommand(cb);
                cmd.Connection = conn;
                int res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res != -1)
                {
                    MessageBox.Show("Record Added successfully", "Success", MessageBoxButtons.OK);
                    reset();
                    loadID();
                    LoadSupplierRecord();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }

        /*private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        */
        private void frmNewSupplier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblSupplier' table. You can move, or remove it, as needed.
            this.tblSupplierTableAdapter.Fill(this.dataSet1.tblSupplier);
            loadID();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtID.Text = dr.Cells[0].Value.ToString();
            txtSupplierName.Text = dr.Cells[1].Value.ToString();
            txtMobileNumber.Text = dr.Cells[2].Value.ToString();
            txtGSTNumber.Text = dr.Cells[3].Value.ToString();
            rtbAddress.Text = dr.Cells[4].Value.ToString();
            rtbOfficeAddress.Text = dr.Cells[5].Value.ToString();

            btnSubmit.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadID();
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

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
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
        private void LoadSupplierRecord()
        {
            try
            {
                DataTable Supplier = new DataTable();
                SqlDataAdapter SupplierAdapter;
                //SqlConnection myConnect = new SqlConnection(DBConn);
                conn.Open();

                string strCommandText = "SELECT sid, sname, smobno, sgstno, saddress, soaddress FROM tblSupplier";

                SupplierAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(SupplierAdapter);

                Supplier.Clear();
                SupplierAdapter.Fill(Supplier);

                if (Supplier.Rows.Count > 0)
                    dataGridView1.DataSource = Supplier;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_record();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSubmit.Enabled = true;
        }
        void delete_record()
        {
            try
            {

                int RowsAffected = 0;
                int id = Convert.ToInt32(txtID.Text);
                conn.Open();
                string cq = "DELETE FROM tblSupplier WHERE sid=" + id + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = conn;
                RowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();				// Reset All fields.
                    LoadSupplierRecord(); 	// Refreseh Gridview.
                    loadID();
                    txtSupplierName.Focus();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update_record();
        }
        void update_record()
        {
            if(txtSupplierName.Text=="")
            {
                MessageBox.Show("Please Enter Supplier Name");
                txtSupplierName.Focus();
                return;
            }
            if (txtMobileNumber.Text == "")
            {
                MessageBox.Show("Please Enter Mobile Number");
                txtMobileNumber.Focus();
                return;
            }
            if (txtGSTNumber.Text == "")
            {
                MessageBox.Show("Please Enter your GST Number");
                txtGSTNumber.Focus();
                return;
            }
            if (rtbAddress.Text == "")
            {
                MessageBox.Show("Please Enter Address");
                rtbAddress.Focus();
                return;
            }
            if (rtbOfficeAddress.Text == "")
            {
                MessageBox.Show("Enter office address");
                rtbOfficeAddress.Focus();
                return;
            }
            try
            {
                conn.Open();
                int res;
                int sid = Convert.ToInt32(txtID.Text);
                double mobno = Convert.ToDouble(txtMobileNumber.Text);
                string cb1 = "update tblSupplier set sname='"+txtSupplierName.Text+"',smobno='"+mobno+"',sgstno='"+txtGSTNumber.Text+"',saddress='"+rtbAddress.Text+"',soaddress='"+rtbOfficeAddress.Text+"' where sid= '"+sid+"'";
                cmd = new SqlCommand(cb1);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSubmit.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    reset();
                    loadID();
                    LoadSupplierRecord();
                    txtSupplierName.Focus();
                }
                else
                {
                    MessageBox.Show("Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
