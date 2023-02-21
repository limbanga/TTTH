namespace TTTH
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelWelcome = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClass = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTeacher = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemPostNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemViewNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemViewHideNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewNotificationDetail = new TTTH.Views.ViewNotificationDetail();
            this.viewPostNotification = new TTTH.Views.ViewPostNotification();
            this.viewNotification = new TTTH.Views.ViewNotification();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelShowNow = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelWelcome.Location = new System.Drawing.Point(867, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(141, 20);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Xin chào {{user}} nè!";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemManage,
            this.ToolStripMenuItemNotification,
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItemManage
            // 
            this.ToolStripMenuItemManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCourse,
            this.ToolStripMenuItemClass,
            this.ToolStripMenuItemTeacher,
            this.ToolStripMenuItemStudent});
            this.ToolStripMenuItemManage.Name = "ToolStripMenuItemManage";
            this.ToolStripMenuItemManage.Size = new System.Drawing.Size(73, 24);
            this.ToolStripMenuItemManage.Text = "Quản lý";
            // 
            // ToolStripMenuItemCourse
            // 
            this.ToolStripMenuItemCourse.Name = "ToolStripMenuItemCourse";
            this.ToolStripMenuItemCourse.Size = new System.Drawing.Size(162, 26);
            this.ToolStripMenuItemCourse.Text = "Khóa học";
            // 
            // ToolStripMenuItemClass
            // 
            this.ToolStripMenuItemClass.Name = "ToolStripMenuItemClass";
            this.ToolStripMenuItemClass.Size = new System.Drawing.Size(162, 26);
            this.ToolStripMenuItemClass.Text = "Lớp học";
            // 
            // ToolStripMenuItemTeacher
            // 
            this.ToolStripMenuItemTeacher.Name = "ToolStripMenuItemTeacher";
            this.ToolStripMenuItemTeacher.Size = new System.Drawing.Size(162, 26);
            this.ToolStripMenuItemTeacher.Text = "Giảng viên";
            // 
            // ToolStripMenuItemStudent
            // 
            this.ToolStripMenuItemStudent.Name = "ToolStripMenuItemStudent";
            this.ToolStripMenuItemStudent.Size = new System.Drawing.Size(162, 26);
            this.ToolStripMenuItemStudent.Text = "Học viên";
            // 
            // ToolStripMenuItemNotification
            // 
            this.ToolStripMenuItemNotification.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemPostNotification,
            this.ToolStripMenuItemViewNotification,
            this.ToolStripMenuItemViewHideNotification});
            this.ToolStripMenuItemNotification.Name = "ToolStripMenuItemNotification";
            this.ToolStripMenuItemNotification.Size = new System.Drawing.Size(95, 24);
            this.ToolStripMenuItemNotification.Text = "Thông báo";
            // 
            // ToolStripMenuItemPostNotification
            // 
            this.ToolStripMenuItemPostNotification.Name = "ToolStripMenuItemPostNotification";
            this.ToolStripMenuItemPostNotification.Size = new System.Drawing.Size(205, 26);
            this.ToolStripMenuItemPostNotification.Text = "Đăng thông báo";
            this.ToolStripMenuItemPostNotification.Click += new System.EventHandler(this.ToolStripMenuItemPostNotification_Click);
            // 
            // ToolStripMenuItemViewNotification
            // 
            this.ToolStripMenuItemViewNotification.Name = "ToolStripMenuItemViewNotification";
            this.ToolStripMenuItemViewNotification.Size = new System.Drawing.Size(205, 26);
            this.ToolStripMenuItemViewNotification.Text = "Xem thông báo";
            this.ToolStripMenuItemViewNotification.Click += new System.EventHandler(this.ToolStripMenuItemViewNotification_Click);
            // 
            // ToolStripMenuItemViewHideNotification
            // 
            this.ToolStripMenuItemViewHideNotification.Name = "ToolStripMenuItemViewHideNotification";
            this.ToolStripMenuItemViewHideNotification.Size = new System.Drawing.Size(205, 26);
            this.ToolStripMenuItemViewHideNotification.Text = "Thông báo đã ẩn";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.viewNotificationDetail);
            this.panel1.Controls.Add(this.viewPostNotification);
            this.panel1.Controls.Add(this.viewNotification);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 575);
            this.panel1.TabIndex = 2;
            // 
            // viewNotificationDetail
            // 
            this.viewNotificationDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewNotificationDetail.Location = new System.Drawing.Point(0, 0);
            this.viewNotificationDetail.Name = "viewNotificationDetail";
            this.viewNotificationDetail.Size = new System.Drawing.Size(1008, 575);
            this.viewNotificationDetail.TabIndex = 4;
            // 
            // viewPostNotification
            // 
            this.viewPostNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPostNotification.Location = new System.Drawing.Point(0, 0);
            this.viewPostNotification.Name = "viewPostNotification";
            this.viewPostNotification.Size = new System.Drawing.Size(1008, 575);
            this.viewPostNotification.TabIndex = 4;
            // 
            // viewNotification
            // 
            this.viewNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewNotification.Location = new System.Drawing.Point(0, 0);
            this.viewNotification.Name = "viewNotification";
            this.viewNotification.Size = new System.Drawing.Size(1008, 575);
            this.viewNotification.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelShowNow);
            this.panel2.Controls.Add(this.labelWelcome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 24);
            this.panel2.TabIndex = 3;
            // 
            // labelShowNow
            // 
            this.labelShowNow.AutoSize = true;
            this.labelShowNow.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelShowNow.Location = new System.Drawing.Point(0, 0);
            this.labelShowNow.Name = "labelShowNow";
            this.labelShowNow.Size = new System.Drawing.Size(85, 20);
            this.labelShowNow.TabIndex = 1;
            this.labelShowNow.Text = "19/02/2003";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Quản lý trung tâm tin học";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelWelcome;
        private MenuStrip menuStrip;
        private ToolStripMenuItem ToolStripMenuItemManage;
        private ToolStripMenuItem ToolStripMenuItemNotification;
        private ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemCourse;
        private ToolStripMenuItem ToolStripMenuItemClass;
        private ToolStripMenuItem ToolStripMenuItemTeacher;
        private ToolStripMenuItem ToolStripMenuItemStudent;
        private ToolStripMenuItem ToolStripMenuItemPostNotification;
        private ToolStripMenuItem ToolStripMenuItemViewNotification;
        private ToolStripMenuItem ToolStripMenuItemViewHideNotification;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Label labelShowNow;
        private Views.ViewNotification viewNotification;
        private Views.ViewPostNotification viewPostNotification;
        private Views.ViewNotificationDetail viewNotificationDetail;
    }
}