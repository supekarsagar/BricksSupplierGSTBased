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
    public partial class frmNewServiceProvider : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
       // SqlConnection conn = new SqlConnection();
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = new SqlCommand();

        public frmNewServiceProvider()
        {
            InitializeComponent();
        }

        void LoadServiceProviderRecord()
        {
            try
            {
                DataTable ServiceProvider = new DataTable();

                SqlDataAdapter ServiceProviderAdapter;

                //STEP 1: Create connection
                //SqlConnection myConnect = new SqlConnection(cs.DBConn);
                SqlConnection myConnect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");

                //STEP 2: Create command
                string strCommandText = "SELECT spid, spname, spmobno, spvehicleno, spgstno, spdhumper_type, service_id from tblServiceProvider";

                ServiceProviderAdapter = new SqlDataAdapter(strCommandText, myConnect);

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ServiceProviderAdapter);

                ServiceProvider.Clear();

                ServiceProviderAdapter.Fill(ServiceProvider);

                // if there are records, bind to Grid view & display
                if (ServiceProvider.Rows.Count > 0)
                    dataGridView1.DataSource = ServiceProvider;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void LoadServicesRecord()
        {
            try
            {
                DataTable Services = new DataTable();

                SqlDataAdapter ServicesAdapter;

                //STEP 1: Create connection
                //SqlConnection myConnect = new SqlConnection(cs.DBConn);
                SqlConnection myConnect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");

                //STEP 2: Create command
                string strCommandText = "SELECT sid, sname from tblServices";

                ServicesAdapter = new SqlDataAdapter(strCommandText, myConnect);

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ServicesAdapter);

                Services.Clear();

                ServicesAdapter.Fill(Services);

                // if there are records, bind to Grid view & display
                if (Services.Rows.Count > 0)
                    dataGridView2.DataSource = Services;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void loadID()
        {
            try
            {
                //conn = new SqlConnection(cs.DBConn);
                conn.Open();
                string s = "select max(spid) from tblServiceProvider";
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        void reset()
        {
            txtName.Text = "";
            txtVehicleNumber.Text = "";
            txtContactNumber.Text = "";
            txtGSTNumber.Text = "";
            cmbDhumperType.SelectedIndex = -1;
            cmbDhumperType.Text = "0";
            txtID.Text = "";
            txtServiceId.Text = "";
            service_name.Text = "";
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtName.Text=="")
            {
                MessageBox.Show("Please Enter name ");
                txtName.Focus();
                return;
            }
            if(txtContactNumber.Text=="")
            {
                MessageBox.Show("Please Enter Contact number.");
                txtContactNumber.Focus();
                return;
            }
            if (txtServiceId.Text == "")
            {
                MessageBox.Show("Please select service from Service box.");
                dataGridView2.Focus();
                return;
            }
            
            if (service_name.Text=="Dhumper" && cmbDhumperType.Text == "0")
            {
                MessageBox.Show("Please Select dhumper type.");
                cmbDhumperType.Focus();
                return;
            }
            
            if (txtVehicleNumber.Text == "")
            {
                MessageBox.Show("Please Enter vehicle number.");
                txtVehicleNumber.Focus();
                return;
            }

            try
            {
               
                conn.Open();
                int spid = Convert.ToInt32(txtID.Text);
                double mobno = Convert.ToDouble(txtContactNumber.Text);
                int service_id = Convert.ToInt32(txtServiceId.Text);
                int res;
                string cb = "insert into tblServiceProvider(spid, spname, spmobno, spvehicleno, spgstno, spdhumper_type, service_id) VALUES ('"+spid+"','"+txtName.Text+"','"+mobno+"','"+txtVehicleNumber.Text+"','"+txtGSTNumber.Text+"','"+cmbDhumperType.Text+"','"+service_id+"')";

                cmd = new SqlCommand(cb);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res != -1)
                {
                    MessageBox.Show("Successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    loadID();
                    LoadServiceProviderRecord();
                }
                else
                {
                    MessageBox.Show("Failed Execution", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error : Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSubmit.Enabled = true;
        }

        private void frmNewServiceProvider_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblServiceProvider' table. You can move, or remove it, as needed.
            //this.tblServiceProviderTableAdapter.Fill(this.dataSet1.tblServiceProvider);
            // TODO: This line of code loads data into the 'dataSet1.tblServiceProvider' table. You can move, or remove it, as needed.
            // this.tblServiceProviderTableAdapter.Fill(this.dataSet1.tblServiceProvider);
            // TODO: This line of code loads data into the 'dataSet1.tblServices' table. You can move, or remove it, as needed.
            //this.tblServicesTableAdapter.Fill(this.dataSet1.tblServices);
            LoadServiceProviderRecord();
            LoadServicesRecord();
            loadID();
            txtID.Focus();
            service_name.Hide();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAddNewSe_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmNewService().Show();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter name ");
                txtName.Focus();
                return;
            }
            if (txtContactNumber.Text == "")
            {
                MessageBox.Show("Please Enter Contact number.");
                txtContactNumber.Focus();
                return;
            }
            if (txtServiceId.Text == "")
            {
                MessageBox.Show("Please select service from Service box.");
                dataGridView2.Focus();
                return;
            }

            if (service_name.Text == "Dhumper" && cmbDhumperType.Text == "0")
            {
                MessageBox.Show("Please Select dhumper type.");
                cmbDhumperType.Focus();
                return;
            }

            if (txtVehicleNumber.Text == "")
            {
                MessageBox.Show("Please Enter vehicle number.");
                txtVehicleNumber.Focus();
                return;
            }

            try
            {

                conn.Open();
                int spid = Convert.ToInt32(txtID.Text);
                double mobno = Convert.ToDouble(txtContactNumber.Text);
                int service_id = Convert.ToInt32(txtServiceId.Text);
                int res;
                string cb = "update tblServiceProvider set spname='" + txtName.Text + "', spmobno='" + mobno + "', spvehicleno='" + txtVehicleNumber.Text + "', spgstno='" + txtGSTNumber.Text + "', spdhumper_type='" + cmbDhumperType.Text + "', service_id='" + service_id + "' where spid = '" + spid + "'";
              
                cmd = new SqlCommand(cb);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res != -1)
                {
                    MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    loadID();
                    LoadServiceProviderRecord();
                }
                else
                {
                    MessageBox.Show("Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error : Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
       
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                txtServiceId.Text = dr.Cells[0].Value.ToString();
                service_name.Show();
                service_name.Text = dr.Cells[1].Value.ToString();
                if (service_name.Text != "DHUMPER")
                {
                    
                    cmbDhumperType.Enabled = false; ;
                    cmbDhumperType.SelectedIndex = 0;
                }
                else
                {
                    
                    cmbDhumperType.Enabled = true; ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtServiceId_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSubmit.Enabled = false;
            service_name.Text = "";
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtName.Text = dr.Cells[1].Value.ToString();
                txtContactNumber.Text = dr.Cells[2].Value.ToString();
                txtVehicleNumber.Text = dr.Cells[3].Value.ToString();
                txtGSTNumber.Text = dr.Cells[4].Value.ToString();
                cmbDhumperType.Text = dr.Cells[5].Value.ToString();
                txtServiceId.Text = dr.Cells[6].Value.ToString();
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteRecord();
        }
        void deleteRecord()
        {
            try
            {

                int RowsAffected = 0;
                int id = Convert.ToInt32(txtID.Text);
                //conn = new SqlConnection(cs.DBConn);
                conn.Open();
                string cq = "DELETE FROM tblServiceProvider WHERE spid='" + id +"'";
                cmd = new SqlCommand(cq);
                cmd.Connection = conn;
                RowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();				        // Reset All fields.
                    loadID();
                    LoadServiceProviderRecord(); 	// Refreseh Gridview.
                    txtID.Focus();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                btnSubmit.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
