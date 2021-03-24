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
    public partial class fSalary : Form
    {
        public fSalary()
        {
            InitializeComponent();
        }

        private void btnSalary_bill_Click(object sender, EventArgs e)
        {
            txtSalaryBill_id.Enabled = true;
            txtSalaryBill_sumDay.Enabled = true;
            txtSalaryBill_sumMoney.Enabled = true;
            txtSalaryBill_teacherID.Enabled = true;
            txtSalaryBill_classID.Enabled = true;
            txtSalaryBill_datePay.Enabled = true;
            txtSalaryBill_datePayFor.Enabled = true;
            ckbPayed.Enabled = true;
            btnSalaryBill_add.Enabled = true;
            btnSalaryBill_edit.Enabled = true;
            btnSalaryBill_delete.Enabled = true;
            btnSalaryBill_clear.Enabled = true;
        }
    }
}
