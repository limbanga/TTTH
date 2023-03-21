namespace TTTH.Views
{
    partial class ViewClassDetail
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
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelClassName = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelShift = new System.Windows.Forms.Label();
            this.labelDatesInWeeks = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTeacher = new System.Windows.Forms.Label();
            this.buttonEnterScore = new System.Windows.Forms.Button();
            this.buttonTakeAttention = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelStudentBindingSource)).BeginInit();
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
            this.phoneNumberDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.modelStudentBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(30, 105);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1064, 458);
            this.dataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            // 
            // modelStudentBindingSource
            // 
            this.modelStudentBindingSource.DataSource = typeof(TTTH.Models.ModelStudent);
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Location = new System.Drawing.Point(30, 9);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(160, 20);
            this.labelClassName.TabIndex = 1;
            this.labelClassName.Text = "Danh sách lớp: {{ lớp }}";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(942, 60);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(152, 29);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Thêm học viên";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelShift
            // 
            this.labelShift.AutoSize = true;
            this.labelShift.Location = new System.Drawing.Point(30, 60);
            this.labelShift.Name = "labelShift";
            this.labelShift.Size = new System.Drawing.Size(76, 20);
            this.labelShift.TabIndex = 3;
            this.labelShift.Text = "Ca: {{ ca }}";
            // 
            // labelDatesInWeeks
            // 
            this.labelDatesInWeeks.AutoSize = true;
            this.labelDatesInWeeks.Location = new System.Drawing.Point(231, 60);
            this.labelDatesInWeeks.Name = "labelDatesInWeeks";
            this.labelDatesInWeeks.Size = new System.Drawing.Size(121, 20);
            this.labelDatesInWeeks.TabIndex = 4;
            this.labelDatesInWeeks.Text = "Thứ: {{ 2 - 3 - 4 }}";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(768, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Điều chỉnh lương";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelTeacher
            // 
            this.labelTeacher.AutoSize = true;
            this.labelTeacher.Location = new System.Drawing.Point(231, 9);
            this.labelTeacher.Name = "labelTeacher";
            this.labelTeacher.Size = new System.Drawing.Size(183, 20);
            this.labelTeacher.TabIndex = 6;
            this.labelTeacher.Text = "Giảng viên: {{ giảng viên }}";
            // 
            // buttonEnterScore
            // 
            this.buttonEnterScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnterScore.Location = new System.Drawing.Point(942, 9);
            this.buttonEnterScore.Name = "buttonEnterScore";
            this.buttonEnterScore.Size = new System.Drawing.Size(152, 29);
            this.buttonEnterScore.TabIndex = 7;
            this.buttonEnterScore.Text = "Nhập điểm";
            this.buttonEnterScore.UseVisualStyleBackColor = true;
            this.buttonEnterScore.Click += new System.EventHandler(this.buttonEnterScore_Click);
            // 
            // buttonTakeAttention
            // 
            this.buttonTakeAttention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTakeAttention.Location = new System.Drawing.Point(768, 9);
            this.buttonTakeAttention.Name = "buttonTakeAttention";
            this.buttonTakeAttention.Size = new System.Drawing.Size(152, 29);
            this.buttonTakeAttention.TabIndex = 8;
            this.buttonTakeAttention.Text = "Điểm danh";
            this.buttonTakeAttention.UseVisualStyleBackColor = true;
            this.buttonTakeAttention.Click += new System.EventHandler(this.buttonTakeAttention_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thù lao: {{ tiền công }}";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(462, 60);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(210, 20);
            this.labelStart.TabIndex = 10;
            this.labelStart.Text = "Ngày bắt đầu: {{ 30-02-2022 }}";
            // 
            // ViewClassDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonTakeAttention);
            this.Controls.Add(this.buttonEnterScore);
            this.Controls.Add(this.labelTeacher);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelDatesInWeeks);
            this.Controls.Add(this.labelShift);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelClassName);
            this.Controls.Add(this.dataGridView);
            this.Name = "ViewClassDetail";
            this.Size = new System.Drawing.Size(1117, 584);
            this.Load += new System.EventHandler(this.ViewClassDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelStudentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private Label labelClassName;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private BindingSource modelStudentBindingSource;
        private Button buttonAdd;
        private Label labelShift;
        private Label labelDatesInWeeks;
        private Button button1;
        private Label labelTeacher;
        private Button buttonEnterScore;
        private Button buttonTakeAttention;
        private Label label5;
        private Label labelStart;
    }
}
