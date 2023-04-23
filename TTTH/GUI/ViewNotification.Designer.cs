using TTTH.Models.DTO;

namespace TTTH.Views
{
    partial class ViewNotification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.modelNotificationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.topicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createddateDisplayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getUserPostedNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelNotificationBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.topicDataGridViewTextBoxColumn,
            this.createddateDisplayDataGridViewTextBoxColumn,
            this.getUserPostedNameDataGridViewTextBoxColumn,
            this.ViewDetail});
            this.dataGridView.DataSource = this.modelNotificationBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(19, 172);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1122, 477);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // modelNotificationBindingSource
            // 
            this.modelNotificationBindingSource.DataSource = typeof(TTTH.Models.DTO.DTONotification);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.labelHeader);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 666);
            this.panel1.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.Lime;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAdd.Location = new System.Drawing.Point(923, 111);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(218, 40);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Đăng thông báo";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.SystemColors.HotTrack;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(1165, 91);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Danh sách thông báo";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topicDataGridViewTextBoxColumn
            // 
            this.topicDataGridViewTextBoxColumn.DataPropertyName = "Topic";
            this.topicDataGridViewTextBoxColumn.HeaderText = "Chủ đề";
            this.topicDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.topicDataGridViewTextBoxColumn.Name = "topicDataGridViewTextBoxColumn";
            this.topicDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createddateDisplayDataGridViewTextBoxColumn
            // 
            this.createddateDisplayDataGridViewTextBoxColumn.DataPropertyName = "Created_dateDisplay";
            this.createddateDisplayDataGridViewTextBoxColumn.HeaderText = "Ngày đăng";
            this.createddateDisplayDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.createddateDisplayDataGridViewTextBoxColumn.Name = "createddateDisplayDataGridViewTextBoxColumn";
            this.createddateDisplayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // getUserPostedNameDataGridViewTextBoxColumn
            // 
            this.getUserPostedNameDataGridViewTextBoxColumn.DataPropertyName = "GetUserPostedName";
            this.getUserPostedNameDataGridViewTextBoxColumn.HeaderText = "Người đăng";
            this.getUserPostedNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.getUserPostedNameDataGridViewTextBoxColumn.Name = "getUserPostedNameDataGridViewTextBoxColumn";
            this.getUserPostedNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ViewDetail
            // 
            this.ViewDetail.HeaderText = "Xem chi tiết";
            this.ViewDetail.MinimumWidth = 6;
            this.ViewDetail.Name = "ViewDetail";
            this.ViewDetail.ReadOnly = true;
            this.ViewDetail.Text = "Xem";
            this.ViewDetail.UseColumnTextForButtonValue = true;
            // 
            // ViewNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ViewNotification";
            this.Size = new System.Drawing.Size(1165, 666);
            this.Load += new System.EventHandler(this.ViewNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelNotificationBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private BindingSource modelNotificationBindingSource;
        private Panel panel1;
        public Button buttonAdd;
        private Label labelHeader;
        private DataGridViewTextBoxColumn topicDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createddateDisplayDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn getUserPostedNameDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn ViewDetail;
    }
}
