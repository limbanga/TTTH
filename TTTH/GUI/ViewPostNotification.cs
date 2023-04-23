using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models.DAO;

namespace TTTH.Views
{
    public partial class ViewPostNotification : UserControl
    {
        public EventHandler? SwitchToViewNotification;
        public ViewPostNotification()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------
        // EVENTS
        //-----------------------------------------------------------------------------
        private void ButtonPost_Click(object sender, EventArgs e)
        {
            if (BUS.user is null)
            {
                MessageBox.Show(
                    "Hệ thống không thể xác thực bạn. Vui lòng đăng nhập lại.",
                    "Lỗi",
                    MessageBoxButtons.OK);
                Application.Exit();
                return;
            }

            // validate
            if (CheckInputValid() == false) { return; }
            // get input
            string topic = textBoxTopic.Text;
            string content = richTextBoxContent.Text;
            // insert
            AddNewNotification(topic, content);
        }

        //-----------------------------------------------------------------------------
        //  HELPER FUNCTIONS
        //-----------------------------------------------------------------------------
        private void AddNewNotification(string topic, string content)
        {
            try
            {
                ModelNotification.Insert(topic, content, BUS.user.Id);
                MessageBox.Show(
                    "Đăng thông báo thành công.",
                    "Thành công",
                    MessageBoxButtons.OK);
                SwitchToViewNotification?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi. Không thể đăng thông báo.",
                    "Đã xảy ra lỗi",
                    MessageBoxButtons.OK);
            }
        }

        private bool CheckInputValid()
        {
            if (string.IsNullOrEmpty(textBoxTopic.Text))
            {
                MessageBox.Show(
                    "Không thể để trống phần tiêu đề.",
                    "Vui lòng nhập tiêu đề.",
                    MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(richTextBoxContent.Text))
            {
                MessageBox.Show(
                    "Không thể để trống phần nội dung.",
                    "Vui lòng nhập nội dung thông báo.",
                    MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}
