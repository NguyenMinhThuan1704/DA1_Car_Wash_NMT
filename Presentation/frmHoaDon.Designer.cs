namespace Presentation
{
    partial class frmHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.clmathuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsolg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.clmadv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltendv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvhoadon = new System.Windows.Forms.DataGridView();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbPriceText = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.clma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIncrease = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDecrement = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDestroy);
            this.panel1.Controls.Add(this.btnPay);
            this.panel1.Controls.Add(this.lbPrice);
            this.panel1.Controls.Add(this.lbPriceText);
            this.panel1.Controls.Add(this.dgvhoadon);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 683);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(483, 50);
            this.panel5.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(117, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(483, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 683);
            this.panel2.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            this.panel7.Controls.Add(this.label8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(484, 50);
            this.panel7.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(148, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "THÔNG TIN DỊCH VỤ";
            // 
            // clmathuoc
            // 
            this.clmathuoc.DataPropertyName = "MaThuoc";
            this.clmathuoc.HeaderText = "Mã thuốc";
            this.clmathuoc.Name = "clmathuoc";
            this.clmathuoc.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "TenThuoc";
            this.colName.HeaderText = "Tên thuốc";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "GiaBan";
            this.colPrice.HeaderText = "Giá bán";
            this.colPrice.MinimumWidth = 8;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // clsolg
            // 
            this.clsolg.DataPropertyName = "Soluong";
            this.clsolg.HeaderText = "Số lượng";
            this.clsolg.Name = "clsolg";
            this.clsolg.ReadOnly = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 61);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(267, 38);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Gray;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(285, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 38);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(374, 61);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 38);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDichVu);
            this.groupBox1.Location = new System.Drawing.Point(7, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 564);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin dịch vụ";
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.AllowUserToResizeColumns = false;
            this.dgvDichVu.AllowUserToResizeRows = false;
            this.dgvDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDichVu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDichVu.ColumnHeadersHeight = 35;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmadv,
            this.coltendv,
            this.colgia,
            this.clsoluong});
            this.dgvDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDichVu.EnableHeadersVisualStyles = false;
            this.dgvDichVu.Location = new System.Drawing.Point(3, 16);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.Size = new System.Drawing.Size(461, 545);
            this.dgvDichVu.TabIndex = 8;
            this.dgvDichVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDichVu_CellClick);
            // 
            // clmadv
            // 
            this.clmadv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmadv.DataPropertyName = "Madv";
            this.clmadv.HeaderText = "ID";
            this.clmadv.Name = "clmadv";
            this.clmadv.Width = 48;
            // 
            // coltendv
            // 
            this.coltendv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coltendv.DataPropertyName = "Tendv";
            this.coltendv.HeaderText = "Tên dịch vụ";
            this.coltendv.Name = "coltendv";
            // 
            // colgia
            // 
            this.colgia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colgia.DataPropertyName = "Giadv";
            this.colgia.HeaderText = "Giá dịch vụ";
            this.colgia.Name = "colgia";
            this.colgia.Width = 116;
            // 
            // clsoluong
            // 
            this.clsoluong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clsoluong.DataPropertyName = "Soluong";
            this.clsoluong.HeaderText = "Số lượng";
            this.clsoluong.Name = "clsoluong";
            this.clsoluong.Width = 91;
            // 
            // dgvhoadon
            // 
            this.dgvhoadon.AllowUserToAddRows = false;
            this.dgvhoadon.AllowUserToDeleteRows = false;
            this.dgvhoadon.AllowUserToResizeColumns = false;
            this.dgvhoadon.AllowUserToResizeRows = false;
            this.dgvhoadon.BackgroundColor = System.Drawing.Color.White;
            this.dgvhoadon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvhoadon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvhoadon.ColumnHeadersHeight = 35;
            this.dgvhoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvhoadon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clma,
            this.clten,
            this.cldongia,
            this.clsl,
            this.btnIncrease,
            this.btnDecrement});
            this.dgvhoadon.EnableHeadersVisualStyles = false;
            this.dgvhoadon.Location = new System.Drawing.Point(0, 61);
            this.dgvhoadon.Name = "dgvhoadon";
            this.dgvhoadon.RowHeadersVisible = false;
            this.dgvhoadon.Size = new System.Drawing.Size(483, 499);
            this.dgvhoadon.TabIndex = 9;
            this.dgvhoadon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvhoadon_CellContentClick);
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(76, 585);
            this.lbPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(19, 20);
            this.lbPrice.TabIndex = 15;
            this.lbPrice.Text = "0";
            // 
            // lbPriceText
            // 
            this.lbPriceText.AutoSize = true;
            this.lbPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPriceText.Location = new System.Drawing.Point(11, 585);
            this.lbPriceText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPriceText.Name = "lbPriceText";
            this.lbPriceText.Size = new System.Drawing.Size(64, 20);
            this.lbPriceText.TabIndex = 14;
            this.lbPriceText.Text = "Tổng : ";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(15, 633);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(197, 38);
            this.btnPay.TabIndex = 18;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnDestroy
            // 
            this.btnDestroy.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDestroy.FlatAppearance.BorderSize = 0;
            this.btnDestroy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestroy.ForeColor = System.Drawing.Color.White;
            this.btnDestroy.Location = new System.Drawing.Point(270, 633);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(197, 38);
            this.btnDestroy.TabIndex = 19;
            this.btnDestroy.Text = "Hủy";
            this.btnDestroy.UseVisualStyleBackColor = false;
            this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
            // 
            // clma
            // 
            this.clma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clma.HeaderText = "ID";
            this.clma.Name = "clma";
            this.clma.Width = 48;
            // 
            // clten
            // 
            this.clten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clten.HeaderText = "Tên dịch vụ";
            this.clten.Name = "clten";
            // 
            // cldongia
            // 
            this.cldongia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cldongia.HeaderText = "Đơn giá";
            this.cldongia.Name = "cldongia";
            this.cldongia.Width = 89;
            // 
            // clsl
            // 
            this.clsl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clsl.HeaderText = "Số lượng";
            this.clsl.Name = "clsl";
            this.clsl.Width = 91;
            // 
            // btnIncrease
            // 
            this.btnIncrease.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnIncrease.HeaderText = "";
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnIncrease.Width = 17;
            // 
            // btnDecrement
            // 
            this.btnDecrement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnDecrement.HeaderText = "";
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnDecrement.Width = 17;
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(967, 683);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHoaDon";
            this.Text = "frmHoaDon";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmathuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clsolg;
        private System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnDestroy;
        public System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbPriceText;
        private System.Windows.Forms.DataGridView dgvhoadon;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmadv;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltendv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clsoluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clma;
        private System.Windows.Forms.DataGridViewTextBoxColumn clten;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clsl;
        private System.Windows.Forms.DataGridViewButtonColumn btnIncrease;
        private System.Windows.Forms.DataGridViewButtonColumn btnDecrement;
    }
}