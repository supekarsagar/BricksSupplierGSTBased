namespace MD_Brief_Supplier
{
    partial class frmSale
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRemainsBricks = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAvailable = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPaidAmt = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRoasterNo = new System.Windows.Forms.TextBox();
            this.btnGetCustomerID = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGST = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblBricksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new MD_Brief_Supplier.DataSet1();
            this.tblBricksTableAdapter = new MD_Brief_Supplier.DataSet1TableAdapters.tblBricksTableAdapter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBricksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnSubmit.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.Location = new System.Drawing.Point(104, 14);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(95, 35);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(212, 375);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(337, 29);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Value = new System.DateTime(2018, 4, 19, 10, 16, 31, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(85, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 22);
            this.label9.TabIndex = 33;
            this.label9.Text = "Date";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTotalAmount.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtTotalAmount.Location = new System.Drawing.Point(212, 340);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(145, 29);
            this.txtTotalAmount.TabIndex = 98;
            this.txtTotalAmount.Text = "0";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalAmount_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(85, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 22);
            this.label8.TabIndex = 34;
            this.label8.Text = "Total Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(84, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 22);
            this.label7.TabIndex = 35;
            this.label7.Text = "GST";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtAmount.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtAmount.Location = new System.Drawing.Point(212, 270);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(337, 29);
            this.txtAmount.TabIndex = 99;
            this.txtAmount.Text = "0";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 22);
            this.label6.TabIndex = 36;
            this.label6.Text = "Amount";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtRate.Location = new System.Drawing.Point(212, 235);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(337, 29);
            this.txtRate.TabIndex = 4;
            this.txtRate.Text = "0";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 22);
            this.label5.TabIndex = 37;
            this.label5.Text = "Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 22);
            this.label4.TabIndex = 38;
            this.label4.Text = "Roaster No.";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtQuantity.Location = new System.Drawing.Point(212, 165);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(337, 29);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "0";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 39;
            this.label3.Text = "Quantity";
            // 
            // cmbSize
            // 
            this.cmbSize.Enabled = false;
            this.cmbSize.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Items.AddRange(new object[] {
            "3*4*9",
            "4*6*9"});
            this.cmbSize.Location = new System.Drawing.Point(212, 200);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(337, 30);
            this.cmbSize.TabIndex = 1;
            this.cmbSize.Text = "-- Please Select Size --";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 22);
            this.label2.TabIndex = 40;
            this.label2.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRemainsBricks);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtAvailable);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtChange);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtPaidAmt);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtBillNo);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtRoasterNo);
            this.panel1.Controls.Add(this.btnGetCustomerID);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtGST);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTotalAmount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtRate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbSize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 599);
            this.panel1.TabIndex = 1;
            // 
            // txtRemainsBricks
            // 
            this.txtRemainsBricks.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRemainsBricks.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtRemainsBricks.Location = new System.Drawing.Point(663, 165);
            this.txtRemainsBricks.Name = "txtRemainsBricks";
            this.txtRemainsBricks.Size = new System.Drawing.Size(120, 29);
            this.txtRemainsBricks.TabIndex = 901;
            this.txtRemainsBricks.Text = "0";
            this.txtRemainsBricks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(690, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 22);
            this.label14.TabIndex = 900;
            this.label14.Text = "Remains";
            // 
            // txtAvailable
            // 
            this.txtAvailable.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtAvailable.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtAvailable.Location = new System.Drawing.Point(559, 165);
            this.txtAvailable.Name = "txtAvailable";
            this.txtAvailable.Size = new System.Drawing.Size(98, 29);
            this.txtAvailable.TabIndex = 899;
            this.txtAvailable.Text = "0";
            this.txtAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(555, 132);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 22);
            this.label22.TabIndex = 898;
            this.label22.Text = "Available";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(733, 347);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 18);
            this.label20.TabIndex = 896;
            this.label20.Text = "Rs.";
            // 
            // txtChange
            // 
            this.txtChange.Enabled = false;
            this.txtChange.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtChange.Location = new System.Drawing.Point(593, 340);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(134, 29);
            this.txtChange.TabIndex = 7;
            this.txtChange.Text = "0";
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(636, 308);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 22);
            this.label21.TabIndex = 897;
            this.label21.Text = "Change";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(556, 345);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 18);
            this.label18.TabIndex = 893;
            this.label18.Text = "Rs.";
            // 
            // txtPaidAmt
            // 
            this.txtPaidAmt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtPaidAmt.Location = new System.Drawing.Point(400, 340);
            this.txtPaidAmt.Name = "txtPaidAmt";
            this.txtPaidAmt.Size = new System.Drawing.Size(149, 29);
            this.txtPaidAmt.TabIndex = 6;
            this.txtPaidAmt.Text = "0";
            this.txtPaidAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaidAmt.TextChanged += new System.EventHandler(this.txtPaidAmt_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(473, 308);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 22);
            this.label19.TabIndex = 894;
            this.label19.Text = "Paid";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Enabled = false;
            this.txtBillNo.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtBillNo.Location = new System.Drawing.Point(212, 24);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(145, 29);
            this.txtBillNo.TabIndex = 890;
            this.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(85, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 22);
            this.label17.TabIndex = 891;
            this.label17.Text = "Bill No.";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(212, 431);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 22);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Print Bill";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtName.Location = new System.Drawing.Point(212, 94);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(337, 29);
            this.txtName.TabIndex = 100;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(84, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 22);
            this.label16.TabIndex = 101;
            this.label16.Text = "Name";
            // 
            // txtRoasterNo
            // 
            this.txtRoasterNo.Enabled = false;
            this.txtRoasterNo.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtRoasterNo.Location = new System.Drawing.Point(212, 129);
            this.txtRoasterNo.Name = "txtRoasterNo";
            this.txtRoasterNo.Size = new System.Drawing.Size(337, 29);
            this.txtRoasterNo.TabIndex = 28;
            this.txtRoasterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGetCustomerID
            // 
            this.btnGetCustomerID.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnGetCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetCustomerID.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGetCustomerID.Location = new System.Drawing.Point(363, 59);
            this.btnGetCustomerID.Name = "btnGetCustomerID";
            this.btnGetCustomerID.Size = new System.Drawing.Size(32, 29);
            this.btnGetCustomerID.TabIndex = 0;
            this.btnGetCustomerID.Text = "<";
            this.btnGetCustomerID.UseVisualStyleBackColor = false;
            this.btnGetCustomerID.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtID.Location = new System.Drawing.Point(212, 59);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(145, 29);
            this.txtID.TabIndex = 26;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(363, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 18);
            this.label13.TabIndex = 25;
            this.label13.Text = "%";
            // 
            // txtGST
            // 
            this.txtGST.BackColor = System.Drawing.SystemColors.Window;
            this.txtGST.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.txtGST.Location = new System.Drawing.Point(212, 305);
            this.txtGST.Name = "txtGST";
            this.txtGST.Size = new System.Drawing.Size(145, 29);
            this.txtGST.TabIndex = 5;
            this.txtGST.Text = "5";
            this.txtGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGST.TextChanged += new System.EventHandler(this.txtGST_TextChanged);
            this.txtGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGST_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSubmit);
            this.panel2.Location = new System.Drawing.Point(89, 477);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 62);
            this.panel2.TabIndex = 888;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnClear.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(330, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 35);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(217, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 35);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(363, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 18);
            this.label12.TabIndex = 24;
            this.label12.Text = "Rs.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(556, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Rs.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(556, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "Rs.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(101, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 31);
            this.label15.TabIndex = 28;
            this.label15.Text = "Sale";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.bnoDataGridViewTextBoxColumn,
            this.btypeDataGridViewTextBoxColumn,
            this.byearDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.tblBricksBindingSource;
            this.dataGridView2.GridColor = System.Drawing.Color.White;
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(518, 574);
            this.dataGridView2.TabIndex = 891;
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bnoDataGridViewTextBoxColumn
            // 
            this.bnoDataGridViewTextBoxColumn.DataPropertyName = "bno";
            this.bnoDataGridViewTextBoxColumn.HeaderText = "ROASTER NO.";
            this.bnoDataGridViewTextBoxColumn.Name = "bnoDataGridViewTextBoxColumn";
            this.bnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btypeDataGridViewTextBoxColumn
            // 
            this.btypeDataGridViewTextBoxColumn.DataPropertyName = "btype";
            this.btypeDataGridViewTextBoxColumn.HeaderText = "TYPE";
            this.btypeDataGridViewTextBoxColumn.Name = "btypeDataGridViewTextBoxColumn";
            this.btypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.btypeDataGridViewTextBoxColumn.Width = 175;
            // 
            // byearDataGridViewTextBoxColumn
            // 
            this.byearDataGridViewTextBoxColumn.DataPropertyName = "byear";
            this.byearDataGridViewTextBoxColumn.HeaderText = "YEAR";
            this.byearDataGridViewTextBoxColumn.Name = "byearDataGridViewTextBoxColumn";
            this.byearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblBricksBindingSource
            // 
            this.tblBricksBindingSource.DataMember = "tblBricks";
            this.tblBricksBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblBricksTableAdapter
            // 
            this.tblBricksTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(802, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 599);
            this.groupBox3.TabIndex = 892;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Roaster Menu";
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1344, 688);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSale";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSale_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBricksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtGST;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGetCustomerID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRoasterNo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dataGridView2;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblBricksBindingSource;
        private DataSet1TableAdapters.tblBricksTableAdapter tblBricksTableAdapter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPaidAmt;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtAvailable;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn btypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byearDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtRemainsBricks;
        private System.Windows.Forms.Label label14;
    }
}