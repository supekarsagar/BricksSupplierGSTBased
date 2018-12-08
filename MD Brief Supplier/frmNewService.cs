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
    public partial class frmNewService : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;

        public frmNewService()
        {
            InitializeComponent();
            
        }

        void LoadRecordServices()
        {
           
            DataTable Services = new DataTable();

            SqlDataAdapter ServiceAdapter;
            try
            {
                conn.Open();
                string strCommandText = "SELECT sid, sname from tblServices";

                ServiceAdapter = new SqlDataAdapter(strCommandText, conn);

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ServiceAdapter);

                Services.Clear();
                ServiceAdapter.Fill(Services);

                // if there are records, bind to Grid view & display
                if (Services.Rows.Count > 0)
                    dataGridView1.DataSource = Services;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblServices' table. You can move, or remove it, as needed.
            //this.tblServicesTableAdapter.Fill(this.dataSet1.tblServices);
            LoadRecordServices();
            loadID();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        protected void loadID()
        {
            try
            {
                conn.Open();
                string s = "select max(sid) from tblServices";
                cmd = new SqlCommand(s, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        txtID.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
                        //MessageBox.Show(dr[0].ToString(), "");
                    }
                }
                else
                {
                    //txtID.Text = dr[0].ToString(1);
                    //txtID.Text = (Convert.ToString(1));
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
            txtID.Text = "";
            txtName.Text = "";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Something went Wrong with ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter service Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            try
            {
                conn.Open();
                int res;
                int Roid = 1;
                int sid = Convert.ToInt32(txtID.Text);
                string cb = "insert into tblServices(sid, sname, ROId) VALUES ('"+sid+"','" + txtName.Text + "','"+Roid+"')";

                cmd = new SqlCommand(cb);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res != -1)
                {
                    MessageBox.Show("Successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    loadID();
                    LoadRecordServices();
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
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSubmit.Enabled = true;
            txtName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                int res;
                conn.Open();
                string cb1 = "update tblServices set sname = '"+name+"' where sid = '"+id+"'";
                cmd = new SqlCommand(cb1);
                cmd.Connection = conn;
                res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res != -1)
                {
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    loadID();
                    LoadRecordServices();
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
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int RowsAffected = 0;
                int id = Convert.ToInt32(txtID.Text);

                conn.Open();
                string cq = "DELETE FROM tblServices WHERE sid=" + id + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = conn;
                RowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();				// Reset All fields.
                    LoadRecordServices(); 	// Refreseh Gridview.
                    loadID();               // Load Next ID.
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSubmit.Enabled = true;
                txtName.Focus();
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSubmit.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtName.Text = dr.Cells[1].Value.ToString();
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            loadID();
            LoadRecordServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNewServiceProvider frm = new frmNewServiceProvider();
            frm.ShowDialog();
        }
    }
}
