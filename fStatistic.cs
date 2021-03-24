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
    public partial class fStatistic : Form
    {
        public fStatistic()
        {
            InitializeComponent();
        }

        List<string> listItem;

        private void btnStatistic_Click(object sender, EventArgs e)
        {

        }

        private void fStatistic_Load(object sender, EventArgs e)
        {
            listItem = new List<string>() { "Thống kê học phí", "Thống kê lương" };
            cmb1.DataSource = listItem;
        }

        private void cmb1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmb1.SelectedValue.ToString() == "Thống kê học phí")
            {
                listItem = new List<string>() { "Học sinh đã thu học phí", "Học sinh chưa thu học phí" };
                cmb2.DataSource = listItem;
                pnlClassID.Visible = true;
            }    
            if(cmb1.SelectedValue.ToString() == "Thống kê lương")
            {
                listItem = new List<string>() { "Giáo viên đã trả lương", "Giáo viên chưa trả lương" };
                cmb2.DataSource = listItem;
                pnlClassID.Visible = false;
            }    
        }
    }
}
