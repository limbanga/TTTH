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
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // open form handle add event
            DialogUpdateOrAddRoom addForm = new DialogUpdateOrAddRoom(true);
            addForm.ShowDialog();

            // update data after add
            ReLoadData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // click header row
            if (e.RowIndex <= 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;
            // get clicked room
            Env.modelRoom = Env.roomList[e.RowIndex];
            if (columnName.Equals("_Update"))
            {
                // get course
                // create new form to update
                DialogUpdateOrAddRoom updateForm = new DialogUpdateOrAddRoom(false); // update -> forAdd = false 
                updateForm.ShowDialog();
                // reload data after change
                ReLoadData();
            }
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
