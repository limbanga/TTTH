using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.GUI.Dialog;
using TTTH.Models;
using TTTH.Views.Dialog;

namespace TTTH.GUI
{
    public partial class ViewClassDetail : UserControl
    {
        public EventHandler? SwtichToViewClassDate;

        private int classID = -1;
        private List<DTOClassDate> list = new List<DTOClassDate>();
        public ViewClassDetail()
        {
            InitializeComponent();
        }

        //---------------------------------------------------
        // ENVENTS
        //---------------------------------------------------
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            // get selected class date
            DTOClassDate selectedClassDate = list[e.RowIndex];

            if (columnName.Equals("UpdateButton"))
            {
                DialogClassDate dialogUpdate = new DialogClassDate(selectedClassDate);
                dialogUpdate.ShowDialog();
                ReloadDataGridview(classID);
            }
            else
            {
                MessageBox.Show("Chuyển hướng sang class date");
                // public envent to main form
                SwtichToViewClassDate?.Invoke(this, new EventArgs());
            }
        }

        //---------------------------------------------------
        // HELPER FUNCTIONS
        //---------------------------------------------------

        public void LoadDataByClassID(int classID)
        {
            this.classID = classID;
            ReloadDataGridview(classID);
        }

        private void ReloadDataGridview(int classID)
        {
            list = ModelClassDate.GetClassDatesByClassID(classID);
            dataGridView.DataSource = list;
        }
    }
}
