namespace StockManagement.Windows.View
{
    partial class ContactView
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_contact = new System.Windows.Forms.DataGridView();
            this.DisplaySet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_reg = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_modify = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbox_seed = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbox_MainCon = new System.Windows.Forms.ComboBox();
            this.ctucodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrepDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctbnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cttelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctfaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmangerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmangertelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmemoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_contact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.groupBox1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 30);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3);
            this.panel10.Size = new System.Drawing.Size(1015, 460);
            this.panel10.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid_contact);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "거래처 목록";
            // 
            // grid_contact
            // 
            this.grid_contact.AllowUserToAddRows = false;
            this.grid_contact.AllowUserToDeleteRows = false;
            this.grid_contact.AutoGenerateColumns = false;
            this.grid_contact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_contact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctucodeDataGridViewTextBoxColumn,
            this.ctnameDataGridViewTextBoxColumn,
            this.ctrepDataGridViewTextBoxColumn,
            this.ctbnumberDataGridViewTextBoxColumn,
            this.ctemailDataGridViewTextBoxColumn,
            this.cttelDataGridViewTextBoxColumn,
            this.ctfaxDataGridViewTextBoxColumn,
            this.ctmangerDataGridViewTextBoxColumn,
            this.ctmangertelDataGridViewTextBoxColumn,
            this.ctmemoDataGridViewTextBoxColumn});
            this.grid_contact.DataMember = "dp_contact";
            this.grid_contact.DataSource = this.DisplaySet;
            this.grid_contact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_contact.Location = new System.Drawing.Point(3, 17);
            this.grid_contact.MultiSelect = false;
            this.grid_contact.Name = "grid_contact";
            this.grid_contact.RowHeadersVisible = false;
            this.grid_contact.RowTemplate.Height = 23;
            this.grid_contact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_contact.Size = new System.Drawing.Size(1003, 434);
            this.grid_contact.TabIndex = 0;
            // 
            // DisplaySet
            // 
            this.DisplaySet.DataSetName = "NewDataSet";
            this.DisplaySet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10});
            this.dataTable1.TableName = "dp_contact";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ct_ucode";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "ct_name";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "ct_rep";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "ct_bnumber";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "ct_email";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "ct_tel";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "ct_fax";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "ct_manger";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "ct_mangertel";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "ct_memo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 30);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_reg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(757, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(86, 30);
            this.panel3.TabIndex = 6;
            // 
            // btn_reg
            // 
            this.btn_reg.Location = new System.Drawing.Point(6, 4);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(75, 23);
            this.btn_reg.TabIndex = 1;
            this.btn_reg.Text = "등록";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_add_contactor_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_modify);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(843, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(86, 30);
            this.panel7.TabIndex = 5;
            // 
            // btn_modify
            // 
            this.btn_modify.Location = new System.Drawing.Point(6, 4);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(75, 23);
            this.btn_modify.TabIndex = 1;
            this.btn_modify.Text = "수정";
            this.btn_modify.UseVisualStyleBackColor = true;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_delete);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(929, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(86, 30);
            this.panel6.TabIndex = 4;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(6, 4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "삭제";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_search);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(254, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(93, 30);
            this.panel5.TabIndex = 3;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(6, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "조회";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbox_seed);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(127, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(127, 30);
            this.panel4.TabIndex = 2;
            // 
            // tbox_seed
            // 
            this.tbox_seed.Location = new System.Drawing.Point(3, 4);
            this.tbox_seed.Name = "tbox_seed";
            this.tbox_seed.Size = new System.Drawing.Size(121, 21);
            this.tbox_seed.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbox_MainCon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 30);
            this.panel2.TabIndex = 0;
            // 
            // cbox_MainCon
            // 
            this.cbox_MainCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_MainCon.FormattingEnabled = true;
            this.cbox_MainCon.Items.AddRange(new object[] {
            "전체",
            "업체명",
            "담당자명",
            "전화번호"});
            this.cbox_MainCon.Location = new System.Drawing.Point(3, 4);
            this.cbox_MainCon.Name = "cbox_MainCon";
            this.cbox_MainCon.Size = new System.Drawing.Size(121, 20);
            this.cbox_MainCon.TabIndex = 0;
            // 
            // ctucodeDataGridViewTextBoxColumn
            // 
            this.ctucodeDataGridViewTextBoxColumn.DataPropertyName = "ct_ucode";
            this.ctucodeDataGridViewTextBoxColumn.HeaderText = "번호";
            this.ctucodeDataGridViewTextBoxColumn.Name = "ctucodeDataGridViewTextBoxColumn";
            // 
            // ctnameDataGridViewTextBoxColumn
            // 
            this.ctnameDataGridViewTextBoxColumn.DataPropertyName = "ct_name";
            this.ctnameDataGridViewTextBoxColumn.HeaderText = "거래처";
            this.ctnameDataGridViewTextBoxColumn.Name = "ctnameDataGridViewTextBoxColumn";
            // 
            // ctrepDataGridViewTextBoxColumn
            // 
            this.ctrepDataGridViewTextBoxColumn.DataPropertyName = "ct_rep";
            this.ctrepDataGridViewTextBoxColumn.HeaderText = "대표자";
            this.ctrepDataGridViewTextBoxColumn.Name = "ctrepDataGridViewTextBoxColumn";
            // 
            // ctbnumberDataGridViewTextBoxColumn
            // 
            this.ctbnumberDataGridViewTextBoxColumn.DataPropertyName = "ct_bnumber";
            this.ctbnumberDataGridViewTextBoxColumn.HeaderText = "사업자번호";
            this.ctbnumberDataGridViewTextBoxColumn.Name = "ctbnumberDataGridViewTextBoxColumn";
            // 
            // ctemailDataGridViewTextBoxColumn
            // 
            this.ctemailDataGridViewTextBoxColumn.DataPropertyName = "ct_email";
            this.ctemailDataGridViewTextBoxColumn.HeaderText = "이메일";
            this.ctemailDataGridViewTextBoxColumn.Name = "ctemailDataGridViewTextBoxColumn";
            // 
            // cttelDataGridViewTextBoxColumn
            // 
            this.cttelDataGridViewTextBoxColumn.DataPropertyName = "ct_tel";
            this.cttelDataGridViewTextBoxColumn.HeaderText = "연락처";
            this.cttelDataGridViewTextBoxColumn.Name = "cttelDataGridViewTextBoxColumn";
            // 
            // ctfaxDataGridViewTextBoxColumn
            // 
            this.ctfaxDataGridViewTextBoxColumn.DataPropertyName = "ct_fax";
            this.ctfaxDataGridViewTextBoxColumn.HeaderText = "팩스";
            this.ctfaxDataGridViewTextBoxColumn.Name = "ctfaxDataGridViewTextBoxColumn";
            // 
            // ctmangerDataGridViewTextBoxColumn
            // 
            this.ctmangerDataGridViewTextBoxColumn.DataPropertyName = "ct_manger";
            this.ctmangerDataGridViewTextBoxColumn.HeaderText = "담당자";
            this.ctmangerDataGridViewTextBoxColumn.Name = "ctmangerDataGridViewTextBoxColumn";
            // 
            // ctmangertelDataGridViewTextBoxColumn
            // 
            this.ctmangertelDataGridViewTextBoxColumn.DataPropertyName = "ct_mangertel";
            this.ctmangertelDataGridViewTextBoxColumn.HeaderText = "담당자연락처";
            this.ctmangertelDataGridViewTextBoxColumn.Name = "ctmangertelDataGridViewTextBoxColumn";
            // 
            // ctmemoDataGridViewTextBoxColumn
            // 
            this.ctmemoDataGridViewTextBoxColumn.DataPropertyName = "ct_memo";
            this.ctmemoDataGridViewTextBoxColumn.HeaderText = "비고";
            this.ctmemoDataGridViewTextBoxColumn.Name = "ctmemoDataGridViewTextBoxColumn";
            // 
            // ContactView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 490);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel1);
            this.Name = "ContactView";
            this.Text = "ContactView";
            this.panel10.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_contact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbox_seed;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbox_MainCon;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid_contact;
        private System.Data.DataSet DisplaySet;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctucodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctrepDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctbnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctemailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cttelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctfaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctmangerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctmangertelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctmemoDataGridViewTextBoxColumn;
    }
}