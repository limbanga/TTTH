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
    public partial class ViewRoom : UserControl
    {
        public ViewRoom()
        {
            InitializeComponent();
        }

        //--------------------------------------------------
        // EVENTS
        //--------------------------------------------------
        private void ViewRoom_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Env.roomList;
        }

        //--------------------------------------------------
        // HELPER FUNCTIIONS
        //--------------------------------------------------

        public void ReLoadData()
        {
            dataGridView.DataSource = Env.ReloadRoom();
        }

 
    }
}
