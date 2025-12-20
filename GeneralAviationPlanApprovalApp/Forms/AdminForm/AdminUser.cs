using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralAviationPlanApprovalApp.Forms.AdminForm;

namespace GeneralAviationPlanApprovalApp
{
    
    public partial class AdminUser : Form
    {
        // 存储当前打开的子窗体
        private Form currentChildForm = null;
        private Panel containerPanel = null;
        private UserInfo currentUser;
        private AdminUser admainForm;

        public AdminUser(UserInfo userInfo)
        {
            this.currentUser = userInfo;
            this.admainForm = this;
            InitializeComponent();
            InitializeHomePage();
        }

        // 初始化首页
        private void InitializeHomePage()
        {
            this.Text = "通用航空审批平台 - 管理员";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 创建容器Panel
            containerPanel = new Panel();
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.Location = new Point(0, menuStrip1.Height);
            containerPanel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - menuStrip1.Height);
            this.Controls.Add(containerPanel);

            // 显示首页
            ShowHomePage();
        }

        // 显示首页
        public void ShowHomePage()
        {
            // 关闭当前子窗体
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

            // 清除容器中的所有控件
            containerPanel.Controls.Clear();

            // 显示首页
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

            // 更新窗口标题
            this.Text = "通用航空审批平台 - 管理员 - 首页";
        }

        // 通用方法：打开子窗体
        private void OpenChildForm(Form childForm, string formTitle)
        {
            // 关闭当前子窗体
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // 清除容器中的所有控件
            containerPanel.Controls.Clear();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            // 将子窗体添加到容器
            containerPanel.Controls.Add(childForm);
            childForm.Show();

            // 更新窗口标题
            this.Text = $"通用航空审批平台 - 管理员 - {formTitle}";
        }

        // ========== 菜单点击事件处理 ==========

        // 首页按钮finish
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowHomePage();
        }

        // 待审批计划finish
        private void 待审批计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingApprovalForm form = new PendingApprovalForm(currentUser);
            OpenChildForm(form, "待审批计划");
        }

        // 已审批计划finish
        private void 已审批计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlreadyApprovalForm form = new AlreadyApprovalForm(currentUser ,admainForm);
            OpenChildForm(form, "已审批计划");
        }

        // 审批数据库finsh
        private void 审批数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApprovalDatabaseForm form = new ApprovalDatabaseForm(currentUser, admainForm);
            OpenChildForm(form, "审批数据库");
        }

        // 待告警信息
        private void 待告警信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingAlertsForm form = new PendingAlertsForm();
            OpenChildForm(form, "待告警信息");
        }

        // 已告警信息
        private void 已告警信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessedAlertsForm form = new ProcessedAlertsForm();
            OpenChildForm(form, "已告警信息");
        }

        // 告警历史
        private void 告警历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlertHistoryForm form = new AlertHistoryForm();
            OpenChildForm(form, "告警历史");
        }

        // 企业信息
        private void 企业信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterpriseInfoForm form = new EnterpriseInfoForm();
            OpenChildForm(form, "企业信息");
        }

        // 飞行员信息
        private void 飞行员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PilotInfoForm form = new PilotInfoForm();
            OpenChildForm(form, "飞行员信息");
        }

        // 飞行器信息
        private void 飞行器信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AircraftInfoForm form = new AircraftInfoForm();
            OpenChildForm(form, "飞行器信息");
        }

        // 窗体关闭事件
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("确定要退出程序吗？", "确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

    }

    // ========== 各个功能窗体的简单实现 ==========

    // 其他窗体类（按需创建）

    public class PendingAlertsForm : Form
    {
        public PendingAlertsForm() { this.Text = "待告警信息"; }
    }

    public class ProcessedAlertsForm : Form
    {
        public ProcessedAlertsForm() { this.Text = "已告警信息"; }
    }

    public class AlertHistoryForm : Form
    {
        public AlertHistoryForm() { this.Text = "告警历史"; }
    }

    public class EnterpriseInfoForm : Form
    {
        public EnterpriseInfoForm() { this.Text = "企业信息"; }
    }

    public class PilotInfoForm : Form
    {
        public PilotInfoForm() { this.Text = "飞行员信息"; }
    }

    public class AircraftInfoForm : Form
    {
        public AircraftInfoForm() { this.Text = "飞行器信息"; }
    }
}