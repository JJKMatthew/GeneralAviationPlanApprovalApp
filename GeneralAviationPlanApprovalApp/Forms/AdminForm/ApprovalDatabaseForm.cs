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
using System.Drawing.Text;
using GeneralAviationPlanApprovalApp.Forms.AdminForm;

namespace GeneralAviationPlanApprovalApp.Forms.AdminForm
{
    public partial class ApprovalDatabaseForm : Form
    {
        private AdminUser admainForm1;
        UserInfo currentUser;
        int userID;
        private string connectionString;
        public ApprovalDatabaseForm(UserInfo UserInfo, AdminUser admainForm)
        {
            InitializeComponent();
            InitializeConnectionString();
            currentUser = UserInfo;
            admainForm1 = admainForm;
            userID = currentUser.UserID;
        }
        private void InitializeConnectionString()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["myconnstring"].ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库连接配置错误：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ApprovalDatabaseForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“gAPADataSet2.Approval_Log”中。您可以根据需要移动或移除它。
            this.approval_LogTableAdapter.Fill(this.gAPADataSet2.Approval_Log);
            LoadUserFinshedPlans();
        }
        private void LoadUserFinshedPlans()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 修正SQL查询，使用参数化查询
                    string sql = @"
                        SELECT *
                        FROM Approval_Log al
                        ORDER BY al.ApprovalTime ASC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // 添加参数
                        cmd.Parameters.AddWithValue("@ReviewerID", userID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // 绑定到DataGridView
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            admainForm1.ShowHomePage();
        }
    }
}
