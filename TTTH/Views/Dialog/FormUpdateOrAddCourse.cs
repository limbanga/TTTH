using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models;

namespace TTTH.Views.Dialog
{
    public partial class FormUpdateOrAddCourse : Form
    {
        private ModelCourse? modelCourse = null;
        public FormUpdateOrAddCourse(ModelCourse? courseInput)
        {
            InitializeComponent();
            // có truyền vào thanh số nghĩa là update ngược lại add
            if (courseInput is not null ) 
            {
                this.modelCourse = courseInput;
            }
        }
        //-----------------------------------------------------------------------
        // ENVENTS 
        //-----------------------------------------------------------------------
        private void FormUpdateOrAddCourse_Load(object sender, EventArgs e)
        {
            BindData();
        }
        //-----------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------------------------
        private void BindData()
        {
            if (modelCourse is null) { return; }

            textBoxID.Enabled = false;
            textBoxID.Text = modelCourse.Id.ToString();
            textBoxName.Text = modelCourse.Name;
            textBoxDuration.Text = modelCourse.Duration.ToString();
            textBoxFee.Text = modelCourse.Fee.ToString();
        }
    }
}
