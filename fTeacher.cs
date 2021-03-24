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
        }

        private void fTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void Display()
        {
            string sqlCode = "SELECT * FROM GIAOVIEN";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvTeacher.DataSource = dataTable;
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

        }

        private void btnTeacher_edit_Click(object sender, EventArgs e)
        {

        }

        private void btnTeacher_delete_Click(object sender, EventArgs e)
        {

        }

        private void btnTeacher_clear_Click(object sender, EventArgs e)
        {

        }

        private void btnTeacher_search_Click(object sender, EventArgs e)
        {

        }

        private void btnTeacher_all_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
