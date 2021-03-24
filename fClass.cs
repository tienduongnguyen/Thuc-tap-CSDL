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


        private void fClass_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Display();
        }

        private void fClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void Display()
        {
            string class_sqlCode = "SELECT * FROM LOPHOC";
            SqlCommand class_cmd = new SqlCommand(class_sqlCode, con);
            SqlDataReader class_dataReader = class_cmd.ExecuteReader();
            DataTable class_dataTable = new DataTable();
            class_dataTable.Load(class_dataReader);
            dgvClass.DataSource = class_dataTable;

            string lesson_sqlCode = "SELECT * FROM BUOIHOC";
            SqlCommand lesson_cmd = new SqlCommand(lesson_sqlCode, con);
            SqlDataReader lesson_dataReader = lesson_cmd.ExecuteReader();
            DataTable lesson_dataTable = new DataTable();
            lesson_dataTable.Load(lesson_dataReader);
            dgvLesson.DataSource = lesson_dataTable;
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

        private void btnLesson_add_Click(object sender, EventArgs e)
        {
            openChildForm(new fAttend(), sender);
        }        
    }
}
