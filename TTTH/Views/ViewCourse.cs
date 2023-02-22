using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewCourse : UserControl
    {
        public ViewCourse()
        {
            InitializeComponent();
        }
        //--------------------------------------------------
        // EVENTS
        //--------------------------------------------------
        private void ViewCourse_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Env.courseList;
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            if (columnName.Equals("Update"))
            {
                // get course
                Env.course = Env.courseList[e.RowIndex];
                // create new form to update
                Form updateForm = new FormUpdateOrAddCourse(Env.course);
                updateForm.ShowDialog();
            }
        }


        //--------------------------------------------------
        // HELPER FUNTIONS
        //--------------------------------------------------
        public void ReLoadCourse()
        {
            dataGridView.DataSource = Env.ReloadCourse();
        }


    }
}
