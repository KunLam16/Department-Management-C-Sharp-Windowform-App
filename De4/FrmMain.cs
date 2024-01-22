using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De4
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void QL_Click(object sender, EventArgs e)
        {
            frmDepartment frm = new frmDepartment(); //Khởi tạo đối tượng
            //frm.MdiParent = this; //Hiển thị
            frm.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Department.Connect();
        }
        public void SetUserInfo(string userInfo)
        {
            this.Text = $"Welcome, {userInfo}!"; // Thay đổi tiêu đề của FormMain
        }
        private void LogInMenuItem_Click(object sender, EventArgs e)
        {
            frmLogIn frm = new frmLogIn();
            //frm.MdiParent = this; //Hiển thị
            this.Hide();
            frm.Show();
            
            

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RpMenuItem_Click(object sender, EventArgs e)
        {
            rptBaoCao rpt = new rptBaoCao();
            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();

            SqlConnection conn = new SqlConnection(strConnection);
            //conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Department ", conn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            rpt.SetDataSource(ds.Tables[0]);
            frmReport reportForm = new frmReport();
            reportForm.CRV.ReportSource = rpt;
            reportForm.Show();
            
        }
    }
}
