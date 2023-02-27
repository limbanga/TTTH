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

namespace TTTH.Views
{
    public partial class FormLogin : Form
    {
        private bool isExit = true;

        //---------------------------------------------------------------------------
        // FORM EVENTS
        //---------------------------------------------------------------------------

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // get input user name and password
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;

            // validate


            // call api
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
            Env.user = Models.DAO.DAOUser.CheckLogin(userName, password);
            
            // can't find user case
            if (Env.user is null)
            {
                MessageBox.Show(Env.wrongPassMessage, "Không thể đăng nhập");
                return;
            }

            // login success -> close login form
            isExit = false;
            this.Close();
        }


    }
}
