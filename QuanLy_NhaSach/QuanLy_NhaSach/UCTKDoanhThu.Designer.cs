namespace QuanLy_NhaSach
{
    partial class UCTKDoanhThu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongChiPhi = new System.Windows.Forms.Label();
            this.lblLoiNhuan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(614, 18);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 24;
            this.dgvBaoCao.Size = new System.Drawing.Size(598, 275);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBaoCao);
            this.groupBox1.Controls.Add(this.btnXemBaoCao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblLoiNhuan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblTongChiPhi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTongDoanhThu);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox1.Location = new System.Drawing.Point(3, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1222, 299);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chartDoanhThu
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend2);
            this.chartDoanhThu.Location = new System.Drawing.Point(266, 342);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDoanhThu.Series.Add(series2);
            this.chartDoanhThu.Size = new System.Drawing.Size(675, 376);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tổng Doanh Thu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tổng Lợi Nhuận:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(207, 150);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(116, 25);
            this.lblTongDoanhThu.TabIndex = 8;
            this.lblTongDoanhThu.Text = "10,000,000 đ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng Chi Phí Nhập:";
            // 
            // lblTongChiPhi
            // 
            this.lblTongChiPhi.AutoSize = true;
            this.lblTongChiPhi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongChiPhi.Location = new System.Drawing.Point(207, 189);
            this.lblTongChiPhi.Name = "lblTongChiPhi";
            this.lblTongChiPhi.Size = new System.Drawing.Size(106, 25);
            this.lblTongChiPhi.TabIndex = 9;
            this.lblTongChiPhi.Text = "5,000,000 đ";
            // 
            // lblLoiNhuan
            // 
            this.lblLoiNhuan.AutoSize = true;
            this.lblLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLoiNhuan.Location = new System.Drawing.Point(207, 229);
            this.lblLoiNhuan.Name = "lblLoiNhuan";
            this.lblLoiNhuan.Size = new System.Drawing.Size(106, 25);
            this.lblLoiNhuan.TabIndex = 10;
            this.lblLoiNhuan.Text = "5,000,000 đ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDenNgay.Location = new System.Drawing.Point(127, 83);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(249, 32);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTuNgay.Location = new System.Drawing.Point(127, 42);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(249, 32);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBaoCao.Location = new System.Drawing.Point(395, 48);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(168, 60);
            this.btnXemBaoCao.TabIndex = 4;
            this.btnXemBaoCao.Text = "Xem Báo Cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";
            // 
            // UCTKDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCTKDoanhThu";
            this.Size = new System.Drawing.Size(1228, 721);
            this.Load += new System.EventHandler(this.UCTKDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongChiPhi;
        private System.Windows.Forms.Label lblLoiNhuan;
    }
}
