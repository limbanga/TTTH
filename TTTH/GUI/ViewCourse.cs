using TTTH.Models.DAO;
using TTTH.Models.DTO;
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewCourse : UserControl
    {
        private List<DTOCourse> displayList = new List<DTOCourse>();
        public ViewCourse()
        {
            InitializeComponent();
        }

        //--------------------------------------------------
        // EVENTS
        //--------------------------------------------------

        private void ViewCourse_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = displayList;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            DTOCourse selectedCourse = (DTOCourse) dataGridView.Rows[e.RowIndex].DataBoundItem;
            if (columnName.Equals("DeleteButton"))
            {
                int courseID = selectedCourse.Id;
                string courseName = selectedCourse.Name;

                DialogResult r = ConfirmDelete(courseID, courseName);

                if (r != DialogResult.OK) { return; }

                HandleDelete(courseID);
                // reload data
                LoadData2DataGridView();
            }
            else if(columnName.Equals("UpdateButton"))
            {
                DialogCourse dialogCourse = new DialogCourse(selectedCourse);
                dialogCourse.ShowDialog();
                LoadData2DataGridView();
            }
            else if (columnName.Equals("OpenClassButton"))
            {
                DialogClass newClassDialog = new DialogClass(selectedCourse, null);
                newClassDialog.ShowDialog();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DialogCourse addDialog = new DialogCourse();
            addDialog.ShowDialog();
            // reload data after update
            LoadData2DataGridView();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string keyWord = textBoxFind.Text;
            FilterByKeyWord(keyWord);
        }

        //--------------------------------------------------
        // HELPER FUNTIONS
        //--------------------------------------------------

        private void FilterByKeyWord(string keyWord)
        {
            dataGridView.DataSource = displayList.FindAll(c => c.Name.Contains(keyWord));
            dataGridView.Refresh();
        }

        public void LoadData2DataGridView()
        {
            displayList = BUS.ReloadCourse();
            dataGridView.DataSource = displayList;
        }

        private void HandleDelete(int courseID)
        {
            try
            {
                ModelCourse.Delete(courseID);
                MessageBox.Show(
                    "Xóa khóa học thành công!",
                    "Xóa thành công",
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Vui lòng thử lại!",
                    MessageBoxButtons.OK);
            }
        }

        private DialogResult ConfirmDelete(int courseID, string courseName)
        {
            const int numberOfRecord = 3;

            List<string> classDependent = ModelClass.GetClassNameByCourseID(courseID, numberOfRecord);

            string msg = $"Bạn có thực sự muốn xóa khóa học {courseName} không?";

            if (classDependent.Count > 0)
            {
                string temp = string.Join(",", classDependent.ToArray());
                msg = $"Có lớp học {temp} đang học khóa học {courseName}. " +
                    $"Bạn có muốn xóa khóa học này và các dữ liệu liên quan không?";
            }

            return MessageBox.Show(
            msg,
            "Xác nhận xóa.",
            MessageBoxButtons.OKCancel);
        }
    }
}
