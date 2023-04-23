using System.Net.Mail;
using System.Net;
using TTTH.Models.DAO;

namespace TTTH.Views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------
        // FORM EVENTS
        //---------------------------------------------------------------------------
        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // validate
            if (!ValidateInput()) { return; }

            // get input user name and password
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;

            // query to database
            CheckLogin(userName, password);
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPass.Checked;
        }

        private void labelForgetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy liên hệ với quản trị viên để được hỗ trợ lấy lại mật khẩu.");
            //SendEmail("Chào lim", "hello", "gmail.com");
        }

        //----------------------------------------------------------------------------
        // HELPER FUNCTIONS
        //----------------------------------------------------------------------------

        private void CheckLogin(string userName, string password)
        {
            try
            {
                BUS.user = ModelUser.CheckLogin(userName, password);
                // phân quyền
                Authorize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vui lòng kiểm tra lại", MessageBoxButtons.OK);
            }
           
        }

        private void Authorize()
        {
            if (BUS.user is null) { return; }

            this.Hide();

            if (BUS.user.PermissionID == 1)
            {
                FormAdmin formAdmin = new FormAdmin();
                formAdmin.ShowDialog();
            }
            else if (BUS.user.PermissionID == 2)
            {
                FormTeacher formTeacher = new FormTeacher();
                formTeacher.ShowDialog();
            }
            this.Show();   
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(textBoxUserName.Text))
            {
                MessageBox.Show(
                    "Tên đăng nhập không thể để trống.",
                    "Vui lòng kiểm tra lại",
                    MessageBoxButtons.OK);
                return false;
            }

            if (textBoxPassword.Text.Length < 8)
            {
                MessageBox.Show(
                    "Độ dài mật khẩu ít nhất là 8 ký tự.",
                    "Vui lòng kiểm tra lại",
                    MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        public void SendEmail(string subject, string body, string recipient)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("@gmail.com");
                mail.To.Add(recipient);
                mail.Subject = subject;
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("@gmail.com", "!dewtf534#FF");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
