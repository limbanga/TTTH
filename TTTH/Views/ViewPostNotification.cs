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
            string topic = textBoxTopic.Text;
            string content = richTextBoxContent.Text;

            // validate

            // insert
            if (Env.user is null) { return; }
            MessageBox.Show("Test 33"+ Env.user.Id);
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
