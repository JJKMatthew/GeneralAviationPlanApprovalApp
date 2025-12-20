using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralAviationPlanApprovalApp.Forms.AdminForm
{
    public partial class ProcessedAlertsForm : Form
    {
        private UserInfo currentUser;
        // 数据库连接字符串
        private string connectionString;
        public ProcessedAlertsForm(UserInfo UserInfo)
        {
            InitializeComponent();
            InitializeConnectionString();
            this.currentUser = UserInfo;
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
        private void ProcessedAlertsForm_Load(object sender, EventArgs e)
        {
            LoadAllProcessedAlerts();
        }
        private void LoadAllProcessedAlerts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    // 获取当前登录的审批员ID（需要从登录信息传递过来）
                    int reviewerId = GetCurrentReviewerId();
                    string sql = @"
                        SELECT *
                        FROM Alert_Notification an
                        WHERE an.IsRead = 1 
                        AND an.ReviewerID = @ReviewerID
                        ORDER BY an.CreatedTime ASC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReviewerID", reviewerId);

                        // 使用这个cmd创建SqlDataAdapter
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要撤销的告警通知！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"确定要撤销选中的 {dataGridView1.SelectedRows.Count} 个告警通知吗？",
                "确认撤销", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AlertMessageCancel();
            }
        }
        private void AlertMessageCancel()
        {
            try
            {
                List<int> alertIDs = new List<int>();

                // 收集选中的alertID
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int alertID = Convert.ToInt32(row.Cells[0].Value);
                        alertIDs.Add(alertID);
                    }
                }

                if (alertIDs.Count == 0)
                {
                    MessageBox.Show("未找到有效的告警ID！", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 开始事务
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (int alertID in alertIDs)
                            {
                                // 1. 更新状态
                                string updatePlanSql = @"
                                    UPDATE Alert_Notification
                                    SET IsRead = @Status
                                    WHERE alertID = @alertID";

                                using (SqlCommand cmd = new SqlCommand(updatePlanSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Status", 0);
                                    cmd.Parameters.AddWithValue("@alertID", alertID);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 提交事务
                            transaction.Commit();

                            // 刷新列表
                            LoadAllProcessedAlerts();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"审批操作失败：{ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetCurrentReviewerId()
        {
            if (currentUser != null)
            {
                return currentUser.UserID;  // 直接返回当前用户的ID
            }
            else
            {
                // 如果currentUser为空，可能是通过默认构造函数创建的
                MessageBox.Show("用户信息未正确传递，请重新登录！", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;  // 返回无效ID，审批时会失败
            }
        }
    }
}
