namespace Thuc_Tap_CSDL
{
    partial class fStatistic
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
            this.grbStatistic = new Thuc_Tap_CSDL.ColorBorderGroupBox();
            this.cmb1 = new System.Windows.Forms.ComboBox();
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStatistic = new ePOSOne.btnProduct.Button_WOC();
            this.pnlClassID = new System.Windows.Forms.Panel();
            this.dgvStatistic = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grbStatistic.SuspendLayout();
            this.pnlClassID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbStatistic
            // 
            this.grbStatistic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.grbStatistic.Controls.Add(this.dataGridView1);
            this.grbStatistic.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.grbStatistic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.grbStatistic.Location = new System.Drawing.Point(12, 157);
            this.grbStatistic.Name = "grbStatistic";
            this.grbStatistic.Size = new System.Drawing.Size(919, 459);
            this.grbStatistic.TabIndex = 0;
            this.grbStatistic.TabStop = false;
            this.grbStatistic.Text = "Danh sách thống kê";
            // 
            // cmb1
            // 
            this.cmb1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.cmb1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.cmb1.FormattingEnabled = true;
            this.cmb1.Items.AddRange(new object[] {
            "Mã giáo viên",
            "Tên giáo viên"});
            this.cmb1.Location = new System.Drawing.Point(297, 12);
            this.cmb1.Name = "cmb1";
            this.cmb1.Size = new System.Drawing.Size(146, 25);
            this.cmb1.TabIndex = 92;
            this.cmb1.SelectedValueChanged += new System.EventHandler(this.cmb1_SelectedValueChanged);
            // 
            // cmb2
            // 
            this.cmb2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.cmb2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Items.AddRange(new object[] {
            "Mã giáo viên",
            "Tên giáo viên"});
            this.cmb2.Location = new System.Drawing.Point(449, 12);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(192, 25);
            this.cmb2.TabIndex = 92;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel18.Location = new System.Drawing.Point(420, 75);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(168, 1);
            this.panel18.TabIndex = 98;
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.Color.White;
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.txtMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.txtMonth.Location = new System.Drawing.Point(424, 55);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(161, 18);
            this.txtMonth.TabIndex = 95;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.label10.Location = new System.Drawing.Point(334, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 19);
            this.label10.TabIndex = 94;
            this.label10.Text = "Nhập tháng:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Location = new System.Drawing.Point(111, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 1);
            this.panel4.TabIndex = 101;
            // 
            // txtClassID
            // 
            this.txtClassID.BackColor = System.Drawing.Color.White;
            this.txtClassID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClassID.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.txtClassID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.txtClassID.Location = new System.Drawing.Point(115, 12);
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(161, 18);
            this.txtClassID.TabIndex = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.label9.Location = new System.Drawing.Point(26, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 19);
            this.label9.TabIndex = 99;
            this.label9.Text = "Mã lớp học:";
            // 
            // btnStatistic
            // 
            this.btnStatistic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(75)))));
            this.btnStatistic.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(75)))));
            this.btnStatistic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatistic.FlatAppearance.BorderSize = 0;
            this.btnStatistic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStatistic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistic.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnStatistic.ForeColor = System.Drawing.Color.Black;
            this.btnStatistic.Location = new System.Drawing.Point(415, 120);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.btnStatistic.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(39)))));
            this.btnStatistic.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStatistic.Size = new System.Drawing.Size(103, 29);
            this.btnStatistic.TabIndex = 102;
            this.btnStatistic.Text = "THỐNG KÊ";
            this.btnStatistic.TextColor = System.Drawing.Color.White;
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // pnlClassID
            // 
            this.pnlClassID.Controls.Add(this.label9);
            this.pnlClassID.Controls.Add(this.txtClassID);
            this.pnlClassID.Controls.Add(this.panel4);
            this.pnlClassID.Location = new System.Drawing.Point(310, 78);
            this.pnlClassID.Name = "pnlClassID";
            this.pnlClassID.Size = new System.Drawing.Size(309, 36);
            this.pnlClassID.TabIndex = 103;
            // 
            // dgvStatistic
            // 
            this.dgvStatistic.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatistic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvStatistic.Location = new System.Drawing.Point(9, 24);
            this.dgvStatistic.Name = "dgvStatistic";
            this.dgvStatistic.Size = new System.Drawing.Size(901, 426);
            this.dgvStatistic.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(907, 429);
            this.dataGridView1.TabIndex = 0;
            // 
            // fStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 628);
            this.Controls.Add(this.pnlClassID);
            this.Controls.Add(this.btnStatistic);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmb2);
            this.Controls.Add(this.cmb1);
            this.Controls.Add(this.grbStatistic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fStatistic";
            this.Text = "THỐNG KÊ DỮ LIỆU";
            this.Load += new System.EventHandler(this.fStatistic_Load);
            this.grbStatistic.ResumeLayout(false);
            this.pnlClassID.ResumeLayout(false);
            this.pnlClassID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorBorderGroupBox grbStatistic;
        private System.Windows.Forms.ComboBox cmb1;
        private System.Windows.Forms.ComboBox cmb2;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtClassID;
        private System.Windows.Forms.Label label9;
        private ePOSOne.btnProduct.Button_WOC btnStatistic;
        private System.Windows.Forms.Panel pnlClassID;
        private System.Windows.Forms.DataGridView dgvStatistic;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}