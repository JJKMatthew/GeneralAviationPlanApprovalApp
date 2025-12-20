namespace GeneralAviationPlanApprovalApp.Forms.AdminForm
{
    partial class PendingAlertsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gAPADataSet3 = new GeneralAviationPlanApprovalApp.GAPADataSet3();
            this.alertNotificationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alert_NotificationTableAdapter = new GeneralAviationPlanApprovalApp.GAPADataSet3TableAdapters.Alert_NotificationTableAdapter();
            this.alertIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageContentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alertTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createdTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertNotificationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alertIDDataGridViewTextBoxColumn,
            this.planIDDataGridViewTextBoxColumn,
            this.reviewerIDDataGridViewTextBoxColumn,
            this.messageContentDataGridViewTextBoxColumn,
            this.alertTypeDataGridViewTextBoxColumn,
            this.isReadDataGridViewCheckBoxColumn,
            this.createdTimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.alertNotificationBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(30, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(746, 211);
            this.dataGridView1.TabIndex = 0;
            // 
            // gAPADataSet3
            // 
            this.gAPADataSet3.DataSetName = "GAPADataSet3";
            this.gAPADataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alertNotificationBindingSource
            // 
            this.alertNotificationBindingSource.DataMember = "Alert_Notification";
            this.alertNotificationBindingSource.DataSource = this.gAPADataSet3;
            // 
            // alert_NotificationTableAdapter
            // 
            this.alert_NotificationTableAdapter.ClearBeforeFill = true;
            // 
            // alertIDDataGridViewTextBoxColumn
            // 
            this.alertIDDataGridViewTextBoxColumn.DataPropertyName = "AlertID";
            this.alertIDDataGridViewTextBoxColumn.HeaderText = "AlertID";
            this.alertIDDataGridViewTextBoxColumn.Name = "alertIDDataGridViewTextBoxColumn";
            this.alertIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // planIDDataGridViewTextBoxColumn
            // 
            this.planIDDataGridViewTextBoxColumn.DataPropertyName = "PlanID";
            this.planIDDataGridViewTextBoxColumn.HeaderText = "PlanID";
            this.planIDDataGridViewTextBoxColumn.Name = "planIDDataGridViewTextBoxColumn";
            // 
            // reviewerIDDataGridViewTextBoxColumn
            // 
            this.reviewerIDDataGridViewTextBoxColumn.DataPropertyName = "ReviewerID";
            this.reviewerIDDataGridViewTextBoxColumn.HeaderText = "ReviewerID";
            this.reviewerIDDataGridViewTextBoxColumn.Name = "reviewerIDDataGridViewTextBoxColumn";
            // 
            // messageContentDataGridViewTextBoxColumn
            // 
            this.messageContentDataGridViewTextBoxColumn.DataPropertyName = "MessageContent";
            this.messageContentDataGridViewTextBoxColumn.HeaderText = "MessageContent";
            this.messageContentDataGridViewTextBoxColumn.Name = "messageContentDataGridViewTextBoxColumn";
            // 
            // alertTypeDataGridViewTextBoxColumn
            // 
            this.alertTypeDataGridViewTextBoxColumn.DataPropertyName = "AlertType";
            this.alertTypeDataGridViewTextBoxColumn.HeaderText = "AlertType";
            this.alertTypeDataGridViewTextBoxColumn.Name = "alertTypeDataGridViewTextBoxColumn";
            // 
            // isReadDataGridViewCheckBoxColumn
            // 
            this.isReadDataGridViewCheckBoxColumn.DataPropertyName = "IsRead";
            this.isReadDataGridViewCheckBoxColumn.HeaderText = "IsRead";
            this.isReadDataGridViewCheckBoxColumn.Name = "isReadDataGridViewCheckBoxColumn";
            // 
            // createdTimeDataGridViewTextBoxColumn
            // 
            this.createdTimeDataGridViewTextBoxColumn.DataPropertyName = "CreatedTime";
            this.createdTimeDataGridViewTextBoxColumn.HeaderText = "CreatedTime";
            this.createdTimeDataGridViewTextBoxColumn.Name = "createdTimeDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "推送告警";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "待告警信息";
            // 
            // PendingAlertsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PendingAlertsForm";
            this.Text = "PendingAlertsForm";
            this.Load += new System.EventHandler(this.PendingAlertsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertNotificationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private GAPADataSet3 gAPADataSet3;
        private System.Windows.Forms.BindingSource alertNotificationBindingSource;
        private GAPADataSet3TableAdapters.Alert_NotificationTableAdapter alert_NotificationTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn alertIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageContentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alertTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}