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
    public partial class frmPurchaseService : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader dr;
        int res = 0;

        public frmPurchaseService()
        {
            InitializeComponent();
        }

        void loadPurchaseID()
        {
            string str = "SELECT MAX(psid) FROM tblPurchaseService";
            try
            {
                conn.Open();
                cmd = new SqlCommand(str, conn);
                dr = cmd.ExecuteReader();

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
                MessageBox.Show(ex.Message, "Error : Purchase Sevice ID Can't Load");
            }
            finally
            {
                conn.Close();
            }
        }
        
        void reset()
        {
            txtID.Text = "";
            txtServiceId.Clear();
            lblServiceName.Text = "Service Name";
            lblServiceProviderName.Text = "Service Provider Name";
            txtHoursRate.Text = "";
            txtRate.Text = "";
            txtAmount.Text = "";
            dtpNowDate.Text = DateTime.Now.Date.ToShortDateString();
        }
       
        void cal()
        {
            if (txtRate.Text == "" || txtHoursRate.Text == "")
            {
                txtAmount.Text = "0";
            }
            if (txtHoursRate.Text != "" && txtRate.Text != "")
            {
                double ht = Convert.ToDouble(txtHoursRate.Text);
                double rate = Convert.ToDouble(txtRate.Text);
                double amt = ht * rate;
                txtAmount.Text = amt.ToString();
            }

        }
        private void txtHoursRate_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtHoursRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Get ID.");
                txtID.Focus();
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter Rate.");
                txtRate.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Amount.");
                txtAmount.Focus();
                return;
            }
            try
            {
                int psid = Convert.ToInt32(txtID.Text);
                int sid = Convert.ToInt32(txtServiceId.Text);
                double hoursortrips = Convert.ToDouble(txtHoursRate.Text);
                int rate = Convert.ToInt32(txtRate.Text);
                double tot_amt = Convert.ToDouble(txtAmount.Text);
                conn.Open();
                string str = "INSERT INTO tblPurchaseService(psid, sid, hoursortrips, rate, tot_amt, date) VALUES ('"+psid+"','"+sid+"','"+hoursortrips+"','"+rate+"','"+tot_amt+"','"+dtpNowDate.Text+"')";
                cmd = new SqlCommand(str, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record Saved","Success", MessageBoxButtons.OK);
                    reset();
                    loadPurchaseID();
                    BindGridView2Data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Submitting Data");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Get ID.");
                txtID.Focus();
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter Rate.");
                txtRate.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Amount.");
                txtAmount.Focus();
                return;
            }
            try
            {
                int psid = Convert.ToInt32(txtID.Text);
                int sid = Convert.ToInt32(txtServiceId.Text);
                double hoursortrips = Convert.ToDouble(txtHoursRate.Text);
                int rate = Convert.ToInt32(txtRate.Text);
                double tot_amt = Convert.ToDouble(txtAmount.Text);
                conn.Open();
                string str = "UPDATE tblPurchaseService SET sid = '"+sid+"', hoursortrips = '"+hoursortrips+"', rate='"+rate+"', tot_amt='"+tot_amt+"', date='"+dtpNowDate.Text+"' WHERE psid = '"+psid+"'";
                cmd = new SqlCommand(str, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK);
                    reset();
                    loadPurchaseID();
                    BindGridView2Data();
                }
                btnSubmit.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Updating Data");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Select ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
                return;
            }
            int psid = Convert.ToInt32(txtID.Text);
            try
            {
                conn.Open();
                string str  = "DELETE FROM tblPurchaseService WHERE psid = '"+psid+"'";
                cmd = new SqlCommand(str, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if(res>0)
                {
                    MessageBox.Show("Record Deleted Successfully","Success",MessageBoxButtons.OK);
                    reset();
                    loadPurchaseID();
                    BindGridView2Data();   // REFERESH GRID VIEW .
                }
                else
                {
                    MessageBox.Show("Record Not found or Query Not Executed","Error",MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: While Deleting Record",MessageBoxButtons.OK);
            }
            finally 
            {
                conn.Close();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadPurchaseID();
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        
        private void frmPurchaseService_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            loadPurchaseID();
            BindDataGDVServiceProvider();// BIND DATA GRID VIEW OF SERVICE PROVIDER.
            BindGridView2Data();
        }

        private void GDVServiceProvider_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = GDVServiceProvider.SelectedRows[0];
            txtServiceId.Text = dr.Cells[0].Value.ToString();
            lblServiceProviderName.Text = dr.Cells[1].Value.ToString();
            lblServiceName.Text = dr.Cells[3].Value.ToString();
        }
        void BindDataGDVServiceProvider()
        {
            DataTable ServiceProvider_Services = new DataTable();
            SqlDataAdapter ServiceProvider_ServiesAdapter;

            string strCommandText = "SELECT spid as ID, spname as NAME, spdhumper_type as VEHICLE_TYPE, sname AS SERVICE FROM tblServiceProvider sp, tblServices s WHERE s.sid = sp.service_id";
            try
            {
                conn.Open();
                ServiceProvider_ServiesAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ServiceProvider_ServiesAdapter);

                ServiceProvider_Services.Clear();
                ServiceProvider_ServiesAdapter.Fill(ServiceProvider_Services);

                if (ServiceProvider_Services.Rows.Count > 0)
                    GDVServiceProvider.DataSource = ServiceProvider_Services;
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

        void BindGridView2Data()
        {
            DataTable PurchaseService = new DataTable();
            SqlDataAdapter PurchaseServiceAdapter;

            string strCommandText = "SELECT psid as [Purchase ID], ps.sid as [Service ID], s.sname as [SERVICE],spname as [NAME], hoursortrips as[ HOURS/TRIPS], rate as [RATE], tot_amt as [TOTAL AMOUNT], date as [DATE] FROM tblPurchaseService ps, tblServiceProvider sp, tblServices s WHERE ps.sid = s.sid and s.sid = sp.service_id";
            try
            {
                conn.Open();
                PurchaseServiceAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(PurchaseServiceAdapter);

                PurchaseService.Clear();
                PurchaseServiceAdapter.Fill(PurchaseService);
                
                //dataGridView2.SelectedColumns[3].Width = 200;
                if (PurchaseService.Rows.Count > 0)
                    dataGridView2.DataSource = PurchaseService;
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Binding data", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSubmit.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            txtID.Text = dr.Cells[0].Value.ToString();
            txtServiceId.Text = dr.Cells[1].Value.ToString();
            lblServiceName.Text = dr.Cells[2].Value.ToString();
            lblServiceProviderName.Text = dr.Cells[3].Value.ToString();
            txtHoursRate.Text = dr.Cells[4].Value.ToString();
            txtRate.Text = dr.Cells[5].Value.ToString();
            txtAmount.Text = dr.Cells[6].Value.ToString();
            dtpNowDate.Text = dr.Cells[7].Value.ToString();
            txtHoursRate.Focus();
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
    }
}
