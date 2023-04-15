namespace TTTH.Views.Dialog
{
    partial class DialogCheckAttendend
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
            this.relationShipAttendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDateNumber = new System.Windows.Forms.ComboBox();
            this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPresent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isLate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isAbsence = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipAttendanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentNameDataGridViewTextBoxColumn,
            this.studentPhoneNumberDataGridViewTextBoxColumn,
            this.isPresent,
            this.isLate,
            this.isAbsence,
            this.updateTimeDataGridViewTextBoxColumn,
            this.Status});
            this.dataGridView.DataSource = this.relationShipAttendanceBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(29, 133);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(962, 445);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // relationShipAttendanceBindingSource
            // 
            this.relationShipAttendanceBindingSource.DataSource = typeof(TTTH.Models.RelationShipAttendance);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(897, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Điểm danh lớp học {{ lớp học }}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buổi";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(404, 54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(182, 27);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày";
            // 
            // comboBoxDateNumber
            // 
            this.comboBoxDateNumber.FormattingEnabled = true;
            this.comboBoxDateNumber.Location = new System.Drawing.Point(92, 53);
            this.comboBoxDateNumber.Name = "comboBoxDateNumber";
            this.comboBoxDateNumber.Size = new System.Drawing.Size(175, 28);
            this.comboBoxDateNumber.TabIndex = 3;
            this.comboBoxDateNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxDateNumber_SelectedIndexChanged);
            // 
            // studentNameDataGridViewTextBoxColumn
            // 
            this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.HeaderText = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
            this.studentNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.studentNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // studentPhoneNumberDataGridViewTextBoxColumn
            // 
            this.studentPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "StudentPhoneNumber";
            this.studentPhoneNumberDataGridViewTextBoxColumn.HeaderText = "StudentPhoneNumber";
            this.studentPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentPhoneNumberDataGridViewTextBoxColumn.Name = "studentPhoneNumberDataGridViewTextBoxColumn";
            this.studentPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.studentPhoneNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // isPresent
            // 
            this.isPresent.DataPropertyName = "isPresent";
            this.isPresent.HeaderText = "isPresent";
            this.isPresent.MinimumWidth = 6;
            this.isPresent.Name = "isPresent";
            this.isPresent.Width = 125;
            // 
            // isLate
            // 
            this.isLate.DataPropertyName = "isLate";
            this.isLate.HeaderText = "isLate";
            this.isLate.MinimumWidth = 6;
            this.isLate.Name = "isLate";
            this.isLate.Width = 125;
            // 
            // isAbsence
            // 
            this.isAbsence.DataPropertyName = "isAbsence";
            this.isAbsence.HeaderText = "isAbsence";
            this.isAbsence.MinimumWidth = 6;
            this.isAbsence.Name = "isAbsence";
            this.isAbsence.Width = 125;
            // 
            // updateTimeDataGridViewTextBoxColumn
            // 
            this.updateTimeDataGridViewTextBoxColumn.DataPropertyName = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.HeaderText = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.updateTimeDataGridViewTextBoxColumn.Name = "updateTimeDataGridViewTextBoxColumn";
            this.updateTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 125;
            // 
            // DialogCheckAttendend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 641);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDateNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Name = "DialogCheckAttendend";
            this.Text = "DialogCheckAttendend";
            this.Load += new System.EventHandler(this.DialogCheckAttendend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipAttendanceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private Button button1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private BindingSource relationShipAttendanceBindingSource;
        private ComboBox comboBoxDateNumber;
        private DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn studentPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isPresent;
        private DataGridViewCheckBoxColumn isLate;
        private DataGridViewCheckBoxColumn isAbsence;
        private DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Status;
    }
}