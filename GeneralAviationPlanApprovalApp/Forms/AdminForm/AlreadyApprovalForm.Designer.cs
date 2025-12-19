namespace GeneralAviationPlanApprovalApp.Forms.AdminForm
{
    partial class AlreadyApprovalForm
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
            this.gAPADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gAPADataSet = new GeneralAviationPlanApprovalApp.GAPADataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.gAPADataSet1 = new GeneralAviationPlanApprovalApp.GAPADataSet1();
            this.approvalLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.approval_LogTableAdapter = new GeneralAviationPlanApprovalApp.GAPADataSet1TableAdapters.Approval_LogTableAdapter();
            this.logIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet1)).BeginInit();
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
            this.dataGridView1.Location = new System.Drawing.Point(232, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(695, 366);
            this.dataGridView1.TabIndex = 0;
            // 
            // gAPADataSetBindingSource
            // 
            this.gAPADataSetBindingSource.DataSource = this.gAPADataSet;
            this.gAPADataSetBindingSource.Position = 0;
            // 
            // gAPADataSet
            // 
            this.gAPADataSet.DataSetName = "GAPADataSet";
            this.gAPADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gAPADataSet1
            // 
            this.gAPADataSet1.DataSetName = "GAPADataSet1";
            this.gAPADataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // approvalLogBindingSource
            // 
            this.approvalLogBindingSource.DataMember = "Approval_Log";
            this.approvalLogBindingSource.DataSource = this.gAPADataSet1;
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
            // AlreadyApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 621);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AlreadyApprovalForm";
            this.Text = "AlreadyApprovalForm";
            this.Load += new System.EventHandler(this.AlreadyApprovalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAPADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.approvalLogBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource gAPADataSetBindingSource;
        private GAPADataSet gAPADataSet;
        private System.Windows.Forms.Button button1;
        private GAPADataSet1 gAPADataSet1;
        private System.Windows.Forms.BindingSource approvalLogBindingSource;
        private GAPADataSet1TableAdapters.Approval_LogTableAdapter approval_LogTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn logIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalTimeDataGridViewTextBoxColumn;
    }
}