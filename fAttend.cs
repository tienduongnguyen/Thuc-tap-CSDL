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
            lblClassID.Text = id1;
            lblLessonID.Text = id2;
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
            int row = dgvAttend.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                string sqlCode = "UPDATE DIEMDANH SET TichVang = '" + dgvAttend.Rows[i].Cells[2].Value + "' " +
                                 "WHERE MaHocSinh = '" + dgvAttend.Rows[i].Cells[0].Value + "' " +
                                 "and MaBuoiHoc = '" + lblLessonID.Text + "' ";
                SqlCommand cmd = new SqlCommand(sqlCode, con);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Điểm danh thành công\n" + "Sĩ số: " + countAttend(lblLessonID.Text) + "/" + (row - 1).ToString());
            btnAttend_cancel.Text = "THOÁT";
        }

        public string countAttend(string id)
        {
            string result = "";

            string sqlCode = "select count(MaHocSinh) from DIEMDANH where MaBuoiHoc='" + id + "' and TichVang='0'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            result = dr.GetValue(0).ToString();
            dr.Close();

            return result;
        }

        private void fAttend_Load(object sender, EventArgs e)
        {
            //lblSum.Text = sum.ToString();

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            loadClassName();
            Displayattend();
        }

        public virtual void Displayattend()
        {
            string sqlCode = "select * from FUNC_LIST_TO_ATTEND('" + lblLessonID.Text + "')";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dgvAttend.DataSource = dataTable;
        }

        public void loadClassName()
        {
            string sqlCode = "SELECT TenLopHoc FROM LOPHOC WHERE MaLopHoc = '" + lblClassID.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lblClassName.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }

        private void dgvAttend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
