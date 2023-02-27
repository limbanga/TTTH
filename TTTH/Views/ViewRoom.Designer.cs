namespace TTTH.Views
{
    partial class ViewRoom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.labelFind = new System.Windows.Forms.Label();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.checkBoxShowEndedClass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.modelRoomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelHeader = new System.Windows.Forms.Label();
            this.RoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelRoomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nhập giá trị";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(754, 124);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(128, 28);
            this.comboBox2.TabIndex = 19;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(483, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 18;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(266, 124);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(94, 29);
            this.buttonFind.TabIndex = 17;
            this.buttonFind.Text = "tìm";
            this.buttonFind.UseVisualStyleBackColor = true;
            // 
            // labelFind
            // 
            this.labelFind.AutoSize = true;
            this.labelFind.Location = new System.Drawing.Point(38, 133);
            this.labelFind.Name = "labelFind";
            this.labelFind.Size = new System.Drawing.Size(67, 20);
            this.labelFind.TabIndex = 16;
            this.labelFind.Text = "tìm kiếm";
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(122, 126);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(138, 27);
            this.textBoxFind.TabIndex = 15;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Lọc theo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Controls.Add(this.checkBoxShowEndedClass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 197);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(1116, 499);
            this.panel2.TabIndex = 14;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomName,
            this.Type,
            this.Capacity,
            this._Update,
            this.Delete});
            this.dataGridView.DataSource = this.modelRoomBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(20, 20);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1076, 459);
            this.dataGridView.TabIndex = 0;
            // 
            // modelRoomBindingSource
            // 
            this.modelRoomBindingSource.DataSource = typeof(TTTH.Models.ModelRoom);
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(1116, 82);
            this.labelHeader.TabIndex = 13;
            this.labelHeader.Text = "Danh sách phòng học";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoomName
            // 
            this.RoomName.DataPropertyName = "Name";
            this.RoomName.HeaderText = "Tên phòng";
            this.RoomName.MinimumWidth = 6;
            this.RoomName.Name = "RoomName";
            this.RoomName.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Loại phòng";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Capacity
            // 
            this.Capacity.DataPropertyName = "Capacity";
            this.Capacity.HeaderText = "Sức chứa";
            this.Capacity.MinimumWidth = 6;
            this.Capacity.Name = "Capacity";
            this.Capacity.ReadOnly = true;
            // 
            // _Update
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            this._Update.DefaultCellStyle = dataGridViewCellStyle1;
            this._Update.HeaderText = "Sửa";
            this._Update.MinimumWidth = 6;
            this._Update.Name = "_Update";
            this._Update.ReadOnly = true;
            this._Update.Text = "sửa";
            this._Update.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCoral;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.HeaderText = "Xóa";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "xóa";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // ViewRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.labelFind);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelHeader);
            this.Name = "ViewRoom";
            this.Size = new System.Drawing.Size(1116, 696);
            this.Load += new System.EventHandler(this.ViewRoom_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelRoomBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button buttonFind;
        private Label labelFind;
        private TextBox textBoxFind;
        private CheckBox checkBoxShowEndedClass;
        private Label label1;
        private Panel panel2;
        private DataGridView dataGridView;
        private Label labelHeader;
        private BindingSource modelRoomBindingSource;
        private DataGridViewTextBoxColumn RoomName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Capacity;
        private DataGridViewButtonColumn _Update;
        private DataGridViewButtonColumn Delete;
    }
}
