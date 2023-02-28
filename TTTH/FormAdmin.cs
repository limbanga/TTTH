namespace TTTH
{
    public partial class FormAdmin : Form
    {
        private bool isExit = true;
        public FormAdmin()
        {
            InitializeComponent();
            viewNotification1.SwtichToViewPostNotification += SwtichToViewPostNotification;
            viewNotification1.SwtichToViewNotificationDetail += SwtichToViewNotificationDetail;
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
            viewCourse2.ReLoadData();
            ShowView(viewCourse2);
        }

        private void labelClass_Click(object sender, EventArgs e)
        {
            viewClass1.ReLoadData();
            ShowView(viewClass1);
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
            viewRoom1.ReLoadData();
            ShowView(viewRoom1);
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
        private void labelAccount_Click(object sender, EventArgs e)
        {
            ToggleAccountSubmenu();
        }

        private void pictureBoxAccount_Click(object sender, EventArgs e)
        {
            ToggleAccountSubmenu();
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
            viewNotification1.ReLoadNotification();
            ShowView(viewNotification1);
        }

        private void LogoutHandle()
        {
            isExit = false;
            this.Close();
        }

        //------------------------------------------------------
        // HANDLER EVENT FORM SUB FORM
        //------------------------------------------------------

        #region event handler of sub form
        private void SwtichToViewPostNotification(object? sender, EventArgs e)
        {
            ShowView(viewPostNotification1);
        }

        private void SwtichToViewNotificationDetail(object? sender, EventArgs e)
        {
            if (Env.notification is not null)
            {
                viewNotificationDetail1.ChangeTitle(Env.notification.Topic);
                viewNotificationDetail1.ChangeContent(Env.notification.Content);
            }
            ShowView(viewNotificationDetail1);
        }
        #endregion



    }
}
