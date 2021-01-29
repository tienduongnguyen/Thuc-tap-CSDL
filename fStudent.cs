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
    public partial class fStudent : Form
    {
        public fStudent()
        {
            InitializeComponent();
        }

        private void fStudent_Load(object sender, EventArgs e)
        {
            txtStudentID.Focus();
        }

        private void txtStudentBirth_Enter(object sender, EventArgs e)
        {
            if(txtStudentBirth.Text == "YYYY-MM-DD")
            {
                txtStudentBirth.Text = "";
                txtStudentBirth.ForeColor = Color.Black;
            }
        }

        private void txtStudentBirth_Leave(object sender, EventArgs e)
        {
            if(txtStudentBirth.Text == "")
            {
                txtStudentBirth.Text = "YYYY-MM-DD";
                txtStudentBirth.ForeColor = Color.Silver;
            }
        }
    }
}
