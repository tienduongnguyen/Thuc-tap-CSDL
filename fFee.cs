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
    public partial class fFee : Form
    {
        public fFee()
        {
            InitializeComponent();
        }

        private void btnFee_bill_Click(object sender, EventArgs e)
        {
            txtFeeBill_id.Enabled = true;
            txtFeeBill_studentID.Enabled = true;
            txtFeeBill_classID.Enabled = true;
            txtFeeBill_sumDay.Enabled = true;
            txtFeeBill_feePerDay.Enabled = true;
            txtFeeBill_sumFee.Enabled = true;
            txtFeeBill_dateTake.Enabled = true;
            txtFeeBill_takeForDate.Enabled = true;
            ckbTaked.Enabled = true;
            btnFeeBill_add.Enabled = true;
            btnFeeBill_edit.Enabled = true;
            btnFeeBill_delete.Enabled = true;
            btnFeeBill_clear.Enabled = true;
        }
    }
}
