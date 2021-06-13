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
    public partial class fFee : Form
    {
        public fFee()
        {
            InitializeComponent();
        }


        SqlConnection con;


        private void fFee_Load(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            loadCombobox();

        }

        public void Display(string code)
        {

            SqlCommand cmd = new SqlCommand(code, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvFee.DataSource = dataTable;

        }

        public void autoLoadBillID()
        {

            string sqlCode = "SELECT TOP(1) MaBLThuHP FROM BLTHUHP ORDER BY MaBLThuHP DESC";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr.GetValue(0).ToString().Substring(7)) + 1;
                string ID = "";
                if (id < 100) ID = "0" + id.ToString();
                else ID = id.ToString();
                txtFeeBill_id.Text = "BLTHUHP" + ID;
            }
            dr.Close();

        }

        public void Display1(string code)
        {

            SqlCommand cmd = new SqlCommand(code, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(dataReader);
            dgvFee_bill.DataSource = dataTable;

        }

        private void dgvFee_bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dgvFee_bill.CurrentRow.Index;

            txtFeeBill_id.Text = dgvFee_bill.Rows[i].Cells[0].Value.ToString();
            txtFeeBill_studentID.Text = dgvFee_bill.Rows[i].Cells[1].Value.ToString();
            txtFeeBill_classID.Text = dgvFee_bill.Rows[i].Cells[2].Value.ToString();
            txtFeeBill_sumDay.Text = dgvFee_bill.Rows[i].Cells[3].Value.ToString();
            txtFeeBill_feePerDay.Text = dgvFee_bill.Rows[i].Cells[4].Value.ToString();
            txtFeeBill_sumFee.Text = dgvFee_bill.Rows[i].Cells[5].Value.ToString();
            txtFeeBill_dateTake.Text = convertDate(dgvFee_bill.Rows[i].Cells[6].Value.ToString());
            txtFeeBill_takeForDate.Text = dgvFee_bill.Rows[i].Cells[7].Value.ToString();
            if (dgvFee_bill.Rows[i].Cells[8].Value.ToString() == "1") ckbTaked.Checked = true;
            else ckbTaked.Checked = false;

        }

        private void ckbTaked_CheckedChanged(object sender, EventArgs e)
        {

            if (ckbTaked.Checked)
                ckbTaked.Text = "đã thu";
            else
                ckbTaked.Text = "chưa thu";

        }

        private void btnFeeBill_add_Click(object sender, EventArgs e)
        {

            string isCheck = "";
            if (ckbTaked.Checked) isCheck = "1";
            else isCheck = "0";

            string sqlInsert = "exec PROC_INSERT_BLTHUHP '" + txtFeeBill_id.Text + "','" + txtFeeBill_studentID.Text + "','" + txtFeeBill_classID.Text + "','" + txtFeeBill_sumDay.Text + "','" + txtFeeBill_feePerDay.Text + "', '" + txtFeeBill_sumFee.Text + "','" + txtFeeBill_dateTake.Text + "','" + txtFeeBill_takeForDate.Text + "', '" + isCheck + "'";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();

            string sqlCode = "select top(20) * from BLTHUHP where MaHocSinh = '" + txtFeeBill_studentID.Text + "' order by NgayThu desc";
            Display1(sqlCode);

            btnFeeBill_add.Enabled = false;

        }

        private void btnFeeBill_edit_Click(object sender, EventArgs e)
        {

            string isCheck = "";
            if (ckbTaked.Checked) isCheck = "1";
            else isCheck = "0";

            string sqlEdit = "exec PROC_UPDATE_BLTHUHP '" + txtFeeBill_id.Text + "','" + txtFeeBill_studentID.Text + "','" + txtFeeBill_classID.Text + "','" + txtFeeBill_sumDay.Text + "','" + txtFeeBill_feePerDay.Text + "', '" + txtFeeBill_sumFee.Text + "','" + txtFeeBill_dateTake.Text + "','" + txtFeeBill_takeForDate.Text + "', '" + isCheck + "' ";
            SqlCommand cmd = new SqlCommand(sqlEdit, con);
            cmd.ExecuteNonQuery();

            string sqlCode = "select top(20) * from BLTHUHP where MaHocSinh = '" + txtFeeBill_studentID.Text + "' order by NgayThu desc";
            Display1(sqlCode);

        }

        private void btnFeeBill_delete_Click(object sender, EventArgs e)
        {
            string sqlDelete = "exec PROC_DELETE_BLTHUHP '" + txtFeeBill_id.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            string sqlCode = "select top(20) * from BLTHUHP where MaHocSinh = '" + txtFeeBill_studentID.Text + "' order by NgayThu desc";
            Display1(sqlCode);
        }



        //func sql
        public string getSumDay(string ClassID, string StudentID, string months)
        {
            string result = "";

            string sqlCode = "select * from FUNC_TINH_TONGSOBUOI('" + ClassID + "','" + StudentID + "','" + months + "')";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetValue(0).ToString();
            }
            dr.Close();

            return result;
        }

        //func sql
        public string getFeePerDay(string ClassID)
        {
            string result = "";

            string sqlCode = "SELECT SoHocPhi FROM MUCHOCPHI, LOPHOC WHERE MUCHOCPHI.MaMHP = LOPHOC.MaMHP and MaLopHoc = '" + ClassID + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetValue(0).ToString();
            }
            dr.Close();

            return result;
        }

        //func sql
        public string getSumFee(string feePerDay, string sumDay)
        {
            return (int.Parse(feePerDay) * int.Parse(sumDay)).ToString();
        }

        //func sql
        public string convertDate(string date)
        {
            string[] info = date.Split('/');

            return info[1] + "/" + info[0] + "/" + info[2];
        }

        private void dgvFee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvFee.CurrentRow.Index;

            autoLoadBillID(); //MaBienLai
            txtFeeBill_studentID.Text = dgvFee.Rows[i].Cells[0].Value.ToString(); //MaHocSinh
            txtFeeBill_classID.Text = txtFeeSearch.Text; //MaLopHoc
            txtFeeBill_feePerDay.Text = getFeePerDay(txtFeeBill_classID.Text); //HocPhi/Buoi
            txtFeeBill_dateTake.Text = DateTime.Now.ToString("MM/dd/yyyy"); //NgayThu
            txtFeeBill_takeForDate.Text = (DateTime.Now.Month - 1).ToString(); //ThuChoThangNam
            txtFeeBill_sumDay.Text = getSumDay(txtFeeBill_classID.Text, txtFeeBill_studentID.Text, txtFeeBill_takeForDate.Text); //TongSoBuoi
            txtFeeBill_sumFee.Text = getSumFee(txtFeeBill_feePerDay.Text, txtFeeBill_sumDay.Text); //TongHocPhi

            string sqlCode = "select top(20) * from BLTHUHP where MaHocSinh = '" + txtFeeBill_studentID.Text + "' order by NgayThu desc";
            Display1(sqlCode);

            btnFeeBill_add.Enabled = true;
        }

        public void loadCombobox()
        {
            var sqlCode = "Select TenLopHoc from LOPHOC";
            SqlCommand cmd = new SqlCommand(sqlCode, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMLH.ValueMember = "TenLopHoc";
            cbbMLH.DataSource = dt;
        }

        private void cbbMLH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaLopHoc FROM LOPHOC WHERE TenLopHoc = '" + cbbMLH.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtFeeSearch.Text = dr.GetValue(0).ToString();
            }
            dr.Close();

            string sqlCode2 = "select MaHocSinh, TenHocSinh from FUNC_LIST_STUDENT_CLASS('" + txtFeeSearch.Text + "')";
            Display(sqlCode2);
        }

        private void btnFeeBill_Export_Click(object sender, EventArgs e)
        {
            fBillStudent form = new fBillStudent(txtFeeBill_id.Text,
                                                 txtFeeBill_studentID.Text,
                                                 txtFeeBill_classID.Text,
                                                 txtFeeBill_sumDay.Text,
                                                 txtFeeBill_feePerDay.Text,
                                                 txtFeeBill_sumFee.Text,
                                                 txtFeeBill_dateTake.Text,
                                                 txtFeeBill_takeForDate.Text);
            form.ShowDialog();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtFeeBill_takeForDate.Text == "") txtFeeBill_takeForDate.Text = "0";

            txtFeeBill_sumDay.Text = getSumDay(txtFeeBill_classID.Text, txtFeeBill_studentID.Text, txtFeeBill_takeForDate.Text); //TongSoBuoi
            txtFeeBill_sumFee.Text = getSumFee(txtFeeBill_feePerDay.Text, txtFeeBill_sumDay.Text); //TongHocPhi
        }
    }
}
