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
    public partial class ViewStudent : UserControl
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Env.studentList;
        }

        //--------------------------------------------------------------
        // EVENTS
        //--------------------------------------------------------------



        //--------------------------------------------------------------
        // HELPER FUNCTIONS
        //--------------------------------------------------------------
        public void ReloadData()
        {
            dataGridView.DataSource = Env.ReloadStudent();
        }
    }
}
