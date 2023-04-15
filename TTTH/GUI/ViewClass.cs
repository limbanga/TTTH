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
using TTTH.Models.DAO;
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewClass : UserControl
    {
        public EventHandler? SwtichToViewClassDetail;
        private List<DTOCLass> displayData = DAOClass.GetAll();

        public ViewClass()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        // ENVENTS
        //--------------------------------------------------------------------
        private void ViewClass_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = displayData;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;
            
            // get selected class
            BUS.modelClass = BUS.classList[e.RowIndex];
            
            //if (columnName.Equals("_Update"))
            //{
            //    MessageBox.Show("Sua lớp học id lop can sua la"+ Env.modelClass.Id);
            //    DialogClass updateClass = new DialogClass(null, Env.modelClass);
            //    updateClass.ShowDialog();
            //}
            //else
            if (columnName.Equals("Delete"))
            {
                string msg = "Bạn có chắc muốn xóa lớp và dữ liệu liên quan không?";
                if (BUS.modelClass.NumberOfStudent > 0)
                {
                    msg = "Lớp học đã có học viên ghi danh, bạn có chắc muốn xóa lớp và dữ liệu liên quan không?";
                }
                DialogResult r = MessageBox.Show(
                msg,
                "Xác nhận xóa.",
                MessageBoxButtons.OKCancel);
                // cancel action
                if (r != DialogResult.OK) { return; }

                handleDeleteClass(BUS.modelClass.Id);
                ReLoadData();
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
            dataGridView.DataSource = BUS.ReloadClass();
        }

        private void handleDeleteClass(int id)
        {
            try
            {
                DAOClass.DeleteClass(id);
                MessageBox.Show(
                    "Xóa lớp học thành công.",
                    "Xóa thành công",
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa.",
                    MessageBoxButtons.OK);
            }
        }


    }
}
