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

namespace GeneralAviationPlanApprovalApp.Forms.AdminForm
{
    public partial class PendingApprovalForm : Form
    {
        private UserInfo currentUser;
        // 数据库连接字符串
        private string connectionString;

        public PendingApprovalForm(UserInfo UserInfo)
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

        private void PendingApprovalForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“gAPADataSet.Flight_Plan”中。您可以根据需要移动或移除它。
            this.flight_PlanTableAdapter.Fill(this.gAPADataSet.Flight_Plan);
            // 窗体加载时加载所有待审批计划
            LoadAllPendingPlans();
        }

        // 加载所有待审批计划到DataGridView
        private void LoadAllPendingPlans()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT *
                        FROM Flight_Plan fp
                        WHERE fp.Status = '已提交'
                        ORDER BY fp.SubmitTime ASC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // 绑定到DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 按钮1：按企业名称查询
        private void button1_Click(object sender, EventArgs e)
        {
            string companyName = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(companyName))
            {
                MessageBox.Show("请输入企业名称！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchPlansByCompany(companyName);
        }

        // 按企业名称查询待审批计划
        private void SearchPlansByCompany(string companyName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT *
                        FROM Flight_Plan fp
                        WHERE fp.Status = '已提交' 
                        AND fp.EnterpriseID IN (
                                SELECT e.EnterpriseID
                                FROM Enterprise_Info e
                                WHERE e.CompanyName LIKE @CompanyName
                            )
                        ORDER BY fp.SubmitTime ASC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@CompanyName", "%" + companyName + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 按钮2：查询所有待审批计划
        private void button2_Click(object sender, EventArgs e)
        {
            LoadAllPendingPlans();
            textBox1.Clear();
        }

        // 按钮3：批准选中的计划
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要批准的飞行计划！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"确定要批准选中的 {dataGridView1.SelectedRows.Count} 个飞行计划吗？",
                "确认批准", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProcessApproval("已批准");
            }
        }

        // 按钮4：拒绝选中的计划
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要拒绝的飞行计划！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"确定要拒绝选中的 {dataGridView1.SelectedRows.Count} 个飞行计划吗？",
                "确认拒绝", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProcessApproval("已拒绝");
            }
        }

        // 处理审批操作
        private void ProcessApproval(string newStatus)
        {
            try
            {
                List<int> planIds = new List<int>();

                // 收集选中的PlanID
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int planId = Convert.ToInt32(row.Cells[0].Value);
                        planIds.Add(planId);
                    }
                }

                if (planIds.Count == 0)
                {
                    MessageBox.Show("未找到有效的计划ID！", "错误",
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
                            foreach (int planId in planIds)
                            {
                                // 1. 更新飞行计划状态
                                string updatePlanSql = @"
                                    UPDATE Flight_Plan 
                                    SET Status = @Status
                                    WHERE PlanID = @PlanID";

                                using (SqlCommand cmd = new SqlCommand(updatePlanSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Status", newStatus);
                                    cmd.Parameters.AddWithValue("@PlanID", planId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 2. 获取当前登录的审批员ID（需要从登录信息传递过来）
                                int reviewerId = GetCurrentReviewerId();

                                // 3. 插入审批记录
                                string insertLogSql = @"
                                    INSERT INTO Approval_Log 
                                    (PlanID, ReviewerID, Result, Comments, ApprovalTime)
                                    VALUES (@PlanID, @ReviewerID, @Result, @Comments, GETDATE())";

                                string actionText = newStatus == "已批准" ? "通过" : "拒绝";
                                MessageBox.Show($"成功{actionText} {planIds.Count} 个飞行计划", "成功",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                using (SqlCommand cmd = new SqlCommand(insertLogSql, conn, transaction))
                                {   
                                    cmd.Parameters.AddWithValue("@PlanID", planId);
                                    cmd.Parameters.AddWithValue("@ReviewerID", reviewerId);
                                    cmd.Parameters.AddWithValue("@Result", actionText);
                                    cmd.Parameters.AddWithValue("@Comments", $"{newStatus} - 批量审批");
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 提交事务
                            transaction.Commit();

                            // 刷新列表
                            LoadAllPendingPlans();
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

        // 获取当前审批员ID（从当前登录用户获取）
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