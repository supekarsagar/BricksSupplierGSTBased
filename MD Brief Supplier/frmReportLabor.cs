using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace MD_Brief_Supplier
{
    public partial class frmReportLabor : Form
    {
        public frmReportLabor()
        {
            InitializeComponent();
        }

        private void frmReportLabor_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                CrystalReportLabor rpt = new CrystalReportLabor();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet1 myDS = new DataSet1();
                //The DataSet you created.
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='D:\MCS\SEM - II\CS - 204 Project\MD Bricks Supplier\MD Brief Supplier\dBMaheshBricksSupplier.mdf';Integrated Security=True;Connect Timeout=30");
                cmd.Connection = con;
                cmd.CommandText = "select * from tblLaborWork";
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
               // myDA.Fill(myDS, "tblLabor");
                myDA.Fill(myDS, "tblLaborWork");
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
