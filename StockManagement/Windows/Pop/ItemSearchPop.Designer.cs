namespace StockManagement.Windows.Pop
{
    partial class ItemSearchPop
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grid_ItemSearch = new System.Windows.Forms.DataGridView();
            this.skitemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skitemsortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skitemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skitempriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skitemquanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplaySet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbox_seed = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbox_SubCon = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbox_MainCon = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ItemSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(731, 406);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상품 찾기";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.grid_ItemSearch);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 47);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(719, 350);
            this.panel7.TabIndex = 2;
            // 
            // grid_ItemSearch
            // 
            this.grid_ItemSearch.AllowUserToAddRows = false;
            this.grid_ItemSearch.AllowUserToDeleteRows = false;
            this.grid_ItemSearch.AutoGenerateColumns = false;
            this.grid_ItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_ItemSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.skitemcodeDataGridViewTextBoxColumn,
            this.skitemsortDataGridViewTextBoxColumn,
            this.skitemnameDataGridViewTextBoxColumn,
            this.skitempriceDataGridViewTextBoxColumn,
            this.skitemquanDataGridViewTextBoxColumn});
            this.grid_ItemSearch.DataMember = "dp_table";
            this.grid_ItemSearch.DataSource = this.DisplaySet;
            this.grid_ItemSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_ItemSearch.Location = new System.Drawing.Point(0, 0);
            this.grid_ItemSearch.MultiSelect = false;
            this.grid_ItemSearch.Name = "grid_ItemSearch";
            this.grid_ItemSearch.ReadOnly = true;
            this.grid_ItemSearch.RowHeadersVisible = false;
            this.grid_ItemSearch.RowTemplate.Height = 23;
            this.grid_ItemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_ItemSearch.Size = new System.Drawing.Size(719, 350);
            this.grid_ItemSearch.TabIndex = 0;
            this.grid_ItemSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_ItemSearch_CellContentClick);
            this.grid_ItemSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid_ItemSearch_MouseDoubleClick);
            // 
            // skitemcodeDataGridViewTextBoxColumn
            // 
            this.skitemcodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.skitemcodeDataGridViewTextBoxColumn.DataPropertyName = "sk_itemcode";
            this.skitemcodeDataGridViewTextBoxColumn.HeaderText = "sk_itemcode";
            this.skitemcodeDataGridViewTextBoxColumn.Name = "skitemcodeDataGridViewTextBoxColumn";
            this.skitemcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skitemsortDataGridViewTextBoxColumn
            // 
            this.skitemsortDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.skitemsortDataGridViewTextBoxColumn.DataPropertyName = "sk_itemsort";
            this.skitemsortDataGridViewTextBoxColumn.HeaderText = "sk_itemsort";
            this.skitemsortDataGridViewTextBoxColumn.Name = "skitemsortDataGridViewTextBoxColumn";
            this.skitemsortDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skitemnameDataGridViewTextBoxColumn
            // 
            this.skitemnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.skitemnameDataGridViewTextBoxColumn.DataPropertyName = "sk_itemname";
            this.skitemnameDataGridViewTextBoxColumn.HeaderText = "sk_itemname";
            this.skitemnameDataGridViewTextBoxColumn.Name = "skitemnameDataGridViewTextBoxColumn";
            this.skitemnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skitempriceDataGridViewTextBoxColumn
            // 
            this.skitempriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.skitempriceDataGridViewTextBoxColumn.DataPropertyName = "sk_itemprice";
            this.skitempriceDataGridViewTextBoxColumn.HeaderText = "sk_itemprice";
            this.skitempriceDataGridViewTextBoxColumn.Name = "skitempriceDataGridViewTextBoxColumn";
            this.skitempriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skitemquanDataGridViewTextBoxColumn
            // 
            this.skitemquanDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.skitemquanDataGridViewTextBoxColumn.DataPropertyName = "sk_itemquan";
            this.skitemquanDataGridViewTextBoxColumn.HeaderText = "sk_itemquan";
            this.skitemquanDataGridViewTextBoxColumn.Name = "skitemquanDataGridViewTextBoxColumn";
            this.skitemquanDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.dataColumn5});
            this.dataTable1.TableName = "dp_table";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "sk_itemcode";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "sk_itemsort";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "sk_itemname";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "sk_itemprice";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "sk_itemquan";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 30);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_add);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(633, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(86, 30);
            this.panel6.TabIndex = 4;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(6, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "추가";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
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
            this.cbox_SubCon.FormattingEnabled = true;
            this.cbox_SubCon.Items.AddRange(new object[] {
            "건재",
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
            // panel8
            // 
            this.panel8.Controls.Add(this.cbox_MainCon);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(127, 30);
            this.panel8.TabIndex = 0;
            // 
            // cbox_MainCon
            // 
            this.cbox_MainCon.FormattingEnabled = true;
            this.cbox_MainCon.Items.AddRange(new object[] {
            "전체",
            "품목별"});
            this.cbox_MainCon.Location = new System.Drawing.Point(3, 4);
            this.cbox_MainCon.Name = "cbox_MainCon";
            this.cbox_MainCon.Size = new System.Drawing.Size(121, 20);
            this.cbox_MainCon.TabIndex = 0;
            this.cbox_MainCon.SelectedIndexChanged += new System.EventHandler(this.cbox_MainCon_SelectedIndexChanged);
            // 
            // ItemSearchPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 406);
            this.Controls.Add(this.panel1);
            this.Name = "ItemSearchPop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "검색";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_ItemSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbox_seed;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbox_SubCon;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox cbox_MainCon;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView grid_ItemSearch;
        private System.Data.DataSet DisplaySet;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemsortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitempriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skitemquanDataGridViewTextBoxColumn;
    }
}