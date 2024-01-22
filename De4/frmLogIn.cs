using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De4
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string strUserName = this.txtUserName.Text;
            string strPassword = this.txtPassword.Text;
            CheckUserNamePassFromDB(strUserName, strPassword);
            

            /*DialogResult dr = MessageBox.Show(" Bạn có muốn kiểm tra trong Database không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                //MessageBox.Show("Bạn vui lòng chờ hệ thống kiểm tra cơ sở dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckUserNamePassFromDB(strUserName, strPassword);
            }
            else
            {
                MessageBox.Show("Cảm ơn bạn đã sử dụng Hệ Thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }
       
        private bool CheckUserNamePassFromDB(string strusername, string strpassword)
        {
            try
            {
                // Kết nối database
                string strConnect = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
                // Chạy command
                string strCommand = String.Format("Select * from Department" + " where AccountName = N'{0}' " + "and Password = N'{1}' ", strusername, strpassword);

                SqlConnection cnn = new SqlConnection(strConnect);
                SqlCommand myCommand = new SqlCommand(strCommand, cnn);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataSet ds = new DataSet();
                da.Fill(ds, "ABC");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Có dữ liệu trong Database, Đăng nhập thành công", "CÓ DỮ LIỆU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    FrmMain mainForm = new FrmMain();
                    mainForm.SetUserInfo(strusername); // Tùy thuộc vào cách bạn muốn hiển thị thông tin người dùng
                    mainForm.Show();
                    this.Hide(); // Ẩn Form đăng nhập sau khi đăng nhập thành công
                    return true;



                }
                else
                {
                    MessageBox.Show("Người dùng không tồn tại", "KHÔNG CÓ DỮ LIỆU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra", ex.Message);
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string strMessage = string.Format("Bạn có chắc muốn thoát không?");
            DialogResult dr = MessageBox.Show(strMessage, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
