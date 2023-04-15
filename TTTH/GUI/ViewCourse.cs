using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models.DAO;
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
            dataGridView.DataSource = BUS.courseList;
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            BUS.course = BUS.courseList[e.RowIndex];
            if (columnName.Equals("DeleteButton"))
            {
                int courseID = BUS.course.Id;
                string courseName = BUS.course.Name;

                DialogResult r = ConfirmDelete(courseID, courseName);

                if (r != DialogResult.OK) { return; }

                HandleDelete(courseID);
                // reload data
                LoadData2DataGridView();
            }
            else if(columnName.Equals("OpenClassButton"))
            {
                DialogClass newClassDialog = new DialogClass(BUS.course, null);
                newClassDialog.ShowDialog();
                
            }
        }

        private void HandleDelete(int courseID)
        {
            try
            {
                DAOCourse.Delete(courseID);
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

        private static DialogResult ConfirmDelete(int courseID, string courseName)
        {
            const int numberOfRecord = 3;

            List<string> classDependent = DAOClass.GetClassNameByCourseID(courseID, numberOfRecord);

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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DialogCourse addDialog = new DialogCourse();
            addDialog.ShowDialog();
            // reload data after update
            LoadData2DataGridView();
        }

        //--------------------------------------------------
        // HELPER FUNTIONS
        //--------------------------------------------------
        public void LoadData2DataGridView()
        {
            dataGridView.DataSource = BUS.ReloadCourse();
        }
    }
}
