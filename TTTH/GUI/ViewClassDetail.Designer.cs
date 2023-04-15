namespace TTTH.GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewClassDetail));
            this.checkBoxShowEndedClass = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonBackToClassView = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dTOClassDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelHeader = new System.Windows.Forms.Label();
            this.dateNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOClassDateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxShowEndedClass
            // 
            this.checkBoxShowEndedClass.AutoSize = true;
            this.checkBoxShowEndedClass.Location = new System.Drawing.Point(40, 495);
            this.checkBoxShowEndedClass.Name = "checkBoxShowEndedClass";
            this.checkBoxShowEndedClass.Size = new System.Drawing.Size(165, 24);
            this.checkBoxShowEndedClass.TabIndex = 5;
            this.checkBoxShowEndedClass.Text = "Hiện lớp đã kết thúc";
            this.checkBoxShowEndedClass.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonBackToClassView);
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Controls.Add(this.checkBoxShowEndedClass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(1193, 596);
            this.panel2.TabIndex = 14;
            // 
            // buttonBackToClassView
            // 
            this.buttonBackToClassView.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonBackToClassView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBackToClassView.ForeColor = System.Drawing.Color.Transparent;
            this.buttonBackToClassView.Location = new System.Drawing.Point(20, 23);
            this.buttonBackToClassView.Name = "buttonBackToClassView";
            this.buttonBackToClassView.Size = new System.Drawing.Size(102, 42);
            this.buttonBackToClassView.TabIndex = 6;
            this.buttonBackToClassView.Text = "Quay về";
            this.buttonBackToClassView.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBackToClassView.UseVisualStyleBackColor = false;
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
            this.dateNumberDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.shiftDataGridViewTextBoxColumn,
            this.roomNameDataGridViewTextBoxColumn,
            this.teacherNameDataGridViewTextBoxColumn,
            this.UpdateButton});
            this.dataGridView.DataSource = this.dTOClassDateBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(20, 83);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1153, 493);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // dTOClassDateBindingSource
            // 
            this.dTOClassDateBindingSource.DataSource = typeof(TTTH.Models.DTOClassDate);
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(1193, 82);
            this.labelHeader.TabIndex = 13;
            this.labelHeader.Text = "Lịch trình học lớp { className }";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateNumberDataGridViewTextBoxColumn
            // 
            this.dateNumberDataGridViewTextBoxColumn.DataPropertyName = "DateNumber";
            this.dateNumberDataGridViewTextBoxColumn.HeaderText = "DateNumber";
            this.dateNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateNumberDataGridViewTextBoxColumn.Name = "dateNumberDataGridViewTextBoxColumn";
            this.dateNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shiftDataGridViewTextBoxColumn
            // 
            this.shiftDataGridViewTextBoxColumn.DataPropertyName = "Shift";
            this.shiftDataGridViewTextBoxColumn.HeaderText = "Shift";
            this.shiftDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.shiftDataGridViewTextBoxColumn.Name = "shiftDataGridViewTextBoxColumn";
            this.shiftDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roomNameDataGridViewTextBoxColumn
            // 
            this.roomNameDataGridViewTextBoxColumn.DataPropertyName = "RoomName";
            this.roomNameDataGridViewTextBoxColumn.HeaderText = "RoomName";
            this.roomNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.roomNameDataGridViewTextBoxColumn.Name = "roomNameDataGridViewTextBoxColumn";
            this.roomNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // teacherNameDataGridViewTextBoxColumn
            // 
            this.teacherNameDataGridViewTextBoxColumn.DataPropertyName = "TeacherName";
            this.teacherNameDataGridViewTextBoxColumn.HeaderText = "TeacherName";
            this.teacherNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.teacherNameDataGridViewTextBoxColumn.Name = "teacherNameDataGridViewTextBoxColumn";
            this.teacherNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // UpdateButton
            // 
            this.UpdateButton.HeaderText = "Sửa";
            this.UpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateButton.Image")));
            this.UpdateButton.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.UpdateButton.MinimumWidth = 6;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.ReadOnly = true;
            // 
            // ViewClassDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelHeader);
            this.Name = "ViewClassDetail";
            this.Size = new System.Drawing.Size(1193, 678);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTOClassDateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox checkBoxShowEndedClass;
        private Panel panel2;
        private DataGridView dataGridView;
        private Label labelHeader;
        private Button buttonBackToClassView;
        private BindingSource dTOClassDateBindingSource;
        private DataGridViewTextBoxColumn dateNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roomNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn teacherNameDataGridViewTextBoxColumn;
        private DataGridViewImageColumn UpdateButton;
    }
}
