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
            btnSalaryBill_Export.Enabled = true;
        }


        SqlConnection con;
        int percent = 0;


        public void Display(string code)
        {
            SqlCommand cmd = new SqlCommand(code, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(dataReader);
            dgvSalary.DataSource = dataTable;
        }


        public void Display1(string code)
        {
            SqlCommand cmd = new SqlCommand(code, con);
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
           //txtSalaryBill_datePay.Text = convertDate(dgvSalary_bill.Rows[i].Cells[5].Value.ToString());
            txtSalaryBill_datePay.Text = dgvSalary_bill.Rows[i].Cells[5].Value.ToString();
            txtSalaryBill_datePayFor.Text = dgvSalary_bill.Rows[i].Cells[6].Value.ToString();
            if (dgvSalary_bill.Rows[i].Cells[7].Value.ToString() == "1") ckbPayed.Checked = true;
            else ckbPayed.Checked = false;
        }

        private void btnSalaryBill_add_Click_1(object sender, EventArgs e)
        {

            string isCheck = "";
            if (ckbPayed.Checked) isCheck = "1";
            else isCheck = "0";

            string sqlInsert = "exec PROC_INSERT_BLTRALUONG '" + txtSalaryBill_id.Text + "','" + txtSalaryBill_teacherID.Text + "','" + txtSalaryBill_classID.Text + "'," + txtSalaryBill_sumDay.Text + ",'" + txtSalaryBill_sumMoney.Text + "', '" + txtSalaryBill_datePay.Text + "','" + txtSalaryBill_datePayFor.Text + "','" + isCheck + "' ";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();

            string sqlCode = "select top(20) * from BLTraLuong where MaGiaoVien = '" + txtSalaryBill_teacherID.Text + "' order by NgayTra desc";
            Display1(sqlCode);

            btnSalaryBill_add.Enabled = false;
        }

        private void btnSalaryBill_edit_Click_1(object sender, EventArgs e)
        {
            string isCheck = "";
            if (ckbPayed.Checked) isCheck = "1";
            else isCheck = "0";

            string sqlInsert = "exec PROC_UPDATE_BLTRALUONG '" + txtSalaryBill_id.Text + "','" + txtSalaryBill_teacherID.Text + "','" + txtSalaryBill_classID.Text + "'," + txtSalaryBill_sumDay.Text + ",'" + txtSalaryBill_sumMoney.Text + "', '" + txtSalaryBill_datePay.Text + "','" + txtSalaryBill_datePayFor.Text + "','" + isCheck + "' ";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();

            string sqlCode = "select top(20) * from BLTraLuong where MaGiaoVien = '" + txtSalaryBill_teacherID.Text + "' order by NgayTra desc";
            Display1(sqlCode);
        }

        private void btnSalaryBill_delete_Click_1(object sender, EventArgs e)
        {
            string sqlDelete = "exec PROC_DELETE_BLTRALUONG '" + txtSalaryBill_id.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            string sqlCode = "select top(20) * from BLTraLuong where MaGiaoVien = '" + txtSalaryBill_teacherID.Text + "' order by NgayTra desc";
            Display1(sqlCode);
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

            string sqlCode2 = "select * from FUNC_LIST_TEACHER('" + txtSalarySearch.Text + "')";
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

                if (id >= 10) ID = "0" + id.ToString();
                else if (id < 10) ID = "00" + id.ToString();
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
        public int getFeeClass(string ClassID, string months)
        {
            int result = 0;

            string sqlCode = "select * from FUNC_CALC_HOCPHI('" + ClassID + "','" + months + "')";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Int32.TryParse(dr.GetValue(0).ToString(), out result);
            }
            dr.Close();

            return result;
        }

        //func sql
        public string convertDate(string date)
        {
            string[] info = date.Split('/');

            return info[1] + "/" + info[0] + "/" + info[2];
        }

        private void dgvSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvSalary.CurrentRow.Index;
            percent = (int)dgvSalary.Rows[i].Cells[3].Value;

            autoLoadBillID(); //Ma bien lai
            txtSalaryBill_teacherID.Text = dgvSalary.Rows[i].Cells[0].Value.ToString(); //Ma giao vien
            txtSalaryBill_classID.Text = dgvSalary.Rows[i].Cells[2].Value.ToString(); //Ma lop
            txtSalaryBill_sumDay.Text = getSumDay(txtSalaryBill_classID.Text); //Tong so buoi day
            txtSalaryBill_datePay.Text = DateTime.Now.ToString("MM/dd/yyyy"); //Ngay tra
            txtSalaryBill_datePayFor.Text = (DateTime.Now.Month - 1).ToString(); //Tra cho thang/nam
            txtSalaryBill_sumMoney.Text = (percent * getFeeClass(txtSalaryBill_classID.Text, txtSalaryBill_datePayFor.Text) / 100).ToString(); //Tong luong

            string sqlCode = "select * from BLTRALUONG where MaGiaoVien = '" + txtSalaryBill_teacherID.Text + "' order by NgayTra desc";
            Display1(sqlCode);

            btnSalaryBill_add.Enabled = true;
        }

        private void ckbPayed_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPayed.Checked) ckbPayed.Text = "đã trả";
            else ckbPayed.Text = "chưa trả";
        }

        private void btnSalaryBill_Export_Click(object sender, EventArgs e)
        {
            fBillTeacher form = new fBillTeacher(txtSalaryBill_id.Text,
                                                 txtSalaryBill_teacherID.Text,
                                                 txtSalaryBill_classID.Text,
                                                 txtSalaryBill_sumDay.Text,
                                                 txtSalaryBill_sumMoney.Text,
                                                 txtSalaryBill_datePay.Text,
                                                 txtSalaryBill_datePayFor.Text);

            form.ShowDialog();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtSalaryBill_datePayFor.Text == "") txtSalaryBill_datePayFor.Text = "0";

            txtSalaryBill_sumMoney.Text = (percent * getFeeClass(txtSalaryBill_classID.Text, txtSalaryBill_datePayFor.Text) / 100).ToString();
        }
    }
}
