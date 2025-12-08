namespace QuanLy_NhaSach
{
    partial class UCTKDoanhThu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBaoCao = new System.Windows.Forms.Panel();
            this.tabBaoCao = new System.Windows.Forms.TabControl();
            this.tpBieuDo = new System.Windows.Forms.TabPage();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpLichSuBan = new System.Windows.Forms.TabPage();
            this.dgvLichSuBan = new System.Windows.Forms.DataGridView();
            this.tpLichSuNhap = new System.Windows.Forms.TabPage();
            this.dgvLichSuNhap = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.pnlLoiNhuan = new System.Windows.Forms.Panel();
            this.lblLoiNhuan = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlGiaVon = new System.Windows.Forms.Panel();
            this.lblGiaVon = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBaoCao.SuspendLayout();
            this.tabBaoCao.SuspendLayout();
            this.tpBieuDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.tpLichSuBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuBan)).BeginInit();
            this.tpLichSuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuNhap)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.pnlLoiNhuan.SuspendLayout();
            this.pnlDoanhThu.SuspendLayout();
            this.pnlGiaVon.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnXemBaoCao);
            this.pnlTop.Controls.Add(this.dtpKetThuc);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.dtpBatDau);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1228, 90);
            this.pnlTop.TabIndex = 0;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXemBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(892, 25);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(150, 40);
            this.btnXemBaoCao.TabIndex = 5;
            this.btnXemBaoCao.Text = "Xem Báo Cáo 🔍";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKetThuc.Location = new System.Drawing.Point(672, 30);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(200, 30);
            this.dtpKetThuc.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(582, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày:";
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBatDau.Location = new System.Drawing.Point(362, 30);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(200, 30);
            this.dtpBatDau.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(280, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO TÀI CHÍNH";
            // 
            // pnlBaoCao
            // 
            this.pnlBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlBaoCao.Controls.Add(this.tabBaoCao);
            this.pnlBaoCao.Controls.Add(this.pnlSummary);
            this.pnlBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaoCao.Location = new System.Drawing.Point(0, 90);
            this.pnlBaoCao.Name = "pnlBaoCao";
            this.pnlBaoCao.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBaoCao.Size = new System.Drawing.Size(1228, 631);
            this.pnlBaoCao.TabIndex = 1;
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.tpBieuDo);
            this.tabBaoCao.Controls.Add(this.tpLichSuBan);
            this.tabBaoCao.Controls.Add(this.tpLichSuNhap);
            this.tabBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabBaoCao.Location = new System.Drawing.Point(20, 220);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.SelectedIndex = 0;
            this.tabBaoCao.Size = new System.Drawing.Size(1188, 391);
            this.tabBaoCao.TabIndex = 3;
            // 
            // tpBieuDo
            // 
            this.tpBieuDo.Controls.Add(this.chartDoanhThu);
            this.tpBieuDo.Location = new System.Drawing.Point(4, 32);
            this.tpBieuDo.Name = "tpBieuDo";
            this.tpBieuDo.Padding = new System.Windows.Forms.Padding(3);
            this.tpBieuDo.Size = new System.Drawing.Size(1180, 355);
            this.tpBieuDo.TabIndex = 0;
            this.tpBieuDo.Text = "Biểu đồ Doanh thu";
            this.tpBieuDo.UseVisualStyleBackColor = true;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(1174, 349);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chartDoanhThu";
            // 
            // tpLichSuBan
            // 
            this.tpLichSuBan.Controls.Add(this.dgvLichSuBan);
            this.tpLichSuBan.Location = new System.Drawing.Point(4, 32);
            this.tpLichSuBan.Name = "tpLichSuBan";
            this.tpLichSuBan.Padding = new System.Windows.Forms.Padding(3);
            this.tpLichSuBan.Size = new System.Drawing.Size(1180, 355);
            this.tpLichSuBan.TabIndex = 1;
            this.tpLichSuBan.Text = "Lịch sử Bán hàng";
            this.tpLichSuBan.UseVisualStyleBackColor = true;
            // 
            // dgvLichSuBan
            // 
            this.dgvLichSuBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuBan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvLichSuBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichSuBan.ColumnHeadersHeight = 35;
            this.dgvLichSuBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuBan.Location = new System.Drawing.Point(3, 3);
            this.dgvLichSuBan.Name = "dgvLichSuBan";
            this.dgvLichSuBan.RowHeadersWidth = 51;
            this.dgvLichSuBan.RowTemplate.Height = 30;
            this.dgvLichSuBan.Size = new System.Drawing.Size(1174, 349);
            this.dgvLichSuBan.TabIndex = 0;
            // 
            // tpLichSuNhap
            // 
            this.tpLichSuNhap.Controls.Add(this.dgvLichSuNhap);
            this.tpLichSuNhap.Location = new System.Drawing.Point(4, 32);
            this.tpLichSuNhap.Name = "tpLichSuNhap";
            this.tpLichSuNhap.Size = new System.Drawing.Size(1180, 355);
            this.tpLichSuNhap.TabIndex = 2;
            this.tpLichSuNhap.Text = "Lịch sử Nhập hàng";
            this.tpLichSuNhap.UseVisualStyleBackColor = true;
            // 
            // dgvLichSuNhap
            // 
            this.dgvLichSuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuNhap.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvLichSuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichSuNhap.ColumnHeadersHeight = 35;
            this.dgvLichSuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuNhap.Location = new System.Drawing.Point(0, 0);
            this.dgvLichSuNhap.Name = "dgvLichSuNhap";
            this.dgvLichSuNhap.RowHeadersWidth = 51;
            this.dgvLichSuNhap.RowTemplate.Height = 30;
            this.dgvLichSuNhap.Size = new System.Drawing.Size(1180, 355);
            this.dgvLichSuNhap.TabIndex = 1;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.pnlLoiNhuan);
            this.pnlSummary.Controls.Add(this.pnlDoanhThu);
            this.pnlSummary.Controls.Add(this.pnlGiaVon);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(20, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1188, 200);
            this.pnlSummary.TabIndex = 2;
            // 
            // pnlLoiNhuan
            // 
            this.pnlLoiNhuan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlLoiNhuan.Controls.Add(this.lblLoiNhuan);
            this.pnlLoiNhuan.Controls.Add(this.label9);
            this.pnlLoiNhuan.Location = new System.Drawing.Point(820, 40);
            this.pnlLoiNhuan.Name = "pnlLoiNhuan";
            this.pnlLoiNhuan.Size = new System.Drawing.Size(350, 150);
            this.pnlLoiNhuan.TabIndex = 2;
            // 
            // lblLoiNhuan
            // 
            this.lblLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoiNhuan.ForeColor = System.Drawing.Color.White;
            this.lblLoiNhuan.Location = new System.Drawing.Point(10, 70);
            this.lblLoiNhuan.Name = "lblLoiNhuan";
            this.lblLoiNhuan.Size = new System.Drawing.Size(330, 45);
            this.lblLoiNhuan.TabIndex = 1;
            this.lblLoiNhuan.Text = "0 VNĐ";
            this.lblLoiNhuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(10, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "LỢI NHUẬN";
            // 
            // pnlDoanhThu
            // 
            this.pnlDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThu);
            this.pnlDoanhThu.Controls.Add(this.label7);
            this.pnlDoanhThu.Location = new System.Drawing.Point(440, 40);
            this.pnlDoanhThu.Name = "pnlDoanhThu";
            this.pnlDoanhThu.Size = new System.Drawing.Size(350, 150);
            this.pnlDoanhThu.TabIndex = 1;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThu.Location = new System.Drawing.Point(10, 70);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(330, 45);
            this.lblDoanhThu.TabIndex = 1;
            this.lblDoanhThu.Text = "0 VNĐ";
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(10, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "DOANH THU";
            // 
            // pnlGiaVon
            // 
            this.pnlGiaVon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.pnlGiaVon.Controls.Add(this.lblGiaVon);
            this.pnlGiaVon.Controls.Add(this.label5);
            this.pnlGiaVon.Location = new System.Drawing.Point(60, 40);
            this.pnlGiaVon.Name = "pnlGiaVon";
            this.pnlGiaVon.Size = new System.Drawing.Size(350, 150);
            this.pnlGiaVon.TabIndex = 0;
            // 
            // lblGiaVon
            // 
            this.lblGiaVon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblGiaVon.ForeColor = System.Drawing.Color.White;
            this.lblGiaVon.Location = new System.Drawing.Point(10, 70);
            this.lblGiaVon.Name = "lblGiaVon";
            this.lblGiaVon.Size = new System.Drawing.Size(330, 45);
            this.lblGiaVon.TabIndex = 1;
            this.lblGiaVon.Text = "0 VNĐ";
            this.lblGiaVon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "GIÁ VỐN";
            // 
            // UCTKDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBaoCao);
            this.Controls.Add(this.pnlTop);
            this.Name = "UCTKDoanhThu";
            this.Size = new System.Drawing.Size(1228, 721);
            this.Load += new System.EventHandler(this.UCTKDoanhThu_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBaoCao.ResumeLayout(false);
            this.tabBaoCao.ResumeLayout(false);
            this.tpBieuDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.tpLichSuBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuBan)).EndInit();
            this.tpLichSuNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuNhap)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlLoiNhuan.ResumeLayout(false);
            this.pnlLoiNhuan.PerformLayout();
            this.pnlDoanhThu.ResumeLayout(false);
            this.pnlDoanhThu.PerformLayout();
            this.pnlGiaVon.ResumeLayout(false);
            this.pnlGiaVon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBaoCao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Panel pnlGiaVon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGiaVon;
        private System.Windows.Forms.Panel pnlLoiNhuan;
        private System.Windows.Forms.Label lblLoiNhuan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlDoanhThu;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.TabControl tabBaoCao;
        private System.Windows.Forms.TabPage tpBieuDo;
        private System.Windows.Forms.TabPage tpLichSuBan;
        private System.Windows.Forms.TabPage tpLichSuNhap;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataGridView dgvLichSuBan;
        private System.Windows.Forms.DataGridView dgvLichSuNhap;
    }
}