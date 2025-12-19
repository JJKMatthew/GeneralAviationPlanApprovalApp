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
using System.Configuration;

namespace GeneralAviationPlanApprovalApp
{
    public partial class logging : Form
    {
        public logging()
        {
            InitializeComponent();
        }

        private void logging_Load(object sender, EventArgs e)
        {
            // 窗体加载时设置焦点到用户ID文本框
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 登录按钮点击事件
            Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 注册按钮点击事件
            MessageBox.Show("注册功能开发中...", "提示",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Login()
        {
            string userIdText = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // 验证输入
            if (string.IsNullOrEmpty(userIdText))
            {
                MessageBox.Show("请输入用户ID！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // 验证用户ID是否为数字
            if (!int.TryParse(userIdText, out int userId))
            {
                MessageBox.Show("用户ID必须为数字！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // 验证用户ID和密码
            if (ValidateLogin(userId, password))
            {
                // 获取用户信息
                UserInfo userInfo = GetUserInfo(userId);

                if (userInfo != null)
                {
                    // 登录成功，跳转到主窗体
                    //Form2 mainForm = new Form2(userInfo);
                    Form2 mainForm = new Form2();
                    mainForm.Show();
                    this.Hide(); // 隐藏登录窗体
                }
                else
                {
                    MessageBox.Show("获取用户信息失败！", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("用户ID或密码错误！", "登录失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private bool ValidateLogin(int userId, string password)
        {
            string connectionString = "";
            SqlConnection connection = null;

            try
            {
                // 获取连接字符串
                connectionString = ConfigurationManager.ConnectionStrings["myconnstring"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();

                // 使用参数化查询防止SQL注入
                string sql = "SELECT COUNT(*) FROM User_Info WHERE UserID = @UserID AND Password = @Password";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接错误：" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // 确保连接关闭
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private UserInfo GetUserInfo(int userId)
        {
            string connectionString = "";
            SqlConnection connection = null;

            try
            {
                // 获取连接字符串
                connectionString = ConfigurationManager.ConnectionStrings["myconnstring"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();

                // 查询用户详细信息
                string sql = "SELECT UserID, Username, UserType, CreatedTime FROM User_Info WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserInfo userInfo = new UserInfo
                            {
                                UserID = reader.GetInt16(reader.GetOrdinal("UserID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                UserType = reader.GetString(reader.GetOrdinal("UserType")),
                                CreatedTime = reader.GetDateTime(reader.GetOrdinal("CreatedTime"))
                            };
                            return userInfo;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取用户信息错误：" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // 确保连接关闭
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // 按回车键快速登录
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
                e.Handled = true;
            }
        }

        // 按回车键从用户ID框跳转到密码框
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // 验证用户ID是否为数字
                string userIdText = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(userIdText) && !int.TryParse(userIdText, out _))
                {
                    MessageBox.Show("用户ID必须为数字！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    textBox1.SelectAll();
                    e.Handled = true;
                    return;
                }

                textBox2.Focus();
                e.Handled = true;
            }
        }

        // 限制用户ID文本框只能输入数字
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 允许数字、退格键、回车键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // 如果是回车键，跳转到密码框
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }
    }

    // 用户信息类
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; } // "企业" 或 "管制人员"
        public DateTime CreatedTime { get; set; }
    }
}