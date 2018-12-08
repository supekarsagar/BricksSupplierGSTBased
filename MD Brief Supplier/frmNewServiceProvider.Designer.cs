namespace MD_Brief_Supplier
{
    partial class frmNewServiceProvider
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
            this.txtGSTNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVehicleNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddNewSe = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.service_name = new System.Windows.Forms.Label();
            this.txtServiceId = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbDhumperType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.sidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new MD_Brief_Supplier.DataSet1();
            this.tblServicesTableAdapter = new MD_Brief_Supplier.DataSet1TableAdapters.tblServicesTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblServiceProviderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblServiceProviderTableAdapter = new MD_Brief_Supplier.DataSet1TableAdapters.tblServiceProviderTableAdapter();
            this.spidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spmobnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spvehiclenoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spgstnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spdhumpertypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblServiceProviderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGSTNumber
            // 
            this.txtGSTNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGSTNumber.Location = new System.Drawing.Point(159, 188);
            this.txtGSTNumber.Name = "txtGSTNumber";
            this.txtGSTNumber.Size = new System.Drawing.Size(347, 23);
            this.txtGSTNumber.TabIndex = 5;
            this.txtGSTNumber.Text = "0";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtName.Location = new System.Drawing.Point(159, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(347, 23);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(38, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(35, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "GST Number";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnSubmit.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.Location = new System.Drawing.Point(12, 13);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 32);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtContactNumber.Location = new System.Drawing.Point(159, 69);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContactNumber.Size = new System.Drawing.Size(347, 23);
            this.txtContactNumber.TabIndex = 2;
            this.txtContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Contact Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(38, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Vehicle Number";
            // 
            // txtVehicleNumber
            // 
            this.txtVehicleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtVehicleNumber.Location = new System.Drawing.Point(159, 159);
            this.txtVehicleNumber.Name = "txtVehicleNumber";
            this.txtVehicleNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVehicleNumber.Size = new System.Drawing.Size(347, 23);
            this.txtVehicleNumber.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(35, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vehicle/Service";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAddNewSe);
            this.panel2.Location = new System.Drawing.Point(818, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 169);
            this.panel2.TabIndex = 10;
            // 
            // btnAddNewSe
            // 
            this.btnAddNewSe.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnAddNewSe.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddNewSe.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddNewSe.Location = new System.Drawing.Point(18, 17);
            this.btnAddNewSe.Name = "btnAddNewSe";
            this.btnAddNewSe.Size = new System.Drawing.Size(105, 52);
            this.btnAddNewSe.TabIndex = 22;
            this.btnAddNewSe.Text = "&Add New Service";
            this.btnAddNewSe.UseVisualStyleBackColor = false;
            this.btnAddNewSe.Click += new System.EventHandler(this.btnAddNewSe_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(234, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 32);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.service_name);
            this.panel1.Controls.Add(this.txtServiceId);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.cmbDhumperType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtGSTNumber);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtContactNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtVehicleNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 327);
            this.panel1.TabIndex = 9;
            // 
            // service_name
            // 
            this.service_name.AutoSize = true;
            this.service_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.service_name.Location = new System.Drawing.Point(270, 101);
            this.service_name.Name = "service_name";
            this.service_name.Size = new System.Drawing.Size(45, 17);
            this.service_name.TabIndex = 31;
            this.service_name.Text = "Name";
            // 
            // txtServiceId
            // 
            this.txtServiceId.Enabled = false;
            this.txtServiceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtServiceId.Location = new System.Drawing.Point(159, 98);
            this.txtServiceId.Name = "txtServiceId";
            this.txtServiceId.Size = new System.Drawing.Size(105, 23);
            this.txtServiceId.TabIndex = 30;
            this.txtServiceId.TextChanged += new System.EventHandler(this.txtServiceId_TextChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtID.Location = new System.Drawing.Point(159, 11);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(105, 23);
            this.txtID.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(41, 238);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(465, 57);
            this.panel3.TabIndex = 27;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnClear.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(345, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 32);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(123, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 32);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbDhumperType
            // 
            this.cmbDhumperType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbDhumperType.FormattingEnabled = true;
            this.cmbDhumperType.Items.AddRange(new object[] {
            "6 Wheeler",
            "10 Wheeler"});
            this.cmbDhumperType.Location = new System.Drawing.Point(159, 129);
            this.cmbDhumperType.Name = "cmbDhumperType";
            this.cmbDhumperType.Size = new System.Drawing.Size(347, 24);
            this.cmbDhumperType.TabIndex = 25;
            this.cmbDhumperType.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(35, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Type of Dhumper";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(38, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(693, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 327);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sidDataGridViewTextBoxColumn,
            this.snameDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.tblServicesBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(7, 40);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(266, 281);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // sidDataGridViewTextBoxColumn
            // 
            this.sidDataGridViewTextBoxColumn.DataPropertyName = "sid";
            this.sidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.sidDataGridViewTextBoxColumn.Name = "sidDataGridViewTextBoxColumn";
            this.sidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snameDataGridViewTextBoxColumn
            // 
            this.snameDataGridViewTextBoxColumn.DataPropertyName = "sname";
            this.snameDataGridViewTextBoxColumn.HeaderText = "Service Name";
            this.snameDataGridViewTextBoxColumn.Name = "snameDataGridViewTextBoxColumn";
            this.snameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblServicesBindingSource
            // 
            this.tblServicesBindingSource.DataMember = "tblServices";
            this.tblServicesBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblServicesTableAdapter
            // 
            this.tblServicesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.spidDataGridViewTextBoxColumn,
            this.spnameDataGridViewTextBoxColumn,
            this.spmobnoDataGridViewTextBoxColumn,
            this.spvehiclenoDataGridViewTextBoxColumn,
            this.spgstnoDataGridViewTextBoxColumn,
            this.spdhumpertypeDataGridViewTextBoxColumn,
            this.serviceidDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblServiceProviderBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 345);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 204);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // tblServiceProviderBindingSource
            // 
            this.tblServiceProviderBindingSource.DataMember = "tblServiceProvider";
            this.tblServiceProviderBindingSource.DataSource = this.dataSet1;
            // 
            // tblServiceProviderTableAdapter
            // 
            this.tblServiceProviderTableAdapter.ClearBeforeFill = true;
            // 
            // spidDataGridViewTextBoxColumn
            // 
            this.spidDataGridViewTextBoxColumn.DataPropertyName = "spid";
            this.spidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.spidDataGridViewTextBoxColumn.Name = "spidDataGridViewTextBoxColumn";
            // 
            // spnameDataGridViewTextBoxColumn
            // 
            this.spnameDataGridViewTextBoxColumn.DataPropertyName = "spname";
            this.spnameDataGridViewTextBoxColumn.HeaderText = "NAME";
            this.spnameDataGridViewTextBoxColumn.Name = "spnameDataGridViewTextBoxColumn";
            // 
            // spmobnoDataGridViewTextBoxColumn
            // 
            this.spmobnoDataGridViewTextBoxColumn.DataPropertyName = "spmobno";
            this.spmobnoDataGridViewTextBoxColumn.HeaderText = "CONTACT NO.";
            this.spmobnoDataGridViewTextBoxColumn.Name = "spmobnoDataGridViewTextBoxColumn";
            // 
            // spvehiclenoDataGridViewTextBoxColumn
            // 
            this.spvehiclenoDataGridViewTextBoxColumn.DataPropertyName = "spvehicleno";
            this.spvehiclenoDataGridViewTextBoxColumn.HeaderText = "VEHICLE NO.";
            this.spvehiclenoDataGridViewTextBoxColumn.Name = "spvehiclenoDataGridViewTextBoxColumn";
            // 
            // spgstnoDataGridViewTextBoxColumn
            // 
            this.spgstnoDataGridViewTextBoxColumn.DataPropertyName = "spgstno";
            this.spgstnoDataGridViewTextBoxColumn.HeaderText = "GST NO.";
            this.spgstnoDataGridViewTextBoxColumn.Name = "spgstnoDataGridViewTextBoxColumn";
            // 
            // spdhumpertypeDataGridViewTextBoxColumn
            // 
            this.spdhumpertypeDataGridViewTextBoxColumn.DataPropertyName = "spdhumper_type";
            this.spdhumpertypeDataGridViewTextBoxColumn.HeaderText = "DHUMPER TYPE";
            this.spdhumpertypeDataGridViewTextBoxColumn.Name = "spdhumpertypeDataGridViewTextBoxColumn";
            // 
            // serviceidDataGridViewTextBoxColumn
            // 
            this.serviceidDataGridViewTextBoxColumn.DataPropertyName = "service_id";
            this.serviceidDataGridViewTextBoxColumn.HeaderText = "SERVICE ID";
            this.serviceidDataGridViewTextBoxColumn.Name = "serviceidDataGridViewTextBoxColumn";
            // 
            // frmNewServiceProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewServiceProvider";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Service Provider";
            this.Load += new System.EventHandler(this.frmNewServiceProvider_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblServiceProviderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtGSTNumber;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVehicleNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddNewSe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbDhumperType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtServiceId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblServicesBindingSource;
        private DataSet1TableAdapters.tblServicesTableAdapter tblServicesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label service_name;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tblServiceProviderBindingSource;
        private DataSet1TableAdapters.tblServiceProviderTableAdapter tblServiceProviderTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn spidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spmobnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spvehiclenoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spgstnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spdhumpertypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceidDataGridViewTextBoxColumn;
    }
}