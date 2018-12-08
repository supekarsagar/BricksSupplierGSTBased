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
    public partial class frmIncomeEntry : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader dr;
        int res = 0;
        int id;
        public frmIncomeEntry()
        {
            InitializeComponent();
        }

        void loadIncomeRecord()
        {
            string strCommandText = "SELECT incomeid as ID,tblIncome.cid as [CUSTOMER ID], cname as NAME, narration as NARRATION, amount as AMOUNT, gst AS GST, tot_amt AS [TOTAL AMOUNT], payee_by AS [PAYEE BY], method AS METHOD, date FROM tblIncome, tblCustomer WHERE tblIncome.cid=tblCustomer.cid ";
            DataTable Income = new DataTable();
            SqlDataAdapter IncomeAdapter;
            conn.Open();
            
            IncomeAdapter = new SqlDataAdapter(strCommandText, conn);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(IncomeAdapter);

            Income.Clear();
            IncomeAdapter.Fill(Income);

            if (Income.Rows.Count > 0)
                dataGridView2.DataSource = Income;
            conn.Close();
        }
        void loadIncomeId()
        {

            string str = "select max(incomeid) from tblIncome";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr[0].ToString());
                        id += 1;
                        txtIncomeID.Text = id.ToString();
                    }
                }
                else
                {
                    txtIncomeID.Text = "1";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Loading Bill Number");
            }

        }
        void check()
        {
            if (txtIncomeID.Text == "")
            {
                MessageBox.Show("Please Enter Bill No.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIncomeID.Focus();
                return;
            }
            if (txtNarration.Text == "")
            {
                MessageBox.Show("Please Enter Purpose", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNarration.Focus();
                return;
            }
            if (txtGST.Text == "")
            {
                MessageBox.Show("Please Enter GST Else type 0", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGST.Focus();
                return;
            }
            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Please Select Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //btnGetName.Focus();
                return;
            }
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Amount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return;
            }
            if (cmbPayeeBy.Text == "-- Please Select Option --")
            {
                MessageBox.Show("Please Select method !!!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPayeeBy.Focus();
                return;
            }
            if (cmbSelectMethod.Text == "")
            {
                MessageBox.Show("Please Select method !!!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSelectMethod.Focus();
                return;
            }
        }

        void cal()
        {
            if (txtAmount.Text != "" && txtGST.Text != "")
            {
                double amt = Convert.ToInt32(txtAmount.Text);
                double gst = Convert.ToDouble(txtGST.Text);
                double tot_amt = amt+(amt * ((gst)/100));
                txtTotalAmount.Text = tot_amt.ToString();
            }
            if (txtAmount.Text == "" || txtGST.Text == "")
            {
                txtTotalAmount.Text = "0";
            }
        }
        void reset()
        {
            txtIncomeID.Clear();
            //txtBillNo.Text = "";
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtNarration.Text = "";
            txtAmount.Clear();
            txtGST.Text = "5";
            txtTotalAmount.Clear();
            cmbPayeeBy.SelectedIndex = -1;
            cmbSelectMethod.SelectedIndex = -1;
            dateTimePicker1.Text = DateTime.Now.Date.ToShortDateString().ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string payee_by = cmbPayeeBy.SelectedItem.ToString();
            if (payee_by.Equals("By Hand"))
            {
                cmbSelectMethod.SelectedIndex = -1;
                cmbSelectMethod.Enabled = false;
            }
            if (payee_by.Equals("By Bank"))
            {
                
                cmbSelectMethod.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void frmIncomeEntry_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblIncome' table. You can move, or remove it, as needed.
            //this.tblIncomeTableAdapter.Fill(this.dataSet1.tblIncome);
            // TODO: This line of code loads data into the 'dataSet1.tblCustomer' table. You can move, or remove it, as needed.
            this.tblCustomerTableAdapter.Fill(this.dataSet1.tblCustomer);
            loadIncomeRecord();
            btnUpdate.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Hide();
            btnDelete.Hide();
            loadIncomeId();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            reset();
            loadIncomeId();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            check();
            int incomeid = Convert.ToInt32(txtIncomeID.Text);
            int cid = Convert.ToInt32(txtCustomerID.Text);
            string narration = txtNarration.Text;
            int amount = Convert.ToInt32(txtAmount.Text);
            double gst = Convert.ToDouble(txtGST.Text);
            double tot_amt = Convert.ToDouble(txtTotalAmount.Text);
            string payee_by = cmbPayeeBy.SelectedItem.ToString();
            string method = cmbSelectMethod.SelectedItem.ToString();
            string date = dateTimePicker1.Text;

            string income_entry = "INSERT INTO tblIncome (incomeid, cid, narration, amount, gst, tot_amt, payee_by, method, date) VALUES ('"+incomeid+"','"+cid+"','"+narration+"','"+amount+"','"+gst+"','"+tot_amt+"','"+payee_by+"','"+method+"','"+date+"')";
            try
            {
                conn.Open();
                cmd = new SqlCommand(income_entry, conn);
                res = cmd.ExecuteNonQuery();
                if (res != 0)
                {
                    MessageBox.Show("Record Saved Succssfully", "Success");
                    reset();
                    loadIncomeId();
                }
                else
                {
                    MessageBox.Show("Failed to Add a record", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Saving Income record");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            check();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtIncomeID.Text == "")
            {
                MessageBox.Show("Please Enter ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //btnGetID.Focus();
                return;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtCustomerID.Text = dr.Cells[0].Value.ToString();
            txtCustomerName.Text = dr.Cells[1].Value.ToString();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtGST_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
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
       
    }
}
