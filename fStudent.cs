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
            txtStudentID.Focus();


            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Display();
        }

        private void fStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void Display()
        {
            string sqlCode = "SELECT * FROM HOCSINH";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvStudent.DataSource = dataTable;
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


            string sqlInsert = "exec PROC_INSERT_HOCSINH '" + txtStudentID.Text + "','" + txtStudentName.Text + "','" + txtStudentBirth.Text + "','" + gender + "','" + txtStudentAddress.Text + "','" + txtStudentPhone.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlInsert, con);

            cmd.ExecuteNonQuery();
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
        }

        private void btnStudent_all_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnStudent_search_Click(object sender, EventArgs e)
        {
            string sqlCode1 = "Select * from DBO.FUNC_SEARCH_HS_MAHS('" + txtStudentSearch.Text + "')";

            SqlCommand cmd = new SqlCommand(sqlCode1, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dgvStudent.DataSource = dataTable;
        }
    }
}
