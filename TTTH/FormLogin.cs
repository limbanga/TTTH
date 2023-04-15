using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models;
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
            
            //SqlCommand cmd = new SqlCommand("select top 1 * from TTTH_user \r\nwhere _user_name = @username and _pass_word = @password;", DataBase.GetConnection());

            //cmd.Parameters.AddWithValue("@username", "dd");
            //cmd.Parameters.AddWithValue("@password", "a");

            //DataTable datatable = DataBase.ExcuteQuery(cmd);

            //MessageBox.Show("Test" + datatable.Rows[0][0].ToString());
            
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // validate
            //if (!ValidateInput()) { return; }

            // get input user name and password
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;

            // query to database
            CheckLogin(userName, password);
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

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPass.Checked;
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
                MessageBox.Show("Chưa làm owner");
            }
            else if (BUS.user.PermissionID == 2)
            {
                FormAdmin formAdmin = new FormAdmin();
                formAdmin.ShowDialog();
            }
            else
            {
                FormTeacher formTeacher = new FormTeacher();
                formTeacher.ShowDialog();
            }
            this.Show();   
        }
    }
}
