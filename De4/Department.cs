using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De4
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string AccountName { get; set;}
        public string EmailAddress { get; set;}
        public string Password { get; set;}
        public string Tel { get; set;}
        public string Location { get; set;}

        public static SqlConnection Con;

        public Department(int departmentID, string departmentName, string accountName, string emailAddress, string password, string tel, string location)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            AccountName = accountName;
            EmailAddress = emailAddress;
            Password = password;
            Tel = tel;
            Location = location;
        }

        public override string ToString()
        {
            return $"Department ID: {DepartmentID}\n" +
                   $"Department Name: {DepartmentName}\n" +
                   $"Account Name: {AccountName}\n" +
                   $"Email Address: {EmailAddress}\n" +
                   $"Password: {Password}\n" +
                   $"Tel: {Tel}\n" +
                   $"Location: {Location}";
        }
        public static void Connect()
        {
            Con = new SqlConnection();   //Khởi tạo đối tượng
            Con.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();

            if (Con.State != ConnectionState.Open)
            {
                Con.Open();                  //Mở kết nối
                //MessageBox.Show("Kết nối tới hệ thống thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Kiểm tra kết nối


            else MessageBox.Show("Không thể kết nối với dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static DataTable GetDataToTable(string sql)
        {
            DataTable table = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            dap.Fill(table);
            return table;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Department.Con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
       /* public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }*/

    }
   
    
}
