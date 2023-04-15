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
    public partial class ViewStudent : UserControl
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------
        // EVENTS
        //--------------------------------------------------------------
        private void ViewStudent_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = BUS.studentList;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // open form handle add student
            DialogUpdateOrAddStudent dialogAdd = new DialogUpdateOrAddStudent(true);
            dialogAdd.ShowDialog();
            // reload new data after update
            ReloadData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            // get student
            BUS.modelStudent = BUS.studentList[e.RowIndex];
            if (columnName.Equals("UpdateButton"))
            {
                // create new form to update
                DialogUpdateOrAddStudent dialogUpdate = new DialogUpdateOrAddStudent(false);
                dialogUpdate.ShowDialog();
                // reload data after update
                ReloadData();
            }
            else if (columnName.Equals("DeleteButton"))
            {
                MessageBox.Show("Xoa hoc vien");
            }

        }

        //--------------------------------------------------------------
        // HELPER FUNCTIONS
        //--------------------------------------------------------------
        public void ReloadData()
        {
            dataGridView.DataSource = BUS.ReloadStudent();
        }

    }
}
