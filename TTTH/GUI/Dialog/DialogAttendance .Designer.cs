using TTTH.Models.DTO;

namespace TTTH.Views.Dialog
{
    partial class DialogAttendend
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPresent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isLate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isAbsence = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.relationShipAttendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelShift = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipAttendanceBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.studentNameDataGridViewTextBoxColumn,
            this.studentPhoneNumberDataGridViewTextBoxColumn,
            this.isPresent,
            this.isLate,
            this.isAbsence});
            this.dataGridView.DataSource = this.relationShipAttendanceBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(33, 143);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1082, 435);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // studentNameDataGridViewTextBoxColumn
            // 
            this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.HeaderText = "Tên học viên";
            this.studentNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
            this.studentNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentPhoneNumberDataGridViewTextBoxColumn
            // 
            this.studentPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "StudentPhoneNumber";
            this.studentPhoneNumberDataGridViewTextBoxColumn.HeaderText = "Số điện thoại";
            this.studentPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentPhoneNumberDataGridViewTextBoxColumn.Name = "studentPhoneNumberDataGridViewTextBoxColumn";
            this.studentPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isPresent
            // 
            this.isPresent.DataPropertyName = "isPresent";
            this.isPresent.HeaderText = "Có mặt";
            this.isPresent.MinimumWidth = 6;
            this.isPresent.Name = "isPresent";
            // 
            // isLate
            // 
            this.isLate.DataPropertyName = "isLate";
            this.isLate.HeaderText = "Trễ";
            this.isLate.MinimumWidth = 6;
            this.isLate.Name = "isLate";
            // 
            // isAbsence
            // 
            this.isAbsence.DataPropertyName = "isAbsence";
            this.isAbsence.HeaderText = "Vắng";
            this.isAbsence.MinimumWidth = 6;
            this.isAbsence.Name = "isAbsence";
            // 
            // relationShipAttendanceBindingSource
            // 
            this.relationShipAttendanceBindingSource.DataSource = typeof(TTTH.Models.DTO.DTOAttendance);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1009, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(1132, 79);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "Điểm danh lớp học {{ lớp học }}";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(59, 0);
            this.labelDate.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(136, 20);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Ngày 12/11/2022";
            // 
            // labelShift
            // 
            this.labelShift.AutoSize = true;
            this.labelShift.Location = new System.Drawing.Point(0, 0);
            this.labelShift.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.labelShift.Name = "labelShift";
            this.labelShift.Size = new System.Drawing.Size(39, 20);
            this.labelShift.TabIndex = 7;
            this.labelShift.Text = "Ca 3";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.labelShift);
            this.flowLayoutPanel1.Controls.Add(this.labelDate);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(33, 97);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1082, 27);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // DialogAttendend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 641);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "DialogAttendend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Điểm danh";
            this.Load += new System.EventHandler(this.DialogCheckAttendend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipAttendanceBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private Button button1;
        private Label labelHeader;
        private Label labelDate;
        private BindingSource relationShipAttendanceBindingSource;
        private Label labelShift;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn studentPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isPresent;
        private DataGridViewCheckBoxColumn isLate;
        private DataGridViewCheckBoxColumn isAbsence;
    }
}