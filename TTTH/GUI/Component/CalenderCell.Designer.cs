namespace TTTH
{
    partial class CalenderCell
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
            this.labelDateNumber = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelRoom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDateNumber
            // 
            this.labelDateNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDateNumber.Location = new System.Drawing.Point(0, 0);
            this.labelDateNumber.Name = "labelDateNumber";
            this.labelDateNumber.Size = new System.Drawing.Size(285, 46);
            this.labelDateNumber.TabIndex = 0;
            this.labelDateNumber.Text = "Buổi học: 1";
            this.labelDateNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDateNumber.Click += new System.EventHandler(this.labelClass_Click);
            // 
            // labelClass
            // 
            this.labelClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClass.Location = new System.Drawing.Point(0, 46);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(285, 58);
            this.labelClass.TabIndex = 1;
            this.labelClass.Text = "Lớp: abc";
            this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelClass.Click += new System.EventHandler(this.labelClass_Click);
            // 
            // labelRoom
            // 
            this.labelRoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelRoom.Location = new System.Drawing.Point(0, 104);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(285, 52);
            this.labelRoom.TabIndex = 2;
            this.labelRoom.Text = "Phòng: 110";
            this.labelRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRoom.Click += new System.EventHandler(this.labelClass_Click);
            // 
            // CalenderCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.labelDateNumber);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "CalenderCell";
            this.Size = new System.Drawing.Size(285, 156);
            this.ResumeLayout(false);

        }

        #endregion

        public Label labelDateNumber;
        public Label labelClass;
        public Label labelRoom;
    }
}
