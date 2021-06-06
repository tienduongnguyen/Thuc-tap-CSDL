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
    public partial class fBillStudent : Form
    {
        string id = "";
        string studentID = "";
        string classID = "";
        string sumDay = "";
        string feePerDay = "";
        string sumFee = "";
        string dateTake = "";
        string takeFor = "";

        public fBillStudent(string id, string studentID, string classID, string sumDay, string feePerDay, 
                            string sumFee, string dateTake, string takeFor)
        {
            InitializeComponent();
            this.id = id;
            this.studentID = studentID;
            this.classID = classID;
            this.sumDay = sumDay;
            this.feePerDay = feePerDay;
            this.sumFee = sumFee;
            this.dateTake = dateTake;
            this.takeFor = takeFor;
        }

        private void fBillStudent_Load(object sender, EventArgs e)
        {
            lblBillID.Text = id;
            lblStudentID.Text = studentID;
            lblClassID.Text = classID;
            lblSumDay.Text = sumDay;
            lblFeePerDay.Text = feePerDay;
            lblSumFee.Text = sumFee;
            lblDateTake.Text = dateTake;
            lblTakeFor.Text = takeFor;
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
