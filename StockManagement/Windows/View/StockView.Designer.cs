namespace StockManagement.Windows.View
{
    partial class StockView
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
            this.DisplaySet = new System.Data.DataSet();
            this.dp_table = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_stock = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skitemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skmemoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skpictureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp_table)).BeginInit();
            this.panel10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_stock)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplaySet
            // 
            this.DisplaySet.DataSetName = "NewDataSet";
            this.DisplaySet.Tables.AddRange(new System.Data.DataTable[] {
            this.dp_table});
            // 
            // dp_table
            // 
            this.dp_table.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn6,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11});
            this.dp_table.TableName = "dp_stock";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "sk_itemcode";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "sk_itemsort";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "sk_itemname";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "sk_itemprice";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "sk_itemquan";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "sk_itemrecoquan";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "sk_itemrecentin";
            this.dataColumn7.DataType = typeof(System.DateTime);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "sk_itemrecentout";
            this.dataColumn8.DataType = typeof(System.DateTime);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "sk_memo";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "sk_status";
            this.dataColumn10.DataType = typeof(short);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "sk_picture";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.groupBox1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 30);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3);
            this.panel10.Size = new System.Drawing.Size(894, 460);
            this.panel10.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid_stock);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "재고목록";
            // 
            // grid_stock
            // 
            this.grid_stock.AllowUserToAddRows = false;
            this.grid_stock.AllowUserToDeleteRows = false;
            this.grid_stock.AutoGenerateColumns = false;
            this.grid_stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_stock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.skitemnameDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.skmemoDataGridViewTextBoxColumn,
            this.skstatusDataGridViewTextBoxColumn,
            this.skpictureDataGridViewTextBoxColumn});
            this.grid_stock.DataMember = "dp_stock";
            this.grid_stock.DataSource = this.DisplaySet;
            this.grid_stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_stock.Location = new System.Drawing.Point(3, 17);
            this.grid_stock.MultiSelect = false;
            this.grid_stock.Name = "grid_stock";
            this.grid_stock.ReadOnly = true;
            this.grid_stock.RowHeadersVisible = false;
            this.grid_stock.RowTemplate.Height = 23;
            this.grid_stock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_stock.Size = new System.Drawing.Size(882, 434);
            this.grid_stock.TabIndex = 0;
            // 
            // panel1
            // 
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
            this.panel1.Size = new System.Drawing.Size(894, 30);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(636, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(86, 30);
            this.panel8.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "상품 등록";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_modify);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(722, 0);
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
            this.btn_modify.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_delete);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(808, 0);
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
            this.panel5.Location = new System.Drawing.Point(381, 0);
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
            "건재",
            "철물",
            "설비",
            "전기",
            "공구",
            "산업용품",
            "잡화",
            "기타"});
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
            "품목별",
            "삭제상품"});
            this.cbox_MainCon.Location = new System.Drawing.Point(3, 4);
            this.cbox_MainCon.Name = "cbox_MainCon";
            this.cbox_MainCon.Size = new System.Drawing.Size(121, 20);
            this.cbox_MainCon.TabIndex = 0;
            this.cbox_MainCon.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sk_itemcode";
            this.dataGridViewTextBoxColumn1.HeaderText = "상품번호";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sk_itemsort";
            this.dataGridViewTextBoxColumn2.HeaderText = "품목";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // skitemnameDataGridViewTextBoxColumn
            // 
            this.skitemnameDataGridViewTextBoxColumn.DataPropertyName = "sk_itemname";
            this.skitemnameDataGridViewTextBoxColumn.HeaderText = "상품명";
            this.skitemnameDataGridViewTextBoxColumn.Name = "skitemnameDataGridViewTextBoxColumn";
            this.skitemnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sk_itemprice";
            this.dataGridViewTextBoxColumn3.HeaderText = "단가";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sk_itemquan";
            this.dataGridViewTextBoxColumn4.HeaderText = "수량";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "sk_itemrecoquan";
            this.dataGridViewTextBoxColumn5.HeaderText = "보유적정량";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "sk_itemrecentin";
            this.dataGridViewTextBoxColumn6.HeaderText = "최근입고";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "sk_itemrecentout";
            this.dataGridViewTextBoxColumn7.HeaderText = "최근출고";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // skmemoDataGridViewTextBoxColumn
            // 
            this.skmemoDataGridViewTextBoxColumn.DataPropertyName = "sk_memo";
            this.skmemoDataGridViewTextBoxColumn.HeaderText = "sk_memo";
            this.skmemoDataGridViewTextBoxColumn.Name = "skmemoDataGridViewTextBoxColumn";
            this.skmemoDataGridViewTextBoxColumn.ReadOnly = true;
            this.skmemoDataGridViewTextBoxColumn.Visible = false;
            // 
            // skstatusDataGridViewTextBoxColumn
            // 
            this.skstatusDataGridViewTextBoxColumn.DataPropertyName = "sk_status";
            this.skstatusDataGridViewTextBoxColumn.HeaderText = "삭제상태";
            this.skstatusDataGridViewTextBoxColumn.Name = "skstatusDataGridViewTextBoxColumn";
            this.skstatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skpictureDataGridViewTextBoxColumn
            // 
            this.skpictureDataGridViewTextBoxColumn.DataPropertyName = "sk_picture";
            this.skpictureDataGridViewTextBoxColumn.HeaderText = "sk_picture";
            this.skpictureDataGridViewTextBoxColumn.Name = "skpictureDataGridViewTextBoxColumn";
            this.skpictureDataGridViewTextBoxColumn.ReadOnly = true;
            this.skpictureDataGridViewTextBoxColumn.Visible = false;
            // 
            // StockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 490);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel1);
            this.Name = "StockView";
            this.Text = "StockView";
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp_table)).EndInit();
            this.panel10.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_stock)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbox_MainCon;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid_stock;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox tbox_seed;
        private System.Windows.Forms.ComboBox cbox_SubCon;
        private System.Data.DataSet DisplaySet;
        private System.Data.DataTable dp_table;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemsortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitempriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemquanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemrecoquanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemsetdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemrecentinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemrecentoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemmemoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn skstatusDataGridViewCheckBoxColumn;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button1;
        private System.Data.DataColumn dataColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn skmemoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skstatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skpictureDataGridViewTextBoxColumn;
    }
}