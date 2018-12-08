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
    public partial class frmNewCustomer : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

        public frmNewCustomer()
        {
            InitializeComponent();
            loadID();
        }

        void loadID()
        {
            // string insert = "select max(cid) from tblCustomer";
            try
            {
                conn.Open();
                string s = "select max(cid) from tblCustomer";
                SqlCommand cmd = new SqlCommand(s, conn);
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
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void LoadCustomerRecord()
        {
            // Data Table to store employee data
            DataTable Customer = new DataTable();

            // Keeps track of which row in Gridview
            // is selected
            //DataGridViewRow currentRow = null;

            SqlDataAdapter CustomerAdapter;

            //retrieve connection information info from App.config

            //STEP 1: Create connection
            SqlConnection myConnect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
            //STEP 2: Create command
            string strCommandText = "SELECT cid, cname , cmobno, cgstno, caddress FROM tblCustomer";
            //string strCommandText = "SELECT ID, NAME, DOB, MOBNO, EMAIL, PASSWORD FROM STUDENT";

            CustomerAdapter = new SqlDataAdapter(strCommandText, myConnect);

            //command builder generates Select, update, delete and insert SQL
            // statements for MedicalCentreAdapter
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(CustomerAdapter);
            // Empty Customer Table first
            Customer.Clear();
            // Fill Employee Table with data retrieved by data adapter
            // using SELECT statement
            CustomerAdapter.Fill(Customer);

            // if there are records, bind to Grid view & display
            if (Customer.Rows.Count > 0)
                dataGridView1.DataSource = Customer;
        }
        protected void reset()
        {
            txtID.Text = "";
           // loadID();
            txtCustomerName.Text = "";
            txtContactNumber.Text = "";
            txtGSTNumber.Text = "";
            rtbAddress.Text = "";
        }
        void check()
        {
            if (txtCustomerName.Text == "Name Here...")
            {
                MessageBox.Show("Please Enter Customer Name.");
                txtCustomerName.Focus();
                return;
            }
            if (txtContactNumber.Text == "")
            {
                MessageBox.Show("Please Enter Contact Number.");
                txtContactNumber.Focus();
                return;
            }
            if (rtbAddress.Text == "")
            {
                MessageBox.Show("Please Enter Address.");
                rtbAddress.Focus();
                return;
            }

        }
        
        // Submit Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "Name Here...")
            {
                MessageBox.Show("Please Enter Customer Name.");
                txtCustomerName.Focus();
                return;
            }
            if (txtContactNumber.Text == "")
            {
                MessageBox.Show("Please Enter Contact Number.");
                txtContactNumber.Focus();
                return;
            }
            if (rtbAddress.Text == "")
            {
                MessageBox.Show("Please Enter Address.");
                rtbAddress.Focus();
                return;
            }

                conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
                SqlCommand insert = new SqlCommand("insert into tblCustomer(cid, cname, cmobno, cgstno,caddress) values(@Id, @Name, @Mobno, @gstno, @address)", conn);
                insert.Parameters.AddWithValue("@Id", Convert.ToInt32(txtID.Text));
                insert.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                insert.Parameters.AddWithValue("@Mobno", Convert.ToDouble(txtContactNumber.Text));
                insert.Parameters.AddWithValue("@gstno", txtGSTNumber.Text);
                insert.Parameters.AddWithValue("@address", rtbAddress.Text);
                try
                {
                    conn.Open();
                    int res = insert.ExecuteNonQuery();
                    conn.Close();
                    if (res != -1)
                    {
                        MessageBox.Show("Record Added successfully", "Success", MessageBoxButtons.OK);
                        reset();
                        loadID();
                        //int tmp = Convert.ToInt32(txtID.Text);
                      //  tmp += 1;
                       // txtID.Text = tmp.ToString();
                        LoadCustomerRecord();
                    }
                    else
                    {
                        MessageBox.Show("Fail to execute Query","Error",MessageBoxButtons.OK);
                        LoadCustomerRecord();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error when saving on database: "+ex.Message+"","Error",MessageBoxButtons.OK);
                    
                }
                finally
                {
                    conn.Close();
                }
            
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void frmNewCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblCustomer' table. You can move, or remove it, as needed.
            this.tblCustomerTableAdapter.Fill(this.dataSet1.tblCustomer);
            loadID();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadID();
            
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSubmit.Enabled = true;
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

        private void export_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSubmit.Enabled = false;
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtCustomerName.Text = dr.Cells[1].Value.ToString();
                txtContactNumber.Text = dr.Cells[2].Value.ToString();
                txtGSTNumber.Text = dr.Cells[3].Value.ToString();
                rtbAddress.Text = dr.Cells[4].Value.ToString();

                txtCustomerName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            check();
            try
            {
                conn.Open();
                int res;
                int id = Convert.ToInt32(txtID.Text);
                double mobno = Convert.ToDouble(txtContactNumber.Text);
                string cb1 = "update tblCustomer set cname = '"+txtCustomerName.Text + "',cmobno='"+mobno+"',cgstno='"+txtGSTNumber.Text+"',caddress='"+rtbAddress.Text+"' where cid = '"+id+"'";
                cmd = new SqlCommand(cb1);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            reset();				// Reset All fields.
            LoadCustomerRecord(); 	// Refreseh Gridview.
            loadID();
            txtCustomerName.Focus();
        }


        void delete_record()
        {
            try
            {
               // ConnectionString cs = new ConnectionString();
                int RowsAffected = 0;
               // conn = new SqlConnection(cs.DBConn);
                conn.Open();
                int id = Convert.ToInt32(txtID.Text);
                string cq = "DELETE FROM tblCustomer WHERE cid=" +id+ "";
                cmd = new SqlCommand(cq);
                cmd.Connection = conn;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_record();
            
            reset();				// Reset All fields.
            LoadCustomerRecord(); 	// Refreseh Gridview.
            loadID();
            txtCustomerName.Focus();

            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Dispose();
        }
    }
}
