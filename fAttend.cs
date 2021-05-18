using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Thuc_Tap_CSDL
{
    public partial class fAttend : Form
    {
        int sum = 49;
        //int present;

        

        public fAttend()
        {
            InitializeComponent();
           
        }

        
        private Form activeForm;
        SqlConnection con;


        private void openChildForm(Form childForm, object btnsender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlAttend.Controls.Add(childForm);
            this.pnlAttend.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnAttend_cancel_Click(object sender, EventArgs e)
        {
            openChildForm(new fClass(), sender);
        }

        private void btnAttend_confirm_Click(object sender, EventArgs e)
        {
            btnAttend_cancel.Text = "THOÁT";
        }

        private void fAttend_Load(object sender, EventArgs e)
        {
          
            lblSum.Text = sum.ToString();


            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Displayattend();
        }

        public  virtual void Displayattend()
        {
           
            string sqlCode = "SELECT HOCSINH.MaHocSinh, TenHocSinh FROM HOCSINH, DANHSACHLOP, BUOIHOC Where DANHSACHLOP.MaHocSinh=HOCSINH.MaHocSinh AND DANHSACHLOP.MaLopHoc=BUOIHOC.MaLopHoc AND MaBuoiHoc = '" + lbl + "' ";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dgvAttend.DataSource = dataTable;


            string sqlCode1 = "SELECT count(HOCSINH.MaHocSinh) FROM HOCSINH, DANHSACHLOP, BUOIHOC Where DANHSACHLOP.MaHocSinh=HOCSINH.MaHocSinhAND DANHSACHLOP.MaLopHoc=BUOIHOC.MaLopHoc AND MaBuoiHoc = '" + lbl + "'";
            SqlCommand cmd1 = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader1 = cmd.ExecuteReader();
            DataTable dataTable1 = new DataTable();


            dataTable1.Load(dataReader);
            soluong.DataSource = dataTable1;
        }

        private void dgvAttend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblPresent_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
