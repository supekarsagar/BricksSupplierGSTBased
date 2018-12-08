using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace MD_Brief_Supplier
{
    public partial class frmReportRawMaterial : Form
    {
        public frmReportRawMaterial()
        {
            InitializeComponent();
        }

        private void frmReportRawMaterial_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                CrystalReportRawMaterial rpt = new CrystalReportRawMaterial();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet1 myDS = new DataSet1();
                //The DataSet you created.
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
                cmd.Connection = con;
                cmd.CommandText = "select * from tblTmpStock";
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
              
                myDA.Fill(myDS, "tblTmpStock");
                rpt.SetDataSource(myDS);

                this.crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
