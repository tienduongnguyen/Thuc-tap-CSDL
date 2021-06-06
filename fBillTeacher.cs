using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thuc_Tap_CSDL
{
    public partial class fBillTeacher : Form
    {
        string id = "";
        string teacherID = "";
        string classID = "";
        string sumDay = "";
        string sumSalary = "";
        string datePay = "";
        string payFor = "";

        public fBillTeacher(string id, string teacherID, string classID, string sumDay,
                            string sumSalary, string datePay, string payFor)
        {
            InitializeComponent();
            this.id = id;
            this.teacherID = teacherID;
            this.classID = classID;
            this.sumDay = sumDay;
            this.sumSalary = sumSalary;
            this.datePay = datePay;
            this.payFor = payFor;
        }

        private void fBillTeacher_Load(object sender, EventArgs e)
        {
            lblBillID.Text = id;
            lblTeacherID.Text = teacherID;
            lblClassID.Text = classID;
            lblSumDay.Text = sumDay;
            lblSumSalary.Text = sumSalary;
            lblDatePay.Text = datePay;
            lblPayFor.Text = payFor;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In thành công!!", "Thông báo", MessageBoxButtons.OK);
        }
    }
}
