namespace TTTH
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            viewNotification1.SwtichToViewPostNotification += SwtichToViewPostNotification;
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
            ShowView(viewCourse2);
        }

        private void labelClass_Click(object sender, EventArgs e)
        {
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

        //------------------------------------------------------
        // HANDLER EVENT FORM SUB FORM
        //------------------------------------------------------

        private void SwtichToViewPostNotification(object? sender, EventArgs e)
        {
            ShowView(viewPostNotification1);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            viewStudent1.ReloadData();
            ShowView(viewStudent1);
        }
    }
}
