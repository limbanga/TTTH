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
    public partial class ViewClass : UserControl
    {

        public EventHandler? SwtichToViewClassDetail;
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;
            
            // get selected class
            Env.modelClass = Env.classList[e.RowIndex];
            
            if (columnName.Equals("_Update"))
            {
                MessageBox.Show("Sua lớp học id lop can sua la"+ Env.modelClass.Id);
                DialogUpdateOrAddClass updateClass = new DialogUpdateOrAddClass(null, Env.modelClass);
                updateClass.ShowDialog();
            }
            else if (columnName.Equals("Delete"))
            {
                MessageBox.Show("Delete chua lam");
            }
            else
            {
                // public envent to main form
                SwtichToViewClassDetail?.Invoke(this, new EventArgs());
            }
        }

        //--------------------------------------------------------------------
        // HELPERS FUNCTION
        //--------------------------------------------------------------------
        public void ReLoadData()
        {
            dataGridView.DataSource = Env.ReloadClass();
        }


    }
}
