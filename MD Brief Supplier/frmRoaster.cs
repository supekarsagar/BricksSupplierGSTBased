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
    public partial class frmRoaster : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

        public frmRoaster()
        {
            InitializeComponent();
            
        }

        private void LoadID()
        {
            try
            {
                conn.Open();
                string s = "select max(Id) from tblRoaster";
                SqlCommand cmd = new SqlCommand(s, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        /*
                        if (dr[0].ToString().Equals("NULL"))
                        {
                            txtID.Text = "1";
                        }
                        else
                        {*/
                        int id = Convert.ToInt32(dr[0].ToString());
                        id += 1;
                        txtID.Text = id.ToString();
                        //}
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

                MessageBox.Show(ex.Message, "Error: Load ID ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadBricksRecord()
        {
            DataTable Bricks = new DataTable();

            SqlDataAdapter Bricks1Adapter;
            try
            {
                conn.Open();
                string strCommandText = "SELECT Id, bno, btype, byear, bstatus FROM tblRoaster";
                Bricks1Adapter = new SqlDataAdapter(strCommandText, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(Bricks1Adapter);
                Bricks.Clear();
                Bricks1Adapter.Fill(Bricks);

                if (Bricks.Rows.Count > 0)
                    dataGridView1.DataSource = Bricks;
                conn.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error : LoadBrickRecord Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        void reset()
        {
            txtID.Text = "";
            txtBrickNumber.Text = "";
            cmbBrickType.SelectedIndex = -1;
            txtYear.Text = "";
        }
        private void frmBricks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblBricks' table. You can move, or remove it, as needed.
            this.tblBricksTableAdapter.Fill(this.dataSet1.tblBricks);
        
            LoadBricksRecord();
            LoadID();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            LoadID();
            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false; 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int Id = Convert.ToInt32(txtID.Text);
                int bno = Convert.ToInt32(txtBrickNumber.Text);
                string byear = (txtYear.Text);
                int status = Convert.ToInt32(txtStatus.Text);

                string cb = "insert into tblRoaster(Id, bno, btype, byear, bstatus) VALUES ('" + Id + "','" + bno + "','" + cmbBrickType.SelectedItem + "','" + byear + "','"+status+"')";

                cmd = new SqlCommand(cb);
                cmd.Connection = conn;
                int res1 = 0, res2=0;
                res1 = cmd.ExecuteNonQuery();

                string str = " insert into tblTmpStockBricks (Roaster_Id, Collected_Bricks,size) VALUES ('"+bno+"','0','"+cmbBrickType.Text+"')";
                cmd = new SqlCommand(str, conn);
                res2 = cmd.ExecuteNonQuery();

                conn.Close();

                if (res1 > 0 && res2 > 0)
                {
                    MessageBox.Show("New Roaster is Created Succesfully.", "Suceess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    LoadID();
                    LoadBricksRecord();
                }
                else
                {
                    MessageBox.Show("Failed to create Roaster.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtBrickNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            new frmSale().AcceptNumberOnly(e);
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            //new frmSale().AcceptNumberOnly(e);
            
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
                txtBrickNumber.Text = dr.Cells[1].Value.ToString();
                cmbBrickType.Text = dr.Cells[2].Value.ToString();
                txtYear.Text = dr.Cells[3].Value.ToString();
                txtStatus.Text = dr.Cells[4].Value.ToString();

                txtBrickNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtBrickNumber.Text = dr.Cells[1].Value.ToString();
                cmbBrickType.Text = dr.Cells[2].Value.ToString();
                txtYear.Text = dr.Cells[3].Value.ToString();
                txtStatus.Text = dr.Cells[4].Value.ToString();
                txtBrickNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnSubmit.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_record(); 
            reset();
            LoadBricksRecord();
            LoadID();
            txtBrickNumber.Focus();

            btnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        void delete_record()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Enter ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
                return;
            }
            try
            {
                
                int RowsAffected = 0;
                conn.Open();
                int id = Convert.ToInt32(txtID.Text);
                string cq = "DELETE FROM tblRoaster WHERE Id=" + id + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = conn;
                RowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtID.Text == "")
            {
                MessageBox.Show("Please enter ID", "Error ",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
                return;
            }
            if (txtBrickNumber.Text == "")
            {
                MessageBox.Show("Please enter Bricks Number", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBrickNumber.Focus();
                return;
            }
            if (cmbBrickType.Text== "")
            {
                MessageBox.Show("Please select Brick Type", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBrickType.Focus();
                return;
            }
            if (txtYear.Text == "")
            {
                MessageBox.Show("Please enter Year", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return;
            }
            if (txtStatus.Text == "")
            {
                MessageBox.Show("Please Status of Roaster (1-FOR ON /0-FOR OFF)", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return;
            }

            try
            {
                conn.Open();
                int id = Convert.ToInt32(txtID.Text);
               // int ROId = 1;
                int bno = Convert.ToInt32(txtBrickNumber.Text);
                int status = Convert.ToInt32(txtStatus.Text);
                int res ;


                string cb1 = "update tblRoaster set bno = '"+bno+"', btype = '"+cmbBrickType.SelectedItem+"', byear = '"+txtYear.Text+"', bstatus = '"+status+"' where Id='"+id+"'";
	            cmd = new SqlCommand(cb1);
	            cmd.Connection = conn;
	            res = cmd.ExecuteNonQuery();
                conn.Close();

                if (res > 0)
                {
                    MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    LoadID();
                    LoadBricksRecord();
                }
                else
                {
                    MessageBox.Show("Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSubmit.Enabled=true;
                btnDelete.Enabled=false;
                btnUpdate.Enabled=false;
                txtBrickNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In Catch Block", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}
