using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel  = Microsoft.Office.Interop.Excel;

namespace MD_Brief_Supplier
{
    public partial class frmPurchaseSoil : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public frmPurchaseSoil()
        {
            InitializeComponent();

        }

        void loadAvailableSoil()
        {
            try
            {
                conn.Open();
                string str = "select available_qty from tblTmpStock WHERE particular='soil'";
                cmd = new SqlCommand(str, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lblAvailble.Text = dr[0].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Soil Stock cant be read");
            }
            finally { conn.Close(); }
        }
        void loadSoilID()
        {
            try
            {
                conn.Open();
                string s = "select max(SoilID) from tblPurchaseSoil";
                cmd = new SqlCommand(s, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                { 

                    while (dr.Read())
                    {
                        txtSoilID.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
                    }
                }
                else
                {
                    txtSoilID.Text = "1";
                }
                conn.Close();
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

        void BindGridViewPurchaseSoil()
        {
            DataTable PurchaseSoil = new DataTable();
            SqlDataAdapter PurchaseSoilAdapter;

            string strCommandText = "SELECT SoilID as ID, su.sid as Supplier_ID, su.sname as NAME, royalti as ROYALTI, brass as BRASS ,uploading_charges as [UPLOADING CHARGES], no_of_trips as [NO OF TRIPS],  sp.spid as [SERVICE PROVIDER ID],  spname as [SERVICE PROVIDER],  s.sname as [SERVICE NAME],  spdhumper_type as [DHUMPER TYPE],   transportation_charges as [TRANS. CHARGES],    date as DATE FROM tblServiceProvider sp, tblServices s, tblSupplier su, tblPurchaseSoil ps WHERE s.sid = sp.service_id and ps.sid = su.sid and ps.spid=sp.spid";
            try
            {
                conn.Open();
                PurchaseSoilAdapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(PurchaseSoilAdapter);

                PurchaseSoil.Clear();
                PurchaseSoilAdapter.Fill(PurchaseSoil);

                if (PurchaseSoil.Rows.Count > 0)
                    dataGridView3.DataSource = PurchaseSoil;
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
        void reset()
        {
            txtID.Clear();
            txtSoilID.Clear();
            txtRoyalti.Clear();
            txtUploadingCharges.Clear();
          
            textBox3.Clear();
            txtNoOfTrips.Clear();
            txtBrass.Clear();
            txtspid.Clear();
            cmbTransportation.Text = "";
            label13.Text="Name";
            label5.Text = "service provider name";
            txtTransportationCharges.Clear();
            dateTimePicker1.Text = DateTime.Now.Date.ToShortDateString().ToString();
        }
        private void btnGetServiceProviderData_Click(object sender, EventArgs e)
        {
            //new frmRecordSuppiler().Show();
        }

        

        private void frmPurchaseSoil_Load(object sender, EventArgs e)
        {
           
            loadAvailableSoil();
            lblAvailble.Hide();
            BindGridViewPurchaseSoil();
            // TODO: This line of code loads data into the 'dataSet1.tblServiceProvider' table. You can move, or remove it, as needed.
            this.tblServiceProviderTableAdapter.Fill(this.dataSet1.tblServiceProvider);
            // TODO: This line of code loads data into the 'dataSet1.tblSupplier' table. You can move, or remove it, as needed.
            this.tblSupplierTableAdapter.Fill(this.dataSet1.tblSupplier);
          
            BindDataGDVServiceProvider();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            loadSoilID();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // txtID, label13 bind data;
           
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                label13.Text = dr.Cells[1].Value.ToString();

                txtRoyalti.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GDVServiceProvider_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // label5 - service provideer name
            // textbox2 - service provider id
            // textbox3 - vehicle type
           
            try
            {
                DataGridViewRow dr = GDVServiceProvider.SelectedRows[0];
                txtspid.Text = dr.Cells[0].Value.ToString(); // id 
                label5.Text = dr.Cells[1].Value.ToString();  //  name of service provider
                textBox3.Text = dr.Cells[2].Value.ToString(); // type
                cmbTransportation.Text=dr.Cells[3].Value.ToString(); // type
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Enter ID from Land Owner section", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Focus();
                return;
            }
            if (txtRoyalti.Text == "")
            {
                MessageBox.Show("Please Enter Royalti", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoyalti.Focus();
                return;
            }
            if (txtBrass.Text == "")
            {
                MessageBox.Show("Please Enter Brass", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBrass.Focus();
                return;
            }
            if (txtUploadingCharges.Text == "")
            {
                MessageBox.Show("Please Enter Uploading Charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUploadingCharges.Focus();
                return;
            }
            if (txtspid.Text == "")
            {
                MessageBox.Show("Please Enter ID from Service Provider Section", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtspid.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Vehicle Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (cmbTransportation.Text == "")
            {
                MessageBox.Show("Please Enter Transportation from Service Provider section", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTransportation.Focus();
                return;
            }
            if (txtNoOfTrips.Text == "")
            {
                MessageBox.Show("Please Enter Number of Trips", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoOfTrips.Focus();
                return;
            }
            if (txtTransportationCharges.Text == "")
            {
                MessageBox.Show("Please Enter Transportation Charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTransportationCharges.Focus();
                return;
            }
            
            int supplier_id = Convert.ToInt32(txtID.Text);
            int soil_id = Convert.ToInt32(txtSoilID.Text);
            int royalti = Convert.ToInt32(txtRoyalti.Text);
            int uploading_charges = Convert.ToInt32(txtUploadingCharges.Text);
            double brass = Convert.ToDouble(txtBrass.Text);
            int service_provider_id = Convert.ToInt32(txtspid.Text);
            int transportation_charges = Convert.ToInt32(txtTransportationCharges.Text);
            int no_of_trips = Convert.ToInt32(txtNoOfTrips.Text);

            // update stock => tblTempStock
            double available_stock = Convert.ToDouble(lblAvailble.Text);
            double tot_stock = available_stock + brass;

            int res1, res2;
            try
            {
                conn.Open();
                string ins = "INSERT INTO tblPurchaseSoil (SoilID, sid, royalti,brass, uploading_charges, no_of_trips, spid, transportation_charges, date) VALUES (@SoilID, @sid, @royalti,@brass,  @uploading_charges, @no_of_trips, @spid, @transportation_charges, @date)";
                cmd = new SqlCommand(ins);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("SoilID", soil_id);
                cmd.Parameters.AddWithValue("sid", supplier_id);
                cmd.Parameters.AddWithValue("royalti", royalti);
                cmd.Parameters.AddWithValue("brass", brass);
                cmd.Parameters.AddWithValue("uploading_charges", uploading_charges);
                cmd.Parameters.AddWithValue("no_of_trips", no_of_trips);
                cmd.Parameters.AddWithValue("spid", service_provider_id);
                cmd.Parameters.AddWithValue("transportation_charges", transportation_charges);
                cmd.Parameters.AddWithValue("date", dateTimePicker1.Text);
                res1 = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                string up = "update tblTmpStock set available_qty = '"+tot_stock+"' where particular='soil'";
                cmd = new SqlCommand(up, conn);
                res2 = cmd.ExecuteNonQuery();
                conn.Close();

                if (res1 > 0 && res2>0)
                {
                    MessageBox.Show("Record saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();                        // clear all fields
                    loadSoilID();                   // load purchase soil id
                    BindGridViewPurchaseSoil();     // referesh grid view
                    loadAvailableSoil();
                }
                else
                {
                    MessageBox.Show("Failed to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while saving data");
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
                MessageBox.Show("Please Enter ID from Land Owner section", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Focus();
                return;
            }
            if (txtRoyalti.Text == "")
            {
                MessageBox.Show("Please Enter Royalti", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoyalti.Focus();
                return;
            }
            if (txtBrass.Text == "")
            {
                MessageBox.Show("Please Enter Brass", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBrass.Focus();
                return;
            }
            if (txtUploadingCharges.Text == "")
            {
                MessageBox.Show("Please Enter Uploading Charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUploadingCharges.Focus();
                return;
            }
            if (txtspid.Text == "")
            {
                MessageBox.Show("Please Enter ID from Service Provider Section", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtspid.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Vehicle Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (cmbTransportation.Text == "")
            {
                MessageBox.Show("Please Enter Transportation from Service Provider section", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTransportation.Focus();
                return;
            }
            if (txtNoOfTrips.Text == "")
            {
                MessageBox.Show("Please Enter Number of Trips", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoOfTrips.Focus();
                return;
            }
            if (txtTransportationCharges.Text == "")
            {
                MessageBox.Show("Please Enter Transportation Charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTransportationCharges.Focus();
                return;
            }
            int supplier_id = Convert.ToInt32(txtID.Text);
            int soil_id = Convert.ToInt32(txtSoilID.Text);
            int royalti = Convert.ToInt32(txtRoyalti.Text);
            int uploading_charges = Convert.ToInt32(txtUploadingCharges.Text);
            int brass = Convert.ToInt32(txtBrass.Text);
            int service_provider_id = Convert.ToInt32(txtspid.Text);
            int transportation_charges = Convert.ToInt32(txtTransportationCharges.Text);
            int no_of_trips = Convert.ToInt32(txtNoOfTrips.Text);
            int res;
            try
            {
                conn.Open();
                string str = "UPDATE tblPurchaseSoil SET sid='"+supplier_id+"', royalti='"+royalti+"', brass='"+brass+"' , uploading_charges='"+uploading_charges+"' , no_of_trips='"+no_of_trips+"', spid='"+service_provider_id+"', transportation_charges='"+transportation_charges+"', date='"+dateTimePicker1.Text+"' WHERE SoilID='"+soil_id+"'";
                SqlCommand cmd = new SqlCommand(str, conn);
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();                        // clear all fields
                    loadSoilID();                   // load purchase soil id
                    BindGridViewPurchaseSoil();     // referesh grid view
                    loadAvailableSoil();
                }
                else
                {
                    MessageBox.Show("Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error : Exception in Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int RowsAffected = 0;
                int id = Convert.ToInt32(txtSoilID.Text);
                
                conn.Open();
                string cq = "DELETE FROM tblPurchaseSoil WHERE SoilID=" + id + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = conn;
                RowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();						// Reset All fields.
                    loadSoilID();                   // load purchase soil id.
                    BindGridViewPurchaseSoil(); 	// Refreseh Gridview.
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
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtRoyalti.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadSoilID();
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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

                rowsTotal = dataGridView3.RowCount - 1;
                colsTotal = dataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView3.Rows[I].Cells[j].Value;
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

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            txtRoyalti.Enabled = false;
            txtBrass.Enabled = false;
            try
            {
                txtSoilID.Text = dr.Cells[0].Value.ToString();
                txtID.Text = dr.Cells[1].Value.ToString();
                label13.Text = dr.Cells[2].Value.ToString();
                txtRoyalti.Text = dr.Cells[3].Value.ToString();
                txtBrass.Text = dr.Cells[4].Value.ToString();
                txtUploadingCharges.Text = dr.Cells[5].Value.ToString();
                txtNoOfTrips.Text = dr.Cells[6].Value.ToString();
                txtspid.Text = dr.Cells[7].Value.ToString();
                label5.Text = dr.Cells[8].Value.ToString();
                cmbTransportation.Text = dr.Cells[9].Value.ToString();
                textBox3.Text = dr.Cells[10].Value.ToString();
                txtTransportationCharges.Text = dr.Cells[11].Value.ToString();
                dateTimePicker1.Text = dr.Cells[12].Value.ToString();
            }
            catch (Exception)
            {
            }
            txtRoyalti.Focus();
            btnSubmit.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

    }
}
