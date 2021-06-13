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
    public partial class fStudent : Form
    {
        public fStudent()
        {
            InitializeComponent();
        }


        SqlConnection con;


        private void fStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTrungTamHocThemDataSet1.LOPHOC' table. You can move, or remove it, as needed.
            //this.lOPHOCTableAdapter.Fill(this.qLTrungTamHocThemDataSet1.LOPHOC);
            txtStudentID.Focus();

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Display();
            autoLoadStudentID();
            loadDataCombobox();
        }

        private void fStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void Display()
        {
            string sqlCode = "SELECT TOP(30) * FROM HOCSINH";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvStudent.DataSource = dataTable;
        }

        public void autoLoadStudentID()
        {
            string sqlCode = "SELECT TOP(1) MaHocSinh FROM HOCSINH ORDER BY MaHocSinh DESC";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr.GetValue(0).ToString().Substring(2)) + 1;
                txtStudentID.Text = "HS" + id.ToString();
            }
            dr.Close();
        }

        private void txtStudentBirth_Enter(object sender, EventArgs e)
        {
            if (txtStudentBirth.Text == "MM/DD/YYYY")
            {
                txtStudentBirth.Text = "";
                txtStudentBirth.ForeColor = Color.FromArgb(0, 72, 39);
            }
        }

        private void txtStudentBirth_Leave(object sender, EventArgs e)
        {
            if (txtStudentBirth.Text == "")
            {
                txtStudentBirth.Text = "MM/DD/YYYY";
                txtStudentBirth.ForeColor = Color.Silver;
            }
        }

        private void btnStudent_add_Click(object sender, EventArgs e)
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


            string readerCode = "select * from HOCSINH where MaHocSinh = '" + txtStudentID.Text + "' ";
            SqlCommand cmd = new SqlCommand(readerCode, con);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read() == true)
            {
                dr.Close();

                string readerCode1 = "select * from DANHSACHLOP where MaHocSinh = '" + txtStudentID.Text + "' and MaLopHoc = '" + textmalop.Text + "'";
                SqlCommand cmd1 = new SqlCommand(readerCode1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read() == true)
                {
                    dr1.Close();

                    MessageBox.Show("Học sinh đã có sẵn trong lớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dr1.Close();

                    string sqlCode = "exec PROC_INSERT_DANHSACHLOP '" + textmalop.Text + "','" + txtStudentID.Text + "' ";
                    SqlCommand cmd2 = new SqlCommand(sqlCode, con);
                    cmd2.ExecuteNonQuery();

                    string C_name = comboBox1.Text;
                    string S_name = txtStudentName.Text;
                    string noti = "Thêm thành công\n" + S_name + " vào lớp " + C_name;
                    MessageBox.Show(noti, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            else
            {
                dr.Close();

                string sqlCode = "exec PROC_INSERT_HOCSINH '" + txtStudentID.Text + "','" + txtStudentName.Text + "','" + txtStudentBirth.Text + "','" + gender + "','" + txtStudentAddress.Text + "','" + txtStudentPhone.Text + "'";
                SqlCommand cmd2 = new SqlCommand(sqlCode, con);
                cmd2.ExecuteNonQuery();

                string sqlCode1 = "exec PROC_INSERT_DANHSACHLOP '" + textmalop.Text + "','" + txtStudentID.Text + "' ";
                SqlCommand cmd3 = new SqlCommand(sqlCode1, con);
                cmd3.ExecuteNonQuery();
            }
            Display();
        }

        private void btnStudent_edit_Click(object sender, EventArgs e)
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


            string sqlEdit = "exec PROC_UPDATE_HOCSINH '" + txtStudentID.Text + "','" + txtStudentName.Text + "','" + txtStudentBirth.Text + "','" + gender + "','" + txtStudentAddress.Text + "','" + txtStudentPhone.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnStudent_delete_Click(object sender, EventArgs e)
        {
            string sqlupdateDelete1 = "update DANHSACHLOP set MaHocSinh = null where MaHocSinh = '" + txtStudentID.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(sqlupdateDelete1, con);
            cmd1.ExecuteNonQuery();


            string sqlDelete = "exec PROC_DELETE_HOCSINH '" + txtStudentID.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnStudent_clear_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtStudentBirth.Text = "MM/DD/YYYY";
            txtStudentBirth.ForeColor = Color.Silver;
            radGender_male.Checked = true;
            txtStudentAddress.Text = "";
            txtStudentPhone.Text = "";
            txtStudentSearch.Text = "";
            //textmalop.Text = "";

            autoLoadStudentID();
        }

        private void btnStudent_all_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnStudent_search_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedItem == "Mã học sinh")
            {


                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_HS_MAHS('" + txtStudentSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvStudent.DataSource = dataTable;
            }

            if (cmbStudent.SelectedItem == "Tên học sinh")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_HS_TENHS('" + txtStudentSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvStudent.DataSource = dataTable;
            }

            if (cmbStudent.SelectedItem == "Ngày sinh")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_HS_NGAYSINH('" + txtStudentSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvStudent.DataSource = dataTable;
            }

            if (cmbStudent.SelectedItem == "Giới tính")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_HS_GIOITINH('" + txtStudentSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvStudent.DataSource = dataTable;
            }

            if (cmbStudent.SelectedItem == "Địa chỉ")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_HS_DIACHI('" + txtStudentSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvStudent.DataSource = dataTable;
            }

            if (cmbStudent.SelectedItem == "Số điện thoại")
            {

                string sqlCode1 = "select top(20) * from DBO.FUNC_SEARCH_HS_SDT('" + txtStudentSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvStudent.DataSource = dataTable;
            }

        }

        public string convertDate(string date)
        {
            string[] info = date.Split('/');

            return info[1] + "/" + info[0] + "/" + info[2];
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvStudent.CurrentRow.Index;
            txtStudentID.Text = dgvStudent.Rows[i].Cells[0].Value.ToString();
            txtStudentName.Text = dgvStudent.Rows[i].Cells[1].Value.ToString();
            txtStudentBirth.Text = convertDate(dgvStudent.Rows[i].Cells[2].Value.ToString());
            //radGender_male.Checked = dgvStudent.Rows[i].Cells[3].Value.ToString();
            txtStudentAddress.Text = dgvStudent.Rows[i].Cells[4].Value.ToString();
            txtStudentPhone.Text = dgvStudent.Rows[i].Cells[5].Value.ToString();
        }


        public void loadDataCombobox()
        {
            var sqlCode1 = "Select TenLopHoc from LOPHOC";

            SqlCommand cmd = new SqlCommand(sqlCode1, con);
            ///cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            comboBox1.ValueMember = "TenLopHoc";
            comboBox1.DataSource = dt;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaLopHoc FROM LOPHOC WHERE TenLopHoc = '" + comboBox1.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textmalop.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }
    }
}
