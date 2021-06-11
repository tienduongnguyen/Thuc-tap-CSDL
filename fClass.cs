using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Thuc_Tap_CSDL
{

    public partial class fClass : Form
    {
        public fClass()
        {
            InitializeComponent();
        }


        SqlConnection con;
        bool list_class = false;


        public void DisplayL(string code)
        {
            SqlCommand class_cmd = new SqlCommand(code, con);
            SqlDataReader class_dataReader = class_cmd.ExecuteReader();
            DataTable class_dataTable = new DataTable();

            class_dataTable.Load(class_dataReader);
            dgvClass.DataSource = class_dataTable;
        }

        public void DisplayR(string code)
        {
            SqlCommand lesson_cmd = new SqlCommand(code, con);
            SqlDataReader lesson_dataReader = lesson_cmd.ExecuteReader();
            DataTable lesson_dataTable = new DataTable();

            lesson_dataTable.Load(lesson_dataReader);
            dgvLesson.DataSource = lesson_dataTable;
        }

        public void autoLoadClassID()
        {
            string sqlCode = "SELECT TOP(1) MaLopHoc FROM LOPHOC ORDER BY MaLopHoc DESC";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr.GetValue(0).ToString().Substring(2)) + 1;
                txtClassID.Text = "LH" + id.ToString();
            }
            dr.Close();
        }

        public void autoLoadLessonID()
        {
            string sqlCode = "SELECT TOP(1) MaBuoiHoc FROM BUOIHOC ORDER BY MaBuoiHoc DESC";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr.GetValue(0).ToString().Substring(2)) + 1;
                txtLessonID.Text = "BH" + id.ToString();
            }
            dr.Close();
        }

        public void loadDataCombobox1()
        {
            var sqlCode = "Select TenMonHoc from MONHOC";
            SqlCommand cmd = new SqlCommand(sqlCode, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMMH.ValueMember = "TenMonHoc";
            cbbMMH.DataSource = dt;
        }

        public void loadDataCombobox2()
        {
            var sqlCode = "Select TenGiaoVien from GIAOVIEN";
            SqlCommand cmd = new SqlCommand(sqlCode, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMGV.ValueMember = "TenGiaoVien";
            cbbMGV.DataSource = dt;
        }

        public void loadDataCombobox3()
        {
            var sqlCode = "Select SoHocPhi from MUCHOCPHI";
            SqlCommand cmd = new SqlCommand(sqlCode, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMMHP.ValueMember = "SoHocPhi";
            cbbMMHP.DataSource = dt;
        }

        public void loadDataCombobox4()
        {
            var sqlCode = "Select TenKhoaHoc from KHOAHOC";
            SqlCommand cmd = new SqlCommand(sqlCode, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMKH.ValueMember = "TenKhoaHoc";
            cbbMKH.DataSource = dt;
        }

        public void Execute(string code)
        {
            SqlCommand cmd = new SqlCommand(code, con);
            cmd.ExecuteNonQuery();
        }

        //func sql
        public string convertDate(string date)
        {
            string[] info = date.Split('/');

            return info[1] + "/" + info[0] + "/" + info[2];
        }

        private Form activeForm;

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
            this.pnlClass.Controls.Add(childForm);
            this.pnlClass.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void fClass_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            string sqlCode1 = "select top(20) * FROM LOPHOC";
            string sqlCode2 = "select top(20) * FROM BUOIHOC";

            DisplayL(sqlCode1);
            DisplayR(sqlCode2);

            autoLoadClassID();
            autoLoadLessonID();

            loadDataCombobox1();
            loadDataCombobox2();
            loadDataCombobox3();
            loadDataCombobox4();

            list_class = false;
        }

        private void fClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btnClass_add_Click(object sender, EventArgs e)
        {

            string sqlInsert = "exec PROC_INSERT_LOPHOC '" + txtClassID.Text + "','" + txtClassName.Text + "','" + txtSumStudent.Text + "','" + txtCourse.Text + "','" + txtFeeLevel.Text + "', '" + txtTeacherID.Text + "','" + txtSubjectID.Text + "'";
            Execute(sqlInsert);

            string sqlCode = "select top(20) * FROM LOPHOC order by MaLopHoc desc";
            DisplayL(sqlCode);

        }

        private void btnClass_edit_Click(object sender, EventArgs e)
        {
            string sqlEdit = "exec PROC_UPDATE_LOPHOC '" + txtClassID.Text + "','" + txtClassName.Text + "','" + txtSumStudent.Text + "','" + txtCourse.Text + "','" + txtFeeLevel.Text + "', '" + txtTeacherID.Text + "','" + txtSubjectID.Text + "'";
            Execute(sqlEdit);

            string sqlCode = "select top(20) * FROM LOPHOC";
            DisplayL(sqlCode);
        }

        private void btnClass_delete_Click(object sender, EventArgs e)
        {
            if (!list_class)
            {
                string sqlupdateDelete1 = "update BUOIHOC set MaLopHoc = null where MaLopHoc = '" + txtClassID.Text + "' ";
                Execute(sqlupdateDelete1);


                string sqlupdateDelete2 = "update BLTRALUONG set MaLopHoc = null where MaLopHoc = '" + txtClassID.Text + "' ";
                Execute(sqlupdateDelete2);


                string sqlDelete3 = "update BLTHUHP set MaLopHoc = null where MaLopHoc = '" + txtClassID.Text + "'";
                Execute(sqlDelete3);


                string sqlDelete = "exec PROC_DELETE_LOPHOC '" + txtClassID.Text + "'";
                Execute(sqlDelete);

                string sqlCode = "select top(20) * FROM LOPHOC";
                DisplayL(sqlCode);
            }
            else
            {
                string sqlDelete4 = "exec PROC_DELETE_DANHSACHLOP '" + txtClassID.Text + "','"+ txtStudentID.Text +"'";
                Execute(sqlDelete4);

                string sqlCode = "SELECT MaLopHoc,dsl.MaHocSinh,TenHocSinh FROM DANHSACHLOP dsl, HOCSINH hs WHERE dsl.MaHocSinh = hs.MaHocSinh and MaLopHoc = '" + txtClassID.Text + "'";
                DisplayL(sqlCode);
            }
        }

        private void btnClass_clear_Click(object sender, EventArgs e)
        {
            txtClassName.Text = "";
            autoLoadClassID();
        }

        private void btnClass_search_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedItem == "Mã lớp học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_LH_MALH('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

            if (cmbClass.SelectedItem == "Mã lớp học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_BH_MALH('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

            if (cmbClass.SelectedItem == "Tên lớp học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_LH_TENLH('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

            if (cmbClass.SelectedItem == "Số lượng học sinh")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_LH_SLHS('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

            if (cmbClass.SelectedItem == "Mã khóa học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_LH_MAKH('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

            if (cmbClass.SelectedItem == "Mã mức HP")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_LH_MAMHP('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

            if (cmbClass.SelectedItem == "Mã giáo viên")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_LH_MAGV('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

            if (cmbClass.SelectedItem == "Mã môn học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_LH_MAMH('" + txtClassSearch.Text + "')";
                DisplayL(sqlCode);

            }

        }

        private void btnClass_all_Click(object sender, EventArgs e)
        {
            string sqlCode = "select top(20) * FROM LOPHOC";
            DisplayL(sqlCode);

            list_class = false;
        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!list_class)
            {
                int i;
                i = dgvClass.CurrentRow.Index;

                txtClassID.Text = txtLessonClassID.Text = dgvClass.Rows[i].Cells[0].Value.ToString();
                txtClassName.Text = dgvClass.Rows[i].Cells[1].Value.ToString();
                txtSumStudent.Text = dgvClass.Rows[i].Cells[2].Value.ToString();
                txtCourse.Text = dgvClass.Rows[i].Cells[3].Value.ToString();
                txtFeeLevel.Text = dgvClass.Rows[i].Cells[4].Value.ToString();
                txtTeacherID.Text = dgvClass.Rows[i].Cells[5].Value.ToString();
                txtSubjectID.Text = dgvClass.Rows[i].Cells[6].Value.ToString();

                //print buoi hoc cua lop duoc chon sang dgvLesson
                string sqlCode = "select top(20) * FROM BUOIHOC where MaLopHoc = '" + txtClassID.Text + "' order by MaLopHoc desc";
                DisplayR(sqlCode);

                autoLoadLessonID();
            }
            else
            {
                int i;
                i = dgvClass.CurrentRow.Index;

                txtClassID.Text = dgvClass.Rows[i].Cells[0].Value.ToString();
                txtStudentID.Text = dgvClass.Rows[i].Cells[1].Value.ToString();
            }
        }

        private void dgvLesson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvLesson.CurrentRow.Index;
            txtLessonID.Text = dgvLesson.Rows[i].Cells[0].Value.ToString();
            txtLessonDate.Text = convertDate(dgvLesson.Rows[i].Cells[1].Value.ToString());
            txtLessonTime.Text = dgvLesson.Rows[i].Cells[2].Value.ToString();
            txtLessonClassID.Text = dgvLesson.Rows[i].Cells[3].Value.ToString();
        }

        private void btnLesson_add_Click(object sender, EventArgs e)
        {
            string sqlInsert = "exec PROC_INSERT_BUOIHOC '" + txtLessonID.Text + "','" + txtLessonDate.Text + "','" + txtLessonTime.Text + "','" + txtLessonClassID.Text + "' ";
            Execute(sqlInsert);

            string sqlCode = "select top(20) * FROM BUOIHOC where MaLopHoc = '" + txtLessonClassID.Text + "' order by MaBuoiHoc desc";
            DisplayR(sqlCode);
        }

        private void btnLesson_edit_Click(object sender, EventArgs e)
        {
            string sqlInsert = "exec PROC_UPDATE_BUOIHOC '" + txtLessonID.Text + "','" + txtLessonDate.Text + "','" + txtLessonTime.Text + "','" + txtLessonClassID.Text + "' ";
            Execute(sqlInsert);

            string sqlCode = "select top(20) * FROM BUOIHOC order by MaBuoiHoc desc";
            DisplayR(sqlCode);
        }

        private void btnLesson_delete_Click(object sender, EventArgs e)
        {
            string sqlupdateDelete1 = "update DIEMDANH set MaBuoiHoc = null where MaBuoiHoc = '" + txtLessonID.Text + "' ";
            Execute(sqlupdateDelete1);

            string sqlDelete = "exec PROC_DELETE_BUOIHOC '" + txtLessonID.Text + "'";
            Execute(sqlDelete);

            string sqlCode = "select top(20) * FROM BUOIHOC where MaLopHoc = '" + txtLessonClassID.Text + "'";
            DisplayR(sqlCode);
        }

        private void btnLesson_clear_Click(object sender, EventArgs e)
        {
            autoLoadLessonID();
            txtLessonDate.Text = "";
            txtLessonTime.Text = "";
            txtLessonClassID.Text = "";
        }

        private void btnLesson_search_Click(object sender, EventArgs e)
        {
            if (cmbLesson.SelectedItem == "Mã buổi học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_BH_MABH('" + txtLessonSearch.Text + "')";
                DisplayR(sqlCode);

            }

            if (cmbLesson.SelectedItem == "Ngày học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_BH_NGAYHOC('" + txtLessonSearch.Text + "')";
                DisplayR(sqlCode);

            }

            if (cmbLesson.SelectedItem == "Thời gian")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_BH_THOIGIAN('" + txtLessonSearch.Text + "')";
                DisplayR(sqlCode);

            }

            if (cmbLesson.SelectedItem == "Mã lớp học")
            {

                string sqlCode = "select top(20) * from DBO.FUNC_SEARCH_BH_MALH('" + txtLessonSearch.Text + "')";
                DisplayR(sqlCode);

            }

        }

        private void btnLesson_all_Click(object sender, EventArgs e)
        {
            string sqlCode = "select top(20) * FROM BUOIHOC";
            DisplayR(sqlCode);
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (txtLessonID.Text != "")
                openChildForm(new fAttend(txtLessonClassID.Text, txtLessonID.Text), sender);
        }

        private void btnDSL_Click(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaLopHoc,dsl.MaHocSinh,TenHocSinh FROM DANHSACHLOP dsl, HOCSINH hs WHERE dsl.MaHocSinh = hs.MaHocSinh and MaLopHoc = '" + txtClassID.Text + "'";
            DisplayL(sqlCode);

            list_class = true;
        }

        private void txtLessonID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbMMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaMonHoc FROM MONHOC WHERE TenMonHoc = '" + cbbMMH.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtSubjectID.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }

        private void cbbMGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaGiaoVien FROM GIAOVIEN WHERE TenGiaoVien = '" + cbbMGV.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtTeacherID.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }

        private void cbbMKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaKhoaHoc FROM KHOAHOC WHERE TenKhoaHoc = '" + cbbMKH.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtCourse.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }

        private void cbbMMHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaMHP FROM MUCHOCPHI WHERE SoHocPhi = '" + cbbMMHP.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtFeeLevel.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }
    }
}
