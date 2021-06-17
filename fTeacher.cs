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
    public partial class fTeacher : Form
    {
        public fTeacher()
        {
            InitializeComponent();
        }


        SqlConnection con;


        private void fTeacher_Load(object sender, EventArgs e)
        {
            txtTeacherID.Focus();

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Display();
            loadDataCombobox1();
            loadDataCombobox2();
            autoLoadTeacherID();
        }

        private void fTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void Display()
        {
            string sqlCode = "select top(20) * FROM GIAOVIEN";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvTeacher.DataSource = dataTable;
        }

        public void autoLoadTeacherID()
        {
            string sqlCode = "SELECT TOP(1) MaGiaoVien FROM GIAOVIEN ORDER BY MaGiaoVien DESC";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr.GetValue(0).ToString().Substring(2)) + 1;
                txtTeacherID.Text = "GV" + id.ToString();
            }
            dr.Close();
        }

        private void txtTeacherBirth_Enter(object sender, EventArgs e)
        {
            if (txtTeacherBirth.Text == "MM/DD/YYYY")
            {
                txtTeacherBirth.Text = "";
                txtTeacherBirth.ForeColor = Color.FromArgb(0, 72, 39);
            }
        }

        private void txtTeacherBirth_Leave(object sender, EventArgs e)
        {
            if (txtTeacherBirth.Text == "")
            {
                txtTeacherBirth.Text = "MM/DD/YYYY";
                txtTeacherBirth.ForeColor = Color.Silver;
            }
        }

        private void btnTeacher_add_Click(object sender, EventArgs e)
        {
            string gender;
            if (radGender_female.Checked)
            {
                gender = radGender_female.Text;
            }
            else
            {
                gender = radGender_male.Text;
            }

            string readerCode = "select * from GIAOVIEN where MaGiaoVien = '" + txtTeacherID.Text + "' ";
            SqlCommand cmd = new SqlCommand(readerCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                dr.Close();
                MessageBox.Show("Giáo viên đã có sẵn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dr.Close();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string sqlInsert = "exec PROC_INSERT_GIAOVIEN '" + txtTeacherID.Text + "','" + txtTeacherName.Text + "','" + txtTeacherBirth.Text + "','" + gender + "','" + txtTeacherAddress.Text + "','" + txtTeacherPhone.Text + "', '" + txtSubjectID.Text + "', '" + txtSalaryID.Text + "' ";
                SqlCommand cmd1 = new SqlCommand(sqlInsert, con);
                cmd1.ExecuteNonQuery();
                Display();
            }


        }

        private void btnTeacher_edit_Click(object sender, EventArgs e)
        {
            string gender;
            if (radGender_female.Checked)
            {
                gender = radGender_female.Text;
            }
            else
            {
                gender = radGender_male.Text;
            }


            string sqlEdit = "exec PROC_UPDATE_GIAOVIEN '" + txtTeacherID.Text + "','" + txtTeacherName.Text + "','" + txtTeacherBirth.Text + "','" + gender + "','" + txtTeacherAddress.Text + "','" + txtTeacherPhone.Text + "', '" + txtSubjectID.Text + "', '" + txtSalaryID.Text + "' ";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnTeacher_delete_Click(object sender, EventArgs e)
        {
            string sqlupdateDelete1 = "update LOPHOC set MaGiaoVien = null where MaGiaoVien = '" + txtTeacherID.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(sqlupdateDelete1, con);
            cmd1.ExecuteNonQuery();


            string sqlupdateDelete2 = "update BLTRALUONG set MaGiaoVien = null where MaGiaoVien = '" + txtTeacherID.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(sqlupdateDelete2, con);
            cmd2.ExecuteNonQuery();


            string sqlDelete = "exec PROC_DELETE_GIAOVIEN '" + txtTeacherID.Text + "'";

            SqlCommand cmd = new SqlCommand(sqlDelete, con);

            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnTeacher_clear_Click(object sender, EventArgs e)
        {
            txtTeacherID.Text = "";
            txtTeacherName.Text = "";
            txtTeacherBirth.Text = "MM/DD/YYYY";
            txtTeacherBirth.ForeColor = Color.Silver;
            radGender_male.Checked = true;
            txtTeacherAddress.Text = "";
            txtTeacherPhone.Text = "";
            //txtSubjectID.Text = "";
            txtSalaryID.Text = "";
            txtTeacherSearch.Text = "";

            autoLoadTeacherID();
        }

        private void btnTeacher_search_Click(object sender, EventArgs e)
        {
            if (cmbTeacher.SelectedItem == "Mã giáo viên")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_MAGV('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Tên giáo viên")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_TENGV('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Ngày sinh")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_NGAYSINH('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Giới tính")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_GIOITINH('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Địa chỉ")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_DIACHI('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Số điện thoại")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_SDT('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Mã môn học")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_MAMH('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Mã mức TT")
            {
                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_GV_MAMTT('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }
        }


        private void btnTeacher_all_Click(object sender, EventArgs e)
        {
            Display();
        }

        public string convertDate(string date)
        {
            string[] info = date.Split('/');

            return info[1] + "/" + info[0] + "/" + info[2];
        }


        public string getMH(string MaMH)
        {
            string result = "";

            string sqlCode = "select TenMonHoc from MONHOC where MaMonHoc='" + MaMH + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetValue(0).ToString();
            }
            dr.Close();

            return result;
        }

        public string getMMTT(string MaMMTT)
        {
            string result = "";

            string sqlCode = "select TyLePhanTram from MUCTHANHTOAN where MaMTT='" + MaMMTT + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetValue(0).ToString();
            }
            dr.Close();

            return result;
        }


        private void dgvTeacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvTeacher.CurrentRow.Index;
            txtTeacherID.Text = dgvTeacher.Rows[i].Cells[0].Value.ToString();
            txtTeacherName.Text = dgvTeacher.Rows[i].Cells[1].Value.ToString();
            //txtTeacherBirth.Text = convertDate(dgvTeacher.Rows[i].Cells[2].Value.ToString());
            txtTeacherBirth.Text = dgvTeacher.Rows[i].Cells[2].Value.ToString();
            //radGender_male.Checked = dgvStudent.Rows[i].Cells[3].Value.ToString();
            txtTeacherAddress.Text = dgvTeacher.Rows[i].Cells[4].Value.ToString();
            txtTeacherPhone.Text = dgvTeacher.Rows[i].Cells[5].Value.ToString();
            txtSubjectID.Text = dgvTeacher.Rows[i].Cells[6].Value.ToString();
            txtSalaryID.Text = dgvTeacher.Rows[i].Cells[7].Value.ToString();

            cbbSubID.Text = getMH(txtSubjectID.Text);
            cbbMMTT.Text = getMMTT(txtSalaryID.Text);
        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
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
            cbbSubID.ValueMember = "TenMonHoc";
            cbbSubID.DataSource = dt;
        }



        private void cbbSubID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaMonHoc FROM MONHOC WHERE TenMonHoc = '" + cbbSubID.SelectedValue.ToString() + "'";

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
            var sqlCode2 = "Select TyLePhanTram from MUCTHANHTOAN";
            SqlCommand cmd2 = new SqlCommand(sqlCode2, con);
            ///cmd.ExecuteNonQuery();
            var dr2 = cmd2.ExecuteReader();
            var dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Dispose();
            cbbMMTT.ValueMember = "TyLePhanTram";
            cbbMMTT.DataSource = dt2;
        }

        private void cbbMMTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaMTT FROM MUCTHANHTOAN WHERE TyLePhanTram = '" + cbbMMTT.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtSalaryID.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }
    }
}
