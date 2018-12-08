using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MD_Brief_Supplier
{
    public partial class frmRecordCustomer : Form
    {
        public frmRecordCustomer()
        {
            InitializeComponent();
        }

        private void frmRecordCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tblCustomer' table. You can move, or remove it, as needed.
            this.tblCustomerTableAdapter.Fill(this.dataSet1.tblCustomer);

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmSale frm = new frmSale();
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            frm.txtID.Text = dr.Cells[0].Value.ToString();
            frm.txtName.Text = dr.Cells[1].Value.ToString();
            
           this.Hide();
            frm.Show();

        }
    }
}
