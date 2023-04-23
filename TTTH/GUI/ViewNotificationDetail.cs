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
    public partial class ViewNotificationDetail : UserControl
    {

        public EventHandler? SwitchToViewNotification;
        public ViewNotificationDetail()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------
        // EVENTS
        //--------------------------------------------------------------

        private void buttonBack_Click(object sender, EventArgs e)
        {
            SwitchToViewNotification?.Invoke(sender, EventArgs.Empty);
        }

        //--------------------------------------------------------------
        // HELPER FUNCTIONS
        //--------------------------------------------------------------

        public void ChangeTitle(string title)
        {
            labelTopic.Text = title;
        }

        public void ChangeContent(string content)
        {
            textBoxShowContent.Text = content;
        }


    }
}
