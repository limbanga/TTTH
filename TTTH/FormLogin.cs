using Microsoft.VisualBasic.ApplicationServices;
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
            // get input user name and password
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;

            // validate



            CheckLogin(userName, password);

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
            // return null if user don't exists
            Env.user = DAOUser.CheckLogin(userName, password);
            
            // can't find user case
            if (Env.user is null)
            {
                MessageBox.Show(Env.wrongPassMessage, "Không thể đăng nhập");
                return;
            }
            // phân quyền
            Authorize();
        }

        private void Authorize()
        {
            if (Env.user is null) { return; }

            this.Hide();


            if (Env.user.PermissionID == 1)
            {
                MessageBox.Show("Chưa làm owner");
            }
            else if (Env.user.PermissionID == 2)
            {
                FormAdmin formAdmin = new FormAdmin();
                formAdmin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa làm");
            }
            this.Show();   
        }
    }
}
