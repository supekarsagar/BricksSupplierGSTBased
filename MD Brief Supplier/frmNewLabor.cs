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
    public partial class frmNewLabor : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;

        public frmNewLabor()
        {
            InitializeComponent();
            loadID();
        }
        private void LoadLaborRecord()
        {
            // Data Table to store employee data
            DataTable Labor = new DataTable();

            // Keeps track of which row in Gridview
            // is selected
            //DataGridViewRow currentRow = null;

            SqlDataAdapter LaborAdapter;

            //retrieve connection information info from App.config

            //STEP 1: Create connection
            SqlConnection myConnect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
            //STEP 2: Create command
            string strCommandText = "SELECT lid, lname , lmobno, lno_of_per, laddress FROM tblLabor";
            
            LaborAdapter = new SqlDataAdapter(strCommandText, myConnect);

            //command builder generates Select, update, delete and insert SQL
            // statements for MedicalCentreAdapter
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(LaborAdapter);
            // Empty Customer Table first
            Labor.Clear();
            // Fill Employee Table with data retrieved by data adapter
            // using SELECT statement
            LaborAdapter.Fill(Labor);

            // if there are records, bind to Grid view & display
            if (Labor.Rows.Count > 0)
                dataGridView1.DataSource = Labor;
        }


        void check()
        {
            if (txtMobno.Text == "")
            {
                MessageBox.Show("Please enter mobile number", "Error", MessageBoxButtons.OK);
                txtMobno.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name", "Error", MessageBoxButtons.OK);
                txtName.Focus();
                return;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK);
                txtAddress.Focus();
                return;
            }
            if (txtNoOfPerson.Text == "")
            {
                MessageBox.Show("Please Enter number of Person", "Error", MessageBoxButtons.OK);
                txtNoOfPerson.Focus();
                return;
            }
        }
        void loadID()
        {
            try
            {
                conn.Open();
                string s = "select max(lid) from tblLabor";
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
                MessageBox.Show("" + ex);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            check();
            try
            {
                conn.Open();
                int res;
                int id = Convert.ToInt32(txtID.Text);
                double mobno = Convert.ToDouble(txtMobno.Text);
                int no_of_person = Convert.ToInt32(txtNoOfPerson.Text);
                string cb1 = "update tblLabor set lname = '" + txtName.Text + "', lmobno='" + mobno + "', lno_of_per = '"+no_of_person+"', laddress='" + txtAddress.Text + "' where lid = '" + id + "'";
                cmd = new SqlCommand(cb1);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            reset();				// Reset All fields.
            LoadLaborRecord(); 	// Refreseh Gridview.
            loadID();
            txtName.Focus();
        }
        void reset()
        {
            txtID.Text = "";
            txtAddress.Text = "";
            txtMobno.Text = "";
            txtName.Text = "";
            txtNoOfPerson.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check();

            SqlCommand insert = new SqlCommand("insert into tblLabor(lid, lname, lmobno, lno_of_per,laddress) values(@Id, @Name, @Mobno, @No_of_person, @address)", conn);
            insert.Parameters.AddWithValue("@Id", Convert.ToInt32(txtID.Text));
            insert.Parameters.AddWithValue("@Name", txtName.Text);
            insert.Parameters.AddWithValue("@Mobno", Convert.ToDouble(txtMobno.Text));
            insert.Parameters.AddWithValue("@No_of_person", Convert.ToInt32(txtNoOfPerson.Text));
            insert.Parameters.AddWithValue("@address", txtAddress.Text);
            try
            {
                conn.Open();
                int res = insert.ExecuteNonQuery();
                if (res != -1)
                {
                    MessageBox.Show("Record Added successfully", "Success", MessageBoxButtons.OK);
                    conn.Close();
                    int tmp = Convert.ToInt32(txtID.Text) + 1;
                    txtID.Text = tmp.ToString();
                    reset();
                    loadID();
                    LoadLaborRecord();
                }
                else
                {
                    MessageBox.Show("Fail to execute Query", "Error", MessageBoxButtons.OK);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when saving on database:" + ex + "", "Error", MessageBoxButtons.OK);
               
            }
            finally
            {
                conn.Close();
            }


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void frmNewLabor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblLabor' table. You can move, or remove it, as needed.
            this.tblLaborTableAdapter.Fill(this.dataSet1.tblLabor);
            loadID();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // clear button
            reset();
            loadID();
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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
                string cq = "DELETE FROM tblLabor WHERE lid=" + id + "";
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
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Enter ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            delete_record();

            reset();				// Reset All fields.
            LoadLaborRecord();  	// Refreseh Gridview.
            loadID();
            txtName.Focus();

            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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

        private void btnExport_Click(object sender, EventArgs e)
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
                txtName.Text = dr.Cells[1].Value.ToString();
                txtMobno.Text = dr.Cells[2].Value.ToString();
                txtNoOfPerson.Text = dr.Cells[3].Value.ToString();
                txtAddress.Text = dr.Cells[4].Value.ToString();

                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
