namespace TTTH.Views
{
    partial class ViewClass
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
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxCapacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.modelClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxShowEndedClass = new System.Windows.Forms.CheckBox();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.labelFind = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelClassBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.startDataGridViewTextBoxColumn,
            this.endDataGridViewTextBoxColumn,
            this.maxCapacityDataGridViewTextBoxColumn,
            this.shiftDataGridViewTextBoxColumn,
            this.courseNameDataGridViewTextBoxColumn,
            this.roomNameDataGridViewTextBoxColumn,
            this._Update,
            this.Delete});
            this.dataGridView.DataSource = this.modelClassBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(20, 20);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(904, 385);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // startDataGridViewTextBoxColumn
            // 
            this.startDataGridViewTextBoxColumn.DataPropertyName = "Start";
            this.startDataGridViewTextBoxColumn.HeaderText = "Start";
            this.startDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.startDataGridViewTextBoxColumn.Name = "startDataGridViewTextBoxColumn";
            this.startDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endDataGridViewTextBoxColumn
            // 
            this.endDataGridViewTextBoxColumn.DataPropertyName = "End";
            this.endDataGridViewTextBoxColumn.HeaderText = "End";
            this.endDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endDataGridViewTextBoxColumn.Name = "endDataGridViewTextBoxColumn";
            this.endDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxCapacityDataGridViewTextBoxColumn
            // 
            this.maxCapacityDataGridViewTextBoxColumn.DataPropertyName = "MaxCapacity";
            this.maxCapacityDataGridViewTextBoxColumn.HeaderText = "MaxCapacity";
            this.maxCapacityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maxCapacityDataGridViewTextBoxColumn.Name = "maxCapacityDataGridViewTextBoxColumn";
            this.maxCapacityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shiftDataGridViewTextBoxColumn
            // 
            this.shiftDataGridViewTextBoxColumn.DataPropertyName = "Shift";
            this.shiftDataGridViewTextBoxColumn.HeaderText = "Shift";
            this.shiftDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.shiftDataGridViewTextBoxColumn.Name = "shiftDataGridViewTextBoxColumn";
            this.shiftDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // courseNameDataGridViewTextBoxColumn
            // 
            this.courseNameDataGridViewTextBoxColumn.DataPropertyName = "CourseName";
            this.courseNameDataGridViewTextBoxColumn.HeaderText = "CourseName";
            this.courseNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.courseNameDataGridViewTextBoxColumn.Name = "courseNameDataGridViewTextBoxColumn";
            this.courseNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roomNameDataGridViewTextBoxColumn
            // 
            this.roomNameDataGridViewTextBoxColumn.DataPropertyName = "RoomName";
            this.roomNameDataGridViewTextBoxColumn.HeaderText = "RoomName";
            this.roomNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.roomNameDataGridViewTextBoxColumn.Name = "roomNameDataGridViewTextBoxColumn";
            this.roomNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _Update
            // 
            this._Update.HeaderText = "Sửa";
            this._Update.MinimumWidth = 6;
            this._Update.Name = "_Update";
            this._Update.ReadOnly = true;
            this._Update.Text = "sửa";
            this._Update.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Xóa";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "xóa";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // modelClassBindingSource
            // 
            this.modelClassBindingSource.DataSource = typeof(TTTH.Models.ModelClass);
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(944, 82);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Danh sách lớp học";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Controls.Add(this.checkBoxShowEndedClass);
            this.panel2.Location = new System.Drawing.Point(0, 203);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(944, 425);
            this.panel2.TabIndex = 4;
            // 
            // checkBoxShowEndedClass
            // 
            this.checkBoxShowEndedClass.AutoSize = true;
            this.checkBoxShowEndedClass.Location = new System.Drawing.Point(20, 475);
            this.checkBoxShowEndedClass.Name = "checkBoxShowEndedClass";
            this.checkBoxShowEndedClass.Size = new System.Drawing.Size(165, 24);
            this.checkBoxShowEndedClass.TabIndex = 5;
            this.checkBoxShowEndedClass.Text = "Hiện lớp đã kết thúc";
            this.checkBoxShowEndedClass.UseVisualStyleBackColor = true;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(122, 126);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(138, 27);
            this.textBoxFind.TabIndex = 6;
            // 
            // labelFind
            // 
            this.labelFind.AutoSize = true;
            this.labelFind.Location = new System.Drawing.Point(38, 133);
            this.labelFind.Name = "labelFind";
            this.labelFind.Size = new System.Drawing.Size(67, 20);
            this.labelFind.TabIndex = 7;
            this.labelFind.Text = "tìm kiếm";
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(266, 124);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(94, 29);
            this.buttonFind.TabIndex = 8;
            this.buttonFind.Text = "tìm";
            this.buttonFind.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(483, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(754, 124);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(128, 28);
            this.comboBox2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lọc theo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nhập giá trị";
            // 
            // ViewClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.labelFind);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelHeader);
            this.Name = "ViewClass";
            this.Size = new System.Drawing.Size(944, 628);
            this.Load += new System.EventHandler(this.ViewClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelClassBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private BindingSource modelClassBindingSource;
        private Label labelHeader;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maxCapacityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn courseNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roomNameDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn _Update;
        private DataGridViewButtonColumn Delete;
        private Panel panel2;
        private CheckBox checkBoxShowEndedClass;
        private TextBox textBoxFind;
        private Label labelFind;
        private Button buttonFind;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
    }
}
