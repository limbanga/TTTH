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
    public partial class ViewClass : UserControl
    {
        public ViewClass()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        // ENVENTS
        //--------------------------------------------------------------------
        private void ViewClass_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Env.classList;
        }


        //--------------------------------------------------------------------
        // HELPERS FUNCTION
        //--------------------------------------------------------------------
        public void ReLoadClass()
        {
            dataGridView.DataSource = Env.ReloadClass();
        }
    }
}
