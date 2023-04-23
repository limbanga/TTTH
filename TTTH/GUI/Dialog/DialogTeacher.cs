using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models.DAO;
using TTTH.Models.DTO;

namespace TTTH.GUI.Dialog
{
    public partial class DialogTeacher : Form
    {
        private DTOUser? oldUser;
        public DialogTeacher()
        {
            InitializeComponent();
        }
        public DialogTeacher(DTOUser _dTOUser)
        {
            InitializeComponent();
            oldUser = _dTOUser;
        }
        //--------------------------------------------------------------
        // EVENTS
        //--------------------------------------------------------------
        private void DialogTeacher_Load(object sender, EventArgs e)
        {
            BindOldData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (CheckInputValid() == false) { return; }

            DTOUser inputUser = GetInput();
            if (oldUser is null) 
            { // add new
                HandleAddNewTeacher(inputUser);
            }
            else
            {
                HandleUpdateTeacher(inputUser);
            }
        }

        private void pictureBoxShowPass_Click(object sender, EventArgs e)
        {
            bool temp = !textBoxPassWord.UseSystemPasswordChar;
            textBoxPassWord.UseSystemPasswordChar = temp;
            if (temp)
            {
                pictureBoxShowPass.Image = imageList1.Images[0];
            }
            else
            {
                pictureBoxShowPass.Image = imageList1.Images[1];
            }
        }
        private bool CheckInputValid()
        {
            return true;
        }


        //--------------------------------------------------------------
        // HELPER FUNCTIONS
        //--------------------------------------------------------------

        private DTOUser GetInput()
        {
            DTOUser inputUser = new DTOUser();

            inputUser.Id = oldUser is null? -1 : oldUser.Id;

            inputUser.ShowName = textBoxShowName.Text;
            inputUser.LoginName = textBoxLoginName.Text;
            inputUser.Email = textBoxEmail.Text;
            inputUser.PhoneNumber = textBoxPhoneNumber.Text;
            inputUser.Address = textBoxAdress.Text;
            inputUser.PassWord = textBoxPassWord.Text;

            return inputUser;
        }

        private void HandleAddNewTeacher(DTOUser inputUser)
        {
            try
            {
                ModelUser.Insert(inputUser);
                MessageBox.Show(
                    "Thêm tài khoản giảng viên thành công.",
                    "Thêm thành công",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể tạo mới tài khoản giảng viên.",
                    MessageBoxButtons.OK);
            }
        }

        private void HandleUpdateTeacher(DTOUser inputUser)
        {
            try
            {
                ModelUser.Update(inputUser);
                MessageBox.Show(
                    "Cập nhật thông tin tài khoản giảng viên thành công.",
                    "Lưu thành công",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể cập nhật tài khoản giảng viên.",
                    MessageBoxButtons.OK);
            }
        }

        private void BindOldData()
        {
            // add new -> no bind old
            if (oldUser is null) { return; }
            // else
            this.Text = "Cập nhật thông tin tài khoản";
            labelHeader.Text = $"Cập nhật thông tin tài khoản {oldUser.ShowName}";

            textBoxShowName.Text = oldUser.ShowName;
            textBoxLoginName.Text = oldUser.LoginName;
            textBoxEmail.Text = oldUser.Email;
            textBoxPhoneNumber.Text = oldUser.PhoneNumber;
            textBoxAdress.Text = oldUser.Address;

            textBoxPassWord.Enabled = false;
            pictureBoxShowPass.Enabled = false;
        }
    }
}
