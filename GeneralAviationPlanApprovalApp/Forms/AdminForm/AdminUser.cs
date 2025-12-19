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
        private HomePage homePage = null;
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
            this.Size = new Size(1200, 700);
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

            // 创建并显示首页
            homePage = new HomePage();
            homePage.TopLevel = false;
            homePage.FormBorderStyle = FormBorderStyle.None;
            homePage.Dock = DockStyle.Fill;

            containerPanel.Controls.Add(homePage);
            homePage.Show();

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

        // 审批数据库
        private void 审批数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApprovalDatabaseForm form = new ApprovalDatabaseForm();
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

    // 首页窗体
    public class HomePage : Form
    {
        public HomePage()
        {
            InitializeHomePage();
        }

        private void InitializeHomePage()
        {
            this.Text = "首页";

            // 创建欢迎标题
            Label lblWelcome = new Label();
            lblWelcome.Text = "通用航空飞行计划审批平台";
            lblWelcome.Font = new Font("宋体", 24, FontStyle.Bold);
            lblWelcome.ForeColor = Color.DarkBlue;
            lblWelcome.Location = new Point(150, 50);
            lblWelcome.Size = new Size(600, 50);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblWelcome);

            // 创建功能简介
            Label lblIntro = new Label();
            lblIntro.Text = "欢迎使用通用航空飞行计划审批平台\n\n请从顶部菜单选择需要的功能：\n• 审批工作台 - 处理飞行计划审批\n• 告警工作台 - 查看和处理系统告警\n• 企业数据库 - 管理企业、飞行员和飞行器信息";
            lblIntro.Font = new Font("宋体", 14);
            lblIntro.Location = new Point(100, 150);
            lblIntro.Size = new Size(800, 200);
            lblIntro.TextAlign = ContentAlignment.TopCenter;
            this.Controls.Add(lblIntro);

            // 添加统计面板
            Panel statsPanel = new Panel();
            statsPanel.BorderStyle = BorderStyle.FixedSingle;
            statsPanel.Location = new Point(100, 350);
            statsPanel.Size = new Size(800, 150);

            // 添加统计项
            string[] statsTitles = { "今日待审批", "今日已审批", "今日告警", "在线企业" };
            int[] statsValues = { 12, 45, 3, 8 };
            Color[] statsColors = { Color.Red, Color.Green, Color.Orange, Color.Blue };

            for (int i = 0; i < 4; i++)
            {
                int x = 50 + i * 180;

                // 数值显示
                Label lblValue = new Label();
                lblValue.Text = statsValues[i].ToString();
                lblValue.Font = new Font("宋体", 28, FontStyle.Bold);
                lblValue.ForeColor = statsColors[i];
                lblValue.Location = new Point(x, 30);
                lblValue.Size = new Size(100, 50);
                lblValue.TextAlign = ContentAlignment.MiddleCenter;
                statsPanel.Controls.Add(lblValue);

                // 标题
                Label lblTitle = new Label();
                lblTitle.Text = statsTitles[i];
                lblTitle.Font = new Font("宋体", 12);
                lblTitle.Location = new Point(x, 90);
                lblTitle.Size = new Size(100, 30);
                lblTitle.TextAlign = ContentAlignment.TopCenter;
                statsPanel.Controls.Add(lblTitle);
            }

            this.Controls.Add(statsPanel);
        }
    }


    // 其他窗体类（按需创建）
    public class ApprovalDatabaseForm : Form
    {
        public ApprovalDatabaseForm() { this.Text = "审批数据库"; }
    }

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