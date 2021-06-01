﻿using System;
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


        private void fClass_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Display();
            Display1();
            autoLoadClassID();
            autoLoadLessonID();
            loadDataCombobox1();
            loadDataCombobox2();
            loadDataCombobox3();
            loadDataCombobox4();
        }

        private void fClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void Display()
        {
            string class_sqlCode = "select top(20) * FROM LOPHOC";
            SqlCommand class_cmd = new SqlCommand(class_sqlCode, con);
            SqlDataReader class_dataReader = class_cmd.ExecuteReader();
            DataTable class_dataTable = new DataTable();
            class_dataTable.Load(class_dataReader);
            dgvClass.DataSource = class_dataTable;
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


        public void Display1()
        { 
            string lesson_sqlCode = "select top(20) * FROM BUOIHOC";
            SqlCommand lesson_cmd = new SqlCommand(lesson_sqlCode, con);
            SqlDataReader lesson_dataReader = lesson_cmd.ExecuteReader();
            DataTable lesson_dataTable = new DataTable();
            lesson_dataTable.Load(lesson_dataReader);
            dgvLesson.DataSource = lesson_dataTable;
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

       

        private void btnClass_add_Click(object sender, EventArgs e)
        {
         

            string sqlInsert = "exec PROC_INSERT_LOPHOC '" + txtClassID.Text + "','" + txtClassName.Text + "','" + txtSumStudent.Text + "','" + txtCourse.Text + "','" + txtFeeLevel.Text + "', '" + txtTeacherID.Text + "','" + txtSubjectID.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlInsert, con);

            cmd.ExecuteNonQuery();
            Display();
           
        }

        private void btnClass_edit_Click(object sender, EventArgs e)
        {
            string sqlEdit = "exec PROC_UPDATE_LOPHOC '" + txtClassID.Text + "','" + txtClassName.Text + "','" + txtSumStudent.Text + "','" + txtCourse.Text + "','" + txtFeeLevel.Text + "', '" + txtTeacherID.Text + "','" + txtSubjectID.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnClass_delete_Click(object sender, EventArgs e)
        {
            string sqlupdateDelete1 = "update BUOIHOC set MaLopHoc = null where MaLopHoc = '" + txtClassID.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(sqlupdateDelete1, con);
            cmd1.ExecuteNonQuery();


            string sqlupdateDelete2 = "update BLTRALUONG set MaLopHoc = null where MaLopHoc = '" + txtClassID.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(sqlupdateDelete2, con);
            cmd2.ExecuteNonQuery();


            string sqlDelete3 = "update BLTHUHP set MaLopHoc = null where MaLopHoc = '" + txtClassID.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sqlDelete3, con);
            cmd3.ExecuteNonQuery();


            string sqlDelete = "exec PROC_DELETE_LOPHOC '" + txtClassID.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            Display();
        }

        private void btnClass_clear_Click(object sender, EventArgs e)
        {
            txtClassID.Text = "";
            txtClassName.Text = "";
            txtSumStudent.Text = "";
            txtCourse.Text = "";
            txtFeeLevel.Text = "";
            txtTeacherID.Text = "";
            txtSubjectID.Text = "";
       
        }

        private void btnClass_search_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedItem == "Mã lớp học")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_LH_MALH('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvClass.DataSource = dataTable;
            }

            if (cmbClass.SelectedItem == "Mã lớp học")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_BH_MALH('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvLesson.DataSource = dataTable;
            }

            if (cmbClass.SelectedItem == "Tên lớp học")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_LH_TENLH('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvClass.DataSource = dataTable;
            }

            if (cmbClass.SelectedItem == "Số lượng học sinh")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_LH_SLHS('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvClass.DataSource = dataTable;
            }

            if (cmbClass.SelectedItem == "Mã khóa học")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_LH_MAKH('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvClass.DataSource = dataTable;
            }

            if (cmbClass.SelectedItem == "Mã mức HP")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_LH_MAMHP('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvClass.DataSource = dataTable;
            }

            if (cmbClass.SelectedItem == "Mã giáo viên")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_LH_MAGV('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvClass.DataSource = dataTable;
            }

            if (cmbClass.SelectedItem == "Mã môn học")
            {

                string sqlCode2 = "select top(20) * from DBO.FUNC_SEARCH_LH_MAMH('" + txtClassSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvClass.DataSource = dataTable;
            }

        }

        private void btnClass_all_Click(object sender, EventArgs e)
        {
            Display();

        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvClass.CurrentRow.Index;
            txtClassID.Text = txtLessonClassID.Text  = dgvClass.Rows[i].Cells[0].Value.ToString();
            txtClassName.Text = dgvClass.Rows[i].Cells[1].Value.ToString();
            txtSumStudent.Text = dgvClass.Rows[i].Cells[2].Value.ToString();
            txtCourse.Text = dgvClass.Rows[i].Cells[3].Value.ToString();
            txtFeeLevel.Text = dgvClass.Rows[i].Cells[4].Value.ToString();
            txtTeacherID.Text = dgvClass.Rows[i].Cells[5].Value.ToString();
            txtSubjectID.Text = dgvClass.Rows[i].Cells[6].Value.ToString();

            

            //print buoi hoc cua lop duoc chon sang dgvLesson
            string lesson_sqlCode = "select top(20) * FROM BUOIHOC where MaLopHoc = '" + txtClassID.Text +"'";
            SqlCommand lesson_cmd = new SqlCommand(lesson_sqlCode, con);
            SqlDataReader lesson_dataReader = lesson_cmd.ExecuteReader();
            DataTable lesson_dataTable = new DataTable();
            lesson_dataTable.Load(lesson_dataReader);
            dgvLesson.DataSource = lesson_dataTable;

        }

        private void dgvLesson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvLesson.CurrentRow.Index;
            txtLessonID.Text = dgvLesson.Rows[i].Cells[0].Value.ToString();
            txtLessonDate.Text = dgvLesson.Rows[i].Cells[1].Value.ToString();
            txtLessonTime.Text = dgvLesson.Rows[i].Cells[2].Value.ToString();
            txtLessonClassID.Text = dgvLesson.Rows[i].Cells[3].Value.ToString();
        }

        private void btnLesson_add_Click(object sender, EventArgs e)
        {
            string sqlInsert = "exec PROC_INSERT_BUOIHOC '" + txtLessonID.Text + "','" + txtLessonDate.Text + "','" + txtLessonTime.Text + "','" + txtLessonClassID.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnLesson_edit_Click(object sender, EventArgs e)
        {
            string sqlInsert = "exec PROC_UPDATE_BUOIHOC '" + txtLessonID.Text + "','" + txtLessonDate.Text + "','" + txtLessonTime.Text + "','" + txtLessonClassID.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnLesson_delete_Click(object sender, EventArgs e)
        {
            string sqlupdateDelete1 = "update DIEMDANH set MaBuoiHoc = null where MaBuoiHoc = '" + txtLessonID.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(sqlupdateDelete1, con);
            cmd1.ExecuteNonQuery();


            string sqlDelete = "exec PROC_DELETE_BUOIHOC '" + txtLessonID.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            Display1();

        }

        private void btnLesson_clear_Click(object sender, EventArgs e)
        {
            txtLessonID.Text = "";
            txtLessonDate.Text = "";
            txtLessonTime.Text = "";
            txtLessonClassID.Text = "";
            
        }

        private void btnLesson_search_Click(object sender, EventArgs e)
        {
            if (cmbLesson.SelectedItem == "Mã buổi học")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_BH_MABH('" + txtLessonSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvLesson.DataSource = dataTable;
            }

            if (cmbLesson.SelectedItem == "Ngày học")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_BH_NGAYHOC('" + txtLessonSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvLesson.DataSource = dataTable;
            }

            if (cmbLesson.SelectedItem == "Thời gian")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_BH_THOIGIAN('" + txtLessonSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvLesson.DataSource = dataTable;
            }

            if (cmbLesson.SelectedItem == "Mã lớp học")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_BH_MALH('" + txtLessonSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvLesson.DataSource = dataTable;
            }

        }

        private void btnLesson_all_Click(object sender, EventArgs e)
        {
            Display1();
           
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (txtLessonID.Text != "")
                openChildForm(new fAttend(txtLessonClassID.Text,txtLessonID.Text), sender);      
        }

        private void btnDSL_Click(object sender, EventArgs e)
        {
            string class_sqlCode = "SELECT MaLopHoc,dsl.MaHocSinh,TenHocSinh FROM DANHSACHLOP dsl, HOCSINH hs WHERE dsl.MaHocSinh = hs.MaHocSinh and MaLopHoc = '" + txtClassID.Text + "'";
            SqlCommand class_cmd = new SqlCommand(class_sqlCode, con);
            SqlDataReader class_dataReader = class_cmd.ExecuteReader();
            DataTable class_dataTable = new DataTable();
            class_dataTable.Load(class_dataReader);
            dgvClass.DataSource = class_dataTable;
        }

        private void txtLessonID_TextChanged(object sender, EventArgs e)
        {

        }
        public void loadDataCombobox1()
        {
            var sqlCode1 = "Select TenMonHoc from MONHOC";
            SqlCommand cmd = new SqlCommand(sqlCode1, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMMH.ValueMember = "TenMonHoc";
            cbbMMH.DataSource = dt;
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

        public void loadDataCombobox2()
        {
            var sqlCode2 = "Select TenGiaoVien from GIAOVIEN";
            SqlCommand cmd2 = new SqlCommand(sqlCode2, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd2.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMGV.ValueMember = "TenGiaoVien";
            cbbMGV.DataSource = dt;
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

        public void loadDataCombobox4()
        {
            var sqlCode2 = "Select TenKhoaHoc from KHOAHOC";
            SqlCommand cmd2 = new SqlCommand(sqlCode2, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd2.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMKH.ValueMember = "TenKhoaHoc";
            cbbMKH.DataSource = dt;
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

        public void loadDataCombobox3()
        {
            var sqlCode3 = "Select MaMHP from MUCHOCPHI";
            SqlCommand cmd3 = new SqlCommand(sqlCode3, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd3.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMMHP.ValueMember = "MaMHP";
            cbbMMHP.DataSource = dt;
        }

        private void cbbMMHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaMHP FROM MUCHOCPHI WHERE MaMHP = '" + cbbMMHP.SelectedValue.ToString() + "'";

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