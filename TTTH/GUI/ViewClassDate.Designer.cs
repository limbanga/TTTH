using TTTH.Models.DTO;

namespace TTTH.Views
{
    partial class ViewClassDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewClassDate));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAbsence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelClassName = new System.Windows.Forms.Label();
            this.labelShift = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.buttonEnterScore = new System.Windows.Forms.Button();
            this.buttonTakeAttention = new System.Windows.Forms.Button();
            this.labelTeacher = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelStudentBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.AvgScore,
            this.TotalLate,
            this.TotalAbsence});
            this.dataGridView.DataSource = this.modelStudentBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(34, 178);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1230, 472);
            this.dataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "Số điện thoại";
            this.phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            this.phoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AvgScore
            // 
            this.AvgScore.DataPropertyName = "AvgScore";
            this.AvgScore.HeaderText = "Điểm trung bình";
            this.AvgScore.MinimumWidth = 6;
            this.AvgScore.Name = "AvgScore";
            this.AvgScore.ReadOnly = true;
            // 
            // TotalLate
            // 
            this.TotalLate.DataPropertyName = "TotalLate";
            this.TotalLate.HeaderText = "Tổng trễ";
            this.TotalLate.MinimumWidth = 6;
            this.TotalLate.Name = "TotalLate";
            this.TotalLate.ReadOnly = true;
            // 
            // TotalAbsence
            // 
            this.TotalAbsence.DataPropertyName = "TotalAbsence";
            this.TotalAbsence.HeaderText = "Tổng vắng";
            this.TotalAbsence.MinimumWidth = 6;
            this.TotalAbsence.Name = "TotalAbsence";
            this.TotalAbsence.ReadOnly = true;
            // 
            // modelStudentBindingSource
            // 
            this.modelStudentBindingSource.DataSource = typeof(TTTH.Models.DTO.DTOStudent);
            // 
            // labelClassName
            // 
            this.labelClassName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.labelClassName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelClassName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelClassName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelClassName.Location = new System.Drawing.Point(0, 0);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(1290, 96);
            this.labelClassName.TabIndex = 1;
            this.labelClassName.Text = "Lớp tin học 1 - buổi 2";
            this.labelClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShift
            // 
            this.labelShift.AutoSize = true;
            this.labelShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelShift.Location = new System.Drawing.Point(208, 15);
            this.labelShift.Margin = new System.Windows.Forms.Padding(10, 15, 10, 115);
            this.labelShift.Name = "labelShift";
            this.labelShift.Size = new System.Drawing.Size(39, 20);
            this.labelShift.TabIndex = 3;
            this.labelShift.Text = "Ca 1";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDate.Location = new System.Drawing.Point(10, 15);
            this.labelDate.Margin = new System.Windows.Forms.Padding(10, 15, 10, 115);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(178, 20);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Thứ 3 ngày 21/11/2022";
            // 
            // buttonEnterScore
            // 
            this.buttonEnterScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnterScore.Location = new System.Drawing.Point(12, 12);
            this.buttonEnterScore.Margin = new System.Windows.Forms.Padding(12);
            this.buttonEnterScore.Name = "buttonEnterScore";
            this.buttonEnterScore.Size = new System.Drawing.Size(171, 29);
            this.buttonEnterScore.TabIndex = 7;
            this.buttonEnterScore.Text = "Nhập điểm";
            this.buttonEnterScore.UseVisualStyleBackColor = true;
            this.buttonEnterScore.Click += new System.EventHandler(this.ButtonEnterScore_Click);
            // 
            // buttonTakeAttention
            // 
            this.buttonTakeAttention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTakeAttention.Location = new System.Drawing.Point(207, 12);
            this.buttonTakeAttention.Margin = new System.Windows.Forms.Padding(12);
            this.buttonTakeAttention.Name = "buttonTakeAttention";
            this.buttonTakeAttention.Size = new System.Drawing.Size(171, 29);
            this.buttonTakeAttention.TabIndex = 8;
            this.buttonTakeAttention.Text = "Điểm danh";
            this.buttonTakeAttention.UseVisualStyleBackColor = true;
            this.buttonTakeAttention.Click += new System.EventHandler(this.ButtonTakeAttention_Click);
            // 
            // labelTeacher
            // 
            this.labelTeacher.AutoSize = true;
            this.labelTeacher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTeacher.Location = new System.Drawing.Point(267, 15);
            this.labelTeacher.Margin = new System.Windows.Forms.Padding(10, 15, 10, 115);
            this.labelTeacher.Name = "labelTeacher";
            this.labelTeacher.Size = new System.Drawing.Size(195, 20);
            this.labelTeacher.TabIndex = 9;
            this.labelTeacher.Text = "Giảng viên Ngô Thị Tố Mai";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelDate);
            this.flowLayoutPanel1.Controls.Add(this.labelShift);
            this.flowLayoutPanel1.Controls.Add(this.labelTeacher);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(678, 53);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(188, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 53);
            this.panel1.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonEnterScore);
            this.flowLayoutPanel2.Controls.Add(this.buttonTakeAttention);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(678, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(397, 53);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // buttonBack
            // 
            this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.Location = new System.Drawing.Point(34, 118);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(83, 35);
            this.buttonBack.TabIndex = 12;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // ViewClassDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelClassName);
            this.Controls.Add(this.dataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Name = "ViewClassDate";
            this.Size = new System.Drawing.Size(1290, 671);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelStudentBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private Label labelClassName;
        private BindingSource modelStudentBindingSource;
        private Label labelShift;
        private Label labelDate;
        private Button buttonEnterScore;
        private Button buttonTakeAttention;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn AvgScore;
        private DataGridViewTextBoxColumn TotalLate;
        private DataGridViewTextBoxColumn TotalAbsence;
        private Label labelTeacher;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button buttonBack;
    }
}
