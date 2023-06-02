namespace StockManagement.Windows.View
{
    partial class InItemsView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn_reg = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_modify = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbox_seed = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbox_SubCon = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbox_MainCon = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_in = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplaySet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel11 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid_indetail = new System.Windows.Forms.DataGridView();
            this.DisPlaySet_Sub = new System.Data.DataSet();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skucodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skitemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indquanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inducodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel11.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_indetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisPlaySet_Sub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 30);
            this.panel1.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btn_OK);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(612, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(86, 30);
            this.panel9.TabIndex = 7;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(6, 4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "입고처리";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btn_reg);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(698, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(86, 30);
            this.panel8.TabIndex = 6;
            // 
            // btn_reg
            // 
            this.btn_reg.Location = new System.Drawing.Point(6, 4);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(75, 23);
            this.btn_reg.TabIndex = 1;
            this.btn_reg.Text = "등록";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_modify);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(784, 0);
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
            this.panel6.Location = new System.Drawing.Point(870, 0);
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
            this.panel5.Location = new System.Drawing.Point(354, 0);
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
            this.panel4.Location = new System.Drawing.Point(254, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 30);
            this.panel4.TabIndex = 2;
            // 
            // tbox_seed
            // 
            this.tbox_seed.Location = new System.Drawing.Point(3, 4);
            this.tbox_seed.Name = "tbox_seed";
            this.tbox_seed.Size = new System.Drawing.Size(93, 21);
            this.tbox_seed.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbox_SubCon);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(127, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(127, 30);
            this.panel3.TabIndex = 1;
            // 
            // cbox_SubCon
            // 
            this.cbox_SubCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_SubCon.FormattingEnabled = true;
            this.cbox_SubCon.Items.AddRange(new object[] {
            "거래처명"});
            this.cbox_SubCon.Location = new System.Drawing.Point(3, 4);
            this.cbox_SubCon.Name = "cbox_SubCon";
            this.cbox_SubCon.Size = new System.Drawing.Size(121, 20);
            this.cbox_SubCon.TabIndex = 1;
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
            "진행중",
            "입고완료"});
            this.cbox_MainCon.Location = new System.Drawing.Point(3, 4);
            this.cbox_MainCon.Name = "cbox_MainCon";
            this.cbox_MainCon.Size = new System.Drawing.Size(121, 20);
            this.cbox_MainCon.TabIndex = 0;
            this.cbox_MainCon.SelectedIndexChanged += new System.EventHandler(this.cbox_MainCon_SelectedIndexChanged);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.groupBox1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 30);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3);
            this.panel10.Size = new System.Drawing.Size(544, 460);
            this.panel10.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid_in);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "입고목록";
            // 
            // grid_in
            // 
            this.grid_in.AllowUserToAddRows = false;
            this.grid_in.AllowUserToDeleteRows = false;
            this.grid_in.AutoGenerateColumns = false;
            this.grid_in.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_in.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.grid_in.DataMember = "dp_InItems";
            this.grid_in.DataSource = this.DisplaySet;
            this.grid_in.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_in.Location = new System.Drawing.Point(3, 17);
            this.grid_in.Name = "grid_in";
            this.grid_in.ReadOnly = true;
            this.grid_in.RowHeadersVisible = false;
            this.grid_in.RowTemplate.Height = 23;
            this.grid_in.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_in.Size = new System.Drawing.Size(532, 434);
            this.grid_in.TabIndex = 0;
            this.grid_in.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_in_CellContentClick);
            this.grid_in.SelectionChanged += new System.EventHandler(this.grid_in_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "in_ucode";
            this.dataGridViewTextBoxColumn1.HeaderText = "입고번호";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "in_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "입고일";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "in_from";
            this.dataGridViewTextBoxColumn3.HeaderText = "공급처";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "in_items";
            this.dataGridViewTextBoxColumn4.HeaderText = "상품";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 180;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "in_price";
            this.dataGridViewTextBoxColumn5.HeaderText = "가격";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "in_status";
            this.dataGridViewTextBoxColumn6.HeaderText = "입고상태";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
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
            this.dataColumn6});
            this.dataTable1.TableName = "dp_InItems";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "in_ucode";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "in_date";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "in_from";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "in_items";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "in_price";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "in_status";
            this.dataColumn6.DataType = typeof(short);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(544, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 460);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.groupBox2);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(547, 30);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(409, 460);
            this.panel11.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid_indetail);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 460);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상세정보";
            // 
            // grid_indetail
            // 
            this.grid_indetail.AllowUserToAddRows = false;
            this.grid_indetail.AllowUserToDeleteRows = false;
            this.grid_indetail.AutoGenerateColumns = false;
            this.grid_indetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_indetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.skucodeDataGridViewTextBoxColumn,
            this.skitemnameDataGridViewTextBoxColumn,
            this.indquanDataGridViewTextBoxColumn,
            this.indpriceDataGridViewTextBoxColumn,
            this.inducodeDataGridViewTextBoxColumn});
            this.grid_indetail.DataMember = "dp_Initems_sub";
            this.grid_indetail.DataSource = this.DisPlaySet_Sub;
            this.grid_indetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_indetail.Location = new System.Drawing.Point(3, 17);
            this.grid_indetail.MultiSelect = false;
            this.grid_indetail.Name = "grid_indetail";
            this.grid_indetail.ReadOnly = true;
            this.grid_indetail.RowHeadersVisible = false;
            this.grid_indetail.RowTemplate.Height = 23;
            this.grid_indetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_indetail.Size = new System.Drawing.Size(403, 440);
            this.grid_indetail.TabIndex = 0;
            // 
            // DisPlaySet_Sub
            // 
            this.DisPlaySet_Sub.DataSetName = "NewDataSet";
            this.DisPlaySet_Sub.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable2});
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12});
            this.dataTable2.TableName = "dp_Initems_sub";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "ind_ucode";
            this.dataColumn7.DataType = typeof(int);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "ind_quan";
            this.dataColumn8.DataType = typeof(int);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "ind_price";
            this.dataColumn9.DataType = typeof(int);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "in_ucode";
            this.dataColumn10.DataType = typeof(int);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "sk_ucode";
            this.dataColumn11.DataType = typeof(int);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "sk_itemname";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "in_ucode";
            this.dataGridViewTextBoxColumn7.HeaderText = "입고번호";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // skucodeDataGridViewTextBoxColumn
            // 
            this.skucodeDataGridViewTextBoxColumn.DataPropertyName = "sk_ucode";
            this.skucodeDataGridViewTextBoxColumn.HeaderText = "상품코드";
            this.skucodeDataGridViewTextBoxColumn.Name = "skucodeDataGridViewTextBoxColumn";
            this.skucodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skitemnameDataGridViewTextBoxColumn
            // 
            this.skitemnameDataGridViewTextBoxColumn.DataPropertyName = "sk_itemname";
            this.skitemnameDataGridViewTextBoxColumn.HeaderText = "상품명";
            this.skitemnameDataGridViewTextBoxColumn.Name = "skitemnameDataGridViewTextBoxColumn";
            this.skitemnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indquanDataGridViewTextBoxColumn
            // 
            this.indquanDataGridViewTextBoxColumn.DataPropertyName = "ind_quan";
            this.indquanDataGridViewTextBoxColumn.HeaderText = "수량";
            this.indquanDataGridViewTextBoxColumn.Name = "indquanDataGridViewTextBoxColumn";
            this.indquanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indpriceDataGridViewTextBoxColumn
            // 
            this.indpriceDataGridViewTextBoxColumn.DataPropertyName = "ind_price";
            this.indpriceDataGridViewTextBoxColumn.HeaderText = "단가";
            this.indpriceDataGridViewTextBoxColumn.Name = "indpriceDataGridViewTextBoxColumn";
            this.indpriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inducodeDataGridViewTextBoxColumn
            // 
            this.inducodeDataGridViewTextBoxColumn.DataPropertyName = "ind_ucode";
            this.inducodeDataGridViewTextBoxColumn.HeaderText = "ind_ucode";
            this.inducodeDataGridViewTextBoxColumn.Name = "inducodeDataGridViewTextBoxColumn";
            this.inducodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.inducodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // InItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 490);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel1);
            this.Name = "InItemsView";
            this.Text = "InItemsView";
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel11.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_indetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisPlaySet_Sub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbox_seed;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbox_SubCon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbox_MainCon;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn inucodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn infromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instatusDataGridViewTextBoxColumn;
        private System.Data.DataSet DisplaySet;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid_indetail;
        private System.Data.DataSet DisPlaySet_Sub;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn skucodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indquanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inducodeDataGridViewTextBoxColumn;
    }
}