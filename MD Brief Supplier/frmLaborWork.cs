using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel =  Microsoft.Office.Interop.Excel;

namespace MD_Brief_Supplier
{
    public partial class frmLaborWork : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader rdr;

        public frmLaborWork()
        {
            InitializeComponent();
            
            
        }

        private void frmLaborWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        void LoadLaborWorkID()
        {
           string str = "SELECT MAX(lw_id) FROM tblLaborWork";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        int id = Convert.ToInt32(rdr[0].ToString());
                        id += 1;
                        txtLwid.Text = id.ToString();
                        //MessageBox.Show(dr[0].ToString(), "");
                    }
                }
                else
                {
                    txtLwid.Text = "1";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Loading ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        void LoadRecordRoasterMenu()
        {
            try
            {
                DataTable Roaster = new DataTable();
                SqlDataAdapter RoasterAdapter;

                string strCommandText = "SELECT Id, bno as Roaster_No, btype as Bricks_Type, byear as Year FROM tblRoaster WHERE bstatus='1'";

                RoasterAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(RoasterAdapter);

                Roaster.Clear();
                RoasterAdapter.Fill(Roaster);

                if (Roaster.Rows.Count > 0)
                    dataGridView3.DataSource = Roaster;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While loading Roaster in Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void update_stock()
        {

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            check();
            update_stock();

            try
            {
                conn.Open();
                int lwid = Convert.ToInt32(txtLwid.Text);
                double amt = Convert.ToDouble(txtAmount.Text);
                int collected_bricks = Convert.ToInt32(txtCollectedBricks.Text);
                int labor_id = Convert.ToInt32(txtLaborID.Text);
                int roaster_id = Convert.ToInt32(txtRoasterNumber.Text);
                int res;
                int res2;

                string cb = "insert into tblLaborWork(lw_id, lw_narration, lw_size, lw_amount, lw_collected_bricks, lw_date, lid, Id) VALUES ('" + lwid + "','" + rtbNarration.Text + "','" + cmbSize.Text + "','" + amt + "','" + collected_bricks + "','" + dateTimePicker1.Value.Date.ToShortDateString().ToString() + "','" + labor_id + "','" + roaster_id + "')";

                cmd = new SqlCommand(cb);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();

                int tot_stock = Convert.ToInt32(lblFinal_Stock.Text);
                string str = "update tblTmpStockBricks set Collected_Bricks = '"+tot_stock+"' where Roaster_Id = '"+roaster_id+"'";
                cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                if (res != -1)
                {
                    MessageBox.Show("Successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    LoadLaborWorkID();
                    loadLaborWorkRecord();
                    //LoadRecordServices();
                }
                else
                {
                    MessageBox.Show("Failed Execution", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // DO NOT HIDE OR DELETE txtAmount_TextChanged() METHOD .... ELSE YOU WILL GET ERROR .
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // accept only 0-9 not decimal
            AcceptNumberOnly(e);
        }

        private void txtJamaMaal_KeyPress(object sender, KeyPressEventArgs e)
        {
            AcceptNumberOnly(e);
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
        
        private void txtBhattiNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            AcceptNumberOnly(e);
        }

       
        private void frmLaborWork_Load(object sender, EventArgs e)
        {
            btnUpdate.Hide();
            btnDelete.Hide();
            try
            {
                // TODO: This line of code loads data into the 'dataSet1.tblLaborWork' table. You can move, or remove it, as needed.
                this.tblLaborWorkTableAdapter.Fill(this.dataSet1.tblLaborWork);
                // TODO: This line of code loads data into the 'dataSet1.tblBricks' table. You can move, or remove it, as needed.
                this.tblLaborTableAdapter.Fill(this.dataSet1.tblLabor);

                err_Labor_Id.Hide();
                err_Roaster_No.Hide();
                LoadLaborWorkID();        // Generate Next ID.
                LoadRecordRoasterMenu();    // 
                loadLaborWorkRecord();      // grid view 1. [ LABOR WORK]
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        void check()
        {
            if (txtLaborID.Text == "")
            {
                MessageBox.Show("Please Enter labor ID");
                dataGridView2.Focus();
                err_Labor_Id.Show();
                return;
            }
            if (cmbSize.Text == "-- Please Select Size --")
            {
                MessageBox.Show("Please Select size of Bricks.");
                cmbSize.Focus();
                return;
            }
            if (rtbNarration.Text == "")
            {
                MessageBox.Show("Please Enter Desciption else type NA");
                rtbNarration.Focus();
                return;
            }
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Amount");
                txtAmount.Focus();
                return;
            }

            if (txtCollectedBricks.Text == "")
            {
                MessageBox.Show("Please Enter Jama maal");
                txtCollectedBricks.Focus();
                return;
            }
            if (txtRoasterNumber.Text == "")
            {
                MessageBox.Show("Please Enter Roaster Number");
                dataGridView3.Focus();
                err_Roaster_No.Show();
                return;
            }

        }
        void reset()
        {
            err_Labor_Id.Hide();
            err_Roaster_No.Hide();
            lblFinal_Stock.Text = "";
            lblStockBricks.Text = "";
            txtLaborID.Text = "";
            txtLwid.Text = "";
            rtbNarration.Text = "NA";
            txtRoasterNumber.Text = "";
            txtAmount.Text = "";
            cmbSize.SelectedIndex = -1;
            txtCollectedBricks.Text = "";
            dateTimePicker1.Text = DateTime.Now.Date.ToShortDateString();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            LoadLaborWorkID();
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            check();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            txtLaborID.Text = dr.Cells[0].Value.ToString();
            err_Labor_Id.Show();
            err_Labor_Id.Text = dr.Cells[1].Value.ToString();
        }
        
        private void dataGridView3_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            txtRoasterNumber.Text = dr.Cells[1].Value.ToString();
            err_Roaster_No.Text =  "Year: " + dr.Cells[3].Value.ToString();
            cmbSize.Text = dr.Cells[2].Value.ToString();
            err_Roaster_No.Show();
            SqlDataReader datareader = null ;

            try
            {
                conn.Open();
                int roaster_no = Convert.ToInt32(txtRoasterNumber.Text);
                string str = " select Collected_Bricks from tblTmpStockBricks where Roaster_Id = '" + roaster_no + "'";
                cmd = new SqlCommand(str, conn);
                datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    lblStockBricks.Text = datareader[0].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }
        void loadLaborWorkRecord()
        {
            try
            {
                DataTable Labor_Work_Record = new DataTable();
                SqlDataAdapter Labor_Work_Adapter;
                // Here is error Solve This Errro;
                //string strCommandText = "SELECT lw_id AS ID , lw_narration AS NARRATION , lw_size AS SIZE, lw_amount AS AMOUNT, lw_collected_bricks AS COLLECTED_BRICKS, lw_date AS DATE, lw.lid LABOR_ID,lname AS LABOR_NAME, lw.Id AS ROASTER_ID, bno AS ROASTER_NUMBER from tblLabor l,tblLaborWork lw, tblRoaster r WHERE l.lid = lw.lid and r.Id=lw.Id";
                string strCommandText = "select lw_id as [ID], lw_narration as [NARRATION], lw_size AS [SIZE], lw_amount AS [AMOUNT], lw_collected_bricks AS [COLLECTION], lw_date AS [DATE], tblLaborWork.lid AS [LABOR ID],lname AS [NAME], Id AS [ROASTER NO.] from tblLaborWork, tblLabor where tblLabor.lid = tblLaborWork.lid ";

                Labor_Work_Adapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(Labor_Work_Adapter);

                Labor_Work_Record.Clear();
                Labor_Work_Adapter.Fill(Labor_Work_Record);

                if (Labor_Work_Record.Rows.Count > 0)
                    dataGridView1.DataSource = Labor_Work_Record;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While loading Labor Work.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void export_Click(object sender, EventArgs e)
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSubmit.Enabled = false;
            SqlDataReader datareader;
            try 
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];

                txtLwid.Text = Convert.ToInt32(dr.Cells[0].Value.ToString()).ToString();
                txtRoasterNumber.Text = dr.Cells[8].Value.ToString();
               
                try
                {
                    conn.Open();
                    int roaster_no = Convert.ToInt32(txtRoasterNumber.Text);
                    string str = " select Collected_Bricks from tblTmpStockBricks where Roaster_Id = '" + roaster_no + "'";
                    cmd = new SqlCommand(str, conn);
                    datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                        lblStockBricks.Text = datareader[0].ToString();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    conn.Close();
                }

                rtbNarration.Text = dr.Cells[1].Value.ToString();
                cmbSize.Text = dr.Cells[2].Value.ToString();
                txtAmount.Text = dr.Cells[3].Value.ToString();
                txtCollectedBricks.Text = dr.Cells[4].Value.ToString();
                dateTimePicker1.Text = dr.Cells[5].Value.ToString();
                txtLaborID.Text = dr.Cells[6].Value.ToString();
                err_Labor_Id.Text = dr.Cells[7].Value.ToString();
                
		
		        rtbNarration.Focus();
	        }
	        catch (Exception ex)
	        {
		        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_record();
        }
        void delete_record()
        {
            try
            {

                int RowsAffected = 0;
                int id = Convert.ToInt32(txtLwid.Text);
                conn.Open();
                string cq = "DELETE FROM tblLaborWork WHERE lw_id=" + id + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = conn;
                RowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();				// Reset All fields.
                    loadLaborWorkRecord(); 	// Refreseh Gridview.
                    LoadLaborWorkID();
                    rtbNarration.Focus();
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

        private void txtCollectedBricks_TextChanged(object sender, EventArgs e)
        {
            if (txtCollectedBricks.Text!="")
            {
                int collected_brick = Convert.ToInt32(txtCollectedBricks.Text);
                int available_brick = Convert.ToInt32(lblStockBricks.Text);
                int tot = collected_brick + available_brick;
                lblFinal_Stock.Text = tot.ToString();
            }
        }
    }
}
