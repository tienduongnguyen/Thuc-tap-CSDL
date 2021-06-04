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
    public partial class fSalary : Form
    {
        public fSalary()
        {
            InitializeComponent();
        }

        private void btnSalary_bill_Click(object sender, EventArgs e)
        {
            txtSalaryBill_id.Enabled = true;
            txtSalaryBill_sumDay.Enabled = true;
            txtSalaryBill_sumMoney.Enabled = true;
            txtSalaryBill_teacherID.Enabled = true;
            txtSalaryBill_classID.Enabled = true;
            txtSalaryBill_datePay.Enabled = true;
            txtSalaryBill_datePayFor.Enabled = true;
            ckbPayed.Enabled = true;
            btnSalaryBill_add.Enabled = true;
            btnSalaryBill_edit.Enabled = true;
            btnSalaryBill_delete.Enabled = true;
            btnSalaryBill_clear.Enabled = true;
        }


        SqlConnection con;


        public void Display(string code)
        {



            SqlCommand cmd = new SqlCommand(code, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvSalary.DataSource = dataTable;
        }


        public void Display1()
        {
            string sqlCode = "select top(20) * FROM BLTRALUONG ";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvSalary_bill.DataSource = dataTable;
        }

        private void fSalary_Load(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
            string sqlCode = "select top(20) * FROM GIAOVIEN ";
            // Display(sqlCode);
            Display1();
            loadCombobox();
        }

        private void dgvSalary_bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            int i;
            i = dgvSalary_bill.CurrentRow.Index;
            txtSalaryBill_id.Text = dgvSalary_bill.Rows[i].Cells[0].Value.ToString();
            txtSalaryBill_sumDay.Text = dgvSalary_bill.Rows[i].Cells[1].Value.ToString();
            txtSalaryBill_sumMoney.Text = dgvSalary_bill.Rows[i].Cells[2].Value.ToString();
            txtSalaryBill_teacherID.Text = dgvSalary_bill.Rows[i].Cells[3].Value.ToString();
            txtSalaryBill_classID.Text = dgvSalary_bill.Rows[i].Cells[4].Value.ToString();
            txtSalaryBill_datePay.Text = dgvSalary_bill.Rows[i].Cells[5].Value.ToString();
            txtSalaryBill_datePayFor.Text = dgvSalary_bill.Rows[i].Cells[6].Value.ToString();
            ckbPayed.Checked = (dgvSalary_bill.Rows[i].Cells[7].Value.ToString() == "1");
            if (ckbPayed.Checked)
                ckbPayed.Text = "đã thu";
            else
                ckbPayed.Text = "chưa thu";
        }

        private void btnSalaryBill_add_Click_1(object sender, EventArgs e)
        {
            string text;
            if (ckbPayed.Checked == false)

                text = "0";
            else

                text = "1";

            int tongSoBuoiDay;
            tongSoBuoiDay = Int32.Parse(txtSalaryBill_sumDay.Text);


            string sqlInsert = "exec PROC_INSERT_BLTRALUONG '" + txtSalaryBill_id.Text + "','" + txtSalaryBill_teacherID.Text + "','" + txtSalaryBill_classID.Text + "'," + tongSoBuoiDay + ",'" + txtSalaryBill_sumMoney.Text + "', '" + txtSalaryBill_datePay.Text + "','" + txtSalaryBill_datePayFor.Text + "','" + text + "' ";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnSalaryBill_edit_Click_1(object sender, EventArgs e)
        {
            string sqlEdit = "exec PROC_UPDATE_BLTRALUONG '" + txtSalaryBill_id.Text + "','" + txtSalaryBill_sumDay.Text + "','" + txtSalaryBill_sumMoney.Text + "','" + txtSalaryBill_teacherID.Text + "','" + txtSalaryBill_classID.Text + "', '" + txtSalaryBill_datePay.Text + "','" + txtSalaryBill_datePayFor.Text + "','" + ckbPayed.Checked + "' ";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnSalaryBill_delete_Click_1(object sender, EventArgs e)
        {


            string sqlDelete = "exec PROC_DELETE_BLTRALUONG '" + txtSalaryBill_id.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            Display1();
        }

        private void btnSalaryBill_clear_Click_1(object sender, EventArgs e)
        {
            txtSalaryBill_id.Text = "";
            txtSalaryBill_sumDay.Text = "";
            txtSalaryBill_sumMoney.Text = "";
            txtSalaryBill_teacherID.Text = "";
            txtSalaryBill_classID.Text = "";
            txtSalaryBill_datePay.Text = "";
            txtSalaryBill_datePayFor.Text = "";
            ckbPayed.Text = "đã thu";
            Display1();
        }

        public void loadCombobox()
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

        private void cbbMBM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaMonHoc FROM MONHOC WHERE TenMonHoc = '" + cbbMMH.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtSalarySearch.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }

        private void btnSalary_search_Click(object sender, EventArgs e)
        {
            string sqlCode2 = "select MaGiaoVien, TenGiaoVien from GIAOVIEN, MONHOC where GIAOVIEN.MaMonHoc=MONHOC.MaMonHoc and MONHOC.MaMonHoc='" + txtSalarySearch.Text + "'";
            Display(sqlCode2);
        }

        public void autoLoadBillID()
        {

            string sqlCode = "SELECT TOP(1) MaBLTraLuong FROM BLTRALUONG ORDER BY MaBLTraLuong DESC";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr.GetValue(0).ToString().Substring(4)) + 1;
                string ID = "";
                if (id < 100) ID = "0" + id.ToString();
                else ID = id.ToString();
                txtSalaryBill_id.Text = "BLTL" + ID;
            }
            dr.Close();
        }

        //func sql 
        public string getSumDay(string ClassID)
        {
            string result = "";

            string sqlCode = "select count(MaBuoiHoc) from BUOIHOC where MaLopHoc ='" + ClassID + "' ";


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
        public int getFeeClass(string ClassID)
        {
            int result = 0;

            string sqlCode = "select * from FUNC_TONGHOCPHI_1LOP('" + ClassID + "') ";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Int32.TryParse(dr.GetValue(0).ToString(), out result);
            }
            dr.Close();

            return result;
        }
        //fun sql
        public int getPercentTeacher(string TeacherID)
        {
            string result = "";

            string sqlCode = "select TyLePhanTram from GIAOVIEN,MUCTHANHTOAN where GIAOVIEN.MaMTT = MUCTHANHTOAN.MaMTT and MaGiaoVien = '" + TeacherID + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetValue(0).ToString();
            }
            dr.Close();

            return Convert.ToInt32(result);
        }
        //func sql
        public string convertDate(string date)
        {
            string[] info = date.Split('/');

            return info[1] + "/" + info[0] + "/" + info[2];
        }

        //fun sql

        public string getClassID(string TeacherID)
        {
            string result = "";

            string sqlCode = "select MaLopHoc from GIAOVIEN,LOPHOC where GIAOVIEN.MaGiaoVien = LOPHOC.MaGiaoVien and GIAOVIEN.MaGiaoVien = '" + TeacherID + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetValue(0).ToString();
            }
            dr.Close();

            return result;
        }

        private void dgvSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvSalary.CurrentRow.Index;
            autoLoadBillID();
            txtSalaryBill_sumDay.Text = getSumDay(txtSalaryBill_classID.Text);
            txtSalaryBill_teacherID.Text = dgvSalary.Rows[i].Cells[0].Value.ToString();
            txtSalaryBill_classID.Text = getClassID(txtSalaryBill_teacherID.Text);
            txtSalaryBill_datePay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtSalaryBill_datePayFor.Text = DateTime.Now.Month.ToString();
            txtSalaryBill_sumMoney.Text = (getPercentTeacher(txtSalaryBill_teacherID.Text) * getFeeClass(txtSalaryBill_classID.Text) / 100).ToString();
        }
    }
}
