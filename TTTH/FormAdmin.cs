using TTTH.GUI.Dialog;
using TTTH.Models;
using TTTH.Views;

namespace TTTH
{
    public partial class FormAdmin : Form
    {
        private bool isExit = true;
        public FormAdmin()
        {
            InitializeComponent();
            viewNotification.SwtichToViewPostNotification += SwtichToViewPostNotification;
            viewNotification.SwtichToViewNotificationDetail += SwtichToViewNotificationDetail;
            viewClass.SwtichToViewClassDetail += SwtichToViewClassDetail;
            viewClassDetail.SwtichToViewClassDate += SwtichToViewClassDate;
            viewClassDetail.SwtichToViewClass += SwtichToViewClass;
            viewClassDate.SwtichToViewClassDetail += SwtichToViewClassDetail;
            viewNotificationDetail1.SwitchToViewNotification += SwitchToViewNotification;
            viewPostNotification.SwitchToViewNotification += SwitchToViewNotification;
        }

        //---------------------------------------------------------------
        // EVENTS
        //---------------------------------------------------------------
        #region Sidebar behavior
        private void pictureBoxShowSidebar_Click(object sender, EventArgs e)
        {
            ToggleSidebar();
        }

        private void labelManagement_Click(object sender, EventArgs e)
        {
            ShowManageSubmenu();
        }

        private void pictureBoxManage_Click(object sender, EventArgs e)
        {
            ShowManageSubmenu();
        }
        #endregion

        #region Change view
        private void labelCourse_Click(object sender, EventArgs e)
        {
            viewCourse2.LoadData2DataGridView();
            ShowView(viewCourse2);
        }

        private void labelClass_Click(object sender, EventArgs e)
        {
            viewClass.LoadData2DataGridView();
            ShowView(viewClass);
        }

        private void labelNotification_Click(object sender, EventArgs e)
        {
            ShowNotificationView();
        }

        private void pictureBoxNotification_Click(object sender, EventArgs e)
        {
            ShowNotificationView();
        }
        private void labelRoom_Click(object sender, EventArgs e)
        {
            viewRoom.ReLoadData();
            ShowView(viewRoom);
        }
        private void labelStudent_Click(object sender, EventArgs e)
        {
            viewStudent1.ReloadData();
            ShowView(viewStudent1);
        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            LogoutHandle();
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            LogoutHandle();
        }

        private void labelChangePassWord_Click(object sender, EventArgs e)
        {
            OpenDialogToChangePassWord();
        }

        private void pictureBoxChangePassWord_Click(object sender, EventArgs e)
        {
            OpenDialogToChangePassWord();
        }

        private void labelAccount_Click(object sender, EventArgs e)
        {
            ToggleAccountSubmenu();
        }

        private void pictureBoxAccount_Click(object sender, EventArgs e)
        {
            ToggleAccountSubmenu();
        }

        private void labelStatistics_Click(object sender, EventArgs e)
        {
            viewStatistic.LoadData2DataGridView();
            viewStatistic.BringToFront();
        }

        private void pictureBoxStatistics_Click(object sender, EventArgs e)
        {
            viewStatistic.LoadData2DataGridView();
            viewStatistic.BringToFront();
        }

        private void labelAccountInfor_Click_1(object sender, EventArgs e)
        {
            DialogUserInformation dialogUser = new DialogUserInformation(BUS.user);
            dialogUser.ShowDialog();   
        }
        #endregion

        #region Hidden event
        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }


        #endregion


        //---------------------------------------------------------------
        // HELPER FUNCTIONS
        //---------------------------------------------------------------
        private void ShowView(UserControl view)
        {
            view.BringToFront();
        }

        private void ShowManageSubmenu()
        {
            bool isManageSubmenuClose = panelManageSubmenu.Height == panelManageSubmenu.MinimumSize.Height;

            if (isManageSubmenuClose)
            {
                OpenSidebar();
                OpenManageSubmenu();
            }
            else 
            {
                CloseManageSubmenu();
            }
        }

        private void CloseManageSubmenu()
        {
            panelManageSubmenu.Height = panelManageSubmenu.MinimumSize.Height;
        }

        private void OpenManageSubmenu()
        {
            panelManageSubmenu.Height = panelManageSubmenu.MaximumSize.Height;
        }

        private void ToggleSidebar()
        {
            bool isSidebarClose = panelSideBar.Width == panelSideBar.MinimumSize.Width;

            if (isSidebarClose)
            {
                OpenSidebar();
            }
            else
            {
                // close all submenu
                CloseAccountSubmenu();
                CloseManageSubmenu();

                CloseSideBar();
            }
        }

        private void OpenSidebar()
        {
            panelSideBar.Width = panelSideBar.MaximumSize.Width;
        }

        private void CloseSideBar()
        {
            panelSideBar.Width = panelSideBar.MinimumSize.Width;
        }

        private void ToggleAccountSubmenu()
        {
            bool isClose = panelAccountSubmenu.Height == panelAccountSubmenu.MinimumSize.Height;
            if (isClose)
            {
                OpenSidebar();
                OpenAccountSubmenu();
            }
            else
            {
                CloseAccountSubmenu();
            }
        }
        private void CloseAccountSubmenu()
        {
            panelAccountSubmenu.Height = panelAccountSubmenu.MinimumSize.Height;
        }

        private void OpenAccountSubmenu()
        {
            panelAccountSubmenu.Height = panelAccountSubmenu.MaximumSize.Height;
        }
        private void ShowNotificationView()
        {
            viewNotification.ReLoadNotification();
            ShowView(viewNotification);
        }

        private void LogoutHandle()
        {
            isExit = false;
            this.Close();
        }

        private void OpenDialogToChangePassWord()
        {
            DialogChangePassWord dialogChangePassWord = new DialogChangePassWord();
            dialogChangePassWord.ShowDialog();
        }

        private void labelUserAccount_Click(object sender, EventArgs e)
        {
            viewAccountInfor.LoadData2DataGridView();
            viewAccountInfor.BringToFront();
        }

        //------------------------------------------------------
        // HANDLER EVENT FORM SUB FORM
        //------------------------------------------------------

        #region Event handler of sub form
        private void SwtichToViewPostNotification(object? sender, EventArgs e)
        {
            ShowView(viewPostNotification);
        }

        private void SwtichToViewNotificationDetail(object? sender, EventArgs e)
        {
            if (BUS.notification is not null)
            {
                viewNotificationDetail1.ChangeTitle(BUS.notification.Topic);
                viewNotificationDetail1.ChangeContent(BUS.notification.Content);
                ShowView(viewNotificationDetail1);
            }
        }

        private void SwtichToViewClassDetail(object? sender, EventArgs e)
        {
            if (BUS.currentClass is not null)
            {
                viewClassDetail.LoadDataByClassID(BUS.currentClass);
                ShowView(viewClassDetail);
            }
        }

        private void SwtichToViewClassDate(object? sender, EventArgs e)
        {
            if (BUS.currentClassDate is not null)
            {
                viewClassDate.BindClassDateData(BUS.currentClassDate);
                ShowView(viewClassDate);
            }
        }

        private void SwtichToViewClass(object? sender, EventArgs e)
        {
            viewClass.LoadData2DataGridView();
            ShowView(viewClass);
        }

        private void SwitchToViewNotification(object? sender, EventArgs e)
        {
            viewNotification.ReLoadNotification();
            viewNotification.BringToFront();
        }


        #endregion
    }
}
