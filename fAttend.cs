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
        //int sum = 49;
        //int present;



        public fAttend(string id1, string id2)
        {
            InitializeComponent();
            lbl2.Text = id1;
            lbl.Text = id2;
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
            for (int i = 0; i < dgvAttend.Rows.Count; i++)
            {
                string sqlCode = "UPDATE DIEMDANH SET TichVang='" + dgvAttend.Rows[i].Cells[4].Value + "' WHERE MaHocSinh='" + dgvAttend.Rows[i].Cells[2].Value + "'";
                SqlCommand cmd = new SqlCommand(sqlCode, con);

                //cmd.Parameters.AddWithValue("@p1", dgvAttend.Rows[i].Cells[4].Value);
                //cmd.Parameters.AddWithValue("@p2", dgvAttend.Rows[i].Cells[2].Value);

                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Điểm danh thành công");
            btnAttend_cancel.Text = "THOÁT";
        }

        private void fAttend_Load(object sender, EventArgs e)
        {
            //lblSum.Text = sum.ToString();

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Displayattend();
        }

        public virtual void Displayattend()
        {
            string sqlCode = "select MaLopHoc, MaBuoiHoc, dd.MaHocSinh, TenHocSinh, TichVang from DIEMDANH dd, DANHSACHLOP dsl, HOCSINH hs where dsl.MaHocSinh = hs.MaHocSinh and hs.MaHocSinh = dd.MaHocSinh and MaLopHoc='" + lbl2.Text + "' and MaBuoiHoc='" + lbl.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dgvAttend.DataSource = dataTable;
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
