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
    public partial class ViewPostNotification : UserControl
    {
        public ViewPostNotification()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------
        // EVENTS
        //-----------------------------------------------------------------------------
        private void buttonPost_Click(object sender, EventArgs e)
        {
            // get input
            string topic = textBoxTopic.Text;
            string content = richTextBoxContent.Text;

            // validate

            // insert
            if (Env.user is null) 
            {
                MessageBox.Show("Hệ thống không thể xác thực bạn. Vui lòng đăng nhập lại.", "Lỗi");
                Application.Exit();
                return; 
            }

            bool isSuccess = DAONotification.Insert(topic,content, Env.user.Id);

            if (isSuccess)
            {
                MessageBox.Show("Đăng thông báo thành công.", "Thành công", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi. Không thể đăng thông báo.", "Đã xảy ra lỗi", MessageBoxButtons.OK);
            }
        }
    }
}
