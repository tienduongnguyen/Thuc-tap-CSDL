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
            Display(sqlCode);
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
            txtSalaryBill_teacherID .Text= dgvSalary_bill.Rows[i].Cells[3].Value.ToString();
            txtSalaryBill_classID.Text = dgvSalary_bill.Rows[i].Cells[4].Value.ToString();
            txtSalaryBill_datePay .Text= dgvSalary_bill.Rows[i].Cells[5].Value.ToString();
            txtSalaryBill_datePayFor .Text= dgvSalary_bill.Rows[i].Cells[6].Value.ToString();
            ckbPayed.Checked = (dgvSalary_bill.Rows[i].Cells[7].Value.ToString()=="1");
            if (ckbPayed.Checked)
                ckbPayed.Text = "đã thu";
            else
                ckbPayed.Text = "chưa thu";
        }

        private void btnSalaryBill_add_Click_1(object sender, EventArgs e)
        {
            string text;
            if(ckbPayed.Checked==false)
            
                text = "0";  
            else
            
                text = "1";

           int tongSoBuoiDay;
           tongSoBuoiDay = Int32.Parse(txtSalaryBill_sumDay.Text);


            string sqlInsert = "exec PROC_INSERT_BLTRALUONG '" + txtSalaryBill_id.Text + "','" + txtSalaryBill_teacherID.Text + "','" + txtSalaryBill_classID.Text + "'," + tongSoBuoiDay + ",'" + txtSalaryBill_sumMoney.Text + "', '" + txtSalaryBill_datePay.Text + "','" + txtSalaryBill_datePayFor.Text + "','"+ text + "' ";
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
            var sqlCode = "Select MaMonHoc from MONHOC";
            SqlCommand cmd = new SqlCommand(sqlCode, con);
            ///cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbMMH.ValueMember = "MaMonHoc";
            cbbMMH.DataSource = dt;
        }

        private void cbbMBM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCode = "SELECT MaMonHoc FROM MONHOC WHERE MaMonHoc = '" + cbbMMH.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtSalarySearch.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
        }
    }
}
