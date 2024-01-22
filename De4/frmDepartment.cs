using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using De4;

namespace De4
{
    public partial class frmDepartment : Form


    {
        //DataTable tbl;
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            LoadForm();
            txtDID.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtDName.Enabled = false;
        }
        private void LoadForm()
        {
            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
            string strCommand = "Select DepartmentID, DepartmentName from Department union select 0,'All'";
            string sql;
            sql = "SELECT DepartmentID,DepartmentName,AccountName,EmailAddress,Password,Tel,Location FROM Department";
            //Kết nối db
            SqlConnection myConnection = new SqlConnection(strConnection);
            //Chạy lệnh
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            //Thêm dữ liệu
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.cbbID.DataSource = dt;
            this.cbbID.ValueMember = "DepartmentID";
            this.cbbID.DisplayMember = "DepartmentID";
            dgvDep.DataSource = Department.GetDataToTable(sql);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            {
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();

                string strQuery = "";


                if (this.txtName.Text.Length > 0)
                {
                    strQuery = "DepartmentName like N'%" + this.txtName.Text + "%'";
                }
                if (this.cbbID.SelectedValue.ToString() != "0")
                {
                    if (strQuery != "")
                    {
                        strQuery += " and DepartmentID =" + this.cbbID.SelectedValue.ToString();
                    }
                    else
                    {
                        strQuery = " DepartmentID = " + this.cbbID.SelectedValue.ToString();
                    }

                }
                string strCommand = "Select * from Department";

                if (strQuery.Length > 0)
                {
                    strCommand += " Where " + strQuery;
                }
                SqlConnection myConnection = new SqlConnection(strConnection);
                //Chạy lệnh
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                //Thêm dữ liệu
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dgvDep.DataSource = dt;
            }
        }
        private void dgvDep_Click(object sender, EventArgs e)
        {
            /*if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/
            txtDName.Enabled = true;
            txtDID.Text = dgvDep.CurrentRow.Cells["DepartmentID"].Value.ToString();
            txtDName.Text = dgvDep.CurrentRow.Cells["DepartmentName"].Value.ToString();
            txtAccName.Text = dgvDep.CurrentRow.Cells["AccountName"].Value.ToString();
            txtEmail.Text = dgvDep.CurrentRow.Cells["EmailAddress"].Value.ToString();
            txtPassword.Text = dgvDep.CurrentRow.Cells["Password"].Value.ToString();
            txtTel.Text = dgvDep.CurrentRow.Cells["Tel"].Value.ToString();
            txtLocation.Text = dgvDep.CurrentRow.Cells["Location"].Value.ToString();



        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtDName.Enabled = true;
            ResetValues();
            txtDID.Focus();
        }
        private void ResetValues()
        {
            txtDID.Text = "";
            txtDName.Text = "";
            txtAccName.Text = "";
            txtEmail.Text = "";
            txtLocation.Text = "";
            txtPassword.Text = "";
            txtTel.Text = "";
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtDID.Enabled = false;
            txtDName.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            /*if (txtDID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Department", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDID.Focus();
                return;
            }*/
            if (txtDName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Department", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDName.Focus();
                return;
            }
            if (txtAccName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên account", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccName.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (txtTel.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTel.Focus();
                return;
            }
            if (txtLocation.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập location", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }




            sql = "SELECT DepartmentID FROM Department WHERE DepartmentID =N'" + txtDID.Text.Trim() + "'";
            /*if (Department.CheckKey(sql))
            {
                MessageBox.Show("Mã Department này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDID.Focus();
                txtDID.Text = "";
                return;
            }*/
            sql = "INSERT INTO Department( DepartmentName, AccountName, EmailAddress, [Password], Tel, [Location]) VALUES (N'"  + txtDName.Text.Trim() + "',N'" + txtAccName.Text.Trim() + "',N'" + txtEmail.Text.Trim() + "',N'" + txtPassword.Text.Trim() + "',N'" + txtTel.Text.Trim() + "',N'" + txtLocation.Text.Trim() + "')";
            Department.RunSQL(sql);
            MessageBox.Show("Đã thêm 1 bản ghi","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadForm();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtDID.Enabled = false;
            txtDName.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            
            if (txtDID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Department", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDName.Focus();
                return;
            }
            if (txtAccName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Account Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccName.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (txtTel.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTel.Focus();
                return;
            }
            if (txtLocation.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Location", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }
            sql = "UPDATE Department SET  DepartmentName=N'" + txtDName.Text.Trim().ToString() +
                    "',AccountName=N'" + txtAccName.Text.Trim().ToString() +
                    "',EmailAddress='" + txtEmail.Text.ToString() +
                    "',Password='" + txtPassword.Text.ToString() +
                    "',Tel='" + txtTel.Text.ToString() +
                    "',Location='" + txtLocation.Text.ToString() +


                    "' WHERE DepartmentID=N'" + txtDID.Text + "'";


            Department.RunSQL(sql);
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadForm();
            ResetValues();
            txtDName.Enabled = false;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtDID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Department WHERE DepartmentID=N'" + txtDID.Text + "'";
                Department.RunSqlDel(sql);
                LoadForm();
                ResetValues();
                txtDName.Enabled = false;
            }

        }
        private DataTable GetDataGridViewData()
        {
            DataTable dataTable = new DataTable("DepartmentDataTable");

            foreach (DataGridViewColumn column in dgvDep.Columns)
            {
                dataTable.Columns.Add(column.Name);
            }

            foreach (DataGridViewRow row in dgvDep.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            /*frmReport frm = new frmReport();
            frm.Show();*/
            DataTable dataTable = GetDataGridViewData();

            // Tạo đối tượng báo cáo
            rptBaoCao report = new rptBaoCao();

            // Gán dữ liệu cho báo cáo
            report.SetDataSource(dataTable);

            // Tạo Form báo cáo và hiển thị
            frmReport reportForm = new frmReport();
            reportForm.CRV.ReportSource = report;
            reportForm.Show();
        }
    }
}