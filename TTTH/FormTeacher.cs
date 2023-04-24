using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.GUI.Dialog;
using TTTH.Views;

namespace TTTH
{
    public partial class FormTeacher : Form
    {
        private bool isExit = true;
        public FormTeacher()
        {
            InitializeComponent();
            viewNotification.buttonAdd.Visible = false;
            viewClassDetail.UpdateButton.Visible = false;
        }
        //------------------------------------------------------------
        // EVENTS
        //------------------------------------------------------------

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            viewNotification.SwtichToViewNotificationDetail += SwtichToViewNotificationDetail;
            viewNotificationDetail.SwitchToViewNotification += SwitchToViewNotification;
            viewClass.SwtichToViewClassDetail += SwtichToViewClassDetail;
            viewClassDetail.SwtichToViewClassDate += SwtichToViewClassDate;
            viewCalender.SwtichToViewClassDate += SwtichToViewClassDate;
            viewClassDate.SwtichToViewClassDetail += SwtichToViewClassDetail;
            viewClass.UpdateButton1.Visible = false;
            viewClass.DeleteButton1.Visible = false;
            viewClass.RegisterButton1.Visible = false;

            viewNotification.ReLoadNotification();
            viewNotification.BringToFront();
        }

        private void SwtichToViewClassDate(object? sender, EventArgs e)
        {
            if (BUS.currentClassDate is null)
            {
                MessageBox.Show(
                   "Đã có lỗi xảy ra. Vui lòng thử lại.",
                   "Có lỗi xảy ra.",
                   MessageBoxButtons.OK);
                return;
            }

            if (BUS.currentClassDate.TeacherID != BUS.user.Id)
            {
                MessageBox.Show(
                    "Bạn không phụ trách buổi học này.",
                    "Không thể truy cập.",
                    MessageBoxButtons.OK);
                return;
            }

            viewClassDate.BindClassDateData(BUS.currentClassDate);
            viewClassDate.BringToFront();
        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            isExit = false;
            this.Close();
        }

        private void FormTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }

        private void labelNotification_Click(object sender, EventArgs e)
        {
            viewNotification.ReLoadNotification();
            viewNotification.BringToFront();
        }

        private void labelChangePassWord_Click(object sender, EventArgs e)
        {
            DialogChangePassWord dialogChangePassWord = new DialogChangePassWord();
            dialogChangePassWord.ShowDialog();
        }

        private void labelClassList_Click(object sender, EventArgs e)
        {
            viewClass.LoadData2DataGridView();
            viewClass.BringToFront();
        }

        private void labelCalender_Click(object sender, EventArgs e)
        {
            viewCalender.LoadData(DateTime.Now, BUS.user);
            viewCalender.BringToFront();
        }

        private void labelAccountInfor_Click(object sender, EventArgs e)
        {
            DialogUserInformation dialog = new DialogUserInformation(BUS.user);
            dialog.ShowDialog();
        }
        //------------------------------------------------------------
        // HELPER FUNCTIONS
        //------------------------------------------------------------

        //------------------------------------------------------------
        // EVENT FROM SUB FORM
        //------------------------------------------------------------

        private void SwtichToViewNotificationDetail(object? sender, EventArgs e)
        {
            if (BUS.notification is null)
            {
                MessageBox.Show(
                    "Đã có lỗi xảy ra. Vui lòng thử lại sau.", 
                    "Đã xảy ra lỗi",
                    MessageBoxButtons.OK);
                return;
            }
            string title = BUS.notification.Topic;
            string content = BUS.notification.Content;
            viewNotificationDetail.ChangeTitle(title);
            viewNotificationDetail.ChangeContent(content);
            viewNotificationDetail.BringToFront();
        }

        private void SwitchToViewNotification(object? sender, EventArgs e)
        {
            viewNotification.ReLoadNotification();
            viewNotification.BringToFront();
        }

        private void SwtichToViewClassDetail(object? sender, EventArgs e)
        {
            if (BUS.currentClass is not null)
            {
                viewClassDetail.LoadDataByClassID(BUS.currentClass);
                viewClassDetail.BringToFront();
            }
        }
    }
}
