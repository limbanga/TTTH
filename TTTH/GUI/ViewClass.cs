using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models.DAO;
using TTTH.Models.DTO;
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewClass : UserControl
    {
        public EventHandler? SwtichToViewClassDetail;
        private List<DTOClass> displayList = new List<DTOClass>();

        public ViewClass()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        // ENVENTS
        //--------------------------------------------------------------------
        private void ViewClass_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = displayList;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;
            
            // get selected class
            DTOClass selectedClass = (DTOClass)dataGridView.Rows[e.RowIndex].DataBoundItem;
            if (columnName.Equals("updateButton"))
            {
                DialogClass dialogUpdateClass = new DialogClass(null, selectedClass);
                dialogUpdateClass.ShowDialog();
                LoadData2DataGridView();
            }
            else if (columnName.Equals("registerButton"))
            {
                DialogRegister dialogRegister = new DialogRegister(selectedClass);
                dialogRegister.ShowDialog();
                LoadData2DataGridView();
            }
            else if (columnName.Equals("deleteButton"))
            {
                string msg = "Bạn có chắc muốn xóa lớp và dữ liệu liên quan không?";
                if (selectedClass.NumberOfStudent > 0)
                {
                    msg = "Lớp học đã có học viên ghi danh, bạn có chắc muốn xóa lớp và dữ liệu liên quan không?";
                }
                DialogResult r = MessageBox.Show(
                msg,
                "Xác nhận xóa.",
                MessageBoxButtons.OKCancel);
                // cancel action
                if (r != DialogResult.OK) { return; }

                HandleDeleteClass(selectedClass.Id);
                LoadData2DataGridView();
            }
            else
            {
                // public envent to main form
                BUS.currentClass = selectedClass;
                SwtichToViewClassDetail?.Invoke(this, new EventArgs());
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string keyWord = textBoxFind.Text;
            FilterByKeyWord(keyWord);
        }

        //--------------------------------------------------------------------
        // HELPERS FUNCTION
        //--------------------------------------------------------------------

        private void FilterByKeyWord(string keyWord)
        {
            dataGridView.DataSource = displayList.FindAll(c => 
                c.Name.Contains(keyWord) ||
                c.CourseName.Contains(keyWord)
            );
            dataGridView.Refresh();
        }

        public void LoadData2DataGridView()
        {
            displayList = BUS.ReloadClass();
            dataGridView.DataSource = displayList;
        }

        private void HandleDeleteClass(int id)
        {
            try
            {
                ModelClass.DeleteClass(id);
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
