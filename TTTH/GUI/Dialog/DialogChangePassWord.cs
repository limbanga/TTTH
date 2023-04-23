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

namespace TTTH.GUI.Dialog
{
    public partial class DialogChangePassWord : Form
    {
        public DialogChangePassWord()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------
        // EVENTS
        //-----------------------------------------------------
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (CheckValid() == false) { return; }

            if (BUS.user is null)
            {
                MessageBox.Show(
                    "Bạn chưa đăng nhập.", 
                    "Vui lòng đăng nhập",
                    MessageBoxButtons.OK);
                this.Close();
                return;
            }

            string userName = BUS.user.LoginName;
            string oldPass = textBoxPassword.Text;
            string newPass = textBoxNewPassWord.Text;
            string rePass = textBoxRePassWord.Text;

            HandleChangePassWord(userName, oldPass, newPass, rePass);

        }

        //-----------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------

        private bool CheckValid()
        {
            int passwordLength = 8;
            string cap = "Vui lòng kiểm tra lại.";
            if (textBoxPassword.Text.Length < passwordLength)
            {
                MessageBox.Show(
                    $"Mật khẩu cũ phải có độ dài ít nhất là {passwordLength}.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }

            if (textBoxNewPassWord.Text.Length < passwordLength)
            {
                MessageBox.Show(
                    $"Mật khẩu mới phải có độ dài ít nhất là {passwordLength}.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }

            if (textBoxRePassWord.Text.Equals(textBoxNewPassWord.Text) == false)
            {
                MessageBox.Show(
                    "Xác nhận mật khẩu không khớp với mật khẩu mới.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void HandleChangePassWord(string userName, string oldPass, string newPass, string rePass)
        {
            try
            {
                ModelUser.ChangePassWord(userName, oldPass, newPass);
                MessageBox.Show(
                    "Cập nhật mật khẩu mới thành công.",
                    "Cập nhật thành công.",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể cập nhật.",
                    MessageBoxButtons.OK);
            }
        }
    }
}
