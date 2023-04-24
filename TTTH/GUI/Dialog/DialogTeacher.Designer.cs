namespace TTTH.GUI.Dialog
{
    partial class DialogTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogTeacher));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxShowPass = new System.Windows.Forms.PictureBox();
            this.textBoxPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelLoginName = new System.Windows.Forms.Label();
            this.textBoxShowName = new System.Windows.Forms.TextBox();
            this.textBoxLoginName = new System.Windows.Forms.TextBox();
            this.labelShowName = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPass)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxShowPass);
            this.panel1.Controls.Add(this.textBoxPassWord);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxAdress);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxPhoneNumber);
            this.panel1.Controls.Add(this.labelPhoneNumber);
            this.panel1.Controls.Add(this.ButtonSave);
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.labelLoginName);
            this.panel1.Controls.Add(this.textBoxShowName);
            this.panel1.Controls.Add(this.textBoxLoginName);
            this.panel1.Controls.Add(this.labelShowName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(22, 20, 22, 20);
            this.panel1.Size = new System.Drawing.Size(639, 638);
            this.panel1.TabIndex = 10;
            // 
            // pictureBoxShowPass
            // 
            this.pictureBoxShowPass.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxShowPass.Image")));
            this.pictureBoxShowPass.Location = new System.Drawing.Point(582, 156);
            this.pictureBoxShowPass.Name = "pictureBoxShowPass";
            this.pictureBoxShowPass.Size = new System.Drawing.Size(25, 24);
            this.pictureBoxShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxShowPass.TabIndex = 13;
            this.pictureBoxShowPass.TabStop = false;
            this.pictureBoxShowPass.Click += new System.EventHandler(this.pictureBoxShowPass_Click);
            // 
            // textBoxPassWord
            // 
            this.textBoxPassWord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassWord.Location = new System.Drawing.Point(165, 153);
            this.textBoxPassWord.Name = "textBoxPassWord";
            this.textBoxPassWord.Size = new System.Drawing.Size(442, 27);
            this.textBoxPassWord.TabIndex = 2;
            this.textBoxPassWord.Text = "letmein123";
            this.textBoxPassWord.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mật khẩu";
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxAdress.Location = new System.Drawing.Point(165, 329);
            this.textBoxAdress.Multiline = true;
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(442, 205);
            this.textBoxAdress.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(36, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Địa chỉ";
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(165, 273);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(442, 27);
            this.textBoxPhoneNumber.TabIndex = 4;
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPhoneNumber.Location = new System.Drawing.Point(36, 276);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.labelPhoneNumber.TabIndex = 8;
            this.labelPhoneNumber.Text = "Số điện thoại";
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.Lime;
            this.ButtonSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonSave.Location = new System.Drawing.Point(18, 573);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(589, 45);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "Lưu";
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxEmail.Location = new System.Drawing.Point(165, 214);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(442, 27);
            this.textBoxEmail.TabIndex = 3;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(36, 217);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(47, 20);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Email";
            // 
            // labelLoginName
            // 
            this.labelLoginName.AutoSize = true;
            this.labelLoginName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLoginName.Location = new System.Drawing.Point(36, 93);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(112, 20);
            this.labelLoginName.TabIndex = 2;
            this.labelLoginName.Text = "Tên đăng nhập";
            // 
            // textBoxShowName
            // 
            this.textBoxShowName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxShowName.Location = new System.Drawing.Point(165, 26);
            this.textBoxShowName.Name = "textBoxShowName";
            this.textBoxShowName.Size = new System.Drawing.Size(442, 27);
            this.textBoxShowName.TabIndex = 0;
            // 
            // textBoxLoginName
            // 
            this.textBoxLoginName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxLoginName.Location = new System.Drawing.Point(165, 90);
            this.textBoxLoginName.Name = "textBoxLoginName";
            this.textBoxLoginName.Size = new System.Drawing.Size(442, 27);
            this.textBoxLoginName.TabIndex = 1;
            // 
            // labelShowName
            // 
            this.labelShowName.AutoSize = true;
            this.labelShowName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelShowName.Location = new System.Drawing.Point(36, 31);
            this.labelShowName.Name = "labelShowName";
            this.labelShowName.Size = new System.Drawing.Size(91, 20);
            this.labelShowName.TabIndex = 4;
            this.labelShowName.Text = "Tên hiển thị";
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.SystemColors.HotTrack;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(639, 99);
            this.labelHeader.TabIndex = 11;
            this.labelHeader.Text = "Thêm mới giảng viên";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "show-password.png");
            this.imageList1.Images.SetKeyName(1, "hidden.png");
            // 
            // DialogTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 737);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm giảng viên";
            this.Load += new System.EventHandler(this.DialogTeacher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button ButtonSave;
        private TextBox textBoxEmail;
        private Label labelEmail;
        private Label labelLoginName;
        private TextBox textBoxShowName;
        private TextBox textBoxLoginName;
        private Label labelShowName;
        private Label labelHeader;
        private TextBox textBoxAdress;
        private Label label5;
        private TextBox textBoxPhoneNumber;
        private Label labelPhoneNumber;
        private PictureBox pictureBoxShowPass;
        private TextBox textBoxPassWord;
        private Label label1;
        private ImageList imageList1;
    }
}