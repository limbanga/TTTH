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

            Env.course = Env.courseList[e.RowIndex];
            if (columnName.Equals("_Update"))
            {
                // get course
                // create new form to update
                DialogUpdateOrAddCourse updateDialog = new DialogUpdateOrAddCourse(Env.course);
                updateDialog.ShowDialog();
            }
            else if(columnName.Equals("OpenClass"))
            {
                DialogUpdateOrAddClass newClassDialog = new DialogUpdateOrAddClass(Env.course, null);
                newClassDialog.ShowDialog();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DialogUpdateOrAddCourse updateDialog = new DialogUpdateOrAddCourse(null);
            updateDialog.ShowDialog();
        }

        //--------------------------------------------------
        // HELPER FUNTIONS
        //--------------------------------------------------
        public void ReLoadData()
        {
            dataGridView.DataSource = Env.ReloadCourse();
        }
    }
}
