namespace QuanLy_NhaSach
{
    partial class UCAdminTools
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
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.btnChonDuongDanBackup = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpRestore = new System.Windows.Forms.GroupBox();
            this.btnChonDuongDanRestore = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grpBackup.SuspendLayout();
            this.grpRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.btnChonDuongDanBackup);
            this.grpBackup.Controls.Add(this.btnBackup);
            this.grpBackup.Controls.Add(this.txtBackupPath);
            this.grpBackup.Controls.Add(this.label1);
            this.grpBackup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpBackup.Location = new System.Drawing.Point(364, 50);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(500, 250);
            this.grpBackup.TabIndex = 0;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Sao Lưu Cơ Sở Dữ Liệu (Backup)";
            // 
            // btnChonDuongDanBackup
            // 
            this.btnChonDuongDanBackup.BackColor = System.Drawing.Color.LightGray;
            this.btnChonDuongDanBackup.FlatAppearance.BorderSize = 0;
            this.btnChonDuongDanBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonDuongDanBackup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChonDuongDanBackup.Location = new System.Drawing.Point(395, 100);
            this.btnChonDuongDanBackup.Name = "btnChonDuongDanBackup";
            this.btnChonDuongDanBackup.Size = new System.Drawing.Size(85, 32);
            this.btnChonDuongDanBackup.TabIndex = 3;
            this.btnChonDuongDanBackup.Text = "Chọn...";
            this.btnChonDuongDanBackup.UseVisualStyleBackColor = false;
            this.btnChonDuongDanBackup.Click += new System.EventHandler(this.btnChonDuongDanBackup_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(20, 170);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(460, 50);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "TIẾN HÀNH SAO LƯU";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBackupPath.Location = new System.Drawing.Point(20, 100);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(369, 30);
            this.txtBackupPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn thư mục lưu trữ file sao lưu (.bak):";
            // 
            // grpRestore
            // 
            this.grpRestore.Controls.Add(this.btnChonDuongDanRestore);
            this.grpRestore.Controls.Add(this.btnRestore);
            this.grpRestore.Controls.Add(this.txtRestorePath);
            this.grpRestore.Controls.Add(this.label2);
            this.grpRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpRestore.Location = new System.Drawing.Point(364, 330);
            this.grpRestore.Name = "grpRestore";
            this.grpRestore.Size = new System.Drawing.Size(500, 250);
            this.grpRestore.TabIndex = 1;
            this.grpRestore.TabStop = false;
            this.grpRestore.Text = "Phục Hồi Cơ Sở Dữ Liệu (Restore)";
            // 
            // btnChonDuongDanRestore
            // 
            this.btnChonDuongDanRestore.BackColor = System.Drawing.Color.LightGray;
            this.btnChonDuongDanRestore.FlatAppearance.BorderSize = 0;
            this.btnChonDuongDanRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonDuongDanRestore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChonDuongDanRestore.Location = new System.Drawing.Point(395, 100);
            this.btnChonDuongDanRestore.Name = "btnChonDuongDanRestore";
            this.btnChonDuongDanRestore.Size = new System.Drawing.Size(85, 32);
            this.btnChonDuongDanRestore.TabIndex = 3;
            this.btnChonDuongDanRestore.Text = "Chọn...";
            this.btnChonDuongDanRestore.UseVisualStyleBackColor = false;
            this.btnChonDuongDanRestore.Click += new System.EventHandler(this.btnChonDuongDanRestore_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(20, 170);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(460, 50);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "TIẾN HÀNH PHỤC HỒI (CẢNH BÁO)";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRestorePath.Location = new System.Drawing.Point(20, 100);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Size = new System.Drawing.Size(369, 30);
            this.txtRestorePath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn file sao lưu cần phục hồi (.bak file):";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            // 
            // UCAdminTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grpRestore);
            this.Controls.Add(this.grpBackup);
            this.Name = "UCAdminTools";
            this.Size = new System.Drawing.Size(1228, 721);
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.grpRestore.ResumeLayout(false);
            this.grpRestore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChonDuongDanBackup;
        private System.Windows.Forms.GroupBox grpRestore;
        private System.Windows.Forms.Button btnChonDuongDanRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtRestorePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}