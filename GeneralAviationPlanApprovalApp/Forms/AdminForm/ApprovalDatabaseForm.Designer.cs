namespace GeneralAviationPlanApprovalApp.Forms.AdminForm
{
    partial class ApprovalDatabaseForm
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
            this.gAPADataSet2 = new GeneralAviationPlanApprovalApp.GAPADataSet2();
            this.approvalLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.approval_LogTableAdapter = new GeneralAviationPlanApprovalApp.GAPADataSet2TableAdapters.Approval_LogTableAdapter();
            this.logIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.approvalLogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logIDDataGridViewTextBoxColumn,
            this.planIDDataGridViewTextBoxColumn,
            this.reviewerIDDataGridViewTextBoxColumn,
            this.resultDataGridViewTextBoxColumn,
            this.commentsDataGridViewTextBoxColumn,
            this.approvalTimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.approvalLogBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(93, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(831, 448);
            this.dataGridView1.TabIndex = 0;
            // 
            // gAPADataSet2
            // 
            this.gAPADataSet2.DataSetName = "GAPADataSet2";
            this.gAPADataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // approvalLogBindingSource
            // 
            this.approvalLogBindingSource.DataMember = "Approval_Log";
            this.approvalLogBindingSource.DataSource = this.gAPADataSet2;
            // 
            // approval_LogTableAdapter
            // 
            this.approval_LogTableAdapter.ClearBeforeFill = true;
            // 
            // logIDDataGridViewTextBoxColumn
            // 
            this.logIDDataGridViewTextBoxColumn.DataPropertyName = "LogID";
            this.logIDDataGridViewTextBoxColumn.HeaderText = "LogID";
            this.logIDDataGridViewTextBoxColumn.Name = "logIDDataGridViewTextBoxColumn";
            this.logIDDataGridViewTextBoxColumn.ReadOnly = true;
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
            // resultDataGridViewTextBoxColumn
            // 
            this.resultDataGridViewTextBoxColumn.DataPropertyName = "Result";
            this.resultDataGridViewTextBoxColumn.HeaderText = "Result";
            this.resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            // 
            // commentsDataGridViewTextBoxColumn
            // 
            this.commentsDataGridViewTextBoxColumn.DataPropertyName = "Comments";
            this.commentsDataGridViewTextBoxColumn.HeaderText = "Comments";
            this.commentsDataGridViewTextBoxColumn.Name = "commentsDataGridViewTextBoxColumn";
            // 
            // approvalTimeDataGridViewTextBoxColumn
            // 
            this.approvalTimeDataGridViewTextBoxColumn.DataPropertyName = "ApprovalTime";
            this.approvalTimeDataGridViewTextBoxColumn.HeaderText = "ApprovalTime";
            this.approvalTimeDataGridViewTextBoxColumn.Name = "approvalTimeDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ApprovalDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ApprovalDatabaseForm";
            this.Text = "ApprovalDatabaseForm";
            this.Load += new System.EventHandler(this.ApprovalDatabaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.approvalLogBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private GAPADataSet2 gAPADataSet2;
        private System.Windows.Forms.BindingSource approvalLogBindingSource;
        private GAPADataSet2TableAdapters.Approval_LogTableAdapter approval_LogTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn logIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}