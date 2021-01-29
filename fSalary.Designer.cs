namespace Thuc_Tap_CSDL
{
    partial class fSalary
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
            this.pnlSalary = new System.Windows.Forms.Panel();
            this.cmbSalarySearch = new System.Windows.Forms.ComboBox();
            this.cmbSalaryBill = new System.Windows.Forms.ComboBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.colorBorderGroupBox1 = new Thuc_Tap_CSDL.ColorBorderGroupBox();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnPrintBill = new ePOSOne.btnProduct.Button_WOC();
            this.btnSalary_search = new ePOSOne.btnProduct.Button_WOC();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtSalaryBill = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSalary.SuspendLayout();
            this.colorBorderGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSalary
            // 
            this.pnlSalary.BackColor = System.Drawing.Color.White;
            this.pnlSalary.Controls.Add(this.cmbSalarySearch);
            this.pnlSalary.Controls.Add(this.cmbSalaryBill);
            this.pnlSalary.Controls.Add(this.panel14);
            this.pnlSalary.Controls.Add(this.panel13);
            this.pnlSalary.Controls.Add(this.colorBorderGroupBox1);
            this.pnlSalary.Controls.Add(this.panel1);
            this.pnlSalary.Controls.Add(this.panel11);
            this.pnlSalary.Controls.Add(this.panel10);
            this.pnlSalary.Controls.Add(this.btnPrintBill);
            this.pnlSalary.Controls.Add(this.btnSalary_search);
            this.pnlSalary.Controls.Add(this.panel7);
            this.pnlSalary.Controls.Add(this.panel2);
            this.pnlSalary.Controls.Add(this.textBox2);
            this.pnlSalary.Controls.Add(this.panel19);
            this.pnlSalary.Controls.Add(this.textBox1);
            this.pnlSalary.Controls.Add(this.txtSalaryBill);
            this.pnlSalary.Controls.Add(this.textBox10);
            this.pnlSalary.Controls.Add(this.label1);
            this.pnlSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSalary.Location = new System.Drawing.Point(0, 0);
            this.pnlSalary.Name = "pnlSalary";
            this.pnlSalary.Size = new System.Drawing.Size(943, 628);
            this.pnlSalary.TabIndex = 3;
            // 
            // cmbSalarySearch
            // 
            this.cmbSalarySearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.cmbSalarySearch.FormattingEnabled = true;
            this.cmbSalarySearch.Items.AddRange(new object[] {
            "Mã môn học",
            "Tên môn học"});
            this.cmbSalarySearch.Location = new System.Drawing.Point(554, 130);
            this.cmbSalarySearch.Name = "cmbSalarySearch";
            this.cmbSalarySearch.Size = new System.Drawing.Size(96, 25);
            this.cmbSalarySearch.TabIndex = 91;
            // 
            // cmbSalaryBill
            // 
            this.cmbSalaryBill.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.cmbSalaryBill.FormattingEnabled = true;
            this.cmbSalaryBill.Items.AddRange(new object[] {
            "Mã giáo viên",
            "Tên giáo viên"});
            this.cmbSalaryBill.Location = new System.Drawing.Point(554, 196);
            this.cmbSalaryBill.Name = "cmbSalaryBill";
            this.cmbSalaryBill.Size = new System.Drawing.Size(96, 25);
            this.cmbSalaryBill.TabIndex = 91;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Black;
            this.panel14.Location = new System.Drawing.Point(565, 617);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(365, 1);
            this.panel14.TabIndex = 85;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Black;
            this.panel13.Location = new System.Drawing.Point(13, 617);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(552, 1);
            this.panel13.TabIndex = 84;
            // 
            // colorBorderGroupBox1
            // 
            this.colorBorderGroupBox1.BorderColor = System.Drawing.Color.Transparent;
            this.colorBorderGroupBox1.Controls.Add(this.dgvSalary);
            this.colorBorderGroupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.colorBorderGroupBox1.Location = new System.Drawing.Point(15, 32);
            this.colorBorderGroupBox1.Name = "colorBorderGroupBox1";
            this.colorBorderGroupBox1.Size = new System.Drawing.Size(519, 583);
            this.colorBorderGroupBox1.TabIndex = 86;
            this.colorBorderGroupBox1.TabStop = false;
            this.colorBorderGroupBox1.Text = "Danh sách giáo viên của môn";
            // 
            // dgvSalary
            // 
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalary.Location = new System.Drawing.Point(6, 24);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.Size = new System.Drawing.Size(507, 557);
            this.dgvSalary.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(531, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 1);
            this.panel1.TabIndex = 80;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Black;
            this.panel11.Location = new System.Drawing.Point(12, 25);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(400, 1);
            this.panel11.TabIndex = 80;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(930, 26);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1, 592);
            this.panel10.TabIndex = 77;
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BorderColor = System.Drawing.Color.Black;
            this.btnPrintBill.ButtonColor = System.Drawing.Color.White;
            this.btnPrintBill.FlatAppearance.BorderSize = 0;
            this.btnPrintBill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrintBill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBill.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnPrintBill.ForeColor = System.Drawing.Color.Black;
            this.btnPrintBill.Location = new System.Drawing.Point(820, 186);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(168)))), ((int)(((byte)(156)))));
            this.btnPrintBill.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(168)))), ((int)(((byte)(156)))));
            this.btnPrintBill.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPrintBill.Size = new System.Drawing.Size(91, 42);
            this.btnPrintBill.TabIndex = 75;
            this.btnPrintBill.Text = "IN BIÊN LAI";
            this.btnPrintBill.TextColor = System.Drawing.Color.Black;
            this.btnPrintBill.UseVisualStyleBackColor = true;
            // 
            // btnSalary_search
            // 
            this.btnSalary_search.BorderColor = System.Drawing.Color.Black;
            this.btnSalary_search.ButtonColor = System.Drawing.Color.White;
            this.btnSalary_search.FlatAppearance.BorderSize = 0;
            this.btnSalary_search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSalary_search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSalary_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalary_search.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSalary_search.ForeColor = System.Drawing.Color.Black;
            this.btnSalary_search.Location = new System.Drawing.Point(820, 118);
            this.btnSalary_search.Name = "btnSalary_search";
            this.btnSalary_search.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(114)))), ((int)(((byte)(187)))));
            this.btnSalary_search.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(114)))), ((int)(((byte)(187)))));
            this.btnSalary_search.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSalary_search.Size = new System.Drawing.Size(91, 42);
            this.btnSalary_search.TabIndex = 75;
            this.btnSalary_search.Text = "TÌM";
            this.btnSalary_search.TextColor = System.Drawing.Color.Black;
            this.btnSalary_search.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(12, 26);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1, 592);
            this.panel7.TabIndex = 78;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(656, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 1);
            this.panel2.TabIndex = 62;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.textBox2.Location = new System.Drawing.Point(660, 131);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 18);
            this.textBox2.TabIndex = 53;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel19.Location = new System.Drawing.Point(656, 219);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(161, 1);
            this.panel19.TabIndex = 62;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.textBox1.Location = new System.Drawing.Point(660, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 18);
            this.textBox1.TabIndex = 49;
            // 
            // txtSalaryBill
            // 
            this.txtSalaryBill.BackColor = System.Drawing.Color.White;
            this.txtSalaryBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalaryBill.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.txtSalaryBill.Location = new System.Drawing.Point(660, 197);
            this.txtSalaryBill.Name = "txtSalaryBill";
            this.txtSalaryBill.Size = new System.Drawing.Size(154, 18);
            this.txtSalaryBill.TabIndex = 53;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.White;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.textBox10.Location = new System.Drawing.Point(660, 199);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(154, 18);
            this.textBox10.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(443, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "LƯƠNG";
            // 
            // fSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 628);
            this.Controls.Add(this.pnlSalary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSalary";
            this.Text = "QUẢN LÝ LƯƠNG";
            this.pnlSalary.ResumeLayout(false);
            this.pnlSalary.PerformLayout();
            this.colorBorderGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSalary;
        private System.Windows.Forms.ComboBox cmbSalaryBill;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private ColorBorderGroupBox colorBorderGroupBox1;
        private System.Windows.Forms.DataGridView dgvSalary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private ePOSOne.btnProduct.Button_WOC btnPrintBill;
        private ePOSOne.btnProduct.Button_WOC btnSalary_search;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TextBox txtSalaryBill;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSalarySearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}