﻿using System;
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

        private void btnFee_bill_Click(object sender, EventArgs e)
        {
            txtFeeBill_id.Enabled = true;
            txtFeeBill_studentID.Enabled = true;
            txtFeeBill_classID.Enabled = true;
            txtFeeBill_sumDay.Enabled = true;
            txtFeeBill_feePerDay.Enabled = true;
            txtFeeBill_sumFee.Enabled = true;
            txtFeeBill_dateTake.Enabled = true;
            txtFeeBill_takeForDate.Enabled = true;
            ckbTaked.Enabled = true;
            btnFeeBill_add.Enabled = true;
            btnFeeBill_edit.Enabled = true;
            btnFeeBill_delete.Enabled = true;
            btnFeeBill_clear.Enabled = true;

            autoLoadBillID();
        }

        SqlConnection con;


        private void fFee_Load(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            string sqlCode = "SELECT top(30) * FROM HOCSINH";
            Display(sqlCode);
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

        private void btnFee_search_Click(object sender, EventArgs e)
        {
            string sqlCode2 = "select * from FUNC_LIST_STUDENT_CLASS('" + txtFeeSearch.Text + "')";

            Display(sqlCode2);

            string sqlCode = "SELECT TenLopHoc FROM LOPHOC WHERE MaLopHoc = '" + txtFeeSearch.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string result = dr.GetValue(0).ToString();
                txtFeeSearch2.Text = result;
            }
            dr.Close();
        }

        public void Display1()
        {
            string sqlCode = "SELECT * FROM BLTHUHP ";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
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
            txtFeeBill_dateTake.Text = dgvFee_bill.Rows[i].Cells[6].Value.ToString();
            txtFeeBill_takeForDate.Text = dgvFee_bill.Rows[i].Cells[7].Value.ToString();
            ckbTaked.Checked = (dgvFee_bill.Rows[i].Cells[8].Value.ToString() == "1");
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
            string text;

            if (ckbTaked.Checked == false)
                text = "0";
            else
                text = "1";

            string sqlInsert = "exec PROC_INSERT_BLTHUHP '" + txtFeeBill_id.Text + "','" + txtFeeBill_studentID.Text + "','" + txtFeeBill_classID.Text + "','" + txtFeeBill_sumDay.Text + "','" + txtFeeBill_feePerDay.Text + "', '" + txtFeeBill_sumFee.Text + "','" + txtFeeBill_dateTake.Text + "','" + txtFeeBill_takeForDate.Text + "', '" + text + "'";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();

            Display1();
        }

        private void btnFeeBill_edit_Click(object sender, EventArgs e)
        {
            string sqlEdit = "exec PROC_UPDATE_BLTHUHP '" + txtFeeBill_id.Text + "','" + txtFeeBill_studentID.Text + "','" + txtFeeBill_classID.Text + "','" + txtFeeBill_sumDay.Text + "','" + txtFeeBill_feePerDay.Text + "', '" + txtFeeBill_sumFee.Text + "','" + txtFeeBill_dateTake.Text + "','" + txtFeeBill_takeForDate.Text + "', '" + ckbTaked.Checked + "' ";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnFeeBill_delete_Click(object sender, EventArgs e)
        {
            string sqlDelete = "exec PROC_DELETE_BLTHUHP '" + txtFeeBill_id.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            Display1();
        }

        private void btnFeeBill_clear_Click(object sender, EventArgs e)
        {
            txtFeeBill_id.Text = "";
            txtFeeBill_studentID.Text = "";
            txtFeeBill_classID.Text = "";
            txtFeeBill_sumDay.Text = "";
            txtFeeBill_feePerDay.Text = "";
            txtFeeBill_sumFee.Text = "";
            txtFeeBill_dateTake.Text = "";
            txtFeeBill_takeForDate.Text = "";
            ckbTaked.Text = "chưa thu";
            Display1();
        }

        private void btnFeeBill_all_Click(object sender, EventArgs e)
        {
            Display1();
        }

        public string getFeePerDay(string ClassID)
        {
            string result = "";

            string sqlCode = "SELECT SoHocPhi FROM MUCHOCPHI, LOPHOC WHERE MUCHOCPHI.MaMHP = LOPHOC.MaMHP and MUCHOCPHI.MaMHP = '" + txtFeeSearch2.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetValue(0).ToString();
            }
            dr.Close();

            return result;
        }

        private void dgvFee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvFee.CurrentRow.Index;

            autoLoadBillID();

            txtFeeBill_id.Text = dgvFee.Rows[i].Cells[0].Value.ToString();
            txtFeeBill_classID.Text = txtFeeSearch.Text;
        }

        private void btnFee_search2_Click(object sender, EventArgs e)
        {
            string sqlCode2 = "select * from FUNC_LIST_STUDENT_BY_CLASS_NAME('" + txtFeeSearch2.Text + "')";

            Display(sqlCode2);

            string sqlCode = "SELECT MaLopHoc FROM LOPHOC WHERE TenLopHoc = '" + txtFeeSearch2.Text + "'";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string result = dr.GetValue(0).ToString();
                txtFeeSearch.Text = result;
            }
            dr.Close();
        }
    }
}
