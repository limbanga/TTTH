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
            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            Env.modelClass = Env.classList[e.RowIndex];
            if (columnName.Equals("_Update"))
            {
                MessageBox.Show("Sua lớp học");
                DialogUpdateOrAddClass updateClass = new DialogUpdateOrAddClass(null, Env.modelClass);
                updateClass.ShowDialog();
            }
            else if (columnName.Equals("Delete"))
            {
                MessageBox.Show("Delete chua lam");
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
