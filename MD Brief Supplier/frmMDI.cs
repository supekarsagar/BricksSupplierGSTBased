using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
//using System.Data.Sq

namespace MD_Brief_Supplier
{
    public partial class frmMDI : Form
    {

        SqlConnection conn = new SqlConnection();
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd;

        public frmMDI()
        {
            InitializeComponent();
        }

       
        private void frmMDI_Load(object sender, EventArgs e)
        {
            //menuStrip1.Text = "Welcome : Admin";
            
            toolStripStatusLabel2.Text = "Admin";
            toolStripStatusLabel4.Text = DateTime.Now.ToString();
            //toolStripStatusLabel4.Text += " "+DateTime.Now.ToLongTimeString();
        } 

        private void button6_Click(object sender, EventArgs e)
        {
            (this).Hide();
            new frmLogin().Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            new frmRoaster().Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new frmLaborWork().Show();  // menu strip
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            new frmNewCustomer().Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
           new frmNewSupplier().Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new frmSale().Show();   // menu strip
        }
        
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            new frmNewLabor().Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            new frmNewServiceProvider().Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            new frmPurchaseSoil().Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            new frmPurchaseNasikDust().Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            new frmPurchaseCoalDust().Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            new frmPurchaseCoal().Show();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            new frmPurchaseSawdust().Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            new frmPurchaseBangi().Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            new frmPurchaseService().Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            new frmIncomeEntry().Show();    // menu strip
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            new frmExpenseEntry().Show();   // menu strip
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new MD_Bricks_Supplier.frmAboutUs().Show();
        }
         //new MD_Bricks_Supplier.frmAboutUs().Show();
        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("wordpad.exe");
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            new frmChooseDate().Show();
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            new frmChooseDate().Show();
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            new frmChooseDate().Show();
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            new frmChooseDate().Show();
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            new frmChooseDate().Show();
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            //new frmChooseDate().Show();
            //printLaborReport();
            new frmReportLabor().ShowDialog();
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            new frmChooseDate().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = DateTime.Now.ToString();
        }

        private void laborWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLaborWork().Show();
        }

        private void incomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSale().Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void incometoolStripMenuItem12_Click(object sender, EventArgs e)
        {
            new frmIncomeEntry().Show();
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmExpenseEntry().Show();
        }

        private void depositAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDepositAmount().Show();
        }
        
        private void btnLaborWork_Click(object sender, EventArgs e)
        {
            new frmLaborWork().ShowDialog();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            new frmSale().ShowDialog();
        }

        private void btnCreditor_Click(object sender, EventArgs e)
        {
            new frmDepositAmount().Show();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            new frmExpenseEntry().ShowDialog();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            new frmIncomeEntry().ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            new frmDepositAmount().ShowDialog();
        }

      /*  void printLaborReport()
        {
            try
            {


                   
                //Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                CrystalReportLabor rpt = new CrystalReportLabor();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet1 myDS = new DataSet1();
                //The DataSet you created.
                conn = new SqlConnection(cs.DBConn);
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM tblLabor L, tblLaborWork LW WHERE L.lid = LW.lid";
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "tblLabor");
                myDA.Fill(myDS, "tblLaborWork");
                rpt.SetDataSource(myDS);
                frmReportLabor frm = new frmReportLabor();
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Visible = true;
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        */
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            new frmReportRawMaterial().ShowDialog();
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {

        }

        private void billTmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReportNewBill().ShowDialog();
        }
    }
}
 