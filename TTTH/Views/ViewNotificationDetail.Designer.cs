namespace TTTH.Views
{
    partial class ViewNotificationDetail
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
            this.labelTopic = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxShowContent = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTopic
            // 
            this.labelTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTopic.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTopic.Location = new System.Drawing.Point(0, 0);
            this.labelTopic.Name = "labelTopic";
            this.labelTopic.Size = new System.Drawing.Size(1016, 125);
            this.labelTopic.TabIndex = 0;
            this.labelTopic.Text = "Chủ đề.";
            this.labelTopic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.textBoxShowContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 558);
            this.panel1.TabIndex = 1;
            // 
            // textBoxShowContent
            // 
            this.textBoxShowContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxShowContent.Location = new System.Drawing.Point(22, 149);
            this.textBoxShowContent.Multiline = true;
            this.textBoxShowContent.Name = "textBoxShowContent";
            this.textBoxShowContent.ReadOnly = true;
            this.textBoxShowContent.Size = new System.Drawing.Size(970, 390);
            this.textBoxShowContent.TabIndex = 0;
            this.textBoxShowContent.Text = "Nội dung:\r\ncon gà di\r\nlim pro";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTopic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 125);
            this.panel2.TabIndex = 2;
            // 
            // ViewNotificationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ViewNotificationDetail";
            this.Size = new System.Drawing.Size(1016, 558);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Label labelTopic;
        private Panel panel1;
        private Panel panel2;
        public TextBox textBoxShowContent;
    }
}
