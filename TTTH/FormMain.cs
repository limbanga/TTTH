using TTTH.Views;
using TTTH.Args;
using TTTH.Models;
using TTTH.Args;


namespace TTTH
{
    public partial class FormMain : Form
    {
        FormLogin formLogin = new FormLogin();

        public FormMain()
        {

            InitializeComponent();
        }
        //-----------------------------------------------------------------------------
        // EVENTS
        //-----------------------------------------------------------------------------
        private void FormMain_Load(object sender, EventArgs e)
        {
            formLogin.ShowDialog();
            Innit();
            viewNotification.SwtichToViewNotificationDetail += ViewNotificationDetail_Click;

        }



        // Chuyển sang xem thông báo
        private void ToolStripMenuItemViewNotification_Click(object sender, EventArgs e)
        {
            ShowView(viewNotification);
        }
        // chuyển sang trang đăng thông báo
        private void ToolStripMenuItemPostNotification_Click(object sender, EventArgs e)
        {
            ShowView(viewPostNotification);
        }
        // chuyển sang trang xem chi tiết thông báo, sự kiện bắt từ view xem thông báo
        private void ViewNotificationDetail_Click(object? sender, EventArgs e)
        {
            IntArgs args = (IntArgs) e;
            int notificationID = args.Value;
            ShowView(viewNotificationDetail);
            LoadNotificationDetailData(notificationID);
        }

        //---------------------------------------------------------------------------------
        // HELPER FUNCTIONS
        //---------------------------------------------------------------------------------

        private void Innit()
        {
            labelWelcome.Text = "Xin chào " + Env.user?.ShowName + " !";
            labelShowNow.Text = DateTime.Now.ToString("ddd - dd/MM/yyyy");

            HideAllToolStripMenuItem();

            int permissonsGroup = -1;
            if(Env.user is not null)
            {
                permissonsGroup = Env.user.PermissionID;
            }
            PhanQuyen(permissonsGroup);
        }
        private void ShowView(UserControl view)
        {
            view.BringToFront();
            view.Show();
        }

        // phân quyền, hem biết đặt tên
        private void PhanQuyen(int permissonsGroup)
        {
            List<ToolStripMenuItem> GroupPermissAdmin = new List<ToolStripMenuItem>()
            {
                ToolStripMenuItemCourse,
                ToolStripMenuItemClass,
                ToolStripMenuItemTeacher,
                ToolStripMenuItemStudent,

                ToolStripMenuItemPostNotification,
                ToolStripMenuItemViewNotification,
                ToolStripMenuItemViewHideNotification,
            };

            List<ToolStripMenuItem> GroupPermissUser = new List<ToolStripMenuItem>()
            {
                ToolStripMenuItemClass,
                ToolStripMenuItemStudent,

                ToolStripMenuItemViewNotification,
                ToolStripMenuItemViewHideNotification,
            };


            if (permissonsGroup == 1) // quyền quản trị
            {
                foreach (ToolStripMenuItem item in GroupPermissAdmin)
                {
                    item.Visible = true;
                }
            }
            else if (permissonsGroup == 2) // quyền giảng viên 
            {
                foreach (ToolStripMenuItem item in GroupPermissUser)
                {
                    item.Visible = true;
                }
            }
            else // tài khoản mới tạo, không có quyền gì.
            {
                MessageBox.Show(
                    "Bạn chưa được phân bất kỳ quyền nào. Hãy liên hệ quản viên để được phần quyền",
                    "Tài khoản chưa được kích hoạt!",
                    MessageBoxButtons.OK
                    );
            }

        }
        private void HideAllToolStripMenuItem()
        {   // management menu
            ToolStripMenuItemCourse.Visible= false;
            ToolStripMenuItemClass.Visible= false;
            ToolStripMenuItemTeacher.Visible= false;
            ToolStripMenuItemStudent.Visible= false;
            // notification menu
            ToolStripMenuItemPostNotification.Visible= false;
            ToolStripMenuItemViewNotification.Visible= false;
            ToolStripMenuItemViewHideNotification.Visible= false;
        }

        private void LoadNotificationDetailData(int notificationID)
        {
            // fetch data // này chắc tui lấy trong cache vì ít khi thông báo được cập nhập
            ModelNotification? notification = Env.NotificatonList.SingleOrDefault(n => n.Id.Equals(notificationID));

            string topic = "Không thể tìm thấy thông báo.";
            string content = "";
            if (notification is not null)
            {
                topic = notification.Topic;
                content = notification.Content;
            }

            // bind data
            viewNotificationDetail.labelTopic.Text = topic;
            viewNotificationDetail.textBoxShowContent.Text = content;
        }
    }
}