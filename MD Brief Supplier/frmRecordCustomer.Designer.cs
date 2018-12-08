namespace MD_Brief_Supplier
{
    partial class frmRecordCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new MD_Brief_Supplier.DataSet1();
            this.tblCustomerTableAdapter = new MD_Brief_Supplier.DataSet1TableAdapters.tblCustomerTableAdapter();
            this.cidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmobnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cgstnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cidDataGridViewTextBoxColumn,
            this.cnameDataGridViewTextBoxColumn,
            this.cmobnoDataGridViewTextBoxColumn,
            this.cgstnoDataGridViewTextBoxColumn,
            this.caddressDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblCustomerBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(17, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(505, 562);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // tblCustomerBindingSource
            // 
            this.tblCustomerBindingSource.DataMember = "tblCustomer";
            this.tblCustomerBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblCustomerTableAdapter
            // 
            this.tblCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // cidDataGridViewTextBoxColumn
            // 
            this.cidDataGridViewTextBoxColumn.DataPropertyName = "cid";
            this.cidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.cidDataGridViewTextBoxColumn.Name = "cidDataGridViewTextBoxColumn";
            this.cidDataGridViewTextBoxColumn.ReadOnly = true;
            this.cidDataGridViewTextBoxColumn.Width = 50;
            // 
            // cnameDataGridViewTextBoxColumn
            // 
            this.cnameDataGridViewTextBoxColumn.DataPropertyName = "cname";
            this.cnameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.cnameDataGridViewTextBoxColumn.Name = "cnameDataGridViewTextBoxColumn";
            this.cnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cnameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cmobnoDataGridViewTextBoxColumn
            // 
            this.cmobnoDataGridViewTextBoxColumn.DataPropertyName = "cmobno";
            this.cmobnoDataGridViewTextBoxColumn.HeaderText = "Mob.No.";
            this.cmobnoDataGridViewTextBoxColumn.Name = "cmobnoDataGridViewTextBoxColumn";
            this.cmobnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cgstnoDataGridViewTextBoxColumn
            // 
            this.cgstnoDataGridViewTextBoxColumn.DataPropertyName = "cgstno";
            this.cgstnoDataGridViewTextBoxColumn.HeaderText = "GST No.";
            this.cgstnoDataGridViewTextBoxColumn.Name = "cgstnoDataGridViewTextBoxColumn";
            this.cgstnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // caddressDataGridViewTextBoxColumn
            // 
            this.caddressDataGridViewTextBoxColumn.DataPropertyName = "caddress";
            this.caddressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.caddressDataGridViewTextBoxColumn.Name = "caddressDataGridViewTextBoxColumn";
            this.caddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmRecordCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 593);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecordCustomer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Record Customer";
            this.Load += new System.EventHandler(this.frmRecordCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblCustomerBindingSource;
        private DataSet1TableAdapters.tblCustomerTableAdapter tblCustomerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmobnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cgstnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caddressDataGridViewTextBoxColumn;
    }
}