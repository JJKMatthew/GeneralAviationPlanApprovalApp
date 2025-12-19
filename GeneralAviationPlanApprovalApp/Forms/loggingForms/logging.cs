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

            // 验证用户ID和密码，并获取用户信息
            UserInfo userInfo = ValidateLoginAndGetInfo(userId, password);

            if (userInfo != null)
            {
                // 登录成功，根据用户类型跳转到不同界面
                JumpToUserInterface(userInfo);
            }
            else
            {
                MessageBox.Show("用户ID或密码错误！", "登录失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private UserInfo ValidateLoginAndGetInfo(int userId, string password)
        {
            string connectionString = "";
            SqlConnection connection = null;

            try
            {
                // 获取连接字符串
                connectionString = ConfigurationManager.ConnectionStrings["myconnstring"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();

                // 同时验证登录并获取用户信息
                string sql = @"
                    SELECT UserID, Username, UserType, CreatedTime 
                    FROM User_Info 
                    WHERE UserID = @UserID AND Password = @Password";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                UserInfo userInfo = new UserInfo
                                {
                                    UserID = Convert.ToInt16(reader["UserID"]),
                                    Username = reader["Username"].ToString(),
                                    UserType = reader["UserType"].ToString(),
                                    CreatedTime = Convert.ToDateTime(reader["CreatedTime"])
                                };
                                return userInfo;
                            }
                            catch (InvalidCastException ex)
                            {
                                // 如果类型转换出错，使用更安全的方式
                                MessageBox.Show($"数据类型转换错误：{ex.Message}\n请检查数据库字段类型", "错误",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return null;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库验证错误：" + ex.Message, "错误",
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

        private void JumpToUserInterface(UserInfo userInfo)
        {
            try
            {
                // 根据UserType跳转到不同界面
                if (userInfo.UserType == "管制人员")
                {
                    MessageBox.Show($"欢迎，管制人员 {userInfo.Username}！", "登录成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 跳转到管制人员界面 (AdminUser)
                    AdminUser adminForm = new AdminUser(userInfo);
                    //AdminUser adminForm = new AdminUser();
                    adminForm.Show();
                    this.Hide();
                }
                else if (userInfo.UserType == "企业")
                {
                    MessageBox.Show($"欢迎，企业用户 {userInfo.Username}！", "登录成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 跳转到企业用户界面 
                    //EnterpriseUser enterpriseForm = new EnterpriseUser(userInfo);
                    EnterpriseUser enterpriseForm = new EnterpriseUser();
                    enterpriseForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"未知的用户类型：{userInfo.UserType}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"跳转界面失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 允许数字、退格键、回车键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
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