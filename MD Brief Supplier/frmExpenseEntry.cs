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
    public partial class frmExpenseEntry : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader dr;
        int res = 0;
        int id;
        public frmExpenseEntry()
        {
            InitializeComponent();
        }

        void loadExpenseRecord()
        {
            DataTable Expences = new DataTable();
            SqlDataAdapter ExpenseAdapter;

            string strCommandText = "SELECT eid as [ID], bill_no as [BILL NO.], payee_for as [PAYEE FOR], id as [ID], amount as [AMOUNT], creditedby as [CREDITED BY], date as [DATE], bankname as [BANK NAME], narration as NARRATION, chequeno as [CHEQUE NO.], accountno as [ACCOUNT No.], chequedate as [CHEQUE DATE] FROM tblExpense";
            try
            {
                conn.Open();
                ExpenseAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ExpenseAdapter);

                Expences.Clear();
                ExpenseAdapter.Fill(Expences);

                if (Expences.Rows.Count > 0)
                    dataGridView2.DataSource = Expences;
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
        void loadExpenseID()
        {
            string str = "SELECT MAX(eid) FROM tblExpense";
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
                        txtExpenseID.Text = id.ToString();
                    }
                }
                else
                {
                    txtExpenseID.Text = "1";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Loading Expense ID");
            }
            finally
            {
                conn.Close();
            }
        }
        void loadBillNo()
        {
            int billNo;
            string str = "SELECT MAX(bill_no) FROM tblExpense";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        billNo = Convert.ToInt32(dr[0].ToString());
                        billNo += 1;
                        txtBillNo.Text = id.ToString();
                    }
                }
                else
                {
                    txtBillNo.Text = "1";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Loading Bill Number");
            }
            finally
            {
                conn.Close();
            }
        }
        void reset()
        {
            txtExpenseID.Clear();
            cmdPayeeFor.Text = "-- Select Payee For --";
            txtID.Clear();
            txtName.Clear();
            txtAmount.Clear();
            txtBillNo.Clear();
            cmdCreditedBy.Text = "-- Please Select Type --";
            dtpNowDate.Text = DateTime.Now.Date.ToShortDateString();
            txtBanckName.Clear();
            txtChequeNo.Clear();
            txtAccountNumber.Clear();
            txtNarration.Text = "Not Available";
            dtpChequeDate.Text = DateTime.Now.Date.ToShortDateString();
        }
        void bindSupplierRecord()
        {
            //MessageBox.Show("Supplier Data");
            DataTable Supplier = new DataTable();
            SqlDataAdapter SupplierAdapter;

            string strCommandText = "SELECT sid as ID, sname as NAME, smobno as [CONTACT No.], saddress as [ADDRESS] FROM tblSupplier";
            try
            {
                conn.Open();
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
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        void bindServiceProviderRecord()
        {
           // MessageBox.Show("Service provider Data");
            DataTable ServiceProvider = new DataTable();
            SqlDataAdapter ServiceProviderAdapter;

            string strCommandText = "SELECT spid as [ID], spname as [NAME],sname as [SERVICE]  FROM tblServiceProvider sp, tblServices s WHERE sp.service_id = s.sid";
            try
            {
                conn.Open();
                ServiceProviderAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ServiceProviderAdapter);

                ServiceProvider.Clear();
                ServiceProviderAdapter.Fill(ServiceProvider);

                if (ServiceProvider.Rows.Count > 0)
                    dataGridView1.DataSource = ServiceProvider;
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

        void bindLaborRecord()
        {
            DataTable Labor = new DataTable();
            SqlDataAdapter LaborAdapter;

            string strCommandText = "SELECT lid as [ID], lname as [NAME], lmobno as [CONTACT NO.] FROM tblLabor";
            try
            {
                conn.Open();
                LaborAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(LaborAdapter);

                Labor.Clear();
                LaborAdapter.Fill(Labor);

                if (Labor.Rows.Count > 0)
                    dataGridView1.DataSource = Labor;
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
        void check()
        {
         

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lblCreditedBy = cmdCreditedBy.SelectedItem.ToString();
            if (lblCreditedBy.Equals("By Cash"))
            {
                txtBanckName.Enabled = false; txtBanckName.Text = "NA";
                txtAccountNumber.Enabled = false; txtAccountNumber.Text = "0";
                txtChequeNo.Enabled = false; txtChequeNo.Text = "0";
                dtpChequeDate.Enabled = false; dtpChequeDate.Text = DateTime.Now.Date.ToShortDateString();

            } 
            if (lblCreditedBy.Equals("By Bank"))
            {
                txtBanckName.Enabled = true; txtBanckName.Clear();
                txtAccountNumber.Enabled = true; txtAccountNumber.Clear();
                txtChequeNo.Enabled = true; txtChequeNo.Clear();
                dtpChequeDate.Enabled = true;
            }
        }

        private void frmExpenseEntry_Load(object sender, EventArgs e)
        {
            //dateTimePicker1.Text=DateTime.
           // MessageBox.Show("Current Date : "+DateTime.Now);

            txtBanckName.Enabled = false ;
            txtAccountNumber.Enabled = false;
            txtChequeNo.Enabled = false;
            dtpChequeDate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            loadExpenseID();
            loadBillNo();
            loadExpenseRecord();
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error: While Saving Data",MessageBoxButtons.OK);
            
            }
        }
        */
      
        private void cmdPayeeFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            if (cmdPayeeFor.SelectedItem.ToString() == "Labor")
            {
                bindLaborRecord();
            }
            if (cmdPayeeFor.SelectedItem.ToString() == "Service Provider")
            {
                bindServiceProviderRecord();
            }
            if (cmdPayeeFor.SelectedItem.ToString() == "Supplier")
            {
                bindSupplierRecord();
            }
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtID.Text = dr.Cells[0].Value.ToString();
            txtName.Text = dr.Cells[1].Value.ToString();
        }
       
        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadBillNo();
            loadExpenseID();
        }

         
        
        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtBillNo.Text == "")
            {
                MessageBox.Show("Please Enter ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //payee for
            if (cmdPayeeFor.Text == "-- Select Payee For --")
            {
                MessageBox.Show("Please Select Payee for.");
                cmdPayeeFor.Focus();
                return;
            }
            if (cmdCreditedBy.Text == "By Bank" && (txtBanckName.Text=="" || txtChequeNo.Text=="" || txtAccountNumber.Text=="" || dtpChequeDate.Text==""))
            {
                MessageBox.Show("Please fill all information regarding the bank","Bank Information Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtBanckName.Focus();
                return;
            }
            if (txtNarration.Text == "")
            {
                MessageBox.Show("Please Enter some description.");
                txtNarration.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Amount.");
                txtAmount.Focus();
                return;
            }
            if (cmdCreditedBy.Text == "-- Please Select Type --")
            {
                MessageBox.Show("Please Enter Amount.");
                cmdCreditedBy.Focus();
                return;
            }
            int expenseid = Convert.ToInt32(txtExpenseID.Text);
            int id = Convert.ToInt32(txtID.Text);
            string payee_for = cmdPayeeFor.Text;
            double amt = Convert.ToDouble(txtAmount.Text);
            int billno = Convert.ToInt32(txtExpenseID.Text);
            string credited_by = cmdCreditedBy.Text;
            string dt = dtpNowDate.Text;
            string bankname = "";
            double chequeno = 0;
            string accno = "";
            string chequedt = "";
            string narration = txtNarration.Text;
            if (cmdCreditedBy.Text == "By Bank")
            {
                bankname = txtBanckName.Text;
                chequeno = Convert.ToDouble(txtChequeNo.Text);
                accno = txtAccountNumber.Text;
                chequedt = dtpChequeDate.Text;
            }
            string str = "INSERT INTO tblExpense (eid, bill_no, payee_for, id, amount, creditedby, date, bankname, narration, chequeno, accountno, chequedate) VALUES ('"+expenseid+"','"+billno+"','"+payee_for+"','"+id+"','"+amt+"','"+credited_by+"','"+dt+"','"+bankname+"','"+narration+"','"+chequeno+"','"+accno+"','"+chequedt+"')";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record Added Successflly","Success");
                    reset();
                    loadBillNo();
                    loadExpenseID();
                    //loadGridViewRecord();
                }
                else
                {
                    MessageBox.Show("Failed to Add Record");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Saving Data");
            }
            finally
            {
                conn.Close();
            }      
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtBillNo.Text == "")
            {
                MessageBox.Show("Please Enter ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //payee for
            if (cmdPayeeFor.Text == "-- Select Payee For --")
            {
                MessageBox.Show("Please Select Payee for.");
                cmdPayeeFor.Focus();
                return;
            }
            if (txtNarration.Text == "")
            {
                MessageBox.Show("Please Enter some description.");
                txtNarration.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Amount.");
                txtAmount.Focus();
                return;
            }
            if (cmdCreditedBy.Text == "-- Please Select Type --")
            {
                MessageBox.Show("Please Enter Amount.");
                cmdCreditedBy.Focus();
                return;
            }
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSubmit.Enabled = true; 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSubmit.Enabled= true;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            txtExpenseID.Text = dr.Cells[0].Value.ToString();
            txtBillNo.Text = dr.Cells[1].Value.ToString();
            cmdPayeeFor.Text = dr.Cells[2].Value.ToString();
            txtID.Text = dr.Cells[3].Value.ToString();
            txtAmount.Text = dr.Cells[4].Value.ToString();
            cmdCreditedBy.Text = dr.Cells[5].Value.ToString();
            dtpNowDate.Text = dr.Cells[6].Value.ToString();
            txtBanckName.Text = dr.Cells[7].Value.ToString();
            txtNarration.Text = dr.Cells[8].Value.ToString();
            txtChequeNo.Text = dr.Cells[9].Value.ToString();
            txtAccountNumber.Text = dr.Cells[10].Value.ToString();
            dtpChequeDate.Text = dr.Cells[11].Value.ToString();
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
