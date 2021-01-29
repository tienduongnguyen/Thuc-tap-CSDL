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
    public partial class fTeacher : Form
    {
        public fTeacher()
        {
            InitializeComponent();
        }

        private void txtTeacherBirth_Enter(object sender, EventArgs e)
        {
            if (txtTeacherBirth.Text == "YYYY-MM-DD")
            {
                txtTeacherBirth.Text = "";
                txtTeacherBirth.ForeColor = Color.Black;
            }
        }

        private void txtTeacherBirth_Leave(object sender, EventArgs e)
        {
            if (txtTeacherBirth.Text == "")
            {
                txtTeacherBirth.Text = "YYYY-MM-DD";
                txtTeacherBirth.ForeColor = Color.Silver;
            }
        }
    }
}
